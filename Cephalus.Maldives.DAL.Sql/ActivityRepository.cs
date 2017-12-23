using Cephalus.Maldives.DAL.Sql.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Cephalus.Maldives.DAL.Sql
{
    public class ActivityRepository : RepositoryBase
    {
        public ICollection<ActivityDto> GetActivityDto(long id)
        {
            return Enumerable.Empty<ActivityDto>().ToArray();
        }
    }
}
