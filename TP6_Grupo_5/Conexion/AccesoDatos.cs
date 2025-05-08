using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP6_Grupo_5.Conexion
{
    public class AccesoDatos
    {
        /// PROPIEDADES
        string rutaNeptuno = @"Data Source=localhost\sqlexpress; Initial Catalog=Neptuno; Integrated Security=True";

        /// METODO CONSTRUCTOR
        public AccesoDatos()
        {
            /// CONSTRUCTOR POR DEFECTO
        }

        /// METODOS
        public SqlConnection ObtenerConexion()
        {
            SqlConnection sqlConnection = new SqlConnection(rutaNeptuno);
            try
            {
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
        public SqlDataAdapter ObtenerAdaptador(string consultaSql)
        {
            SqlDataAdapter sqlDataAdapter;
            try
            {
                sqlDataAdapter = new SqlDataAdapter(consultaSql, ObtenerConexion());
                return sqlDataAdapter;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand comandoSQL, string nombreProcedimiento)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand = comandoSQL;
            sqlCommand.Connection = Conexion;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = nombreProcedimiento;
            FilasCambiadas = sqlCommand.ExecuteNonQuery();
            return FilasCambiadas;
        }
    }
}