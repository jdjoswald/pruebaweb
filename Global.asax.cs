using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace pruebaWeb
{
    public class Global : HttpApplication
    {
        public static int MiVariableGlobal { get; set; }
        public static int tiempoRefresco { get; set; }
        public static List<string> MiArregloGlobal { get; set; }

        void Application_Start(object sender, EventArgs e)
        {
            Global.MiArregloGlobal = new List<string>();
            MiVariableGlobal = 10;
            tiempoRefresco = 30000;

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}