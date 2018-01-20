using System.Web;
using System.Web.Optimization;

namespace BUOTOnline.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/app/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/addCategoryController").Include(
                        "~/Scripts/app/controllers/addCategoryController.js"));

            bundles.Add(new ScriptBundle("~/bundles/editCategoryController").Include(
                        "~/Scripts/app/controllers/editCategoryController.js"));

            bundles.Add(new ScriptBundle("~/bundles/noticeController").Include(
                        "~/Scripts/app/controllers/noticeController.js"));

            bundles.Add(new ScriptBundle("~/bundles/searchController").Include(
                        "~/Scripts/app/controllers/searchController.js"));

            bundles.Add(new ScriptBundle("~/bundles/adminController").Include(
                        "~/Scripts/app/controllers/adminController.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
