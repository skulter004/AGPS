using AGPS.Core.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using System.Text.Json;

namespace AGPS.Application.Services
{
    public class PlagarismService:IPlagarismService
    {
        private const string ApiUrl = "https://plagiarism-checker-api2.p.rapidapi.com/v1/palagrism-checker";
        private const string ApiKey = "e19c94487dmshb01eda204f3c85ap15a7c5jsn38ef3a59533c"; // Replace with your actual key
        private const string ApiHost = "plagiarism-checker-api2.p.rapidapi.com";
        private readonly HttpClient _httpClient;

        public PlagarismService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> CheckPlagarism(string text)
        {
            try
            {
                // Prepare the request content
                var requestData = new
                {
                    text = text
                };

                var requestContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(requestData),
                    Encoding.UTF8,
                    "application/json"
                );

                // Create the HttpRequestMessage
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(ApiUrl),
                    Headers =
                {
                    { "x-rapidapi-key", ApiKey },
                    { "x-rapidapi-host", ApiHost }
                },
                    Content = requestContent
                };

                // Send the request
                var response = await _httpClient.SendAsync(request); 
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var jsonDocument = JsonDocument.Parse(responseBody);
                    jsonDocument.RootElement.TryGetProperty("palagrism_percentage", out var plagiarismPercentage);
                    var temp = plagiarismPercentage;
                    return plagiarismPercentage.ToString();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error: {error}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }
    }
}
