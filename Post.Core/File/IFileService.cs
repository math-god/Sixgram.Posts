using Microsoft.AspNetCore.Http;
using Post.Core.Dto.File;

namespace Post.Core.File;

public interface IFileService
{
    Task<Guid?> Send(FileSendingDto fileSendingDto);
}