using Cephalus.Maldives.Web.Models.JsonResult;
using System.IO;
using System.Web.Mvc;

namespace Cephalus.Maldives.Web.Controllers
{
    public class BaseController : Controller
    {
        public string RenderRazorViewToString(string viewPath, object model)
        {
            ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewPath);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);

                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);

                return sw.GetStringBuilder().ToString();
            }
        }

        public JsonResult JsonRedirectResult(JsonActionResultType resultType, string redirectUrl)
        {
            return new JsonRedirectResult(resultType, redirectUrl);
        }

        public JsonResult JsonResultWithView(JsonActionResultType resultType, string viewPath, object model)
        {
            return new JsonResult(new JsonResultWithView(resultType, RenderRazorViewToString(viewPath, model));
        }
    }
}