using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pruebaWeb
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

         

           
            if (!IsPostBack)
            {
                int tiempoRefresco = Global.tiempoRefresco;

               
                string script = $@"
                    <script>

                        console.log('{tiempoRefresco}');
                    function abrirNoticia(titulo) {{
                    // Abrir la noticia en una nueva pestaña
                    var nuevaPestana = window.open('DetallesNoticias.aspx?titulo=' + titulo, '_blank');
   

                }}
                        function refreshPage() {{
                            location.reload(); // Recargar la página
                        }}
                        setInterval(refreshPage, {tiempoRefresco});

                    </script>
                ";

               

             
                LiteralControl literalControl = new LiteralControl(script);
                Page.Header.Controls.Add(literalControl);
                obtenerNoticia();
            }
            
        }

        private void obtenerNoticia()
        {
        

            
            NoticiasController noticiaController = new NoticiasController();
            List<NoticiaModel> noticias = noticiaController.ObtenerNoticias();


            foreach (NoticiaModel noticia in noticias)
            {
                string htmlNoticia = $@"
            <div class='card'>
                <div class='card-body'>
                   
                    <h5 class='card-title'>{noticia.Titulo}</h5>
                    <p class='card-text'>{noticia.Resumen}</p>
                    <p class='card-text'>{noticia.Tiempo}</p>
                     <button onclick=""abrirNoticia('{HttpUtility.UrlEncode(noticia.Titulo)}')"" class='btn btn-primary'>Leer más</button>
                     
                   
                </div>
            </div>";

                noticiasContainer.Controls.Add(new LiteralControl(htmlNoticia));
            }
        }




        
    }
}