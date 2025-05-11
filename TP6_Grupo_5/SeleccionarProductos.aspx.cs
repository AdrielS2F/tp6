using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_Grupo_5.Conexion;
using System.Data;
using System.Data.SqlClient;

namespace TP6_Grupo_5
{
    public partial class SeleccionarProductos : System.Web.UI.Page
    {
        // PROPIEDADES
        string consultaSQL = "SELECT IdProducto, NombreProducto, IdProveedor, PrecioUnidad FROM Productos";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

        protected void GVProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GVProductos.SelectedRow != null)
            {
                string idProducto = GVProductos.SelectedRow.Cells[1].Text;
                string nombreProducto = GVProductos.SelectedRow.Cells[2].Text;
                string CantidaPorUnidad = GVProductos.SelectedRow.Cells[3].Text;
                string precioUnidad = GVProductos.SelectedRow.Cells[4].Text;

                DataTable dtSeleccionados = (DataTable)Session["dtSeleccionados"];

                if (dtSeleccionados == null)
                {
                    dtSeleccionados = new DataTable();
                    dtSeleccionados.Columns.Add("idProducto");
                    dtSeleccionados.Columns.Add("nombreProducto");
                    dtSeleccionados.Columns.Add("cantidadPorUnidad");
                    dtSeleccionados.Columns.Add("precioUnidad");
                }

                if (!yaExisteSeleccionados(idProducto, dtSeleccionados))
                {
                    DataRow nuevaFila = dtSeleccionados.NewRow();
                    nuevaFila["idProducto"] = idProducto;
                    nuevaFila["nombreProducto"] = nombreProducto;
                    nuevaFila["cantidadPorUnidad"] = CantidaPorUnidad;
                    nuevaFila["precioUnidad"] = precioUnidad;

                    dtSeleccionados.Rows.Add(nuevaFila);
                    Session["dtSeleccionados"] = dtSeleccionados;
                }
            }
        }

        private bool yaExisteSeleccionados(string idProducto, DataTable dtSeleccionados)
        {
            if (dtSeleccionados == null) return false;

            foreach (DataRow row in dtSeleccionados.Rows)
            {
                if (row["idProducto"].ToString() == idProducto) return true;
            }
            return false;
        }
    }
}