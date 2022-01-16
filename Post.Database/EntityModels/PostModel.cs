using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels;

[Table("posts")]
public class PostModel : BaseModel
{
    [Column("post_id")]
    public override Guid Id { get; set; }
    
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("file_id")]
    public Guid FileId { get; set; }
    
    public ICollection<CommentaryModel> Commentaries { get; set; }
}