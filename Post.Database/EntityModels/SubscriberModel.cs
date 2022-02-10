using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels;

[Table("subscribers")]
public class SubscriberModel : BaseModel
{
    [Column("subscriber_id")]
    public override Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("member_id")]
    [ForeignKey("MembershipModel")]
    public Guid MemberId { get; set; }

    public MembershipModel MembershipModel { get; set; }
}