using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;
using Capa_Negocio;
using UNCSM;

namespace UNCSM
{
    public partial class FrmPaginas : Form
    {
        campus BD = new campus();
        int codigo_rev = 0;
        public FrmPaginas(int codigo)
        {
            InitializeComponent();
            codigo_rev = codigo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPagina.Text == string.Empty)
            {
                MessageBox.Show("DEBE INGRESAR UN VALOR!");
            }
            else
            {
                BD.Insertar_Carrera_Pagina(codigo_rev,Convert.ToInt32(txtPagina.Text));
                this.Close();
            }
        }

        private void txtPagina_KeyPress(object sender, KeyPressEventArgs e)
        {
          
                // Verificar si la tecla presionada es un número o la tecla de retroceso (backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    // Si no es un número ni la tecla de retroceso, se ignora la tecla presionada
                    e.Handled = true;
                }
           
        }
    }
}
