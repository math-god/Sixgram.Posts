using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels
{
    [Table("membership")]
    public class MembershipModel : BaseModel
    {
        [Column("member_id")] 
        public override Guid Id { get; set; } = Guid.NewGuid();
        
        public ICollection<SubscriptionModel> Subscriptions { get; set; }
        public ICollection<SubscriberModel> Subscribers { get; set; }
    }
}