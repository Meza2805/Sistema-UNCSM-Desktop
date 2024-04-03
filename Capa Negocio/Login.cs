using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;
using System.Data.SqlClient;
using Capa_Negocio;

namespace Capa_Negocio
{
    public class Login
    {
        campus bd = new campus();

        Acceso conexion = new Acceso();

        SqlCommand comando = new SqlCommand();

        public struct login
        {
            public int validacion;
            public string cedula;
            public String nombre;
            public String apellido;
            //public int rol;
        }

        public login verficar_login(string usser, string contra)
        {
            login l = new login();
            DataTable table =  bd.AccesoSistema(usser, contra);

            if (table.Columns.Count == 0)
            {
                l.nombre = "";
                l.cedula = "";
                l.apellido = "";
                l.validacion = 2;
               // l.rol = 0;
            }
            else
            {
                foreach (DataRow row in table.Rows)
                {
                    l.cedula = (Convert.ToString(row["PEOPLE_ID"]));
                    l.nombre = (Convert.ToString(row["PRIMER_NOMBRE"]));
                    l.apellido = (Convert.ToString(row["PRIMER_APELLIDO"]));
                    l.validacion = 3;
                  //  l.rol = (Convert.ToInt32(row["PRIMER_APELLIDO"]));
                }

            }






            //if (usser == "registro")
            //{
            //    if (contra == "1234")
            //    {
            //        l.validacion = 3;
            //        l.cedula = "";
            //        l.nombre = "Registro Academico";
            //        l.apellido = "";
            //    }
            //    else
            //    {
            //        l.validacion = 2;
            //        l.cedula = "";
            //        l.nombre = "Registro Academico";
            //        l.apellido = "";
            //    }
            //}
            //else
            //{
            //    l.validacion = 0;
            //    l.cedula = "";
            //    l.nombre = "Registro Academico";
            //    l.apellido = "";

            //}


        
           
            return l;  
         }

    }
}
