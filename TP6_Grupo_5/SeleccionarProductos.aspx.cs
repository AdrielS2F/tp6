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

        protected void GVProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVProductos.PageIndex = e.NewPageIndex;
            CargarGridView();
        }
    }
}