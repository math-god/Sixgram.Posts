using Microsoft.AspNetCore.Http;

namespace Post.Core.Interfaces.File;

public interface IFileStorageService
{
    Task<Guid?> Send(IFormFile file, Guid sourceId);
}