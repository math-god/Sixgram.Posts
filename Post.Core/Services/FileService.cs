using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Post.Core.File;
using Newtonsoft.Json.Linq;

namespace Post.Core.Services;

public class FileService : IFileService
{
    private readonly HttpClient _httpClient;
    private readonly HttpContext _httpContext;

    public FileService
    (
        IHttpClientFactory httpClientFactory,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _httpClient = httpClientFactory.CreateClient("file_storage");
        _httpContext = httpContextAccessor.HttpContext;
    }

    public async Task<Guid?> Send(IFormFile file)
    {
        byte[] data;
        using (var binaryReader = new BinaryReader(file.OpenReadStream()))
            data = binaryReader.ReadBytes((int)file.OpenReadStream().Length);

        var bytes = new ByteArrayContent(data);

        var multiContent = new MultipartFormDataContent();

        multiContent.Add(bytes, "file", file.FileName);

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", await _httpContext.GetTokenAsync("access_token"));

        var responseMessage = await _httpClient.PostAsync("/api/v1/task/downloadfile", multiContent);

        var content = await responseMessage.Content.ReadAsStringAsync();

        var json = JObject.Parse(content);

        var id = json["id"].ToString();

        var result = new Guid(id);

        return result;
        
        
        /*1. FileStorageHttpClient, IFileStorage....
        2. DI
        3. Call by constructor IFileStorage*/
    }
}