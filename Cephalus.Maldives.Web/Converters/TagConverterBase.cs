using Cephalus.Maldives.Core.Models;

namespace Cephalus.Maldives.Web.Converters
{
    public abstract class TagConverterBase<TTarget>
    {
        public abstract TTarget FromTag(Tag tag);

        public abstract Tag ToTag(TTarget target);
    }
}