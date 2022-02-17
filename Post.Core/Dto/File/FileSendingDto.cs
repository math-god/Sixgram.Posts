using Post.Common.Types;

namespace Post.Core.Dto.File;

public class FileSendingDto
{
    public Guid SourceId { get; set; }
    public byte[] UploadedFile { get; set; }
    public string UploadedFileName { get; set; }
    public FileSource FileSource { get; set; }
}