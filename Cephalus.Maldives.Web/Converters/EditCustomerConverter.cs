using Cephalus.Maldives.Core.Models;
using Cephalus.Maldives.Web.Models;

namespace Cephalus.Maldives.Web.Converters
{
    public class EditCustomerConverter : CustomerConverterBase<EditCustomerModel>
    {
        public override EditCustomerModel FromCustomer(Customer customer)
        {
            return new EditCustomerModel
            {
                BirthDate = customer.BirthDate,
                CustomerId = customer.CustomerId,
                CustomerNumber = customer.CustomerNumber,
                Tags = customer.Tags
            };
        }
    }
}