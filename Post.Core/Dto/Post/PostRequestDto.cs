using Microsoft.AspNetCore.Http;

namespace Post.Core.Dto.Post;

public class PostRequestDto
{
    public IFormFile FormFile { get; set; }
    public string Description { get; set; }
}