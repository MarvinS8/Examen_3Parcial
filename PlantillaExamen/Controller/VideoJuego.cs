using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlantillaExamen.Controller
{
    public class VideoJuego
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        //Cambiar Original Precio a Costo
        public double Precio { get; set; }
        public string ImagenUrl { get; set; }
    }
}