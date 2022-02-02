using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Post.Core.Http;

namespace Post.Core.Services
{
    public class FileHttpService : IFileHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly HttpContext _httpContext;

        public FileHttpService
        (
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _httpClient = httpClientFactory.CreateClient("file_storage");
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<string> SendRequest(byte[] data, string fileName)
        {
            var bytes = new ByteArrayContent(data);

            var multiContent = new MultipartFormDataContent();

            multiContent.Add(bytes, "file", fileName);

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await _httpContext.GetTokenAsync("access_token"));

            var responseMessage = await _httpClient.PostAsync("/api/v1/task/downloadfile", multiContent);

            var result = await responseMessage.Content.ReadAsStringAsync();
            
            return result;
        }
    }
}