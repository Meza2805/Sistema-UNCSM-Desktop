using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos; // se agrega la refetencia de la capa datos

namespace Capa_Negocio
{
    public class CRUD_Cliente
    {
        Capa_Datos.Acceso02 conexion = new Capa_Datos.Acceso02(); //se instancia un objeto de tipo acceso
        private SqlCommand Comando; //objeto de tipo SqlCommand para los comandos de sql
        SqlDataAdapter Adaptador; //objeto de tipo sqlAdapter para convertir las tablas de sql y guardarlas en una tabla

        public DataTable Busca_Estudiante_Cedual(String Boleta,String cedula, int tipo)
        {
            DataTable Tabla_Estudiante = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_SHOW_STUDENT"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@ID_BOLETA", System.Data.SqlDbType.VarChar)).Value = Boleta;
            Comando.Parameters.Add(new SqlParameter("@CEDULA", System.Data.SqlDbType.VarChar)).Value = cedula;
            Comando.Parameters.Add(new SqlParameter("@TIPO", System.Data.SqlDbType.Int)).Value = tipo;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_Estudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_Estudiante; // retorno de la tabla 
        }

        public DataTable Mostrar_Etnia()
        {
            DataTable Tabla_Etnia = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_ETNIA"; //se pasa el procedimiento almancenado
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_Etnia); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_Etnia; // retorno de la tabla 
        }

        public DataTable Mostrar_Estado_Civil()
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_ESTADO_CIVIL"; //se pasa el procedimiento almancenado
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }

        public DataTable Mostrar_Sexo()
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_SEXO"; //se pasa el procedimiento almancenado
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }


        public DataTable Mostrar_Nacionalidad()
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_NACIONALIDAD"; //se pasa el procedimiento almancenado
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }

        public DataTable Mostrar_Instituciones_Estatales()
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_ESTADO"; //se pasa el procedimiento almancenado
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }


        public DataTable Mostrar_Departamento()
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_DEPARTAMENTO"; //se pasa el procedimiento almancenado
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }

        public DataTable Mostrar_Municipio(int ID_Departamento)
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_MUNICIPIO"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("ID_DEPARTAMENTO", System.Data.SqlDbType.Int)).Value = ID_Departamento;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }


        public DataTable Mostrar_Proveedor_Internet()
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRA_PROVEEDOR"; //se pasa el procedimiento almancenado
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }

        public DataTable Mostrar_Discapacidad()
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_DISCAPACIDAD"; //se pasa el procedimiento almancenado
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }

        public DataTable Mostrar_Tipo_Bachillerato()
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_BACHILLERATO"; //se pasa el procedimiento almancenado
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }

        public DataTable Mostrar_Centro_Estudios(int ID_Municipio)
        {
            DataTable Tabla = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_MOSTRAR_CENTRO"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@ID_MUNICIPO", System.Data.SqlDbType.Int)).Value = ID_Municipio;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla; // retorno de la tabla 
        }

        public int Insertar_Estudiante_Prematricula(string CEDULA,string NOMBRES, string PRIMER_APELLIDO,string SEGUNDO_APELLIDO,
	                                                int ID_GENERO ,DateTime  FECHA_NACMIENTO, int ID_ESTADO_CIVIL,int ID_DEPARTAMENTO,
	                                                int ID_MUNICIPIO, int ID_ETNIA,int ID_PROCEDENCIA, string TELF_CONVENCIONAL,
	                                                string TELF_CLARO, string TELF_TIGO, string DIRECCION, string BARRIO,
	                                                int ID_ESTATAL, int idcentroestudio, int idcarrera1, int idturno1,int Idanioegresado,
                                                     float promediogeneral, string centrootro,int idizquierdo, int idderecho,
	                                             int idSordera,  int idCeguera, int idDiscapacidadMotora, int  idTEA, int idTGHA,
                                                 int idMudezSord,int  IDNingunaDiscp,  int idcuentaaccesointernet,	int idproveedor,
        int idcuentacomputadora,
	    int idcuentacontablet,
        int idCelular,
		int IdTipoConexion,
        int MATEMATICAS_X,
		int LENGUA_X,
        int GEOGRAFIA_X,
		int FISICA_X ,
        int QUIMICA_X,
		int MATEMATICAS_XI,
        int LENGUA_XI,
		int HISTORIA_IX,
        int FISICA_XI,
		int BIOLGIA_XI )



        {
            int salida = 0;
            DataTable Tabla_Est_Rec_Recudiante = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_INSERT_PERSONA"; //se pasa el procedimiento almancenado
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@CEDULA", System.Data.SqlDbType.VarChar)).Value = CEDULA;
            Comando.Parameters.Add(new SqlParameter("@NOMBRES", System.Data.SqlDbType.VarChar)).Value = NOMBRES;
            Comando.Parameters.Add(new SqlParameter("@PRIMER_APELLIDO", System.Data.SqlDbType.VarChar)).Value = PRIMER_APELLIDO;
            Comando.Parameters.Add(new SqlParameter("@SEGUNDO_APELLIDO", System.Data.SqlDbType.VarChar)).Value = SEGUNDO_APELLIDO;
            Comando.Parameters.Add(new SqlParameter("@ID_GENERO", System.Data.SqlDbType.Int)).Value = ID_GENERO;
            Comando.Parameters.Add(new SqlParameter("@FECHA_NACMIENTO", System.Data.SqlDbType.DateTime)).Value = FECHA_NACMIENTO;
            Comando.Parameters.Add(new SqlParameter("@ID_ESTADO_CIVIL", System.Data.SqlDbType.Int)).Value = ID_ESTADO_CIVIL;
            Comando.Parameters.Add(new SqlParameter("@ID_DEPARTAMENTO", System.Data.SqlDbType.Int)).Value = ID_DEPARTAMENTO;
            Comando.Parameters.Add(new SqlParameter("@ID_MUNICIPIO", System.Data.SqlDbType.Int)).Value = ID_MUNICIPIO;
            Comando.Parameters.Add(new SqlParameter("@ID_ETNIA", System.Data.SqlDbType.Int)).Value = ID_ETNIA;
            Comando.Parameters.Add(new SqlParameter("@ID_PROCEDENCIA", System.Data.SqlDbType.Int)).Value = ID_PROCEDENCIA;
            Comando.Parameters.Add(new SqlParameter("@TELF_CONVENCIONAL", System.Data.SqlDbType.VarChar)).Value = TELF_CONVENCIONAL;
            Comando.Parameters.Add(new SqlParameter("@TELF_CLARO", System.Data.SqlDbType.VarChar)).Value = TELF_CLARO;
            Comando.Parameters.Add(new SqlParameter("@TELF_TIGO", System.Data.SqlDbType.VarChar)).Value = TELF_TIGO;
            Comando.Parameters.Add(new SqlParameter("@DIRECCION", System.Data.SqlDbType.VarChar)).Value = DIRECCION;
            Comando.Parameters.Add(new SqlParameter("@BARRIO", System.Data.SqlDbType.VarChar)).Value = BARRIO;
            Comando.Parameters.Add(new SqlParameter("@ID_ESTATAL", System.Data.SqlDbType.Int)).Value = ID_ESTATAL;
            Comando.Parameters.Add(new SqlParameter("@idcentroestudio", System.Data.SqlDbType.Int)).Value = idcentroestudio;
            Comando.Parameters.Add(new SqlParameter("@idcarrera1", System.Data.SqlDbType.Int)).Value = idcarrera1;
            Comando.Parameters.Add(new SqlParameter("@idturno1", System.Data.SqlDbType.Int)).Value = idturno1;
            Comando.Parameters.Add(new SqlParameter("@Idanioegresado", System.Data.SqlDbType.Int)).Value = Idanioegresado;
            Comando.Parameters.Add(new SqlParameter("@promediogeneral", System.Data.SqlDbType.Float)).Value = promediogeneral;
            Comando.Parameters.Add(new SqlParameter("@centrootro", System.Data.SqlDbType.VarChar)).Value = centrootro;
            Comando.Parameters.Add(new SqlParameter("@idizquierdo", System.Data.SqlDbType.Int)).Value = idizquierdo;
            Comando.Parameters.Add(new SqlParameter("@idderecho", System.Data.SqlDbType.Int)).Value = idderecho;
            Comando.Parameters.Add(new SqlParameter("@idSordera", System.Data.SqlDbType.Int)).Value = idSordera;
            Comando.Parameters.Add(new SqlParameter("@idCeguera", System.Data.SqlDbType.Int)).Value = idCeguera;
            Comando.Parameters.Add(new SqlParameter("@idDiscapacidadMotora", System.Data.SqlDbType.Int)).Value = idDiscapacidadMotora;
            Comando.Parameters.Add(new SqlParameter("@idTEA", System.Data.SqlDbType.Int)).Value = idTEA;
            Comando.Parameters.Add(new SqlParameter("@idTGHA", System.Data.SqlDbType.Int)).Value = idTGHA;
            Comando.Parameters.Add(new SqlParameter("@idMudezSord", System.Data.SqlDbType.Int)).Value = idMudezSord;
            Comando.Parameters.Add(new SqlParameter("@IDNingunaDiscp", System.Data.SqlDbType.Int)).Value = IDNingunaDiscp;
            Comando.Parameters.Add(new SqlParameter("@idcuentaaccesointernet", System.Data.SqlDbType.Int)).Value = idcuentaaccesointernet;
            Comando.Parameters.Add(new SqlParameter("@idproveedor", System.Data.SqlDbType.Int)).Value = idproveedor;
            Comando.Parameters.Add(new SqlParameter("@idcuentacomputadora", System.Data.SqlDbType.Int)).Value = idcuentacomputadora;
            Comando.Parameters.Add(new SqlParameter("@idcuentacontablet", System.Data.SqlDbType.Int)).Value = idcuentacontablet;
            Comando.Parameters.Add(new SqlParameter("@idCelular", System.Data.SqlDbType.Int)).Value = idCelular;
            Comando.Parameters.Add(new SqlParameter("@IdTipoConexion", System.Data.SqlDbType.Int)).Value = IdTipoConexion;
            Comando.Parameters.Add(new SqlParameter("@MATEMATICAS_XI", System.Data.SqlDbType.Int)).Value = MATEMATICAS_XI;
            Comando.Parameters.Add(new SqlParameter("@LENGUA_XI", System.Data.SqlDbType.Int)).Value = LENGUA_XI;
            Comando.Parameters.Add(new SqlParameter("@HISTORIA_IX", System.Data.SqlDbType.Int)).Value = HISTORIA_IX;
            Comando.Parameters.Add(new SqlParameter("@FISICA_XI", System.Data.SqlDbType.Int)).Value = FISICA_XI;
            Comando.Parameters.Add(new SqlParameter("@BIOLGIA_XI", System.Data.SqlDbType.Int)).Value = BIOLGIA_XI;
            Comando.Parameters.Add(new SqlParameter("@QUIMICA_X", System.Data.SqlDbType.Int)).Value = QUIMICA_X;
            Comando.Parameters.Add(new SqlParameter("@FISICA_X", System.Data.SqlDbType.Int)).Value = FISICA_X;
            Comando.Parameters.Add(new SqlParameter("@GEOGRAFIA_X", System.Data.SqlDbType.Int)).Value = GEOGRAFIA_X;
            Comando.Parameters.Add(new SqlParameter("@LENGUA_X", System.Data.SqlDbType.Int)).Value = LENGUA_X;
            Comando.Parameters.Add(new SqlParameter("@MATEMATICAS_X", System.Data.SqlDbType.Int)).Value = MATEMATICAS_X;

            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@SALIDA"].Value);
            return salida;

            //Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            //Adaptador.Fill(Tabla_Est_Recudiante); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
                                             //return Tabla_Est_Recudiante; // retorno de la tabla 

           

        }












































        public DataTable Mostrar_Cliente()
        {
            DataTable Tabla_Cliente = new DataTable(); //Instancia de un ojeto de tipo DataTable para recibir la tabla que devuelde el objeto SqlDataAdapter
            conexion.conexion_datos.Open(); //se abre la conexion para el comando
            Comando = new SqlCommand(); //instancia del objeto de tipo sqlcommando
            Comando.CommandText = "SP_Mostrar_Clientes"; //se pasa el procedimiento almancenado
            Comando.Connection = conexion.conexion_datos; // se abre la conexion para el comando
            Adaptador = new SqlDataAdapter(Comando); //se reciebe la tabla producto de la ejecucion del procedimiento
            Adaptador.Fill(Tabla_Cliente); // con el SqlDataAdapter se llena la tabla
            conexion.conexion_datos.Close(); // se cierra la conexion
            return Tabla_Cliente; // retorno de la tabla 
        }

        public bool Insertar_Cliente(String Cedula, String PNombre, String SNombre, String PApellido, String SApellido, Char Sexo, String Fecha)
        {
            int salida;
            conexion.conexion_datos.Open();
            Comando = new SqlCommand();
            Comando.CommandText = "SP_Insertar_Cliente";
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@Cedula_Cliente", System.Data.SqlDbType.VarChar)).Value = Cedula;
            Comando.Parameters.Add(new SqlParameter("@Primer_Nombre", System.Data.SqlDbType.VarChar)).Value = PNombre;
            Comando.Parameters.Add(new SqlParameter("@Segundo_Nombre", System.Data.SqlDbType.VarChar)).Value = SNombre;
            Comando.Parameters.Add(new SqlParameter("@Primer_Apellido", System.Data.SqlDbType.VarChar)).Value = PApellido;
            Comando.Parameters.Add(new SqlParameter("@Segundo_Apellido", System.Data.SqlDbType.VarChar)).Value = SApellido;
            Comando.Parameters.Add(new SqlParameter("@Sexo", System.Data.SqlDbType.Char)).Value = Sexo;
            Comando.Parameters.Add(new SqlParameter("@Fecha_Nac", System.Data.SqlDbType.Date)).Value = Fecha;
            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos; //Establece la conexio al objeto comando
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@salida"].Value);
            conexion.conexion_datos.Close();
            if (salida == 0)
            {
                return true;
            }
            else return false;
        }
        public bool Eliminar_Cliente(String Cedula)
        {
            int salida;
            conexion.conexion_datos.Open();
            Comando = new SqlCommand();
            Comando.CommandText = "SP_Eliminar_Cliente";
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@Cedula", System.Data.SqlDbType.VarChar)).Value = Cedula;
            Comando.Parameters.Add("@salida", SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos;
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@salida"].Value);
            conexion.conexion_datos.Close();
            if (salida == 1)
            {
                return true;
            }
            else return false;
        }

        public struct Cantidad
        {
            public int activo;
            public int inactivo;
            public int total;
        }
        public Cantidad Cantidad_Cliente()
        {
            Cantidad c = new Cantidad();
            conexion.conexion_datos.Open();
            Comando = new SqlCommand();
            Comando.CommandText = "SP_Cantidad_Cliente";
            Comando.CommandType= System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add("@inactivo",SqlDbType.Int).Direction=ParameterDirection.Output;
            Comando.Parameters.Add("@activo",SqlDbType.Int).Direction=ParameterDirection.Output;
            Comando.Parameters.Add("@total",SqlDbType.Int).Direction=ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos;
            Comando.ExecuteNonQuery();
            c.activo = Convert.ToInt32(Comando.Parameters["@activo"].Value);
            c.inactivo = Convert.ToInt32(Comando.Parameters["@inactivo"].Value);
            c.total = Convert.ToInt32(Comando.Parameters["@total"].Value);
            conexion.conexion_datos.Close();
            return c;
        }
      /*  struct Cliente
        {
            String Primer_Nombre;
            String Segundo_Nombre;
            String Primer_Apellido;
            String Segundo_Apellido;
            char Sexo;
            DateTime Fecha_Nac;
            DateTime Fecha_Registro;
            char Estado;
        }*/

        public bool Actualizar_cliente(String Cedula, String PNombre, String SNombre, String PApellido, String SApellido, Char Sexo, String Fecha)
        {
            int salida;
            bool band = false;
            conexion.conexion_datos.Open();
            Comando = new SqlCommand();
            Comando.CommandText = "SP_Actualizar_Cliente";
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.Parameters.Add(new SqlParameter("@Cedula_Cliente", System.Data.SqlDbType.VarChar)).Value = Cedula;
            Comando.Parameters.Add(new SqlParameter("@Primer_Nombre", System.Data.SqlDbType.VarChar)).Value = PNombre;
            Comando.Parameters.Add(new SqlParameter("@Segundo_Nombre", System.Data.SqlDbType.VarChar)).Value = SNombre;
            Comando.Parameters.Add(new SqlParameter("@Primer_Apellido", System.Data.SqlDbType.VarChar)).Value = PApellido;
            Comando.Parameters.Add(new SqlParameter("@Segundo_Apellido",System.Data.SqlDbType.VarChar)).Value= SApellido;
            Comando.Parameters.Add(new SqlParameter("@Sexo",System.Data.SqlDbType.Char)).Value=Sexo;
            Comando.Parameters.Add(new SqlParameter("@Fecha_Nac",System.Data.SqlDbType.Date)).Value = Fecha;
            Comando.Parameters.Add("@salida",SqlDbType.Int).Direction = ParameterDirection.Output;
            Comando.Connection = conexion.conexion_datos;
            Comando.ExecuteNonQuery();
            salida = Convert.ToInt32(Comando.Parameters["@salida"].Value);
            conexion.conexion_datos.Close();
            if (salida == 0)
            {
                band = true;
            }
            return band;
        }
    }
}
