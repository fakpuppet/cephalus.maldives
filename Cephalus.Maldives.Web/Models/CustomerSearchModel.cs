using Cephalus.Maldives.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Cephalus.Maldives.Web.Models
{
    public class CustomerSearchModel
    {
        public IEnumerable<TagType> Tags { get; set; }

        public string Keywords { get; set; }

        public CustomerSearchModel()
        {
            Tags = Enumerable.Empty<TagType>();
        }

        public string[] GetKeywords()
        {
            return (string.IsNullOrEmpty(Keywords) 
                ? Enumerable.Empty<string>() 
                : Keywords.Split(',').Select(k => k.Trim())).ToArray();
        }
    }
}