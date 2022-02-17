using Microsoft.AspNetCore.Http;
using Post.Core.File;
using Newtonsoft.Json.Linq;
using Post.Common.Types;
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
        
        byte[] data;
        using (var binaryReader = new BinaryReader(file.OpenReadStream()))
            data = binaryReader.ReadBytes((int) file.OpenReadStream().Length);
        
        var fileSendingDto = new FileSendingDto()
        {
            SourceId = postId,
            UploadedFile = data,
            UploadedFileName = file.FileName,
            FileSource = FileSource.Post
        };
        
        var content = await _fileHttpService.SendRequest(fileSendingDto);

        var json = JObject.Parse(content);

        var result = new Guid(json["id"].ToString());

        return result;
    }
}