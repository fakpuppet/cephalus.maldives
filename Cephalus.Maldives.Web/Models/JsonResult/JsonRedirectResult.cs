namespace Cephalus.Maldives.Web.Models.JsonResult
{
    public class JsonRedirectResult 
    {
        public string RedirectUrl { get; set; }

        public JsonActionResultType ActionResultType { get; set; }

        public string JsonResultType => GetType().Name;

        public JsonRedirectResult(JsonActionResultType actionResultType, string redirectUrl)
        {
            RedirectUrl = redirectUrl;
            ActionResultType = actionResultType;
        }
    }
}