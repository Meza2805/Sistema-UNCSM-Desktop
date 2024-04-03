using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;

namespace Ginmasio
{
    public partial class Mensaje_Suscripcion : Form
    {
     
        public static string memb;
        public Mensaje_Suscripcion()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Registro vtn_sus = Owner as Frm_Registro;
            //vtn_sus.txtCedula.Clear();
            //vtn_sus.txtPrimerNombre.Clear();
            //vtn_sus.txtSegundoNombre.Clear();
            //vtn_sus.txtPrimerApellido.Clear();
            //vtn_sus.txtSegundoApellido.Clear();
            //vtn_sus.Cargar_registro_sus();
            //vtn_sus.dgvClientes.Rows.Clear();
            this.Close();
        }

        private void lbBienvenida_Click(object sender, EventArgs e)
        {

        }
    }
}
