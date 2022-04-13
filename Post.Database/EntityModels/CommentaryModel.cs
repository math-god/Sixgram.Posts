using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels;

[Table("commentaries")]
public class CommentaryModel : BaseModel
{
    [Column("commentary_id")] 
    public override Guid Id { get; set; }

    [Column("post_id")]
    [ForeignKey("PostModel")]
    public Guid PostId { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("commentary")]
    public string Commentary { get; set; }
    
    public PostModel Post { get; set; }
}