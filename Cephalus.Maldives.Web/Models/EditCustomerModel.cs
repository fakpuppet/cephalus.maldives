using System;

namespace Cephalus.Maldives.Web.Models
{
    public class EditCustomerModel : AddCustomerModel
    {
        public int Id { get; set; }

        public Guid CustomerId { get; set; }
    }
}