using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Post.Core.Dto.Post;

public class PostCreateRequestDto
{
    public IFormFile File { get; set; }
    
    public Guid UserId { get; set; }
}