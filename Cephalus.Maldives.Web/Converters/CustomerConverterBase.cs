using Cephalus.Maldives.Core.Models;

namespace Cephalus.Maldives.Web.Converters
{
    public abstract class CustomerConverterBase<TTarget>
    {
        public abstract TTarget FromCustomer(Customer customer);
    }
}