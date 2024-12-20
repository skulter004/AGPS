using AGPS.Core.DTOs;
using AGPS.Core.Interfaces.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AGPS.Application.Services
{
    public class CompilerService:ICompilerService
    {
        private readonly HttpClient _httpClient;
       

        public CompilerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }




        public async Task<string> ExecuteCodeAsync(string code, string language, string input, string expectedOutput)
        {
            // Step 1: Submit the code to Judge0 API
            var requestData = new
            {
                source_code = code,
                language_id = "54",
                stdin = input
            };

            var jsonContent = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://judge0-ce.p.rapidapi.com/submissions?fields=*"),
                Headers =
                {
            { "x-rapidapi-key", "19e86fdcb5msh72ea1334d1b2e21p1a1129jsn1558169dbe9f" },
            { "x-rapidapi-host", "judge0-ce.p.rapidapi.com" },
                },
                Content = content
            };
            dynamic response = "";
            using (var responsee = await client.SendAsync(request))
            {
                responsee.EnsureSuccessStatusCode();
                var body = await responsee.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                // If the response is in JSON format, you can deserialize it into an object
                var responseObject = JsonConvert.DeserializeObject<dynamic>(body);
                response = responseObject;
            }

            var submissionId = response.token.ToString();

            // Step 2: Poll the status of the execution
            return await GetExecutionResultAsync(submissionId);
        }

        private async Task<string> GetExecutionResultAsync(string submissionId)
        {
            // Poll for the result until the status is 'completed'
            while (true)
            {
                var response = await _httpClient.GetAsync($"https://api.judge0.com/submissions/{submissionId}?base64_encoded=false?wait=true");
                var result = await response.Content.ReadAsStringAsync();

                var resultData = JsonConvert.DeserializeObject<dynamic>(result);
                string status = resultData.status.description.ToString();

                if (status == "Time Limit Exceeded" || status == "Wrong Answer" || status == "Runtime Error")
                {
                    return resultData.stdout;
                }
                if (status == "Accepted")
                {
                    return resultData.stdout;
                }


                // Wait before polling again (e.g., 1 second)
                await Task.Delay(1000);
            }
        }

    }

}
