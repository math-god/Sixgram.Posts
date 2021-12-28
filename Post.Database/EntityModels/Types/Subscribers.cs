using System.ComponentModel.DataAnnotations.Schema;

namespace Post.Database.EntityModels.Types;

public class Subscribers
{
    [Column("user_id")]
    public Guid UserId { get; set; }
}