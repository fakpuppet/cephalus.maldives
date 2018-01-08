using Cephalus.Maldives.Core.Exceptions;
using Cephalus.Maldives.Core.Services;
using Cephalus.Maldives.DAL.Sql;
using Cephalus.Maldives.Services;
using Cephalus.Maldives.Web.ActionFilters;
using Cephalus.Maldives.Web.Converters;
using Cephalus.Maldives.Web.Models;
using Cephalus.Maldives.Web.Models.JsonResult;
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
        public ActionResult AddCustomer(AddCustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                model.SetAlert("You entered invalid Customer data", AlertType.ClienError);

                return JsonResultWithView(Models.JsonResult.JsonActionResultType.ActionError, "~/Views/Customer/Partials/_AddCustomerForm.cshtml", model);
            }

            try
            {
                _customerService.Create(model.ToCustomer());

                return JsonRedirectResult(Models.JsonResult.JsonActionResultType.ActionSuccess, Url.Action("Index", "Home"));
            }
            catch (CreateCustomerException)
            {
                model.SetAlert("An error occurred while attempting to create a Customer", AlertType.ServerError);
                ModelState.AddModelError("CreateCustomerException", "An error occurred while attempting to add a customer");

                return JsonResultWithView(Models.JsonResult.JsonActionResultType.ActionError, "~/Views/Customer/Partials/_AddCustomerForm.cshtml", model);
            }
        }

        [HttpGet]
        public ActionResult EditCustomer(Guid customerId)
        {
            var converter = new EditCustomerConverter();
            var model = converter.FromCustomer(_customerService.Get(customerId));

            return View(model);
        }

        [HttpPost]
        public ActionResult EditCustomer(EditCustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                model.SetAlert("Changes could not be saved!", AlertType.ClienError);

                return JsonResultWithView(Models.JsonResult.JsonActionResultType.ActionError, "~/Views/Customer/Partials/_EditCustomerForm.cshtml", model);
            }

            _customerService.Update(model.ToCustomer());

            return Json(true);
        }

        [HttpGet]
        public ActionResult AddTag(Guid? customerId)
        {
            return View(new AddTagModel(customerId));
        }

        [HttpPost, AjaxOnly]
        public ActionResult AddTag(AddTagModel model)
        {
            if (!ModelState.IsValid)
            {
                model.SetAlert("Tag could not be added", AlertType.ClienError);

                return JsonResultWithView(JsonActionResultType.ActionError, string.Empty, model);
            }

            var tagConvertter = new AddTagConverter();

            _customerService.AddTag(tagConvertter.ToTag(model));

            return JsonRedirectResult(JsonActionResultType.ActionSuccess, 
                Url.Action("EditCustomer", "Customer", new { id = model.CustomerGuid }));
        }
    }
}