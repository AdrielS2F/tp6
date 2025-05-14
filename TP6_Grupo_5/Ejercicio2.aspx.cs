using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP6_Grupo_5
{
    public partial class Ejercicio2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbEliminarSeleccionados_Click(object sender, EventArgs e)
        {
            // Elimina los productos seleccionados almacenados en la variable Session
            Session.Remove("dtSeleccionados");

            // Mensaje opcional
         Response.Write("<script>alert('Productos eliminados de la sesión');</script>");
        }
    }
}