using System.Web;
using System.Web.Optimization;

namespace ITIProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

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
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/Content/Script").Include(
                "~/Areas/Dashboard/Content/plugins/jquery/jquery.min.js",
                "~/Areas/Dashboard/Content/plugins/bootstrap/js/bootstrap.js",
                "~/Areas/Dashboard/Content/plugins/bootstrap-select/js/bootstrap-select.js",
                "~/Areas/Dashboard/Content/plugins/jquery-slimscroll/jquery.slimscroll.js",
                "~/Areas/Dashboard/Content/plugins/node-waves/waves.js",
                "~/Areas/Dashboard/Content/plugins/jquery-countto/jquery.countTo.js",
                "~/Areas/Dashboard/Content/plugins/raphael/raphael.min.js",
                "~/Areas/Dashboard/Content/plugins/morrisjs/morris.js",
                "~/Areas/Dashboard/Content/plugins/chartjs/Chart.bundle.js",
                "~/Areas/Dashboard/Content/plugins/flot-charts/jquery.flot.js",
                 "~/Areas/Dashboard/Content/plugins/flot-charts/jquery.flot.resize.js",
                 "~/Areas/Dashboard/Content/plugins/flot-charts/jquery.flot.pie.js",
                 "~/Areas/Dashboard/Content/plugins/flot-charts/jquery.flot.categories.js",
                 "~/Areas/Dashboard/Content/plugins/flot-charts/jquery.flot.time.js",
                 "~/Areas/Dashboard/Content/plugins/jquery-sparkline/jquery.sparkline.js",
                 "~/Areas/Dashboard/Content/js/admin.js",
                 "~/Areas/Dashboard/Content/js/pages/index.js",
                 "~/Areas/Dashboard/Content/js/demo.js"
                ));

            bundles.Add(new StyleBundle("~/Content/Style.").Include(
                "~/Areas/Dashboard/Content/plugins/bootstrap/css/bootstrap.css",
                "~/Areas/Dashboard/Content/plugins/node-waves/waves.css",
                "~/Areas/Dashboard/Content/plugins/animate-css/animate.css",
                "~/Areas/Dashboard/Content/plugins/morrisjs/morris.css",
                "~/Areas/Dashboard/Content/css/style.css",
                "~/Areas/Dashboard/Content/css/themes/all-themes.css"
                ));
        }
    }
}
