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


    public DataTable Busqueda_Docentes_Asignatura(String cedula)
    {
        DataTable Tabla_Doc_Asig = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
        conexion.conexion_datos.Open(); // se abre la conexión para el comando
        Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
        Comando.CommandText = "LISTA_DOCENTES_ASIGNATURAS"; // se pasa el procedimiento almacenado
        Comando.CommandType = System.Data.CommandType.StoredProcedure;
        Comando.Parameters.Add(new SqlParameter("@cedula", System.Data.SqlDbType.VarChar)).Value = cedula;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
        Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
        Adaptador.Fill(Tabla_Doc_Asig); // con el SqlDataAdapter se llena la tabla
        conexion.conexion_datos.Close(); // se cierra la conexion
        return Tabla_Doc_Asig; // retorno de la tabla 
    }

        public DataTable Busqueda_Docentes_Reingreso(String cedula, int Id)
        {
            DataTable Tabla_Doc_Asig = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "LISTA_DOCENTESASIG_REINGRESO"; // se pasa el procedimiento almacenado
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
            Comando.CommandText = "MOSTRAR_MATRICULA_ASIGNATURA_NINGRESO"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@Grupo", System.Data.SqlDbType.VarChar)).Value = grupo;
            Comando.Parameters.Add(new SqlParameter("@cod_asig", System.Data.SqlDbType.VarChar)).Value = cod_asig;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_list_asig); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_list_asig; // retorno de la tabla 
        }

        public DataTable Busqueda_Lista_Alumnos_Reingreso(String cod_asig, String section, String carrera)
        {
            DataTable Tabla_list_asig = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "MOSTRAR_ASIGNATURAS_REINGRESO"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@cod_asig", System.Data.SqlDbType.VarChar)).Value = cod_asig;
            Comando.Parameters.Add(new SqlParameter("@section", System.Data.SqlDbType.VarChar)).Value = section;
            Comando.Parameters.Add(new SqlParameter("@cod_carrera", System.Data.SqlDbType.VarChar)).Value = carrera;

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

        public DataTable Ingresando_control_NotasNingreso(String people_id, String estudiante, string grupo, string turno, string area, string carrera, string año,
            string semestre, string cod_Asig, string asignatura, string acumulado, string parcial, string nota_final,string nota_especial,string ced_docente, 
            string docente, string usuario)
        {
            DataTable Tabla_nota_ningreso = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "SP_INGRESANDO_NOTAS_NINGRESO"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.VarChar)).Value = people_id;
            Comando.Parameters.Add(new SqlParameter("@ESTUDIANTE", System.Data.SqlDbType.VarChar)).Value = estudiante;
            Comando.Parameters.Add(new SqlParameter("@GRUPO", System.Data.SqlDbType.VarChar)).Value = grupo;
            Comando.Parameters.Add(new SqlParameter("@TURNO", System.Data.SqlDbType.VarChar)).Value = turno;
            Comando.Parameters.Add(new SqlParameter("@AREA", System.Data.SqlDbType.VarChar)).Value = area;
            Comando.Parameters.Add(new SqlParameter("@CARRERA", System.Data.SqlDbType.VarChar)).Value = carrera;
            Comando.Parameters.Add(new SqlParameter("@AÑO", System.Data.SqlDbType.VarChar)).Value = año;
            Comando.Parameters.Add(new SqlParameter("@SEMESTRE", System.Data.SqlDbType.VarChar)).Value = semestre;
            Comando.Parameters.Add(new SqlParameter("@CODIGO_ASIGNATURA", System.Data.SqlDbType.VarChar)).Value = cod_Asig;
            Comando.Parameters.Add(new SqlParameter("@ASIGNATURA", System.Data.SqlDbType.VarChar)).Value = asignatura;
            Comando.Parameters.Add(new SqlParameter("@ACUMULADO", System.Data.SqlDbType.VarChar)).Value = acumulado;
            Comando.Parameters.Add(new SqlParameter("@PARCIAL", System.Data.SqlDbType.VarChar)).Value = parcial;
            Comando.Parameters.Add(new SqlParameter("@NOTA_FINAL", System.Data.SqlDbType.VarChar)).Value = nota_final;
            Comando.Parameters.Add(new SqlParameter("@NOTA_ESPECIAL", System.Data.SqlDbType.VarChar)).Value = nota_especial;
            Comando.Parameters.Add(new SqlParameter("@CED_DOCENTE", System.Data.SqlDbType.VarChar)).Value = ced_docente;
            Comando.Parameters.Add(new SqlParameter("@DOCENTE", System.Data.SqlDbType.VarChar)).Value = docente;
            Comando.Parameters.Add(new SqlParameter("@USUARIO", System.Data.SqlDbType.VarChar)).Value = usuario;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_nota_ningreso); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_nota_ningreso; // retorno de la tabla 
        }
        public DataTable Actualiza_Notas_Reingreso(String people_id, String cod_asig, String nota_final,string año, string section)
        {
            DataTable Tabla_nota_reing = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "INGRESANDO_NOTAS_REINGRESO"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@people_id", System.Data.SqlDbType.VarChar)).Value = people_id;
            Comando.Parameters.Add(new SqlParameter("@cod_asig", System.Data.SqlDbType.VarChar)).Value = cod_asig;
            Comando.Parameters.Add(new SqlParameter("@NotaFinal", System.Data.SqlDbType.VarChar)).Value = nota_final;
            Comando.Parameters.Add(new SqlParameter("@año", System.Data.SqlDbType.VarChar)).Value = año;
            Comando.Parameters.Add(new SqlParameter("@section", System.Data.SqlDbType.VarChar)).Value = section;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_nota_reing); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_nota_reing; // retorno de la tabla 
        }


        public DataTable Actualiza_Notas_Especial(String people_id, String cod_asig, String nota_final, string nota_especial, string año, string section)
        {
            DataTable Tabla_nota_reing = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "INGRESANDO_NOTAS_ESPECIAL"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@people_id", System.Data.SqlDbType.VarChar)).Value = people_id;
            Comando.Parameters.Add(new SqlParameter("@cod_asig", System.Data.SqlDbType.VarChar)).Value = cod_asig;
            Comando.Parameters.Add(new SqlParameter("@NotaFinal", System.Data.SqlDbType.VarChar)).Value = nota_final;
            Comando.Parameters.Add(new SqlParameter("@NotaEspecial", System.Data.SqlDbType.VarChar)).Value = nota_especial;
            Comando.Parameters.Add(new SqlParameter("@año", System.Data.SqlDbType.VarChar)).Value = año;
            Comando.Parameters.Add(new SqlParameter("@section", System.Data.SqlDbType.VarChar)).Value = section;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_nota_reing); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_nota_reing; // retorno de la tabla 
        }

        public DataTable Actualiza_Especial_Ningeso(String people_id, String cod_asig, String nota_final, string nota_especial)
        {
            DataTable Tabla_nota_Ningreso= new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "INGRESANDO_NOTAS_ESPECIAL_NINGRESO"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.VarChar)).Value = people_id;
            Comando.Parameters.Add(new SqlParameter("@COD_ASIG", System.Data.SqlDbType.VarChar)).Value = cod_asig;
            Comando.Parameters.Add(new SqlParameter("@NOTA_FINAL", System.Data.SqlDbType.VarChar)).Value = nota_final;
            Comando.Parameters.Add(new SqlParameter("@NOTA_ESPECIAL", System.Data.SqlDbType.VarChar)).Value = nota_especial;

            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_nota_Ningreso); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_nota_Ningreso; // retorno de la tabla 
        }
        //public DataTable Actualiza_tabla_especial(String people_id, String cod_asig, String nota_final, string nota_especial, string section)
        //{
        //    DataTable Tabla_nota_reing = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
        //    conexion.conexion_datos.Open(); // se abre la conexión para el comando
        //    Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
        //    Comando.CommandText = "ACTUALIZANDO_TABLA_NESPECIAL"; // se pasa el procedimiento almacenado
        //    Comando.CommandType = System.Data.CommandType.StoredProcedure;
        //    Comando.Parameters.Add(new SqlParameter("@people_id", System.Data.SqlDbType.VarChar)).Value = people_id;
        //    Comando.Parameters.Add(new SqlParameter("@cod_asig", System.Data.SqlDbType.VarChar)).Value = cod_asig;
        //    Comando.Parameters.Add(new SqlParameter("@NotaFinal", System.Data.SqlDbType.VarChar)).Value = nota_final;
        //    Comando.Parameters.Add(new SqlParameter("@NotaEspecial", System.Data.SqlDbType.VarChar)).Value = nota_especial;
        //    Comando.Parameters.Add(new SqlParameter("@section", System.Data.SqlDbType.VarChar)).Value = section;
        //    Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
        //    Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
        //    Adaptador.Fill(Tabla_nota_reing); // con el SqlDataAdapter se llena la tabla
        //    conexion.conexion_datos.Close(); // se cierra la conexion
        //    return Tabla_nota_reing; // retorno de la tabla 
        //}

        public DataTable Actualiza_tabla_Stdegreqevent(String people_id, String cod_asig, string año, string aca_term,string seccion, string evento, string subtype, string section)
        {
            DataTable Tabla_nota_reing = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "SP_ACTUALIZANDO_STDDEGREQEVENT"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE_ID", System.Data.SqlDbType.VarChar)).Value = people_id;
            Comando.Parameters.Add(new SqlParameter("@EVENT_ID", System.Data.SqlDbType.VarChar)).Value = cod_asig;
            Comando.Parameters.Add(new SqlParameter("@AÑO", System.Data.SqlDbType.VarChar)).Value = año;
            Comando.Parameters.Add(new SqlParameter("@ACA_TERM ", System.Data.SqlDbType.VarChar)).Value = aca_term;
            Comando.Parameters.Add(new SqlParameter("@SECCION", System.Data.SqlDbType.VarChar)).Value = seccion;
            Comando.Parameters.Add(new SqlParameter("@EVENTO", System.Data.SqlDbType.VarChar)).Value = evento;
            Comando.Parameters.Add(new SqlParameter("@SUBTYPE", System.Data.SqlDbType.VarChar)).Value = subtype;
            Comando.Parameters.Add(new SqlParameter("@SECTION", System.Data.SqlDbType.VarChar)).Value = section;

            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_nota_reing); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_nota_reing; // retorno de la tabla 
        }

        public DataTable Actualiza_tabla_Stdegreqevent_Ningreso(String people_id, String cod_asig, string año, string aca_term, string seccion, string evento, string subtype, string section, string asignatura, String status)
        {
            DataTable Tabla_nota_reing = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "SP_STDDEGREQEVENT_NINGRESO"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE_ID", System.Data.SqlDbType.VarChar)).Value = people_id;
            Comando.Parameters.Add(new SqlParameter("@EVENT_ID", System.Data.SqlDbType.VarChar)).Value = cod_asig;
            Comando.Parameters.Add(new SqlParameter("@AÑO", System.Data.SqlDbType.VarChar)).Value = año;
            Comando.Parameters.Add(new SqlParameter("@ACA_TERM ", System.Data.SqlDbType.VarChar)).Value = aca_term;
            Comando.Parameters.Add(new SqlParameter("@SECCION", System.Data.SqlDbType.VarChar)).Value = seccion;
            Comando.Parameters.Add(new SqlParameter("@EVENTO", System.Data.SqlDbType.VarChar)).Value = evento;
            Comando.Parameters.Add(new SqlParameter("@SUBTYPE", System.Data.SqlDbType.VarChar)).Value = subtype;
            Comando.Parameters.Add(new SqlParameter("@SECTION", System.Data.SqlDbType.VarChar)).Value = section;
            Comando.Parameters.Add(new SqlParameter("@ASIGNATURA", System.Data.SqlDbType.VarChar)).Value = asignatura;
            Comando.Parameters.Add(new SqlParameter("@STATUS", System.Data.SqlDbType.VarChar)).Value = status;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_nota_reing); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_nota_reing; // retorno de la tabla 
        }
        public DataTable Actualiza_Stdegreqevent_Ningreso(String people_id, String cod_asig, string año, string aca_term, string seccion, string evento, string subtype, string section, string estado, string asignatura)
        {
            DataTable Tabla_nota_reing = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "SP__STDDEGREQEVENT_NINGRESO"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE_ID", System.Data.SqlDbType.VarChar)).Value = people_id;
            Comando.Parameters.Add(new SqlParameter("@EVENT_ID", System.Data.SqlDbType.VarChar)).Value = cod_asig;
            Comando.Parameters.Add(new SqlParameter("@AÑO", System.Data.SqlDbType.VarChar)).Value = año;
            Comando.Parameters.Add(new SqlParameter("@ACA_TERM ", System.Data.SqlDbType.VarChar)).Value = aca_term;
            Comando.Parameters.Add(new SqlParameter("@SECCION", System.Data.SqlDbType.VarChar)).Value = seccion;
            Comando.Parameters.Add(new SqlParameter("@EVENTO", System.Data.SqlDbType.VarChar)).Value = evento;
            Comando.Parameters.Add(new SqlParameter("@SUBTYPE", System.Data.SqlDbType.VarChar)).Value = subtype;
            Comando.Parameters.Add(new SqlParameter("@SECTION", System.Data.SqlDbType.VarChar)).Value = section;
            Comando.Parameters.Add(new SqlParameter("@ESTADO", System.Data.SqlDbType.VarChar)).Value = estado;
            Comando.Parameters.Add(new SqlParameter("@ASIGNATURA", System.Data.SqlDbType.VarChar)).Value = asignatura;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_nota_reing); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_nota_reing; // retorno de la tabla 
        }

        public DataTable tabla_auditoria_Ningresos(String cedula, String docente, String grupo, string turno, string area, string carrera, string asignatura, string usuario)
        {
            DataTable Tabla_nota_asig = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "SP_AUDITORIA_NINGRESO"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CEDULA", System.Data.SqlDbType.VarChar)).Value = cedula;
            Comando.Parameters.Add(new SqlParameter("@DOCENTE", System.Data.SqlDbType.VarChar)).Value = docente;
            Comando.Parameters.Add(new SqlParameter("@GRUPO", System.Data.SqlDbType.VarChar)).Value = grupo;
            Comando.Parameters.Add(new SqlParameter("@TURNO", System.Data.SqlDbType.VarChar)).Value = turno;
            Comando.Parameters.Add(new SqlParameter("@AREA", System.Data.SqlDbType.VarChar)).Value = area;
            Comando.Parameters.Add(new SqlParameter("@CARRERA", System.Data.SqlDbType.VarChar)).Value = carrera;
            Comando.Parameters.Add(new SqlParameter("@ASIGNATURA", System.Data.SqlDbType.VarChar)).Value = asignatura;
            Comando.Parameters.Add(new SqlParameter("@USUARIO", System.Data.SqlDbType.VarChar)).Value = usuario;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_nota_asig); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_nota_asig; // retorno de la tabla 
        }

        public int Insertar_notas_Reingreso(String PEOPLE_ID, string ESTUDIANTE, String CODIGO, string SECTION, string ACUM, string PARC, string NOTA_F,String NOTA_E, String DOCENTE, string USER)
        {
            int salida = 0;
            DataTable Tabla_Estudiante = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_INSERTANDO_NOTAS_REINGRESO"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;

            Comando.Parameters.Add(new SqlParameter("@PEOPLE_ID", System.Data.SqlDbType.VarChar)).Value = PEOPLE_ID;
            Comando.Parameters.Add(new SqlParameter("@ESTUDIANTE", System.Data.SqlDbType.VarChar)).Value = ESTUDIANTE;
            Comando.Parameters.Add(new SqlParameter("@CODIGO_ASIGNATURA", System.Data.SqlDbType.VarChar)).Value = CODIGO;
            Comando.Parameters.Add(new SqlParameter("@SECTION", System.Data.SqlDbType.VarChar)).Value = SECTION;
            Comando.Parameters.Add(new SqlParameter("@ACUMULADO", System.Data.SqlDbType.VarChar)).Value = ACUM;
            Comando.Parameters.Add(new SqlParameter("@PARCIAL", System.Data.SqlDbType.VarChar)).Value = PARC;
            Comando.Parameters.Add(new SqlParameter("@NOTA_FINAL", System.Data.SqlDbType.VarChar)).Value = NOTA_F;
            Comando.Parameters.Add(new SqlParameter("@NOTA_ESPECIAL", System.Data.SqlDbType.VarChar)).Value = NOTA_E;
            Comando.Parameters.Add(new SqlParameter("@DOCENTE", System.Data.SqlDbType.VarChar)).Value = DOCENTE;
            Comando.Parameters.Add(new SqlParameter("@USUARIO", System.Data.SqlDbType.VarChar)).Value = USER;
            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@salida"].Value);

            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Estudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Estudiante; // retorno de la tabla 
            return salida;
        }


        public DataTable Busqueda_Datos_NIngresos(String carnet)
        {
            DataTable Tabla_Doc_Asig = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "SP_DATOS_NUEVOSINGRESOS"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CARNET", System.Data.SqlDbType.VarChar)).Value = carnet;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_Doc_Asig); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_Doc_Asig; // retorno de la tabla 
        }


        public DataTable Insertar_docente_otrasNotas(String cedula, string docente,string grupo)
        {
            DataTable Tabla_Doc_Asig = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "INSERTANDO_DOC_OTRASNOTAS"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CEDULA", System.Data.SqlDbType.VarChar)).Value = cedula;
            Comando.Parameters.Add(new SqlParameter("@DOCENTE", System.Data.SqlDbType.VarChar)).Value = docente;
            Comando.Parameters.Add(new SqlParameter("@GRUPO", System.Data.SqlDbType.VarChar)).Value = grupo;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_Doc_Asig); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_Doc_Asig; // retorno de la tabla 
        }

        public int Insertando_Exa_extraordinario(string people_id,string estudiante, string año, string cod_asig, string docente, string area, string carrera, string plan, string curriculum, string college, string observacion,  string departament,string eventype,string nota, string nletra,string asignatura, DateTime fecha,string user,string modalidad)
        {
            int salida = 0;
            conexion.conexion_datos.Open();
            Comando = new SqlCommand();
            Comando.CommandText = "SP_INGRESANDO_EXTRAORDINARIOS";
            Comando.CommandType = System.Data.CommandType.StoredProcedure;

            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.VarChar)).Value = people_id;
            Comando.Parameters.Add(new SqlParameter("@ESTUDIANTE", System.Data.SqlDbType.VarChar)).Value = estudiante;
            Comando.Parameters.Add(new SqlParameter("@AÑO", System.Data.SqlDbType.VarChar)).Value = año;
            Comando.Parameters.Add(new SqlParameter("@COD_ASIG", System.Data.SqlDbType.VarChar)).Value = cod_asig;
            Comando.Parameters.Add(new SqlParameter("@DOCENTE", System.Data.SqlDbType.VarChar)).Value = docente;
            Comando.Parameters.Add(new SqlParameter("@AREA", System.Data.SqlDbType.VarChar)).Value = area;
            Comando.Parameters.Add(new SqlParameter("@CARRERA", System.Data.SqlDbType.VarChar)).Value = carrera;
            Comando.Parameters.Add(new SqlParameter("@PLAN", System.Data.SqlDbType.VarChar)).Value = plan;
            Comando.Parameters.Add(new SqlParameter("@CURRICULUM", System.Data.SqlDbType.VarChar)).Value = curriculum;
            Comando.Parameters.Add(new SqlParameter("@COLLEGE", System.Data.SqlDbType.VarChar)).Value = college;
            Comando.Parameters.Add(new SqlParameter("@OBSERVACIONES", System.Data.SqlDbType.VarChar)).Value = observacion;
            Comando.Parameters.Add(new SqlParameter("@DEPARTAMENT", System.Data.SqlDbType.VarChar)).Value = departament;
            Comando.Parameters.Add(new SqlParameter("@EVENT_TYPE", System.Data.SqlDbType.VarChar)).Value = eventype;
            Comando.Parameters.Add(new SqlParameter("@NOTA_FINAL", System.Data.SqlDbType.VarChar)).Value = nota;
            Comando.Parameters.Add(new SqlParameter("@NOTA_LETRA", System.Data.SqlDbType.VarChar)).Value = nletra;
            Comando.Parameters.Add(new SqlParameter("@ASIGNATURA", System.Data.SqlDbType.VarChar)).Value = asignatura;
            Comando.Parameters.Add(new SqlParameter("@FECHA", System.Data.SqlDbType.DateTime)).Value = fecha;
            Comando.Parameters.Add(new SqlParameter("@usuario", System.Data.SqlDbType.VarChar)).Value = user;
            Comando.Parameters.Add(new SqlParameter("@MODALIDAD", System.Data.SqlDbType.VarChar)).Value = modalidad;
            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos;
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@salida"].Value);

            conexion.conexion_datos.Close();

            return salida;
        }

        public int Insertando_Equivalencias(string people_id, string cod_asig, string section, string curriculum, string año, string aterm,string asignatura, string cod_equivale)
        {
            int salida = 0;
            conexion.conexion_datos.Open();
            Comando = new SqlCommand();
            Comando.CommandText = "ACTUALIZANDO_EQUIVALENCIAS";
            Comando.CommandType = System.Data.CommandType.StoredProcedure;

            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.VarChar)).Value = people_id;
            Comando.Parameters.Add(new SqlParameter("@COD_ASIG", System.Data.SqlDbType.VarChar)).Value = cod_asig;
            Comando.Parameters.Add(new SqlParameter("@SECTION", System.Data.SqlDbType.VarChar)).Value = section;
            Comando.Parameters.Add(new SqlParameter("@CURRICULUM", System.Data.SqlDbType.VarChar)).Value = curriculum;
            Comando.Parameters.Add(new SqlParameter("@AÑO", System.Data.SqlDbType.VarChar)).Value = año;
            Comando.Parameters.Add(new SqlParameter("@A_TERM ", System.Data.SqlDbType.VarChar)).Value = aterm;
            Comando.Parameters.Add(new SqlParameter("@ASIGNATURA", System.Data.SqlDbType.VarChar)).Value = asignatura;
            Comando.Parameters.Add(new SqlParameter("@COD_EQUIVA", System.Data.SqlDbType.VarChar)).Value = cod_equivale;

            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos;
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@salida"].Value);

            conexion.conexion_datos.Close();

            return salida;
        }

        public int Insertando_Tabla_Equivalencias(string people_id, string estudiante, string area, string carrera, string plan,string cod_Asig, string asignatura, string cod_equivale,string asig_equivale, string user)
        {
            int salida = 0;
            DataTable Tabla_Estudiante = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_INSERTANDO_REGISTRO_EQUIVALENCIA"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;

            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.VarChar)).Value = people_id;
            Comando.Parameters.Add(new SqlParameter("@ESTUDIANTE", System.Data.SqlDbType.VarChar)).Value = estudiante;
            Comando.Parameters.Add(new SqlParameter("@AREA_CONOCIMIENTO", System.Data.SqlDbType.VarChar)).Value = area;
            Comando.Parameters.Add(new SqlParameter("@CARRERA", System.Data.SqlDbType.VarChar)).Value = carrera;
            Comando.Parameters.Add(new SqlParameter("@PLAN_ACADEMICO", System.Data.SqlDbType.VarChar)).Value = plan;
            Comando.Parameters.Add(new SqlParameter("@COD_ASIGNATURA", System.Data.SqlDbType.VarChar)).Value = cod_Asig;
            Comando.Parameters.Add(new SqlParameter("@ASIGNATURA", System.Data.SqlDbType.VarChar)).Value = asignatura;
            Comando.Parameters.Add(new SqlParameter("@CODIGO_EQUIVALENTE", System.Data.SqlDbType.VarChar)).Value = cod_equivale;
            Comando.Parameters.Add(new SqlParameter("@ASIGNATURA_EQUIVALENTE", System.Data.SqlDbType.VarChar)).Value = asig_equivale;
            Comando.Parameters.Add(new SqlParameter("@USUARIO", System.Data.SqlDbType.VarChar)).Value = user;
            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@salida"].Value);

            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Estudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Estudiante; // retorno de la tabla 
            return salida;
        }

        public int Insertando_Tabla_Rectificacion(string people_id, string estudiante, string area, string carrera, string plan, string cod_Asig, string asignatura, string section, string acumulado,string parcial, string nota_final,String ced_doc, string docente, string user)
        {
            int salida = 0;
            DataTable Tabla_Estudiante = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_INSERTANDO_REGISTRO_RECTIFICACION"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;

            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.VarChar)).Value = people_id;
            Comando.Parameters.Add(new SqlParameter("@ESTUDIANTE", System.Data.SqlDbType.VarChar)).Value = estudiante;
            Comando.Parameters.Add(new SqlParameter("@AREA_CONOCIMIENTO", System.Data.SqlDbType.VarChar)).Value = area;
            Comando.Parameters.Add(new SqlParameter("@CARRERA", System.Data.SqlDbType.VarChar)).Value = carrera;
            Comando.Parameters.Add(new SqlParameter("@PLAN_ACADEMICO", System.Data.SqlDbType.VarChar)).Value = plan;
            Comando.Parameters.Add(new SqlParameter("@COD_ASIGNATURA", System.Data.SqlDbType.VarChar)).Value = cod_Asig;
            Comando.Parameters.Add(new SqlParameter("@ASIGNATURA", System.Data.SqlDbType.VarChar)).Value = asignatura;
            Comando.Parameters.Add(new SqlParameter("@SECTION", System.Data.SqlDbType.VarChar)).Value = section;
            Comando.Parameters.Add(new SqlParameter("@ACUMULADO", System.Data.SqlDbType.VarChar)).Value = acumulado;
            Comando.Parameters.Add(new SqlParameter("@PARCIAL", System.Data.SqlDbType.VarChar)).Value = parcial;
            Comando.Parameters.Add(new SqlParameter("@NOTA_FINAL", System.Data.SqlDbType.VarChar)).Value = nota_final;
            Comando.Parameters.Add(new SqlParameter("@CED_DOC", System.Data.SqlDbType.VarChar)).Value = ced_doc;
            Comando.Parameters.Add(new SqlParameter("@DOCENTE", System.Data.SqlDbType.VarChar)).Value = docente;
            Comando.Parameters.Add(new SqlParameter("@USUARIO", System.Data.SqlDbType.VarChar)).Value = user;
            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@salida"].Value);

            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Estudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Estudiante; // retorno de la tabla 
            return salida;
        }

    }
}