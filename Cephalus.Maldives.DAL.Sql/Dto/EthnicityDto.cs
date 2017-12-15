using System.ComponentModel.DataAnnotations.Schema;

namespace Cephalus.Maldives.DAL.Sql.Dto
{
    [Table("Ethnicity")]
    public class EthnicityDto : TagDto
    {
        public string Name { get; set; }

        public override string Display()
        {
            return Name;
        }
    }
}
