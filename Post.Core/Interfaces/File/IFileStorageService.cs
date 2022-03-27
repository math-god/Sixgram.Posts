using Microsoft.AspNetCore.Http;

namespace Post.Core.Interfaces.File;

public interface IFileStorageService
{
    Task<Guid?> CreateFile(IFormFile file, Guid sourceId);

    Task<bool?> DeleteFile(Guid fileId);
}