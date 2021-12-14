using System.ComponentModel.DataAnnotations.Schema;
using Post.Common.Base;

namespace Post.Database.EntityModels
{
    public class TestUserModel: BaseModel
    {
        [Column("name")]
        public string Name { get; set; }
    }
}