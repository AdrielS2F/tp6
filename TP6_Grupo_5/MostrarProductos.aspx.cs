using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_Grupo_5.Conexion;
using System.Data;

namespace TP6_Grupo_5
{
    public partial class MostrarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductosSeleccionados();
            }
        }

        private void CargarProductosSeleccionados()
        {
            if (Session["dtSeleccionados"] != null)
            {
                DataTable dtSeleccionados = (DataTable)Session["dtSeleccionados"];
                gvMostrarSeleccionados.DataSource = dtSeleccionados;
                gvMostrarSeleccionados.DataBind();
            }
        }

        protected void gvMostrarSeleccionados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMostrarSeleccionados.PageIndex = e.NewPageIndex;
            CargarProductosSeleccionados();
        }
    }
}