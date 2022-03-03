namespace Post.Core.Dto.Comment;

public class CommentModelResponseDto
{
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public string Commentary { get; set; }
}