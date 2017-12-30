using Cephalus.Maldives.Core.Exceptions;
using Cephalus.Maldives.Core.Services;
using Cephalus.Maldives.DAL.Sql;
using Cephalus.Maldives.Services;
using Cephalus.Maldives.Web.ActionFilters;
using Cephalus.Maldives.Web.Converters;
using Cephalus.Maldives.Web.Models;
using System;
using System.Web.Mvc;

namespace Cephalus.Maldives.Web.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;
        private const string ConnectionString = @"Server=.\;Database=cephalus.maldives;User Id=sa;Password=1;MultipleActiveResultSets=true";

        public CustomerController() 
            : this(new CustomerService(new CustomerRepository(ConnectionString)))
        {
            // var dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost, AjaxOnly]
        public ActionResult GetCustomersByTagType(CustomerSearchModel searchModel)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("~/Views/Home/Partials/_Customers.cshtml", new CustomersModel());
            }

            var model = new CustomersModel
            {
                Customers = _customerService.GetByTags(searchModel.Tags, searchModel.GetKeywords())
            };

            return PartialView("~/Views/Home/Partials/_Customers.cshtml", model);
        }

        [HttpGet]
        public ActionResult EditCustomer(Guid id)
        {
            var converter = new EditCustomerConverter();
            var model = converter.FromCustomer(_customerService.Get(id));

            return View(model);
        }

        [HttpPost]
        public ActionResult EditCustomer(EditCustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                model.SetAlert("Changes could not be saved!", AlertType.ClienError);

                return View(model);
            }

            _customerService.Update(model.ToCustomer());

            return Json(true);
        }

        [HttpPost, AjaxOnly]
        public ActionResult AddCustomer(AddCustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                model.SetAlert("You entered invalid Customer data", AlertType.ClienError);

                return JsonResultWithView(Models.JsonResult.JsonActionResultType.ActionError, "~/Views/Home/Partials/_AddCustomerForm.cshtml", model);
            }
            
            try
            {
                _customerService.Create(model.ToCustomer());

                return JsonRedirectResult(Models.JsonResult.JsonActionResultType.ActionSuccess, Url.Action("Index", "Home"));
            }
            catch(CreateCustomerException)
            {
                model.SetAlert("An error occurred while attempting to create a Customer", AlertType.ServerError);
                ModelState.AddModelError("CreateCustomerException", "An error occurred while attempting to add a customer");

                return JsonResultWithView(Models.JsonResult.JsonActionResultType.ActionError, "~/Views/Home/Partials/_AddCustomerForm.cshtml", model);
            }
        }
    }
}