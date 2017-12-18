namespace Cephalus.Maldives.DAL.Sql.Dto
{
    public class WatchBrandDto : TagDto
    {
        public WatchBrandDto()
        {
            TagType = TagTypeDto.WatchBrand;
        }

        public override string Display()
        {
            return Name;
        }
    }
}
