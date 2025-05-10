using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TP6_Grupo_5.Conexion
{
    public class GestionProductos
    {
        /// PROPIEDADES

        /// CONSTRUCTORES
        public GestionProductos()
        {
            /// CONSTRUCTOR POR DEFECTO
        }

        /// METODOS
        private DataTable ObtenerTabla(string nombreTabla, string consultaSQL)
        {
            DataSet dataSet = new DataSet();
            AccesoDatos datos = new AccesoDatos();
            SqlDataAdapter sqlDataAdapter = datos.ObtenerAdaptador(consultaSQL);
            sqlDataAdapter.Fill(dataSet, nombreTabla);
            return dataSet.Tables[nombreTabla];
        }

        public DataTable ObtenerTodosLosProductos()
        {
            return ObtenerTabla("Productos", "SELECT IdProducto, NombreProducto, CantidadPorUnidad, PrecioUnidad FROM Productos");
        }

        private void ArmarParametrosProductosEliminar(ref SqlCommand Comando, Producto producto)
        {
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter = Comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            sqlParameter.Value = producto.idProducto;
        }

        public bool EliminarProducto(Producto producto)
        {
            SqlCommand sqlCommand = new SqlCommand();
            ArmarParametrosProductosEliminar(ref sqlCommand, producto);
            AccesoDatos accesoDatos = new AccesoDatos();
            int FilasInsertadas = accesoDatos.EjecutarProcedimientoAlmacenado(sqlCommand, "SpEliminarProducto");
            if (FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ActualizarProducto(string consultaSQL)
        {
            // Establecemos la conexion a la base de datos en SQL Server
            AccesoDatos accesoDatos = new AccesoDatos();
            SqlConnection connection = accesoDatos.ObtenerConexion();

            // Realizamos la consulta
            SqlCommand sqlCommand = new SqlCommand(consultaSQL, connection);
            int filasAfectadas = sqlCommand.ExecuteNonQuery();

            // Cerramos la conexion
            connection.Close();

            if (filasAfectadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}