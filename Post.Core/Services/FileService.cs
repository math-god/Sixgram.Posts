using Post.Core.File;
using Newtonsoft.Json.Linq;
using Post.Core.Dto.File;
using Post.Core.Http;

namespace Post.Core.Services;

public class FileService : IFileService
{
    private readonly IFileHttpService _fileHttpService;

    public FileService
    (
        IFileHttpService fileHttpService
    )
    {
        _fileHttpService = fileHttpService;
    }

    public async Task<Guid?> Send(FileSendingDto fileSendingDto)
    {
        var content = await _fileHttpService.SendRequest(data, fileSendingDto.UploadedFile.FileName);

        var json = JObject.Parse(content);

        var result = new Guid(json["id"].ToString());

        return result;
    }
}