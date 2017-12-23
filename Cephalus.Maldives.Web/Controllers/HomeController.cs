using Cephalus.Maldives.Core.Models;
using Cephalus.Maldives.Core.Services;
using Cephalus.Maldives.DAL.Sql;
using Cephalus.Maldives.Services;
using Cephalus.Maldives.Web.Models;
using System.Web.Mvc;

namespace Cephalus.Maldives.Web.Controllers
{
    public class HomeController : Controller
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
                Customers = _customerService.GetByTags(new[] { TagType.Country, TagType.Ethnicity, TagType.Beverage }, string.Empty)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult GetCustomersByTagType(CustomerSearchModel searchModel)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("~/Views/Home/Partials/_Customers.cshtml", new CustomersModel());
            }

            var model = new CustomersModel
            {
                Customers = _customerService.GetByTags(searchModel.Tags, searchModel.Keyword)
            };

            return PartialView("~/Views/Home/Partials/_Customers.cshtml", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}