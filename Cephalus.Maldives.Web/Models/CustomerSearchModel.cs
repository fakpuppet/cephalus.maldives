using Cephalus.Maldives.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cephalus.Maldives.Web.Models
{
    public class CustomerSearchModel
    {
        public IEnumerable<TagType> Tags { get; set; }

        public string Keyword { get; set; }

        public CustomerSearchModel()
        {
            Tags = Enumerable.Empty<TagType>();
        }
    }
}