using Microsoft.AspNetCore.Http;
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

    public async Task<Guid?> Send(IFormFile file, Guid postId)
    {
        var fileSendingDto = new FileSendingDto()
        {
            SourceId = postId,
            UploadedFile = file
        };
        
        var content = await _fileHttpService.SendRequest(fileSendingDto);

        var json = JObject.Parse(content);

        var result = new Guid(json["id"].ToString());

        return result;
    }
}