using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Post.Common.Types;
using Post.Core.Dto.File;
using Post.Core.Interfaces.File;
using Post.Core.Interfaces.Http;

namespace Post.Core.Services;

public class FileStorageService : IFileStorageService
{
    private readonly IFileStorageHttpService _fileStorageHttpService;

    public FileStorageService
    (
        IFileStorageHttpService fileStorageHttpService
    )
    {
        _fileStorageHttpService = fileStorageHttpService;
    }

    public async Task<Guid?> Send(IFormFile file, Guid postId)
    {
        var data = await CreateContent(file);

        var fileSendingDto = new FileSendingDto()
        {
            SourceId = postId,
            UploadedFile = data,
            UploadedFileName = file.FileName,
            FileSource = FileSource.Post
        };

        var content = await _fileStorageHttpService.SendRequest(fileSendingDto);

        var json = JObject.Parse(content);

        var result = new Guid(json["id"].ToString());

        return result;
    }

    private static async Task<byte[]> CreateContent(IFormFile file)
    {
        using var binaryReader = new BinaryReader(file.OpenReadStream());
        var data = binaryReader.ReadBytes((int) file.OpenReadStream().Length);

        return data;
    }
}