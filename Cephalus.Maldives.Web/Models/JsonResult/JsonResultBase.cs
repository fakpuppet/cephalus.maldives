namespace Cephalus.Maldives.Web.Models.JsonResult
{
    public class JsonResultBase : System.Web.Mvc.JsonResult
    {
        public JsonResultBase(object data)
        {
            JsonRequestBehavior = System.Web.Mvc.JsonRequestBehavior.AllowGet;
            Data = data;
        }
    }
}