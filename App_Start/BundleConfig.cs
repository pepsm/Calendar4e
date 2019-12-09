using System.Web;
using System.Web.Optimization;

namespace Calandar4eApp
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

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // fullcalendar dependency
            
            bundles.Add(new StyleBundle("~/Content/fullcalendarcss").Include(
                "~/Content/fullcalendar.css",
                "~/Content/fullcalendar.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/fullcalendarjs").Include(
                "~/Scripts/lib/jquery-ui.min.css",
                "~/Scripts/lib/moment.min.js",
                "~/Scripts/lib/jquery.min.js",
                "~/Scripts/fullcalendar.min.js",
                "~/Scirpts/fullcalendar.js"));


        }
    }
}
