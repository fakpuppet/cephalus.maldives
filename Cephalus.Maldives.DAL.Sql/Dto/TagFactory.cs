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

            throw new ArgumentException("Unknown class mapping");
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
    }
}
