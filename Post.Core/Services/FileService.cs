using System.Text;
using Microsoft.AspNetCore.Http;
using Post.Core.File;

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

    public async Task<Guid> Send(IFormFile file)
    {
        throw new NotImplementedException();
    }
}