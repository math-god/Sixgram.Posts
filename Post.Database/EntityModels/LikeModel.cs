using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels;

[Table("likes")]
public class LikeModel : BaseModel
{
    [Column("like_id")]
    public override Guid Id { get; set; }
    [Column("user_id")]
    public Guid UserId { get; set; }
    [Column("post_id")]
    [ForeignKey("PostModel")]
    public Guid PostId { get; set; }
    
    public PostModel PostModel { get; set; }
}