using Microsoft.AspNetCore.Http;

namespace Post.Core.Dto.Post;

public class PostCreateRequestDto
{
    public IFormFile File { get; set; }
    public string Description { get; set; }
}