using System.Web.Optimization;

namespace Cephalus.Maldives.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryunobtrusive").Include(
                        "~/Scripts/jquery.unobtrusive*"));

            RegisterSharedBunde(bundles);

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/Customers").Include(
                    "~/Scripts/pages/customers.js",
                    "~/Scripts/services/data-service.js"));

            bundles.Add(new ScriptBundle("~/bundles/AddCustomer").Include(
                    "~/Scripts/pages/add-customer.js"));
            bundles.Add(new ScriptBundle("~/bundles/EditCustomer").Include(
                    "~/Scripts/pages/edit-customer.js"));

        }

        private static void RegisterSharedBunde(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Shared")
                .Include("~/Scripts/libs/jquery.selectric.min.js",
                         "~/Scripts/main/main.js",
                         "~/Scripts/main/constants.js",
                         "~/Scripts/util/helpers/ajax-json-response-handler.js",
                         "~/Scripts/util/helpers/selectric-binder.js",
                         "~/Scripts/util/helpers/form-helper.js"
                ));
        }
    }
}
