namespace Post.Core.Dto.Post;

public class PostModelResponseDto
{
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public Guid? FileId { get; set; }
   
    public DateTime DateCreated { get; set; }
}