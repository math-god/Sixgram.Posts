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
      
        [Column("subscribers")]
        public Guid[] Subscribers { get; set; } = Array.Empty<Guid>();
        
        [Column("subscriptions")]
        public Guid[] Subscriptions { get; set; } = Array.Empty<Guid>();
    }
}