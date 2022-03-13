using Microsoft.AspNetCore.Http;

namespace Post.Core.Interfaces.File;

public interface IFileService
{
    Task<Guid?> Send(IFormFile file, Guid sourceId);
}