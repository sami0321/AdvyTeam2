using System.Web;
using System.Web.Optimization;

namespace WebApp
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {


            bundles.Add(new ScriptBundle("~/admin-lte/js").Include(
             "~/admin-lte/js/adminlte.min.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/admin-lte/css/adminlte.min.css",
                      "~/admin-lte/css/skins/skin-blue.css",
                      "~/admin-lte/plugins/fontawesome-free/css/all.min.css"
                      ));
            bundles.Add(new ScriptBundle("~/admin-lte/js").Include(
             "~/admin-lte/js/app.js"));
            bundles.Add(new ScriptBundle("~/admin-lte/js").Include(
             "~/admin-lte/js/app.js",
             "~/admin-lte/plugins/fastclick/fastclick.js",
             "~/admin-lte/plugins/bootstrap/js/bootstrap.bundle.min.js",
             "~/admin-lte/plugins/jquery/jquery.min.js"
             ));
        }
    }
}
