using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cephalus.Maldives.DAL.Sql.Dto
{
    [Table("SpecificActivity")]
    public class SpecificActivityDto
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public ActivityDto Activity { get; set; }
    }
}
