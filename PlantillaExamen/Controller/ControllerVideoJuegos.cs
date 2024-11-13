using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using PlantillaExamen.Models.DSTiendaTableAdapters;

namespace PlantillaExamen.Controller
{
    public class ControllerVideoJuegos
    {
        public bool AgregarVideoJuego(string nombre,int cantidad,double precio, string img)
        {
            try
            {
                using(videojuegosTableAdapter videojuegos= new videojuegosTableAdapter())
                {
                    videojuegos.InsertQuery(nombre, cantidad, Convert.ToDecimal(precio), img);
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<VideoJuego> ObtenerCatalogo()
        {
            try
            {
                //Cambiar Table Adapter a la del Prof
                using (videojuegosTableAdapter videojuegos = new videojuegosTableAdapter())
                {
                    var dt = videojuegos.GetData();
                    if (dt.Rows.Count>0)
                    {
                        List<VideoJuego> lista = new List<VideoJuego>();
                        foreach (DataRow row in dt.Rows)
                        {
                            VideoJuego v = new VideoJuego
                            {
                                Id = Convert.ToInt32(row["id"]),
                                Nombre = row["Nombre"].ToString(),
                                Cantidad = Convert.ToInt32(row["Cantidad"]),
                                //Cambiar de Costo a Precio
                                Precio = Convert.ToDouble(row["precio"]),
                                ImagenUrl = row["Imagen"].ToString()

                            };
                            lista.Add(v);
                        }
                        return lista;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception ("Error al obtener el catalogo de videojuegos", ex);
            }
        }
    }
}