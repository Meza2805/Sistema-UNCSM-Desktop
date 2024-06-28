using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{

    public class CRUD_GDocentes
    {
        Capa_Datos.Acceso conexion = new Capa_Datos.Acceso(); // se instancia un objeto de tipo acceso
        private SqlCommand Comando; // objeto de tipo SqlCommand para los comandos de SQL
        SqlDataAdapter Adaptador; // objeto de tipo SqlDataAdapter para convertir las tablas de SQL y guardarlas en una tabla

        public DataTable busqueda_docentes(String cedula,String inss,int id)
        {
            DataTable Tabla_Docentes = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "BUSQUEDA_DOCENTES_2024"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CEDULA", System.Data.SqlDbType.VarChar)).Value = cedula;
            Comando.Parameters.Add(new SqlParameter("@INSS", System.Data.SqlDbType.VarChar)).Value = inss;
            Comando.Parameters.Add(new SqlParameter("@TIPO_BUSQUEDA", System.Data.SqlDbType.Int)).Value = id;
            Comando.Connection = conexion.conexion_datos; // se abre la conexión para el comando
            Adaptador = new SqlDataAdapter(Comando); // se recibe la tabla producto de la ejecución del procedimiento
            Adaptador.Fill(Tabla_Docentes); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexión
            return Tabla_Docentes; // retorno de la tabla 
        }

        public DataTable Mostrar_Roles()
        {
            DataTable Tabla_roles = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "MOSTRAR_TIPO_ROL"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Connection = conexion.conexion_datos; // se abre la conexión para el comando
            Adaptador = new SqlDataAdapter(Comando); // se recibe la tabla producto de la ejecución del procedimiento
            Adaptador.Fill(Tabla_roles); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexión
            return Tabla_roles; // retorno de la tabla 
        }

        public DataTable Mostrar_Docentes_Grupo(string cedula)
        {
            DataTable Tabla_doc = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "SP_MOSTRAR_DOC_GRUPO"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CEDULA", System.Data.SqlDbType.VarChar)).Value = cedula;
            Comando.Connection = conexion.conexion_datos; // se abre la conexión para el comando
            Adaptador = new SqlDataAdapter(Comando); // se recibe la tabla producto de la ejecución del procedimiento
            Adaptador.Fill(Tabla_doc); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexión
            return Tabla_doc; // retorno de la tabla 
        }

        public int Actualizar_Docentes_Grupo(string cedulaV, string cedulaN, string Pnombre, string Snombre, string Papellido, string Sapellido)
        {
            int salida = 0; // Variable para almacenar el valor de salida del procedimiento almacenado

            try
            {
                conexion.conexion_datos.Open(); // Abrir la conexión a la base de datos
                Comando = new SqlCommand("SP_ACTUALIZANDO_DOCENTE_GRUPO", conexion.conexion_datos); // Crear el comando con el nombre del procedimiento almacenado
                Comando.CommandType = CommandType.StoredProcedure; // Especificar que es un procedimiento almacenado

                // Agregar los parámetros al comando
                Comando.Parameters.Add("@OLD_GOVERNMENT_ID", SqlDbType.VarChar).Value = cedulaV;
                Comando.Parameters.Add("@NEW_GOVERNMENT_ID", SqlDbType.VarChar).Value = cedulaN;
                Comando.Parameters.Add("@FIRST_NAME", SqlDbType.VarChar).Value = Pnombre;
                Comando.Parameters.Add("@MIDDLE_NAME", SqlDbType.VarChar).Value = Snombre;
                Comando.Parameters.Add("@LAST_NAME", SqlDbType.VarChar).Value = Papellido;
                Comando.Parameters.Add("@LAST_NAME02", SqlDbType.VarChar).Value = Sapellido;
                Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output; // Parámetro de salida

                Comando.ExecuteNonQuery(); // Ejecutar el procedimiento almacenado
                salida = Convert.ToInt32(Comando.Parameters["@salida"].Value); // Obtener el valor de salida del procedimiento almacenado
            }
            catch (Exception ex)
            {
                // Manejo de excepciones (puedes personalizarlo según tus necesidades)
                Console.WriteLine("Error al actualizar docente: " + ex.Message);
            }
            finally
            {
                // Cerrar la conexión a la base de datos
                conexion.conexion_datos.Close();
            }

            return salida; // Devolver el valor de salida del procedimiento almacenado
        }


        /*PROCEDIMIENTOS PARA EXAMENES EXTRAORDINARIOS */

        public DataTable Mostrar_Docentes_Extr(string cedula)
        {
            DataTable Tabla_roles = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "SP_BUSCAR_DOCENTE_EXTR"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CEDULA", System.Data.SqlDbType.VarChar)).Value = cedula;
            Comando.Connection = conexion.conexion_datos; // se abre la conexión para el comando
            Adaptador = new SqlDataAdapter(Comando); // se recibe la tabla producto de la ejecución del procedimiento
            Adaptador.Fill(Tabla_roles); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexión
            return Tabla_roles; // retorno de la tabla 
        }

    }

}