<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="pruebaWeb.About" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <label for="cantidadNoticias">Cantidad de Noticias a Mostrar:</label>
        <input type="number" id="cantidadNoticias" name="cantidadNoticias" min="10" value="10" />
        <button type="button" id="btnMostrarNoticias">Mostrar Noticias</button>
    </div>
    <div>
        <label for="tiempoRefresco">Tiempo de Refresco:</label>
        <select id="tiempoRefresco">
            <option value="10000" selected>10 segundos</option>
            <option value="30000">30 segundos</option>
            <option value="60000">1 minuto</option>
            <option value="300000">5 minutos</option>
            <option value="600000">10 minutos</option>
        </select>
        <button type="button" id="btnActualizar">Actualizar Noticias</button>
    </div>


    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            var btnMostrarNoticias = document.getElementById("btnMostrarNoticias");
            var inputCantidadNoticias = document.getElementById("cantidadNoticias");

            btnMostrarNoticias.addEventListener("click", function () {
                var cantidad = inputCantidadNoticias.value;
                console.log(cantidad)
                if (cantidad > 0) {

                    
                    window.location.href = "About.aspx?cantidad=" + cantidad;
                }
            });
        });

        document.addEventListener("DOMContentLoaded", function () {
            var btnTiempoRefresco = document.getElementById("btnActualizar");
            var selectTiempoRefresco = document.getElementById("tiempoRefresco");
            
            btnTiempoRefresco.addEventListener("click", function () {
                var cantidad = parseInt(selectTiempoRefresco.value);

                console.log(cantidad)
                
                if (cantidad > 0) {
                    
                    window.location.href = "About.aspx?refresco=" + cantidad;
                }
            });
        });
    </script>

    

</asp:Content>
