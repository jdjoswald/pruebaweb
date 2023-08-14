using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pruebaWeb
{
    public partial class DetallesNoticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDetallesNoticia();
            }
        }

        private void CargarDetallesNoticia()
        {
            string tituloNoticia = Request.QueryString["titulo"];

           


            if (!string.IsNullOrEmpty(tituloNoticia))
            {
                Global.MiArregloGlobal.Add(tituloNoticia);
                NoticiasController noticiaController = new NoticiasController();
                NoticiaModel noticiaDetalles = noticiaController.ObtenerDetallesNoticia(tituloNoticia);

                if (noticiaDetalles != null)
                {
                    lblTitulo.Text = noticiaDetalles.Titulo;
                    lblResumen.Text = noticiaDetalles.Resumen;
                    // Otros campos que quieras mostrar en la página
                }
                else
                {
                    lblTitulo.Text = "Noticia no encontrada";
                    lblResumen.Text = "La noticia que estás buscando no se ha encontrado en el feed RSS.";
                }
            }
            else
            {
                lblTitulo.Text = "Detalles de Noticia";
                lblResumen.Text = "No se ha proporcionado un título de noticia válido.";
            }
        }
    }
}
