using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Post.Common.Types;
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

        public async Task<string> SendRequest(FileSendingDto fileSendingDto)
        {
            byte[] data;
            using (var binaryReader = new BinaryReader(fileSendingDto.UploadedFile.OpenReadStream()))
                data = binaryReader.ReadBytes((int) fileSendingDto.UploadedFile.OpenReadStream().Length);
            
            var bytes = new ByteArrayContent(data);
            var postId = new StringContent(fileSendingDto.SourceId.ToString());
            var fileSource = new StringContent(FileSource.Post.ToString());

            var multiContent = new MultipartFormDataContent();

            multiContent.Add(bytes, "UploadedFile", fileSendingDto.UploadedFile.FileName);
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