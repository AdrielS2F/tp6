using System;
using System.Collections.Generic;
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
            gvProductos.DataSource = gestionProductos.ObtenerTodosLosLibros(); /// DATA TABLE
            gvProductos.DataBind();
        }
        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idLibro = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_it_IdProducto")).Text;
            Libro libro = new Libro(Convert.ToInt32(idLibro));
            GestionProductos gestionProductos = new GestionProductos();
            gestionProductos.EliminarLibro(libro);

            CargarGridView();
        }
    }
}