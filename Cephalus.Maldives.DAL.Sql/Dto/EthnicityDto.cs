using System.ComponentModel.DataAnnotations.Schema;

namespace Cephalus.Maldives.DAL.Sql.Dto
{
    [Table("Ethnicity")]
    public class EthnicityDto : TagDto
    {
        public override TagTypeDto TagType { get; set; }

        public EthnicityDto()
        {
            TagType = TagTypeDto.Ethnicity;
        }

        public override string Display()
        {
            return Name;
        }
    }
}
