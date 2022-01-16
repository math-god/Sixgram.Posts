﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels
{
    [Table("subscriptions")]
    public class SubscriptionModel : BaseModel
    {
        [Column("user_id")] 
        public override Guid Id { get; set; } = Guid.NewGuid();
        
        [Column("subscribers")]
        public List<Guid> Subscribers { get; set; } = new();
        
        [Column("subscriptions")]
        public List<Guid> Subscriptions { get; set; } = new();
    }
}