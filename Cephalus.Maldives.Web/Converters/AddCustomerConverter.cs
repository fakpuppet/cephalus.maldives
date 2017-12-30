using Cephalus.Maldives.Core.Models;
using Cephalus.Maldives.Web.Models;

namespace Cephalus.Maldives.Web.Converters
{
    public class AddCustomerConverter : CustomerConverterBase<AddCustomerModel>
    {
        public override AddCustomerModel FromCustomer(Customer customer)
        {
            return new AddCustomerModel
            {
                BirthDate  = customer.BirthDate,
                CustomerNumber = customer.CustomerNumber,
                Tags = customer.Tags
            };
        }
    }
}