using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels;

[Table("commentaries")]
public class CommentaryModel : BaseModel
{
    [Column("post_id")]
    public override Guid Id { get; set; }

    [Column("commentary_dict")]
    public Dictionary<Guid, string> CommentaryArray { get; set; }
}