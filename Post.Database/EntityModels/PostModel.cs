using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels;

[Table("posts")]
public class PostModel : BaseModel
{
    [Column("post_id")]
    public override Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("member_id")]
    [ForeignKey("MembershipModel")]
    public Guid MemberId { get; set; }
    
    [Column("file_id")]
    public Guid? FileId { get; set; } 

    [Column("description")]
    public string Description { get; set; } = string.Empty;
    
    public ICollection<CommentaryModel> CommentaryModels { get; set; }
    public MembershipModel MembershipModel { get; set; }
}