using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels;

[Table("respondents")]
public class RespondentModel : BaseModel
{
    [Column("respondent_id")]
    public override Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("member_id")]
    [ForeignKey("MembershipModel")]
    public Guid MemberId { get; set; }

    public MembershipModel MembershipModel { get; set; }
}