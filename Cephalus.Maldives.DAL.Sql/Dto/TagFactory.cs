using Cephalus.Maldives.Core.Models;
using System;

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
            return new Ethnicity
            {
                Id = dto.Id,
                TagId = dto.TagId,
                Name = dto.Name,
                CustomerId = dto.CustomerId,
            };
        }

        private static Tag TagFromDto(CountryDto dto)
        {
            return new Country
            {
                Id = dto.Id,
                TagId = dto.TagId,
                Name = dto.Name,
                CustomerId = dto.CustomerId,
            };
        }

        private static Tag TagFromDto(WatchBrandDto dto)
        {
            return new WatchBrand
            {
                Id = dto.Id,
                TagId = dto.TagId,
                Name = dto.Name,
                CustomerId = dto.CustomerId,
            };
        }

        private static Tag TagFromDto(ActivityDto dto)
        {
            return new Activity
            {
                Id = dto.Id,
                TagId = dto.TagId,
                Name = dto.Name,
                CustomerId = dto.CustomerId,
            };
        }
    }
}
