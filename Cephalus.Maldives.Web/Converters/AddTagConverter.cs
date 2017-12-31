using Cephalus.Maldives.Core.Models;
using Cephalus.Maldives.Web.Models;

namespace Cephalus.Maldives.Web.Converters
{
    public class AddTagConverter : TagConverterBase<AddTagModel>
    {
        public override AddTagModel FromTag(Tag tag)
        {
            return new AddTagModel
            {
                CustomerGuid = tag.CustomerGuid,
                Name = tag.Name
            };
        }

        public override Tag ToTag(AddTagModel target)
        {
            return new Tag
            {
                Name = target.Name,
                CustomerGuid = target.CustomerGuid,
            };
        }
    }
}