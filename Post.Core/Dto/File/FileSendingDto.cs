using Microsoft.AspNetCore.Http;
using Post.Common.Types;

namespace Post.Core.Dto.File;

public class FileSendingDto
{
    public Guid SourceId { get; set; }
    public IFormFile UploadedFile { get; set; }
}