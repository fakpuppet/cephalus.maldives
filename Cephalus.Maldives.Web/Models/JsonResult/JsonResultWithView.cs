namespace Cephalus.Maldives.Web.Models.JsonResult
{
    public class JsonResultWithView
    {
        public JsonActionResultType ActionResultType { get; set; }

        public string JsonResultType => GetType().Name;

        public string ViewResult { get; set; }

        public JsonResultWithView(object data) 
            : base(data)
        {
        }
    }
}