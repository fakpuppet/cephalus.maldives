using System;

namespace Cephalus.Maldives.DAL.Sql.Dto
{
    public class CountryDto : TagDto
    {
        public string Name { get; set; }

        public override string Display()
        {
            return Name;
        }
    }
}
