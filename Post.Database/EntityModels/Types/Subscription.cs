using System.ComponentModel.DataAnnotations.Schema;

namespace Post.Database.EntityModels.Types;

public class Subscription
{
    [Column("user_id")]
    public Guid UserId { get; set; }
}