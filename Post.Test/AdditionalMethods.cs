using System;
using System.Collections.Generic;
using Post.Database.EntityModels;

namespace Post.Test;

public class AdditionalMethods
{
    public static List<SubscriptionModel> GetTestSubscriptions()
    {
        var subscriptions = new List<SubscriptionModel>()
        {
            new() { RespondentId = new Guid("B52F727F-88D5-43AD-B9DA-9038BBAABE44"), SubscriberId = Guid.NewGuid() },
            new() { RespondentId = new Guid("B52F727F-88D5-43AD-B9DA-9038BBAABE44"), SubscriberId = Guid.NewGuid() }
        };
        return subscriptions;
    }
}