using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels
{
    [Table("subscription")]
    public class SubscriptionModel : BaseModel
    {
        [Column("user_id")] 
        public override Guid Id { get; set; } = Guid.NewGuid();
        
        /*[Column("subscribers")]
        public virtual ICollection<Subscribers> Subscribers { get; set; }
        
        [Column("subscriptions")]
        public virtual ICollection<Subscription> Subscriptions { get; set; }*/

        [Column("subscribers", TypeName = "uuid[]")]
        public List<Guid> Subscribers { get; set; } = new();
        
        [Column("subscriptions", TypeName = "uuid[]")]
        public List<Guid> Subscriptions { get; set; } = new();
    }
}