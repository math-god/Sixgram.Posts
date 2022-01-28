using Microsoft.AspNetCore.Http;

namespace Post.Core.File;

public interface IFileService
{
    Task<Guid> Send(IFormFile file);
}