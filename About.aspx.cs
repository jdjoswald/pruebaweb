using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pruebaWeb
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
                actualizardatos();
            

        }

        private void actualizardatos() {

            Global.MiVariableGlobal = ObtenerCantidadNoticiasDesdeURL();
            Global.tiempoRefresco = TimepoDeRefreco();


        }

        private int ObtenerCantidadNoticiasDesdeURL()
        {
            int cantidad = Global.MiVariableGlobal; 
            if (Request.QueryString["cantidad"] != null)
            {
                int.TryParse(Request.QueryString["cantidad"], out cantidad);
            }

            return cantidad;
        }

        private int TimepoDeRefreco()
        {
            int cantidad = Global.tiempoRefresco; 

            if (Request.QueryString["refresco"] != null)
            {
                int.TryParse(Request.QueryString["refresco"], out cantidad);
            }

            return cantidad;
        }
    }
}