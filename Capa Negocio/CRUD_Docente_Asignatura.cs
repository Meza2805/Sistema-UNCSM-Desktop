using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
 

   public class CRUD_Docente_Asignatura
    {
        Capa_Datos.Acceso conexion = new Capa_Datos.Acceso(); // se instancia un objeto de tipo acceso
        private SqlCommand Comando; // objeto de tipo SqlCommand para los comandos de SQL
        SqlDataAdapter Adaptador; // objeto de tipo SqlDataAdapter para convertir las tablas de SQL y guardarlas en una tabla


    public DataTable Busqueda_Docentes_Asignatura(String cedula,int Id)
    {
        DataTable Tabla_Doc_Asig = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
        conexion.conexion_datos.Open(); // se abre la conexión para el comando
        Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
        Comando.CommandText = "LISTA_DOCENTES_ASIGNATURAS"; // se pasa el procedimiento almacenado
        Comando.CommandType = System.Data.CommandType.StoredProcedure;
        Comando.Parameters.Add(new SqlParameter("@cedula", System.Data.SqlDbType.VarChar)).Value = cedula;
            Comando.Parameters.Add(new SqlParameter("@id_asig", System.Data.SqlDbType.VarChar)).Value = Id;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
        Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
        Adaptador.Fill(Tabla_Doc_Asig); // con el SqlDataAdapter se llena la tabla
        conexion.conexion_datos.Close(); // se cierra la conexion
        return Tabla_Doc_Asig; // retorno de la tabla 
    }

        public DataTable Busqueda_Lista_Alumnos(String grupo,String cod_asig)
        {
            DataTable Tabla_list_asig = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "MOSTRAR_MATRICULA_ASIGNATURA"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@Grupo", System.Data.SqlDbType.VarChar)).Value = grupo;
            Comando.Parameters.Add(new SqlParameter("@cod_asig", System.Data.SqlDbType.VarChar)).Value = cod_asig;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_list_asig); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_list_asig; // retorno de la tabla 
        }

        public DataTable Actualiza_Notas_Alumnos(String people_id, String cod_asig, String nota_final)
        {
            DataTable Tabla_nota_asig = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "ACTUALIZANDO_NOTAS_2024"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@people_id", System.Data.SqlDbType.VarChar)).Value = people_id;
            Comando.Parameters.Add(new SqlParameter("@cod_asig", System.Data.SqlDbType.VarChar)).Value = cod_asig;
            Comando.Parameters.Add(new SqlParameter("@NotaFinal", System.Data.SqlDbType.VarChar)).Value = nota_final;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_nota_asig); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_nota_asig; // retorno de la tabla 
        }
    }
}