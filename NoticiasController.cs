using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.ServiceModel.Syndication;

namespace pruebaWeb
{
    public class NoticiasController
    {

        /*  public List<NoticiaModel> ObtenerNoticias()
          {
              List<NoticiaModel> noticias = new List<NoticiaModel>();
              // Agrega aquí la lógica real para obtener las noticias desde los feeds configurados
              // Por ahora, simularemos algunos datos de noticias
              noticias.Add(new NoticiaModel("Título Noticia 1", "Resumen noticia 1", "Hace 5 minutos"));
              noticias.Add(new NoticiaModel("Título Noticia 2", "Resumen noticia 2", "Hace 10 minutos"));
              noticias.Add(new NoticiaModel("Título Noticia 3", "Resumen noticia 3", "Hace 15 minutos"));
              return noticias;
          }*/

        public List<NoticiaModel> ObtenerNoticias()
        {
            int cantidad = Global.MiVariableGlobal;
            if (cantidad < 10)
            {
                cantidad = 10;
            }
            List<NoticiaModel> noticias = new List<NoticiaModel>();

            using (XmlReader reader = XmlReader.Create("https://feeds.bbci.co.uk/news/rss.xml"))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                int contador = 0;  // Contador para limitar la cantidad de noticias

                foreach (SyndicationItem item in feed.Items)
                {
                    if (contador >= cantidad)
                        break;  // Salir del bucle si se ha alcanzado la cantidad deseada

                    string titulo = item.Title.Text;

                    // Verificar si el título ya está en el arreglo global
                    if (!Global.MiArregloGlobal.Contains(titulo))
                    {
                        string resumen = item.Summary.Text;
                        DateTime fechaPublicacion = item.PublishDate.DateTime;
                        string tiempo = ObtenerTiempoTranscurrido(fechaPublicacion);

                        // Agregar el título al arreglo global
                        Global.MiArregloGlobal.Add(titulo);

                        // Agregar la noticia a la lista
                        noticias.Add(new NoticiaModel(titulo, resumen, tiempo));

                        contador++;  // Incrementar el contador solo si se agrega la noticia
                    }
                }
            }

            return noticias;
        }

        public NoticiaModel ObtenerDetallesNoticia(string titulo)
        {
            string urlRss = "https://feeds.bbci.co.uk/news/rss.xml";
            XmlReader reader = XmlReader.Create(urlRss);
            SyndicationFeed feed = SyndicationFeed.Load(reader);

            // Buscar la noticia por título en el feed
            SyndicationItem noticiaEncontrada = feed.Items.FirstOrDefault(item => item.Title.Text.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (noticiaEncontrada != null)
            {
                string tituloe = noticiaEncontrada.Title.Text;
                string resumen = noticiaEncontrada.Summary.Text;
                DateTime fechaPublicacion = noticiaEncontrada.PublishDate.DateTime;
                string tiempo = ObtenerTiempoTranscurrido(fechaPublicacion);
                NoticiaModel noticiaDetalles = new NoticiaModel(titulo, resumen, tiempo);


                ;

                return noticiaDetalles;
            }

            return null; // Noticia no encontrada
        }
        // Método para calcular el tiempo transcurrido desde la publicación
        private string ObtenerTiempoTranscurrido(DateTime fecha)
        {
            TimeSpan diferencia = DateTime.Now - fecha;

            if (diferencia.TotalMinutes < 1)
            {
                return "Hace unos segundos";
            }
            else if (diferencia.TotalHours < 1)
            {
                return $"Hace {diferencia.Minutes} minutos";
            }
            else if (diferencia.TotalDays < 1)
            {
                return $"Hace {diferencia.Hours} horas";
            }
            else
            {
                return $"Hace {diferencia.Days} días";
            }
        }
    }
}

   

