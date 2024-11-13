using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlantillaExamen.Controller;
using PlantillaExamen.Models.DSTiendaTableAdapters;

namespace PlantillaExamen.Views
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarProductos();
            if (Session["NombreUsuario"] != null && Session["NombreUsuario"].ToString() == "mlagunas")
            {
                lblUsername.Text = Session["NombreUsuario"].ToString();
            }
            else
            {
                string script = "<script type='text/javascript'>alert('Inicia sesión antes, por favor.'); window.location.href='Loggin.aspx';</script>";
                Response.Write(script);
                Response.End(); // Finaliza el procesamiento de la página

            }
        }
        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int cantidad;
            decimal precio;
            string imagenUrl = null;

            // Validar que los campos cantidad y costo sean valores numéricos.
            if (!int.TryParse(txtCantidad.Text, out cantidad))
            {
                Response.Write("<script>alert('Por favor ingrese una cantidad válida.');</script>");
                return;
            }

            if (!decimal.TryParse(txtCosto.Text, out precio))
            {
                Response.Write("<script>alert('Por favor ingrese un costo válido.');</script>");
                return;
            }

            // Validar si se ha seleccionado un archivo de imagen y guardarlo.
            if (fileImagen.HasFile)
            {
                string fileName = Path.GetFileName(fileImagen.PostedFile.FileName);
                string filePath = Server.MapPath("~/Images/") + fileName;

                try
                {
                    fileImagen.SaveAs(filePath);
                    imagenUrl = "~/Images/" + fileName; // Ruta para guardar en la base de datos
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error al subir la imagen: " + ex.Message + "');</script>");
                    return;
                }
            }

            // Instanciar el controlador
            ControllerVideoJuegos controller = new ControllerVideoJuegos();

            try
            {
                bool result = controller.AgregarVideoJuego(nombre, cantidad, (double)precio, imagenUrl);

                if (result)
                {
                    Response.Write("<script>alert('Producto agregado exitosamente.');</script>");
                    CargarProductos(); // Recargar los productos después de agregar uno nuevo
                }
                else
                {
                    Response.Write("<script>alert('Hubo un error al agregar el producto.');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }


        // Método para cargar los productos en el GridView
        private void CargarProductos()
        {
            ControllerVideoJuegos controller = new ControllerVideoJuegos();
            var productos = controller.ObtenerCatalogo();
            gvProductos.DataSource = productos;
            gvProductos.DataBind();
        }

    }
}