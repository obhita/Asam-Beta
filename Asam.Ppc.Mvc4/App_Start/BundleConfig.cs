using System.Web;
using System.Web.Optimization;

namespace Asam.Ppc.Mvc4
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-2.*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
                "~/Scripts/jquery.unobtrusive*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquerydatatable").Include(
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/jquery.dataTables.TableTools.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryformatcurrency").Include(
                "~/Scripts/jquery.formatCurrency*",
                "~/Scripts/jquery.numeric.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryasam").Include(
                "~/Scripts/jquery.asam-*",
                "~/Scripts/jquery.history.js"));

            bundles.Add(new ScriptBundle("~/bundles/assessmentrules").Include(
                "~/Scripts/AsamClientBusinessRules.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/browser-reset.css",
                "~/Content/site.css",
                "~/Content/960Grid.css",
                "~/Content/asam-controls.css"));


            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                "~/Content/themes/base/jquery.ui.core.css",
                "~/Content/themes/base/jquery.ui.resizable.css",
                "~/Content/themes/base/jquery.ui.selectable.css",
                "~/Content/themes/base/jquery.ui.accordion.css",
                "~/Content/themes/base/jquery.ui.autocomplete.css",
                "~/Content/themes/base/jquery.ui.button.css",
                "~/Content/themes/base/jquery.ui.dialog.css",
                "~/Content/themes/base/jquery.ui.slider.css",
                "~/Content/themes/base/jquery.ui.tabs.css",
                "~/Content/themes/base/jquery.ui.datepicker.css",
                "~/Content/themes/base/jquery.ui.progressbar.css",
                "~/Content/themes/base/jquery.ui.theme.css",
                "~/Content/DataTables/css/jquery.dataTables.css",
                "~/Content/DataTables/css/demo_table.css",
                "~/Content/DataTables/css/demo_table.jui.css"));
        }
    }
}