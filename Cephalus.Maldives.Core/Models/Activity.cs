using System.Collections.Generic;
using System.Linq;

namespace Cephalus.Maldives.Core.Models
{
    public class Activity : Tag
    {
        public ICollection<SpecificActivity> Activities { get; set; }

        public override string Display()
        {
            if (Activities?.Any() == true)
            {
                return string.Join(", ", Activities?.Select(a => a.Name));
            }

            return string.Empty;
        }
    }
}
