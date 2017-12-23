using Cephalus.Maldives.Core.Models;
using System;

namespace Cephalus.Maldives.DAL.Sql.Dto
{
    public class TagDtoFactory
    {
        public static TagDto TagDtoFromTag(Tag tag)
        {
            if (tag is Ethnicity)
                return TagDtoFromTag(tag as Ethnicity);

            if (tag is Country)
                return TagDtoFromTag(tag as Country);

            if (tag is WatchBrand)
                return TagDtoFromTag(tag as WatchBrand);

            if (tag is Activity)
                return TagDtoFromTag(tag as Activity);

            throw new ArgumentException("Unsupported Tag class mapping");
        }

        private static TagDto TagDtoFromTag(Activity tag)
        {
            return TagDtoFromTag<Activity, ActivityDto>(tag);
        }

        private static TagDto TagDtoFromTag(Ethnicity tag)
        {
            return TagDtoFromTag<Ethnicity, EthnicityDto>(tag);
        }

        private static TagDto TagDtoFromTag(Country tag)
        {
            return TagDtoFromTag<Country, CountryDto>(tag);
        }

        private static TagDto TagDtoFromTag(WatchBrand tag)
        {
            return TagDtoFromTag<WatchBrand, WatchBrandDto>(tag);
        }

        private static TTagDto TagDtoFromTag<TTag, TTagDto>(TTag tag)
            where TTag : Tag
            where TTagDto : TagDto, new()
        {
            return new TTagDto
            {
                Id = tag.Id,
                TagId = tag.TagId,
                Name = tag.Name,
            };
        }
    }
}
