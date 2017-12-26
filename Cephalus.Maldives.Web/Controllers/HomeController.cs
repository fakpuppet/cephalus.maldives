using Cephalus.Maldives.Core.Exceptions;
using Cephalus.Maldives.Core.Models;
using Cephalus.Maldives.Core.Services;
using Cephalus.Maldives.DAL.Sql;
using Cephalus.Maldives.Services;
using Cephalus.Maldives.Web.ActionFilters;
using Cephalus.Maldives.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace Cephalus.Maldives.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICustomerService _customerService;
        private const string ConnectionString = @"Server=.\;Database=cephalus.maldives;User Id=sa;Password=1;MultipleActiveResultSets=true";

        public HomeController() 
            : this(new CustomerService(new CustomerRepository(ConnectionString)))
        {
            // var dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public HomeController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public ActionResult Index()
        {
            var model = new CustomersModel
            {
                Customers = _customerService.GetByTags(new TagType[0], Enumerable.Empty<string>().ToArray())
            };

            return View(model);
        }
        public ActionResult Customer()
        {
            return View(new AddCustomerModel());
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