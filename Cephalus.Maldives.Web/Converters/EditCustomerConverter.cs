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
                Id = customer.Id,
                CustomerId = customer.CustomerId,
                BirthDate = customer.BirthDate,
                CustomerNumber = customer.CustomerNumber,
                Tags = customer.Tags
            };
        }
    }
}