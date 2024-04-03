using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CRUD_GCARRERA
    {

        Capa_Datos.Acceso conexion = new Capa_Datos.Acceso(); // se instancia un objeto de tipo acceso
        private SqlCommand Comando; // objeto de tipo SqlCommand para los comandos de SQL
        SqlDataAdapter Adaptador; // objeto de tipo SqlDataAdapter para convertir las tablas de SQL y guardarlas en una tabla


        public DataTable Busqueda_Grupos_Carrera( String grupo, int Id)
        {
            DataTable Tabla_Grupos = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "GRUPOS_TURNO_2024"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@grupo", System.Data.SqlDbType.VarChar)).Value = grupo;
            Comando.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.VarChar)).Value = Id;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_Grupos); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_Grupos; // retorno de la tabla 
        }
    }
}
