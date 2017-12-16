namespace Cephalus.Maldives.DAL.Sql.Dto
{
    public class WatchBrandDto : TagDto
    {
        public override TagTypeDto TagType { get => TagTypeDto.WatchBrand; }

        public override string Display()
        {
            return Name;
        }
    }
}
