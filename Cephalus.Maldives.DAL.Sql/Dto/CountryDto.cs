using System.ComponentModel.DataAnnotations.Schema;

namespace Cephalus.Maldives.DAL.Sql.Dto
{
    [Table("Country")]
    public class CountryDto : TagDto
    {
        public override TagTypeDto TagType { get; set; }

        public CountryDto()
        {
            TagType = TagTypeDto.Country;
        }

        public override string Display()
        {
            return Name;
        }
    }
}
