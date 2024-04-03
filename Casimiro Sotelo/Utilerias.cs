using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNCSM
{
   public class Utilerias
    {
        //Funcion para evitar que se ingresen letras, solo numeros
       public void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni la tecla de retroceso, se ignora la tecla presionada
                e.Handled = true;
            }
        }

        //Metodo para filtrar filas de un GridView en base a un Texbox
        public DataView FiltrarDatos(string columnaFiltro, string filtro, DataTable Table)
        {   
                DataView dv = new DataView(Table);
                dv.RowFilter = $"{columnaFiltro} LIKE '%{filtro}%'";
                return dv;

        }
    }
}
