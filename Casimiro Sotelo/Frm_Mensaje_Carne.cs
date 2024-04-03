using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNCSM
{
    public partial class Frm_Mensaje_Carne : Form
    {
        public Frm_Mensaje_Carne(String Mensaje, String Cedula)
        {
            InitializeComponent();
            lbMensaje.Text = Mensaje;
            txtCarne.Text = Cedula;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCarne_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
