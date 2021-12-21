using System;
using System.Net.Http;
using System.Threading.Tasks;
using Post.Core.Http;

namespace Post.Core.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("auth");
        }

        public async Task<string> GetRequestContent()
        {
            var request = await _httpClient.GetAsync("");
            Console.WriteLine(request.StatusCode);
            var responseBody = request.Content.ReadAsStringAsync();
            var result = responseBody.Result;

            return result;
        }
    }
}