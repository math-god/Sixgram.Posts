using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels;

[Table("subscribers")]
public class SubscriberModel : BaseModel
{
    [Column("id")]
    public override Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("member_id")]
    [ForeignKey("MembershipModel")]
    public Guid MemberId { get; set; }
    
    [Column("respondent_id")]
    public  Guid SubscriberId { get; set; }
    
    public MembershipModel MembershipModel { get; set; }
}