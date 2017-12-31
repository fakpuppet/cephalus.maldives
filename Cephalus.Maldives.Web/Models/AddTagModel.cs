using System;

namespace Cephalus.Maldives.Web.Models
{
    public class AddTagModel : AlertingModelBase
    {
        public Guid CustomerGuid { get; set; }

        public string Name { get; set; }
    }
}