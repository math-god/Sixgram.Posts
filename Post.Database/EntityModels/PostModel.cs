using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels;

[Table("posts")]
public class PostModel : BaseModel
{
    [Column("post_id")]
    public override Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("file_id")]
    public Guid? FileId { get; set; } 

    [Column("description")]
    public string Description { get; set; } = string.Empty;

    [Column("commentaries")]
    public List<Guid> Commentaries { get; set; } = new();

    public ICollection<CommentaryModel> CommentaryModels { get; set; }
}