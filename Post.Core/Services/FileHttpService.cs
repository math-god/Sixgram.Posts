using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Post.Core.Dto.File;
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
        
/*/api/v1/subscribe POST - create
/api/v1/subscribe GET - получение записей по фильтру
a/v/subscribe/{id} GET - получение записи по ID
a/v/subscribe/{id}  delete - delete записи по ID
a/v/subscribe/{id}  put - update записи по ID*/

        public async Task<string> SendRequest(FileSendingDto fileSendingDto)
        {
            var bytes = new ByteArrayContent(fileSendingDto.UploadedFile);
            var postId = new StringContent(fileSendingDto.SourceId.ToString());
            var fileSource = new StringContent(fileSendingDto.FileSource.ToString());

            var multiContent = new MultipartFormDataContent();

            multiContent.Add(bytes, "UploadedFile", fileSendingDto.UploadedFileName);
            multiContent.Add(postId, "SourceId");
            multiContent.Add(fileSource, "FileSource");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await _httpContext.GetTokenAsync("access_token"));

            var responseMessage = await _httpClient.PostAsync("/api/v1/task/downloadfile", multiContent);

            var result = await responseMessage.Content.ReadAsStringAsync();

            return result;
        }
    }
}