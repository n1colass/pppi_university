using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Lab_5.API
{
    public class Api
    {
        private readonly string url = "http://localhost:5000/";
        private readonly HttpClient _client;

        public Api()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
        }

        private async Task<HandleDTO> HandleResponse(HttpResponseMessage response)
        {
            try
            {
                var responseContent = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var data = JsonSerializer.Deserialize<List<ProductDTO>>(responseContent, options);
                HandleDTO handleResponse = new HandleDTO();
                handleResponse.products = data;
                handleResponse.httpStatusCode = response.StatusCode;
                handleResponse.errorMessage = "Response is handling good!";

                return handleResponse;
            }
            catch (HttpRequestException ex)
            {
                return new HandleDTO
                {
                    errorMessage = ex.Message,
                    httpStatusCode = HttpStatusCode.InternalServerError,
                    products = null,
                };
            }
        }

        public async Task<HandleDTO> GetAll()
        {
            var response = await _client.GetAsync("");
            return await HandleResponse(response);
        }
        public async Task<HandleDTO> GetCategory(List<string> reqBody)
        {
            var json = JsonSerializer.Serialize(reqBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("", content);
            return await HandleResponse(response);
        }
    }
}