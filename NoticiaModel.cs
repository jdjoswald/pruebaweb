using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaWeb
{
    public class NoticiaModel
    {
       
            public string Titulo { get; set; }
            public string Resumen { get; set; }
            public string Tiempo { get; set; }

            public NoticiaModel(string titulo, string resumen, string tiempo)
            {
                Titulo = titulo;
                Resumen = resumen;
                Tiempo = tiempo;
            }
        
    }
}