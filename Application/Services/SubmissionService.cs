using AGPS.Core.DTOs;
using AGPS.Core.Interfaces.Repositories;
using AGPS.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AGPS.Application.Services
{
    public class SubmissionService:ISubmissionService
    {
        private readonly IFileStorageService _fileStorageService;
        private readonly ISubmissionRepo _submissionRepo;
        private readonly ICompilerService _compilerService;
        private readonly IPlagarismService _plagarismService;
        private readonly IConfiguration _configuration;

        public SubmissionService(IFileStorageService fileStorageService, ISubmissionRepo  submissionRepo, ICompilerService compilerService, IPlagarismService plagarismService, IConfiguration configuration)
        {
            _fileStorageService = fileStorageService;
            _submissionRepo = submissionRepo;
            _compilerService = compilerService;
            _plagarismService = plagarismService;
            _configuration = configuration;
        }
        public async Task<SubmissionResult> SubmitAssignment(SubmissionRequest request)
        {
            try
            {

                var sourceCodePath = await _fileStorageService.UploadFile(request.SourceCode, request.AssignmentId, request.StudentId);

                string sourceCodeContent;
                using (var reader = new StreamReader(request.SourceCode.OpenReadStream()))
                {
                    sourceCodeContent = await reader.ReadToEndAsync();
                }
                List<TestCaseDTO> testCases  = await _submissionRepo.GetTestCases(request.AssignmentId);
                int testPassed = 0;
                SubmissionResult result = new SubmissionResult();

                foreach (TestCaseDTO testCase in testCases)
                {
                     var output = await _compilerService.ExecuteCodeAsync(sourceCodeContent,request.Language.ToString(), testCase.Input, testCase.ExpectedOutput);
                    if (output == testCase.ExpectedOutput)
                    {
                        testPassed++;
                    }
                    else
                    {
                        result.FailedTestCases.Add(new FailedTest
                        {
                            Input = testCase.Input,
                            ExpectedOutput = testCase.ExpectedOutput,
                            YourOutput = output,
                        });
                    }
                }
                {
                    await _plagarismService.CheckPlagarism("An application programming interface (API) is a set of definitions and protocols for building and integrating application software. APIs let your product or service communicate with other products and services without having to know how they're implemented. This can simplify app development, saving time and resources");
                    result.Grade = await CalculateGrade(testCases.Count, testPassed);
                };

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<double> CalculateGrade(int testCases, int testPassed)
        {
            try
            {
                double grade = (((testPassed / testCases) * 100)/100)*10;
                return grade;
            }
            catch(Exception e)
            {
                return 0;
            }
        }

        public async Task<string> LoginUser(LoginRequest request)
        {
            try
            {
                bool userExist = await _submissionRepo.LoginUser(request);
                if (userExist)
                {
                    return GenerateJwtToken(request);
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        private string GenerateJwtToken(LoginRequest user)
        {


            var claims = new List<Claim>
                            {
                                new Claim(JwtRegisteredClaimNames.Email, user.Email)
                            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
