using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_Grupo_5.Conexion;

namespace TP6_Grupo_5
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
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
            gvProductos.DataSource = gestionProductos.ObtenerTodosLosProductos(); /// DATA TABLE
            gvProductos.DataBind();
        }
        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idProducto = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_it_IdProducto")).Text;
            Producto producto = new Producto(Convert.ToInt32(idProducto));
            GestionProductos gestionProductos = new GestionProductos();
            gestionProductos.EliminarProducto(producto);

            CargarGridView();
        }
        // ELIMINAR FILA
        protected void gvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProductos.EditIndex = e.NewEditIndex;
            CargarGridView();
        }

        protected void gvProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProductos.EditIndex = -1;
            CargarGridView();
        }
        // ACTUALIZAR FILA
        protected void gvProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // BUSCAR FILA DENTRO DEL EDIT ITEM TEMPLATE
            string idProducto = ((Label)gvProductos.Rows[e.RowIndex].FindControl("Lbl_eit_idProducto")).Text;
            string nombreProducto = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("Txt_eit_nombreProducto")).Text;
            string cantidadPorUnidad = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("Txt_eit_cantidadPorUnidad")).Text;
            string precioUnitario = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("Txt_eit_precioUnidad")).Text;

            // CAMBIAR EL PRECIO CAMBIANDO LA COMA POR PUNTO
            string precioUnitarioFormateado = precioUnitario.Replace(',', '.');

            // ARMAR CONSULTA SQL CORREGIDA
            string consultaSQLUpdate = "UPDATE Productos SET NombreProducto = '" + nombreProducto +
                                       "', CantidadPorUnidad = '" + cantidadPorUnidad +
                                       "', PrecioUnidad = " + precioUnitarioFormateado +
                                       " WHERE IdProducto = " + idProducto;

            // EJECUTAR CONSULTA
            GestionProductos gestionProductos = new GestionProductos();
            gestionProductos.ActualizarProducto(consultaSQLUpdate);

            gvProductos.EditIndex = -1;
            CargarGridView();
        }

        // PAGINACION
        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            CargarGridView();
        }
    }
}