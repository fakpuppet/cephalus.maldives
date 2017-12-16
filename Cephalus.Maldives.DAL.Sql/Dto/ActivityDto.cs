using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cephalus.Maldives.DAL.Sql.Dto
{
    [Table("Activity")]
    public class ActivityDto : TagDto
    {
        public virtual ICollection<string> Activities { get; set; }

        public override string Display()
        {
            return string.Join(", ", Activities);
        }
    }
}
