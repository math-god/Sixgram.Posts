using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Post.Core.Dto.Request;
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

        public async Task<RequestDto> GetRequestContent(HttpRequestMessage request)
        {
            string body;
            
            using (Stream stream = await request.Content.ReadAsStreamAsync())
            {
                stream.Seek(0, SeekOrigin.Begin);
                using (StreamReader sr = new StreamReader(stream))
                {
                    body = await sr.ReadToEndAsync();
                }
            }

            return new RequestDto()
            {
                Content = body,
                Headers = request.Headers,
                HttpVersion = request.Version.ToString(),
                Method = request.Method.Method,
                RequestUri = request.RequestUri
            };
        }
    }
}