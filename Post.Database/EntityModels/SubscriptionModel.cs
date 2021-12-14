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
        public Guid TestUserModelId { get; set; }
        
        [Column("subscribers")]
        public List<Guid> Subscribers { get; set; } = new();
        
        [Column("subscribes")]
        public List<Guid> Subscribes { get; set; } = new();
        
        [ForeignKey("TestUserModelId")]
        public TestUserModel TestUserModel{ get; set; }
    }
}