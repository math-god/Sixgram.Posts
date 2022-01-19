namespace Post.Core.Dto.Post;

public class CommentRequestDto
{
    public Guid PostId { get; set; }
    public string Commentary { get; set; }
}