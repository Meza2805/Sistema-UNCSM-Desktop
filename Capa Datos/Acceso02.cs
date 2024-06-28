using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    /*CONEXION A PREMATRICULA*/
    public class Acceso02
    {


        // private String Cadena = "Persist Security Info=False;User ID=SA;Password=R2d2sc3sc42016;Initial Catalog=Prematricula;Server=172.16.3.10";

        //  private String Cadena = "Persist Security Info=False;User ID=sa;Password=R2d2sc3sc42016;Initial Catalog=Prematricula;Server=172.16.3.38";
        private String Cadena = "Data Source=LEONELC;Initial Catalog=prematricula; Integrated Security=True";
        //private String Cadena = "Persist Security Info=False;User ID=sa;Password=meza93;Initial Catalog=Prematricula;Server=DESKTOP-AE7Q4HD\\SQLSERVER_LOCAL";
        public SqlConnection conexion_datos; // se declara una objeto de tipo SqlConnection para establecer la conexion

        public Acceso02() //dentro del constructo llamamos al metodo de conexion
        {
            conectar();
        }

        public void conectar()
        {
            conexion_datos = new SqlConnection(Cadena);// se instancia el objeto de tipo conexion agregando como parametro la cadena de conexion
        }
    }
}
