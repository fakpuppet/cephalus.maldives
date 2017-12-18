using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Cephalus.Maldives.DAL.Sql.Dto
{
    [Table("Activity")]
    public class ActivityDto : TagDto
    {
        public virtual ICollection<SpecificActivityDto> Activities { get; set; }

        public ActivityDto()
        {
            TagType = TagTypeDto.Activity;
        }

        public override string Display() => string.Join(", ", Activities.Select(a => a.Name));
    }
}
