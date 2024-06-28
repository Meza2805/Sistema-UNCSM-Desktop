using System;
using System.Data;
using System.Data.SqlClient;


namespace Capa_Negocio
{
    public class campus
    {
        
        Capa_Datos.Acceso conexion = new Capa_Datos.Acceso(); //se instancia un objeto de tipo acceso
        private SqlCommand Comando; //objeto de tipo SqlCommand para los comandos de sql
        SqlDataAdapter Adaptador; //objeto de tipo sqlAdapter para convertir las tablas de sql y guardarlas en una tabla

        public DataTable mostrar_registro()
        {
            DataTable tabla_registro = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "sp_mostrar_matricula_2024"; //se pasa el procedimiento almancenado
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_registro); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_registro; // retorno de la tabla 
        }
         public int Insertar_Usuario(String GOVERMENT_ID, string PREFIX, String NAME01, string NAME02, string LASTNAME01, string LASTNAME02, int ID_ETNIA, string GENDER, int ID_MARITAL_STATUS, int ID_REGLIGION, string ADDRES_COMPLETE, DateTime BIRTH_DATE, int ID_BIRTH_COUNTRY, int ID_COUNTRY_LIVE, int ID_DEPARTMENTO, int ID_MUNICIPIO, string ADDRES_MAIL, string PHONE01, string P_DESCRIPTION01, string PHONE02, string P_DESCRIPTION02, string PHONE03, string P_DESCRIPTION03, int PEOPLE_TYPE, String INSS)
        {
            int salida = 0;
            DataTable Tabla_Estudiante = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_INGRESAR_USUARIOS_2024"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;

            Comando.Parameters.Add(new SqlParameter("@GOVERMENT_ID", System.Data.SqlDbType.VarChar)).Value = GOVERMENT_ID;
            Comando.Parameters.Add(new SqlParameter("@PREFIX", System.Data.SqlDbType.VarChar)).Value = PREFIX;
            Comando.Parameters.Add(new SqlParameter("@NAME01", System.Data.SqlDbType.VarChar)).Value = NAME01;
            Comando.Parameters.Add(new SqlParameter("@NAME02", System.Data.SqlDbType.VarChar)).Value = NAME02;
            Comando.Parameters.Add(new SqlParameter("@LASTNAME01", System.Data.SqlDbType.VarChar)).Value = LASTNAME01;
            Comando.Parameters.Add(new SqlParameter("@LASTNAME02", System.Data.SqlDbType.VarChar)).Value = LASTNAME02;
            Comando.Parameters.Add(new SqlParameter("@ID_ETNIA", System.Data.SqlDbType.Int)).Value = ID_ETNIA;
            Comando.Parameters.Add(new SqlParameter("@GENDER", System.Data.SqlDbType.VarChar)).Value = GENDER;
            Comando.Parameters.Add(new SqlParameter("@ID_MARITAL_STATUS", System.Data.SqlDbType.Int)).Value = ID_MARITAL_STATUS;
            Comando.Parameters.Add(new SqlParameter("@ID_REGLIGION", System.Data.SqlDbType.Int)).Value = ID_REGLIGION;
            Comando.Parameters.Add(new SqlParameter("@ADDRES_COMPLETE", System.Data.SqlDbType.VarChar)).Value = ADDRES_COMPLETE;
            Comando.Parameters.Add(new SqlParameter("@BIRTH_DATE", System.Data.SqlDbType.DateTime)).Value = BIRTH_DATE;
            Comando.Parameters.Add(new SqlParameter("@ID_BIRTH_COUNTRY", System.Data.SqlDbType.Int)).Value = ID_BIRTH_COUNTRY;
            Comando.Parameters.Add(new SqlParameter("@ID_COUNTRY_LIVE", System.Data.SqlDbType.Int)).Value = ID_COUNTRY_LIVE;
            Comando.Parameters.Add(new SqlParameter("@ID_DEPARTMENTO", System.Data.SqlDbType.Int)).Value = ID_DEPARTMENTO;
            Comando.Parameters.Add(new SqlParameter("@ID_MUNICIPIO", System.Data.SqlDbType.Int)).Value = ID_MUNICIPIO;
            Comando.Parameters.Add(new SqlParameter("@ADDRES_MAIL", System.Data.SqlDbType.NVarChar)).Value = ADDRES_MAIL;
            //Comando.Parameters.Add(new SqlParameter("@HOUSE_NUMBER", System.Data.SqlDbType.NVarChar)).Value = HOUSE_NUMBER;
            Comando.Parameters.Add(new SqlParameter("@P_DESCRIPTION01", System.Data.SqlDbType.NVarChar)).Value = P_DESCRIPTION01;
            Comando.Parameters.Add(new SqlParameter("@PHONE01", System.Data.SqlDbType.NVarChar)).Value = PHONE01;
            Comando.Parameters.Add(new SqlParameter("@P_DESCRIPTION02", System.Data.SqlDbType.NVarChar)).Value = P_DESCRIPTION02;
            Comando.Parameters.Add(new SqlParameter("@PHONE02", System.Data.SqlDbType.NVarChar)).Value = PHONE02;
            Comando.Parameters.Add(new SqlParameter("@P_DESCRIPTION03", System.Data.SqlDbType.NVarChar)).Value = P_DESCRIPTION03;
            Comando.Parameters.Add(new SqlParameter("@PHONE03", System.Data.SqlDbType.NVarChar)).Value = PHONE03;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE_TYPE", System.Data.SqlDbType.Int)).Value = PEOPLE_TYPE;
            Comando.Parameters.Add(new SqlParameter("@INSS", System.Data.SqlDbType.NVarChar)).Value = INSS;
            //Comando.Parameters.Add(new SqlParameter("@ID_CURRICULUM_P", System.Data.SqlDbType.Int)).Value = ID_CURRICULUM_P;
            //Comando.Parameters.Add(new SqlParameter("@ACA_SESSION_P", System.Data.SqlDbType.NVarChar)).Value = ACA_SESSION_P;
            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@SALIDA"].Value);

            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Estudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Estudiante; // retorno de la tabla 
            return salida;
        }
        public int ValidarUsuario(String usuario)
        {
            int salida = 0;
            DataTable Tabla_Estudiante = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_BUSCAR_USUARIO"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@USUARIO", System.Data.SqlDbType.NVarChar)).Value = usuario;
            //Comando.Parameters.Add(new SqlParameter("@ID_CURRICULUM_P", System.Data.SqlDbType.Int)).Value = ID_CURRICULUM_P;
            //Comando.Parameters.Add(new SqlParameter("@ACA_SESSION_P", System.Data.SqlDbType.NVarChar)).Value = ACA_SESSION_P;
            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@SALIDA"].Value);
            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Estudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Estudiante; // retorno de la tabla
            return salida;
        }
        public DataTable AccesoSistema(string usuario, string contra)
        {
            DataTable tabla_registro = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_ACCESO_UNCSM"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@USUARIO", System.Data.SqlDbType.NChar)).Value = usuario;
            Comando.Parameters.Add(new SqlParameter("@CONTRASE", System.Data.SqlDbType.NChar)).Value = contra;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_registro); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_registro; // retorno de la tabla 
        }
        public int Insertar_Doc_Grupos(String GOVERNMENT_ID, String NAME01, string NAME02, string LASTNAME01, string LASTNAME02, String AREA_CONOCIMIENTO,String CODIGO_AREA, String AÑO, String SEMESTRE, String CARRRERA, String CODIGO_CARRERA, String TURNO, String COD_ASIG, String ASIGNATURA, String GRUPO,String ACA_TERM,String SUBTYPE,String SECTION, String SECCION)
        {
            int salida = 0;
            DataTable Tabla_DocGrup = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "InsertarDocenteGrupo"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@GOVERNMENT_ID", System.Data.SqlDbType.VarChar)).Value = GOVERNMENT_ID;
            Comando.Parameters.Add(new SqlParameter("@FIRTSNAME", System.Data.SqlDbType.VarChar)).Value = NAME01;
            Comando.Parameters.Add(new SqlParameter("@MIDDLE_NAME", System.Data.SqlDbType.VarChar)).Value = NAME02;
            Comando.Parameters.Add(new SqlParameter("@LAST_NAME", System.Data.SqlDbType.VarChar)).Value = LASTNAME01;
            Comando.Parameters.Add(new SqlParameter("@LAST_NAME02", System.Data.SqlDbType.VarChar)).Value = LASTNAME02;
            Comando.Parameters.Add(new SqlParameter("@AREA_CONOCIMIENTO", System.Data.SqlDbType.VarChar)).Value = AREA_CONOCIMIENTO;
            Comando.Parameters.Add(new SqlParameter("@CODIGO_AREA", System.Data.SqlDbType.VarChar)).Value = CODIGO_AREA;
            Comando.Parameters.Add(new SqlParameter("@AÑO", System.Data.SqlDbType.VarChar)).Value = AÑO;
            Comando.Parameters.Add(new SqlParameter("@SEMESTRE", System.Data.SqlDbType.VarChar)).Value = SEMESTRE;
            Comando.Parameters.Add(new SqlParameter("@CARRERA", System.Data.SqlDbType.VarChar)).Value = CARRRERA;
            Comando.Parameters.Add(new SqlParameter("@CODIGO_CARRRERA", System.Data.SqlDbType.VarChar)).Value = CODIGO_CARRERA;
            Comando.Parameters.Add(new SqlParameter("@TURNO", System.Data.SqlDbType.VarChar)).Value = TURNO;
            Comando.Parameters.Add(new SqlParameter("@GRUPO", System.Data.SqlDbType.VarChar)).Value = GRUPO;
            Comando.Parameters.Add(new SqlParameter("@COD_ASIG", System.Data.SqlDbType.VarChar)).Value = COD_ASIG;
            Comando.Parameters.Add(new SqlParameter("@ASIGNATURA", System.Data.SqlDbType.VarChar)).Value = ASIGNATURA;
            Comando.Parameters.Add(new SqlParameter("@ACA_TERM", System.Data.SqlDbType.VarChar)).Value = ACA_TERM;
            Comando.Parameters.Add(new SqlParameter("@SUBTYPE", System.Data.SqlDbType.VarChar)).Value = SUBTYPE;
            Comando.Parameters.Add(new SqlParameter("@SECTION", System.Data.SqlDbType.VarChar)).Value = SECTION;
            Comando.Parameters.Add(new SqlParameter("@SECCION", System.Data.SqlDbType.VarChar)).Value = SECCION;
            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@SALIDA"].Value);

            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Estudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Estudiante; // retorno de la tabla 

            return salida;
        }

        public int Insertar_Doc_Grupos_Reingreso(String GOVERNMENT_ID, String NAME01, string NAME02, string LASTNAME01, string LASTNAME02, String AREA_CONOCIMIENTO, String codigo_area, String AÑO, String SEMESTRE, String CARRRERA, string codigo_carrera, String TURNO, String COD_ASIG, String ASIGNATURA, String SECTION, String ACA_TERM, String SUBTYPE, String SECCION)
        {
            int salida = 0;
            DataTable Tabla_DocGrup = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "INSERTAR_DOCENTE_REINGRESO"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@GOVERNMENT_ID", System.Data.SqlDbType.VarChar)).Value = GOVERNMENT_ID;
            Comando.Parameters.Add(new SqlParameter("@FIRTSNAME", System.Data.SqlDbType.VarChar)).Value = NAME01;
            Comando.Parameters.Add(new SqlParameter("@MIDDLE_NAME", System.Data.SqlDbType.VarChar)).Value = NAME02;
            Comando.Parameters.Add(new SqlParameter("@LAST_NAME", System.Data.SqlDbType.VarChar)).Value = LASTNAME01;
            Comando.Parameters.Add(new SqlParameter("@LAST_NAME02", System.Data.SqlDbType.VarChar)).Value = LASTNAME02;
            Comando.Parameters.Add(new SqlParameter("@AREA_CONOCIMIENTO", System.Data.SqlDbType.VarChar)).Value = AREA_CONOCIMIENTO;
            Comando.Parameters.Add(new SqlParameter("@CODIGO_AREA", System.Data.SqlDbType.VarChar)).Value = codigo_area;
            Comando.Parameters.Add(new SqlParameter("@AÑO", System.Data.SqlDbType.VarChar)).Value = AÑO;
            Comando.Parameters.Add(new SqlParameter("@SEMESTRE", System.Data.SqlDbType.VarChar)).Value = SEMESTRE;
            Comando.Parameters.Add(new SqlParameter("@CARRERA", System.Data.SqlDbType.VarChar)).Value = CARRRERA;
            Comando.Parameters.Add(new SqlParameter("@CODIGO_CARRERA", System.Data.SqlDbType.VarChar)).Value = codigo_carrera;
            Comando.Parameters.Add(new SqlParameter("@TURNO", System.Data.SqlDbType.VarChar)).Value = TURNO;
            Comando.Parameters.Add(new SqlParameter("@SECTION", System.Data.SqlDbType.VarChar)).Value = SECTION;
            Comando.Parameters.Add(new SqlParameter("@COD_ASIG", System.Data.SqlDbType.VarChar)).Value = COD_ASIG;
            Comando.Parameters.Add(new SqlParameter("@ASIGNATURA", System.Data.SqlDbType.VarChar)).Value = ASIGNATURA;
            Comando.Parameters.Add(new SqlParameter("@ACA_TERM", System.Data.SqlDbType.VarChar)).Value = ACA_TERM;
            Comando.Parameters.Add(new SqlParameter("@SUBTYPE", System.Data.SqlDbType.VarChar)).Value = SUBTYPE;
            Comando.Parameters.Add(new SqlParameter("@SECCION", System.Data.SqlDbType.VarChar)).Value = SECCION;
            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@SALIDA"].Value);

            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Estudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Estudiante; // retorno de la tabla 

            return salida;
        }
        public DataTable Mostrar_Turno(int Id_rol) //1 para todos los turnos, 0 para solo sabado y domingo
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_TURNO"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@ROL", System.Data.SqlDbType.Int)).Value = Id_rol;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }
        public DataTable Mostrar_Area()
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_AREA"; //se pasa el procedimiento almancenado
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }
        public DataTable Carrera_por_Area(int Id_Area)
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_CARRERA_POR_AREA"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@ID_AREA", System.Data.SqlDbType.Int)).Value = Id_Area;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }
        public DataTable BuscarDatosEstudiantes(string carne)
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_BUSCAR_ESTUDIANTE"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CARNE", System.Data.SqlDbType.NVarChar)).Value = carne;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }
        public DataTable Matricula_Consolidado()
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_CONSOLIDAD_MATRICULA"; //se pasa el procedimiento almancenado
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }
        public DataTable Buscar_Carne(string cedula)
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_CARNE"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CEDULA", System.Data.SqlDbType.NChar)).Value = cedula;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }
        public int Insertar_Est_Recudiante_campus(String GOVERMENT_ID, String NAME01, string NAME02, string LASTNAME01, string LASTNAME02, int ID_ETNIA, string GENDER, int ID_MARITAL_STATUS, int ID_REGLIGION, string ADDRES_COMPLETE, DateTime BIRTH_DATE, int ID_BIRTH_COUNTRY, int ID_COUNTRY_LIVE, int ID_DEPARTMENTO, int ID_MUNICIPIO, string ADDRES_MAIL,string HOUSE_NUMBER, string PHONE01, string P_DESCRIPTION01, string PHONE02, string P_DESCRIPTION02, string PHONE03, string P_DESCRIPTION03, int PEOPLE_TYPE,int ID_CURRICULUM,string ACA_SESSION_P)

        {
            int salida = 0;
            DataTable Tabla_Est_Rec_Recudiante = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_INSERT_PEOPLE_CSM_2024"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@GOVERMENT_ID", System.Data.SqlDbType.VarChar)).Value = GOVERMENT_ID;
            //Comando.Parameters.Add(new SqlParameter("@PREFIX", System.Data.SqlDbType.VarChar)).Value = PREFIX;
            Comando.Parameters.Add(new SqlParameter("@NAME01", System.Data.SqlDbType.VarChar)).Value = NAME01;
            Comando.Parameters.Add(new SqlParameter("@NAME02", System.Data.SqlDbType.VarChar)).Value = NAME02;
            Comando.Parameters.Add(new SqlParameter("@LASTNAME01", System.Data.SqlDbType.VarChar)).Value = LASTNAME01;
            Comando.Parameters.Add(new SqlParameter("@LASTNAME02", System.Data.SqlDbType.VarChar)).Value = LASTNAME02;
            Comando.Parameters.Add(new SqlParameter("@ID_ETNIA", System.Data.SqlDbType.Int)).Value = ID_ETNIA;
            Comando.Parameters.Add(new SqlParameter("@GENDER", System.Data.SqlDbType.VarChar)).Value = GENDER;
            Comando.Parameters.Add(new SqlParameter("@ID_MARITAL_STATUS", System.Data.SqlDbType.Int)).Value = ID_MARITAL_STATUS;
            Comando.Parameters.Add(new SqlParameter("@ID_REGLIGION", System.Data.SqlDbType.Int)).Value = ID_REGLIGION;
            Comando.Parameters.Add(new SqlParameter("@ADDRES_COMPLETE", System.Data.SqlDbType.VarChar)).Value = ADDRES_COMPLETE;
            Comando.Parameters.Add(new SqlParameter("@BIRTH_DATE", System.Data.SqlDbType.DateTime)).Value = BIRTH_DATE;
            Comando.Parameters.Add(new SqlParameter("@ID_BIRTH_COUNTRY", System.Data.SqlDbType.Int)).Value = ID_BIRTH_COUNTRY;
            Comando.Parameters.Add(new SqlParameter("@ID_COUNTRY_LIVE", System.Data.SqlDbType.Int)).Value = ID_COUNTRY_LIVE;
            Comando.Parameters.Add(new SqlParameter("@ID_DEPARTMENTO", System.Data.SqlDbType.Int)).Value = ID_DEPARTMENTO;
            Comando.Parameters.Add(new SqlParameter("@ID_MUNICIPIO", System.Data.SqlDbType.Int)).Value = ID_MUNICIPIO;
            Comando.Parameters.Add(new SqlParameter("@ADDRES_MAIL", System.Data.SqlDbType.NVarChar)).Value =ADDRES_MAIL;
            Comando.Parameters.Add(new SqlParameter("@HOUSE_NUMBER", System.Data.SqlDbType.NVarChar)).Value = HOUSE_NUMBER;
            Comando.Parameters.Add(new SqlParameter("@P_DESCRIPTION01", System.Data.SqlDbType.NVarChar)).Value = P_DESCRIPTION01;
            Comando.Parameters.Add(new SqlParameter("@PHONE01", System.Data.SqlDbType.NVarChar)).Value =PHONE01;
            Comando.Parameters.Add(new SqlParameter("@P_DESCRIPTION02", System.Data.SqlDbType.NVarChar)).Value =P_DESCRIPTION02;
            Comando.Parameters.Add(new SqlParameter("@PHONE02", System.Data.SqlDbType.NVarChar)).Value = PHONE02;
            Comando.Parameters.Add(new SqlParameter("@P_DESCRIPTION03", System.Data.SqlDbType.NVarChar)).Value = P_DESCRIPTION03;
            Comando.Parameters.Add(new SqlParameter("@PHONE03", System.Data.SqlDbType.NVarChar)).Value = PHONE03;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE_TYPE", System.Data.SqlDbType.Int)).Value = PEOPLE_TYPE;
            Comando.Parameters.Add(new SqlParameter("@ID_CURRICULUM_P", System.Data.SqlDbType.Int)).Value = ID_CURRICULUM;
            Comando.Parameters.Add(new SqlParameter("@ACA_SESSION_P", System.Data.SqlDbType.NVarChar)).Value = ACA_SESSION_P;
            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@SALIDA"].Value);

            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Est_Recudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Est_Recudiante; // retorno de la tabla
            return salida;
        }
        public DataTable Martricula_por_Opcion(int Id_Area)
        {
            SqlDataAdapter r;
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRA_MATRICULA_POR_GRUPOS_CSM_V02"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@VALOR", System.Data.SqlDbType.Int)).Value = Id_Area;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            r = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            r.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }
        public DataTable Martricula_por_Turno(int Id_Opcion)
        {
            SqlDataAdapter r;
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_MATRICULA_POR_SEXO"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@VALOR", System.Data.SqlDbType.Int)).Value = Id_Opcion;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            r = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            r.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }
        public DataTable Contar_Grupo_Regular(int Id_Opcion)
        {
            SqlDataAdapter r;
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOTRAR_GRUPOS_REGULAR"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@VALOR", System.Data.SqlDbType.Int)).Value = Id_Opcion;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            r = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            r.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }

        public DataTable ValidarAsignatura(string usuario, string carrera, string asignatura)
        {
            DataTable tabla_registro = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_COMPROBAR_ASIGNATURA"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@people", System.Data.SqlDbType.NChar)).Value = Convert.ToInt32(usuario);
            Comando.Parameters.Add(new SqlParameter("@Carrera", System.Data.SqlDbType.NChar)).Value = carrera;
            Comando.Parameters.Add(new SqlParameter("@Asignatura02", System.Data.SqlDbType.NChar)).Value = asignatura;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_registro); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_registro; // retorno de la tabla 
        }



        public DataTable VerAsignatura(string asignatura)
        {
            DataTable tabla_registro = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_ASIGNATURAS"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@COD_ASIG", System.Data.SqlDbType.VarChar)).Value = asignatura;

            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_registro); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_registro; // retorno de la tabla 
        }

        public DataTable VerAsignaturaEquivalente(string asignatura)
        {
            DataTable tabla_registro = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_ASIGNATURAS_EQUIVALENTE"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@COD_ASIG", System.Data.SqlDbType.VarChar)).Value = asignatura;

            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_registro); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_registro; // retorno de la tabla 
        }
        public DataTable Contar_Grupo_Fin(int Id_Opcion)
        {
            SqlDataAdapter r;
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOTRAR_GRUPOS_FINES"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@VALOR", System.Data.SqlDbType.Int)).Value = Id_Opcion;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            r = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            r.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }
        public int Contar_Estudiantes(int Id_Curriculum, int turno)
        {
            int salida = 0;
            DataTable Tabla_Est_Rec_Recudiante = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_CONTAR_MATRICULA"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@ID_CURRIULM", System.Data.SqlDbType.Int)).Value = Id_Curriculum;
            Comando.Parameters.Add(new SqlParameter("@ACA_SESSION", System.Data.SqlDbType.Int)).Value = turno;
            Comando.Parameters.Add("@CANTIDAD", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@CANTIDAD"].Value);

            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Est_Recudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Est_Recudiante; // retorno de la tabla
            return salida;
        }
        public DataTable Mostrar_listado_2024()
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_LISTADO_2024"; //se pasa el procedimiento almancenado
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }

        public DataTable Busqueda_Datos_Reingreso_Extr(String people)
        {
            DataTable Tabla_Docentes = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "SP_DATOS_REINGRESOS"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.VarChar)).Value = Convert.ToInt32(people); 
            Comando.Connection = conexion.conexion_datos; // se abre la conexión para el comando
            Adaptador = new SqlDataAdapter(Comando); // se recibe la tabla producto de la ejecución del procedimiento
            Adaptador.Fill(Tabla_Docentes); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexión
            return Tabla_Docentes; // retorno de la tabla 
        }
        public DataTable Busqueda_Datos_Equivalencia(String people)
        {
            DataTable Tabla_Docentes = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "SP_DATOS_EQUIVALENCIAS"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.VarChar)).Value = Convert.ToInt32(people); ;
            Comando.Connection = conexion.conexion_datos; // se abre la conexión para el comando
            Adaptador = new SqlDataAdapter(Comando); // se recibe la tabla producto de la ejecución del procedimiento
            Adaptador.Fill(Tabla_Docentes); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexión
            return Tabla_Docentes; // retorno de la tabla 
        }
        public DataTable Busqueda_Datos_Otros_Reingresos(String people)
        {
            DataTable Tabla_Docentes = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "SP_DATOS_REINGRESOS_OTRAS"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.VarChar)).Value = Convert.ToInt32(people); ;
            Comando.Connection = conexion.conexion_datos; // se abre la conexión para el comando
            Adaptador = new SqlDataAdapter(Comando); // se recibe la tabla producto de la ejecución del procedimiento
            Adaptador.Fill(Tabla_Docentes); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexión
            return Tabla_Docentes; // retorno de la tabla 
        }

        public DataTable Busqueda_Datos_Otros_rectificacion(String people)
        {
            DataTable Tabla_Docentes = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "SP_DATOS_REINGRESOS_RECTIFICACION"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE_ID", System.Data.SqlDbType.VarChar)).Value = Convert.ToInt32(people); ;
            Comando.Connection = conexion.conexion_datos; // se abre la conexión para el comando
            Adaptador = new SqlDataAdapter(Comando); // se recibe la tabla producto de la ejecución del procedimiento
            Adaptador.Fill(Tabla_Docentes); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexión
            return Tabla_Docentes; // retorno de la tabla 
        }


        public DataTable Actualizando_Datos_Otros_Reingresos(String people,string event_id,string section,string nota_final , string año)
        {
            DataTable Tabla_Docentes = new DataTable(); // Instancia de un objeto de tipo DataTable para recibir la tabla que devuelve el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); // se abre la conexión para el comando
            Comando = new SqlCommand(); // instancia del objeto de tipo SqlCommand
            Comando.CommandText = "SP_ACTUALIZANDO_NOTAS_REINGRESO"; // se pasa el procedimiento almacenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.VarChar)).Value = people;
            Comando.Parameters.Add(new SqlParameter("@EVENT_ID", System.Data.SqlDbType.VarChar)).Value = event_id;
            Comando.Parameters.Add(new SqlParameter("@SECTION", System.Data.SqlDbType.VarChar)).Value = section;
            Comando.Parameters.Add(new SqlParameter("@NOTA_FINAL", System.Data.SqlDbType.VarChar)).Value = nota_final;
            Comando.Parameters.Add(new SqlParameter("@AÑO", System.Data.SqlDbType.VarChar)).Value = año;
            Comando.Connection = conexion.conexion_datos; // se abre la conexión para el comando
            Adaptador = new SqlDataAdapter(Comando); // se recibe la tabla producto de la ejecución del procedimiento
            Adaptador.Fill(Tabla_Docentes); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexión
            return Tabla_Docentes; // retorno de la tabla 
        }

        public void Actualizar_Usuario(string cedula, string primer_nombre, string segundo_nombre, string primer_apellido, string segundo_apellido, string sexo)
        {
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando.CommandText = "SP_ACTUALIZAR_USUARIO"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CEDULA", System.Data.SqlDbType.VarChar)).Value = cedula;
            Comando.Parameters.Add(new SqlParameter("@PRIMER_NOMBRE", System.Data.SqlDbType.VarChar)).Value = primer_nombre;
            Comando.Parameters.Add(new SqlParameter("@SEGUNDO_NOMBRE", System.Data.SqlDbType.VarChar)).Value = segundo_nombre;
            Comando.Parameters.Add(new SqlParameter("@PRIMER_APELLIDO", System.Data.SqlDbType.VarChar)).Value = primer_apellido;
            Comando.Parameters.Add(new SqlParameter("@SEGUNDO_APELLIDO ", System.Data.SqlDbType.VarChar)).Value = segundo_apellido;
            Comando.Parameters.Add(new SqlParameter("@SEXO", System.Data.SqlDbType.VarChar)).Value = sexo;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            conexion.conexion_datos.Close(); // se cierra la conexion
        }
        public int Realizar_Cambios_Estudiantes(String CARNE, String TURNO, int ID_CURRICULUM)
        {
            int salida = 0;
            DataTable Tabla_DocGrup = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_CAMBIOS_ESTUDIANTES_UNCSM"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CARNE", System.Data.SqlDbType.VarChar)).Value = CARNE;
            Comando.Parameters.Add(new SqlParameter("@TURNO", System.Data.SqlDbType.VarChar)).Value = TURNO;
            Comando.Parameters.Add(new SqlParameter("@ID_CURRICULUM_R", System.Data.SqlDbType.Int)).Value = ID_CURRICULUM;
         
            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@SALIDA"].Value);
            conexion.conexion_datos.Close(); // se cierra la conexion
            return salida;
        }
        public int Insertar_Estudiante_2(String GOVERMENT_ID, String NAME01, string NAME02, string LASTNAME01, string LASTNAME02, int ID_ETNIA, string GENDER, int ID_MARITAL_STATUS, int ID_REGLIGION, string ADDRES_COMPLETE, DateTime BIRTH_DATE, int ID_BIRTH_COUNTRY, int ID_COUNTRY_LIVE, int ID_DEPARTMENTO, int ID_MUNICIPIO, string ADDRES_MAIL, string HOUSE_NUMBER, string PHONE01, string P_DESCRIPTION01, string PHONE02, string P_DESCRIPTION02, string PHONE03, string P_DESCRIPTION03, int PEOPLE_TYPE, int ID_CURRICULUM, string ACA_SESSION_P,string barrio, int IdProcedencia, int IdEstatal, int IdCentroEstudio,int IdanioEgresado, float PromedioGeneral, string CentroOtro,int IdIzquierdo, int IdDerecho, int IdSordera,int IdCeguera, int IdDiscapacidadMotora,int IdTEA, int IdTGHA, int IdMudezSord, int IdNingunaDiscp,int idcuentaaccesointernet,int Idproveedor, int Idcuentacomputadora, int IdCuentacontablet, int IdCelular,int IdTipoConexion, int MATEMATICAS_X, int LENGUA_X, int GEOGRAFIA_X, int FISICA_X,int QUIMICA_X,int MATEMATICAS_XI,int LENGUA_XI, int HISTORIA_IX, int FISICA_XI, int BIOLGIA_XI)

        {
            
            int salida = 0;
            DataTable Tabla_Est_Rec_Recudiante = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_INSERT_PEOPLE_CSM_FULL_2024"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;

            //Valores para Campus
            Comando.Parameters.Add(new SqlParameter("@GOVERMENT_ID", System.Data.SqlDbType.VarChar)).Value = GOVERMENT_ID;
            Comando.Parameters.Add(new SqlParameter("@NAME01", System.Data.SqlDbType.VarChar)).Value = NAME01;
            Comando.Parameters.Add(new SqlParameter("@NAME02", System.Data.SqlDbType.VarChar)).Value = NAME02;
            Comando.Parameters.Add(new SqlParameter("@LASTNAME01", System.Data.SqlDbType.VarChar)).Value = LASTNAME01;
            Comando.Parameters.Add(new SqlParameter("@LASTNAME02", System.Data.SqlDbType.VarChar)).Value = LASTNAME02;
            Comando.Parameters.Add(new SqlParameter("@ID_ETNIA", System.Data.SqlDbType.Int)).Value = ID_ETNIA;
            Comando.Parameters.Add(new SqlParameter("@GENDER", System.Data.SqlDbType.VarChar)).Value = GENDER;
            Comando.Parameters.Add(new SqlParameter("@ID_MARITAL_STATUS", System.Data.SqlDbType.Int)).Value = ID_MARITAL_STATUS;
            Comando.Parameters.Add(new SqlParameter("@ID_REGLIGION", System.Data.SqlDbType.Int)).Value = ID_REGLIGION;
            Comando.Parameters.Add(new SqlParameter("@ADDRES_COMPLETE", System.Data.SqlDbType.VarChar)).Value = ADDRES_COMPLETE;
            Comando.Parameters.Add(new SqlParameter("@BIRTH_DATE", System.Data.SqlDbType.DateTime)).Value = BIRTH_DATE;
            Comando.Parameters.Add(new SqlParameter("@ID_BIRTH_COUNTRY", System.Data.SqlDbType.Int)).Value = ID_BIRTH_COUNTRY;
            Comando.Parameters.Add(new SqlParameter("@ID_COUNTRY_LIVE", System.Data.SqlDbType.Int)).Value = ID_COUNTRY_LIVE;
            Comando.Parameters.Add(new SqlParameter("@ID_DEPARTMENTO", System.Data.SqlDbType.Int)).Value = ID_DEPARTMENTO;
            Comando.Parameters.Add(new SqlParameter("@ID_MUNICIPIO", System.Data.SqlDbType.Int)).Value = ID_MUNICIPIO;
            Comando.Parameters.Add(new SqlParameter("@ADDRES_MAIL", System.Data.SqlDbType.NVarChar)).Value = ADDRES_MAIL;
            Comando.Parameters.Add(new SqlParameter("@HOUSE_NUMBER", System.Data.SqlDbType.NVarChar)).Value = HOUSE_NUMBER;
            Comando.Parameters.Add(new SqlParameter("@P_DESCRIPTION01", System.Data.SqlDbType.NVarChar)).Value = P_DESCRIPTION01;
            Comando.Parameters.Add(new SqlParameter("@PHONE01", System.Data.SqlDbType.NVarChar)).Value = PHONE01;
            Comando.Parameters.Add(new SqlParameter("@P_DESCRIPTION02", System.Data.SqlDbType.NVarChar)).Value = P_DESCRIPTION02;
            Comando.Parameters.Add(new SqlParameter("@PHONE02", System.Data.SqlDbType.NVarChar)).Value = PHONE02;
            Comando.Parameters.Add(new SqlParameter("@P_DESCRIPTION03", System.Data.SqlDbType.NVarChar)).Value = P_DESCRIPTION03;
            Comando.Parameters.Add(new SqlParameter("@PHONE03", System.Data.SqlDbType.NVarChar)).Value = PHONE03;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE_TYPE", System.Data.SqlDbType.Int)).Value = PEOPLE_TYPE;
            Comando.Parameters.Add(new SqlParameter("@ID_CURRICULUM_P", System.Data.SqlDbType.Int)).Value = ID_CURRICULUM;
            Comando.Parameters.Add(new SqlParameter("@ACA_SESSION_P", System.Data.SqlDbType.NVarChar)).Value = ACA_SESSION_P;

            //Valores para Prematricula
            Comando.Parameters.Add(new SqlParameter("@BARRIO", System.Data.SqlDbType.NVarChar)).Value = barrio;
            Comando.Parameters.Add(new SqlParameter("@ID_PROCEDENCIA", System.Data.SqlDbType.Int)).Value = IdProcedencia;
            Comando.Parameters.Add(new SqlParameter("@ID_ESTATAL", System.Data.SqlDbType.Int)).Value = IdEstatal;
            Comando.Parameters.Add(new SqlParameter("@idcentroestudio", System.Data.SqlDbType.Int)).Value = IdCentroEstudio;
            Comando.Parameters.Add(new SqlParameter("@Idanioegresado", System.Data.SqlDbType.Int)).Value = IdanioEgresado;
            Comando.Parameters.Add(new SqlParameter("@promediogeneral", System.Data.SqlDbType.Float)).Value = PromedioGeneral;
            Comando.Parameters.Add(new SqlParameter("@centrootro", System.Data.SqlDbType.NVarChar)).Value = CentroOtro;
            Comando.Parameters.Add(new SqlParameter("@idizquierdo", System.Data.SqlDbType.Int)).Value = IdIzquierdo;
            Comando.Parameters.Add(new SqlParameter("@idderecho ", System.Data.SqlDbType.Int)).Value = IdDerecho;
            Comando.Parameters.Add(new SqlParameter("@idSordera", System.Data.SqlDbType.Int)).Value = IdSordera;
            Comando.Parameters.Add(new SqlParameter("@idCeguera", System.Data.SqlDbType.Int)).Value = IdCeguera;
            Comando.Parameters.Add(new SqlParameter("@idDiscapacidadMotora", System.Data.SqlDbType.Int)).Value = IdDiscapacidadMotora;
            Comando.Parameters.Add(new SqlParameter("@idTEA", System.Data.SqlDbType.Int)).Value = IdTEA;
            Comando.Parameters.Add(new SqlParameter("@idTGHA", System.Data.SqlDbType.Int)).Value = IdTGHA;
            Comando.Parameters.Add(new SqlParameter("@idMudezSord", System.Data.SqlDbType.Int)).Value = IdMudezSord;
            Comando.Parameters.Add(new SqlParameter("@IDNingunaDiscp", System.Data.SqlDbType.Int)).Value = IdNingunaDiscp;
            Comando.Parameters.Add(new SqlParameter("@idcuentaaccesointernet", System.Data.SqlDbType.Int)).Value = idcuentaaccesointernet;
            Comando.Parameters.Add(new SqlParameter("@idproveedor", System.Data.SqlDbType.Int)).Value = Idproveedor;
            Comando.Parameters.Add(new SqlParameter("@idcuentacomputadora", System.Data.SqlDbType.Int)).Value = Idcuentacomputadora;
            Comando.Parameters.Add(new SqlParameter("@idcuentacontablet", System.Data.SqlDbType.Int)).Value = IdCuentacontablet;
            Comando.Parameters.Add(new SqlParameter("@idCelular", System.Data.SqlDbType.Int)).Value = IdCelular;
            Comando.Parameters.Add(new SqlParameter("@IdTipoConexion", System.Data.SqlDbType.Int)).Value = IdTipoConexion;
            Comando.Parameters.Add(new SqlParameter("@MATEMATICAS_X", System.Data.SqlDbType.Int)).Value = MATEMATICAS_X;
            Comando.Parameters.Add(new SqlParameter("@LENGUA_X", System.Data.SqlDbType.Int)).Value = LENGUA_X;
            Comando.Parameters.Add(new SqlParameter("@GEOGRAFIA_X", System.Data.SqlDbType.Int)).Value = GEOGRAFIA_X;
            Comando.Parameters.Add(new SqlParameter("@FISICA_X", System.Data.SqlDbType.Int)).Value = FISICA_X;
            Comando.Parameters.Add(new SqlParameter("@QUIMICA_X", System.Data.SqlDbType.Int)).Value = QUIMICA_X;
            Comando.Parameters.Add(new SqlParameter("@MATEMATICAS_XI", System.Data.SqlDbType.Int)).Value = MATEMATICAS_XI;
            Comando.Parameters.Add(new SqlParameter("@LENGUA_XI", System.Data.SqlDbType.Int)).Value = LENGUA_XI;
            Comando.Parameters.Add(new SqlParameter("@HISTORIA_IX", System.Data.SqlDbType.Int)).Value = HISTORIA_IX;
            Comando.Parameters.Add(new SqlParameter("@FISICA_XI", System.Data.SqlDbType.Int)).Value = FISICA_XI;
            Comando.Parameters.Add(new SqlParameter("@BIOLGIA_XI", System.Data.SqlDbType.Int)).Value = BIOLGIA_XI;



            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@SALIDA"].Value);

            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Est_Recudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Est_Recudiante; // retorno de la tabla
            return salida;
        }
        public DataTable MOSTRAR_PLAN_ESTUDIANTE(int usuario)
        {
            DataTable tabla_registro = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_PLAN_ESTUDIANTE"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.Int)).Value = usuario;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_registro); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_registro; // retorno de la tabla 
        }
        public DataTable MOSTRAR_ASIGNATURA_SEGUN_PLAN(int usuario,string curriculum)
        {
            DataTable tabla_registro = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_ASGINATURAS_SEGUN_PLAN"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.Int)).Value = usuario;
            Comando.Parameters.Add(new SqlParameter("@CURRICULUM", System.Data.SqlDbType.NVarChar)).Value = curriculum;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_registro); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_registro; // retorno de la tabla 
        }
        public DataTable MOSTRAR_CERTIFICADO(int usuario, string curriculum)
        {
            DataTable tabla_registro = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_CERTIFICADO_ALL"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.Int)).Value = usuario;
            Comando.Parameters.Add(new SqlParameter("@CURRICULUM", System.Data.SqlDbType.NVarChar)).Value = curriculum;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_registro); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_registro; // retorno de la tabla 
        }

        public DataTable Listada_Carrera()
        {
            DataTable tabla_registro = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_LISTA_CARRERA"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            //Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.Int)).Value = usuario;
            //Comando.Parameters.Add(new SqlParameter("@CURRICULUM", System.Data.SqlDbType.NVarChar)).Value = curriculum;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_registro); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_registro; // retorno de la tabla 
        }

        public int Insertar_Registro_Certificado(string carne,string usuario,string nombre)
        {
            int salida = 0;
            DataTable Tabla_Est_Rec_Recudiante = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_GUARDAR_REGISTRO_CERTIFICADO"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CARNE", System.Data.SqlDbType.VarChar)).Value = carne;
            //Comando.Parameters.Add(new SqlParameter("@CODIGO", System.Data.SqlDbType.VarChar)).Value = codigo;
            Comando.Parameters.Add(new SqlParameter("@NOMBRE", System.Data.SqlDbType.VarChar)).Value = nombre;
            Comando.Parameters.Add(new SqlParameter("@USUARIO", System.Data.SqlDbType.VarChar)).Value = usuario;

            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@SALIDA"].Value);

            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Est_Recudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Est_Recudiante; // retorno de la tabla
            return salida;
        }

        public void Insertar_Carrera_Certificado(string Carrera,int codigo)
        {
            //int salida = 0;
            //DataTable Tabla_Est_Rec_Recudiante = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_INSERTAR_CARRERA"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CARRRERA", System.Data.SqlDbType.VarChar)).Value = Carrera;
            Comando.Parameters.Add(new SqlParameter("@CODIGO", System.Data.SqlDbType.Int)).Value = codigo;
            //Comando.Parameters.Add(new SqlParameter("@USUARIO", System.Data.SqlDbType.VarChar)).Value = usuario;

            //Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            //salida = Convert.ToInt32(Comando.Parameters["@SALIDA"].Value);

            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Est_Recudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Est_Recudiante; // retorno de la tabla
                                             //return salida;
        }

        public void Insertar_Carrera_Pagina(int Codigo, int pagina)
        {
            //int salida = 0;
            //DataTable Tabla_Est_Rec_Recudiante = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_INSERTAR_PAGINAS"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CODIGO", System.Data.SqlDbType.Int)).Value = Codigo;
            Comando.Parameters.Add(new SqlParameter("@PAGINAS", System.Data.SqlDbType.Int)).Value = pagina;
            //Comando.Parameters.Add(new SqlParameter("@USUARIO", System.Data.SqlDbType.VarChar)).Value = usuario;

            //Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            //salida = Convert.ToInt32(Comando.Parameters["@SALIDA"].Value);

            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Est_Recudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Est_Recudiante; // retorno de la tabla
                                             //return salida;
        }
        public DataTable Ultimo_Certificado()
        {
            DataTable tabla_registro = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_ULTIMO_CERTIFICADO"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            //Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.Int)).Value = usuario;
            //Comando.Parameters.Add(new SqlParameter("@CURRICULUM", System.Data.SqlDbType.NVarChar)).Value = curriculum;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_registro); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_registro; // retorno de la tabla 
        }

        public int Insertar_Registro_Certificado_Other(string carne, string carrera,string usuario,int pagina,string nombre)
        {
            int salida = 0;
            DataTable Tabla_Est_Rec_Recudiante = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_GUARDAR_REGISTRO_CERTIFICADO_EMPTY"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CARNE", System.Data.SqlDbType.VarChar)).Value = carne;
            Comando.Parameters.Add(new SqlParameter("@NOMBRE", System.Data.SqlDbType.VarChar)).Value = nombre;
            Comando.Parameters.Add(new SqlParameter("@CARRERA", System.Data.SqlDbType.VarChar)).Value = carrera;
            Comando.Parameters.Add(new SqlParameter("@USUARIO", System.Data.SqlDbType.VarChar)).Value = usuario;
            Comando.Parameters.Add(new SqlParameter("@PAGINA", System.Data.SqlDbType.Int)).Value = pagina;
            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@SALIDA"].Value);

            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Est_Recudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Est_Recudiante; // retorno de la tabla
            return salida;
        }

        public DataTable Historial_Certificado()
        {
            DataTable tabla_registro = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_REGISTRO_CERTIFICADO"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            //Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.Int)).Value = usuario;
            //Comando.Parameters.Add(new SqlParameter("@CURRICULUM", System.Data.SqlDbType.NVarChar)).Value = curriculum;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_registro); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_registro; // retorno de la tabla 
        }

        public DataTable mostrar_usuarios()
        {
            DataTable tabla_usuarios = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "MOSTRAR_USUARIO_CONTRASEÑA"; //se pasa el procedimiento almancenado
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_usuarios); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_usuarios; // retorno de la tabla 
        }
        public void Actualizar_Usuario_password(string id, string usuario, string contraseña)
        {
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando.CommandText = "ACTUALIZANDO_USER_PASSWORD"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@People_Id", System.Data.SqlDbType.VarChar)).Value = id;
            Comando.Parameters.Add(new SqlParameter("@nickname", System.Data.SqlDbType.VarChar)).Value = usuario;
            Comando.Parameters.Add(new SqlParameter("@Contrasena", System.Data.SqlDbType.VarChar)).Value = contraseña;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            conexion.conexion_datos.Close(); // se cierra la conexion
        }
        public int BajaEstudiante(string usuario, string carne,string motivo,int opcion)
        {
            int salida = 0;
            DataTable Tabla_Estudiante = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_BAJA_MATRICULA"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CODE_USER", System.Data.SqlDbType.NVarChar)).Value = usuario;
            Comando.Parameters.Add(new SqlParameter("@CARNE", System.Data.SqlDbType.NVarChar)).Value = carne;
            Comando.Parameters.Add(new SqlParameter("@MOTIVO", System.Data.SqlDbType.NVarChar)).Value = motivo;
            Comando.Parameters.Add(new SqlParameter("@OPCION", System.Data.SqlDbType.Int)).Value = opcion;
            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@SALIDA"].Value);
            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Estudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Estudiante; // retorno de la tabla
            return salida;
        }

        public DataTable Historial_BajaMatricula()
        {
            DataTable tabla_registro = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRA_REGISTRO_BAJA"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            //Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.Int)).Value = usuario;
            //Comando.Parameters.Add(new SqlParameter("@CURRICULUM", System.Data.SqlDbType.NVarChar)).Value = curriculum;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_registro); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_registro; // retorno de la tabla 
        }
        public DataTable BuscarDatosEstudiantesReingreso(string id)
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_ESTUDIANTE_REINGRESO"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.NVarChar)).Value = id;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }

        public DataTable Todas_Asignaturas(int PeopleId)
        {
            DataTable tabla_registro = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_ASGINATURAS_TODAS"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.Int)).Value = PeopleId;
            //Comando.Parameters.Add(new SqlParameter("@CURRICULUM", System.Data.SqlDbType.NVarChar)).Value = curriculum;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_registro); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_registro; // retorno de la tabla 
        }

        public DataTable Buscar_Asignatura(int usuario, string asignatura)
        {
            DataTable tabla_registro = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_BUSCAR_ASIGNATURA"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.Int)).Value = usuario;
            Comando.Parameters.Add(new SqlParameter("@EVENT_ID", System.Data.SqlDbType.NVarChar)).Value = asignatura;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_registro); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_registro; // retorno de la tabla 
        }
        public DataTable PlanAcadamicoVerficado(int PeopleID)
        {
            DataTable tabla_registro = new DataTable(); //instancia de un ojeto de tipo datatable para recibir la tabla que devuelde el objeto sqldataadapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_PLAN_VERIFICADO"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@PEOPLE", System.Data.SqlDbType.Int)).Value = PeopleID;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(tabla_registro); // con el sqldataadapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return tabla_registro; // retorno de la tabla 
        }
    }
    public class Est_Recudiante_Campus
    {
        public String GOVERMENT_ID { get; set; }
        public String NAME01 { get; set; }
        public String NAME02 { get; set; }
        public String LASTANAME01 { get; set; }
        public String LASTANAME02 { get; set; }
        public int ID_ETNIA { get; set; }
        public String GENDER { get; set; }
        public int ID_MARITAL_STATUS { get; set; }
        public int ID_RELEGION { get; set; }
        public String ADDRES_COMPLETE { get; set; }
        public DateTime BIRTH_DATE { get; set; }
        public int ID_BIRTH_COUNTRY { get; set; }
        public int ID_COUNTRY_LIVE { get; set; }
        public int ID_DEPARTAMENTO { get; set; }
        public int ID_MUNICIPIO { get; set; }
        public String ADDRES_MAIL { get; set; }
        public String HOUSE_NUMBER { get; set; }
        public String PHONE01 { get; set; }
        public String P_DESCRIPTION01 { get; set; }
        public String PHONE02 { get; set; }
        public String P_DESCRIPTION02 { get; set; }
        public String PHONE03 { get; set; }
        public String P_DESCRIPTION03 { get; set; }
        public int PEOPLE_TYPE { get; set; }

        public int ID_CURRICULUM { get; set; }
        public String ACA_SESSION_P { get; set; }
    }
}
