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

        public DataTable ObtenerTodosLosLibros()
        {
            return ObtenerTabla("Productos", "SELECT IdProducto, NombreProducto, CantidadPorUnidad, PrecioUnidad FROM Productos");
        }

        private void ArmarParametrosLibrosEliminar(ref SqlCommand Comando, Libro libro)
        {
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter = Comando.Parameters.Add("@IdLibro", SqlDbType.Int);
            sqlParameter.Value = libro.IdLibro;
        }

        public bool EliminarLibro(Libro libro)
        {
            SqlCommand sqlCommand = new SqlCommand();
            ArmarParametrosLibrosEliminar(ref sqlCommand, libro);
            AccesoDatos accesoDatos = new AccesoDatos();
            int FilasInsertadas = accesoDatos.EjecutarProcedimientoAlmacenado(sqlCommand, "spEliminarLibro");
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