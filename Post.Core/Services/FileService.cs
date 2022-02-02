using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Post.Core.File;
using Newtonsoft.Json.Linq;
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

    public async Task<Guid?> Send(IFormFile file)
    {
        byte[] data;
        using (var binaryReader = new BinaryReader(file.OpenReadStream()))
            data = binaryReader.ReadBytes((int)file.OpenReadStream().Length);

        var content = await _fileHttpService.SendRequest(data);

        var json = JObject.Parse(content);

        var result = new Guid(json["id"].ToString());

        return result;
    }
}