using Cephalus.Maldives.Core.Models;
using System;
using System.Linq;

namespace Cephalus.Maldives.DAL.Sql.Dto
{
    public class TagFactory
    {
        public static Tag TagFromDto(TagDto dto)
        {
            if (dto is EthnicityDto)
                return TagFromDto(dto as EthnicityDto);

            if (dto is CountryDto)
                return TagFromDto(dto as CountryDto);

            if (dto is WatchBrandDto)
                return TagFromDto(dto as WatchBrandDto);

            if (dto is ActivityDto)
                return TagFromDto(dto as ActivityDto);

            throw new ArgumentException("Unsupported Tag class mapping");
        }

        private static Tag TagFromDto(EthnicityDto dto)
        {
            return TagFromDto<EthnicityDto, Ethnicity>(dto);
        }

        private static Tag TagFromDto(CountryDto dto)
        {
            return TagFromDto<CountryDto, Country>(dto);
        }

        private static Tag TagFromDto(WatchBrandDto dto)
        {
            return TagFromDto<WatchBrandDto, WatchBrand>(dto);
        }

        private static Tag TagFromDto(ActivityDto dto)
        {
            var activity = TagFromDto<ActivityDto, Activity>(dto);

            activity.Activities = dto.Activities?.Select(a => FromDto(a)).ToArray();

            return activity;
        }

        private static TTag TagFromDto<TTagDto, TTag>(TTagDto dto)
            where TTagDto : TagDto
            where TTag : Tag, new()
        {
            return new TTag
            {
                Id = dto.Id,
                TagId = dto.TagId,
                Name = dto.Name,
            };
        }

        private static SpecificActivity FromDto(SpecificActivityDto dto)
        {
            return new SpecificActivity
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
