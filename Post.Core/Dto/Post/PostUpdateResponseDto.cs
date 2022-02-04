using Microsoft.AspNetCore.Http;

namespace Post.Core.Dto.Post;

public class PostUpdateResponseDto
{
    public Guid FileId { get; set; }
    public string Description { get; set; }
}