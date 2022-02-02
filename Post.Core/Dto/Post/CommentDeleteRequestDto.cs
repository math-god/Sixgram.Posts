namespace Post.Core.Dto.Post;

public class CommentDeleteRequestDto
{
    public Guid PostId { get; set; }
    public Guid CommentId { get; set; }
}