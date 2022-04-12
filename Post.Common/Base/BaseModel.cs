using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Post.Common.Base
{
    public class BaseModel
    {
        [Column("id")]
        public virtual Guid Id { get; set; }
        
        [Column("day_created")]
        public DateTime DateCreated { get; set; }
        
        /*[Column("day_updated")]
        public DateTime? DateUpdated { get; set; }*/
    }
}