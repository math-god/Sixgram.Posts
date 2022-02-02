namespace Post.Core.Dto.Post;

public class CommentCreateRequestDto
{
    public Guid PostId { get; set; }
    public string Commentary { get; set; }
}