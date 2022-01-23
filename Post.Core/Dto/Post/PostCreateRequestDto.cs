using Microsoft.AspNetCore.Http;

namespace Post.Core.Dto.Post;

public class PostCreateRequestDto
{
    public IFormFile FormFile { get; set; }
    public string Description { get; set; }
}