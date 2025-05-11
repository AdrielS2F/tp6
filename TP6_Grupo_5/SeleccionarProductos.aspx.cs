using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_Grupo_5.Conexion;

namespace TP6_Grupo_5
{
    public partial class SeleccionarProductos : System.Web.UI.Page
    {
        // PROPIEDADES
        string consultaSQL = "SELECT IdProducto, NombreProducto, IdProveedor, PrecioUnidad FROM Productos";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                CargarGridView();
            }
        }

        // CARGAR GRIDVIEW
        private void CargarGridView()
        {
            GestionProductos gestionProductos = new GestionProductos();
            GVProductos.DataSource = gestionProductos.ObtenerTodosLosProductos(consultaSQL);
            GVProductos.DataBind();
        }

        // PAGINACION EN EL GRIDVIEW
        protected void GVProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVProductos.PageIndex = e.NewPageIndex;
            CargarGridView();
        }

        // FUNCION DE SELEECIONAR EN EL GRIDVIEW
        protected void GVProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            // Declaramos como string el nombre del producto para luego que se pueda encontrar y tomar el valor que esta en el gridview
            string nombreProducto = ((Label)GVProductos.Rows[e.NewSelectedIndex].FindControl("Lbl_it_nombreProducto")).Text;

            // Mostramos que selecciono el usuario mediante un label
            LblProductoSeleccionado.Text = "Productos agregados: " + nombreProducto;
        }
    }
}