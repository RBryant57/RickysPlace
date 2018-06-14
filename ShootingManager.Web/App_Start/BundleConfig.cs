using System.Web;
using System.Web.Optimization;

namespace ShootingManager.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.js",
                        "~/Scripts/jquery.tablesorter.js",
                        "~/Scripts/gridforms.js"));

            bundles.Add(new ScriptBundle("~/bundles/brass").Include("~/Scripts/brass.js"));
            bundles.Add(new ScriptBundle("~/bundles/bullet").Include("~/Scripts/bullet.js"));
            bundles.Add(new ScriptBundle("~/bundles/cartridge").Include("~/Scripts/cartridge.js"));
            bundles.Add(new ScriptBundle("~/bundles/load").Include("~/Scripts/load.js"));
            bundles.Add(new ScriptBundle("~/bundles/powder").Include("~/Scripts/powder.js"));
            bundles.Add(new ScriptBundle("~/bundles/primer").Include("~/Scripts/primer.js"));
            bundles.Add(new ScriptBundle("~/bundles/shootingsession").Include("~/Scripts/shootingsession.js"));
            bundles.Add(new ScriptBundle("~/bundles/tablefilter").Include("~/Scripts/tablefilter.js"));
            bundles.Add(new ScriptBundle("~/bundles/validate").Include("~/Scripts/validate.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include("~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-extensions.css",
                      "~/Content/shooting-manager.css",
                      "~/Content/gridforms.css",
                      "~/Content/tablestyle.css",
                      "~/Content/jquery-ui.css"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
              "~/Scripts/knockout-{version}.js",
              "~/Scripts/app.js"));
        }
    }
}
