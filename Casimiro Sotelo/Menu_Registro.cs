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
    public partial class Menu_Registro : Form
    {
        string codigo_user = "";
        public Menu_Registro(string cedula)
        {
            InitializeComponent();
            codigo_user = cedula;
        }

        private void extningreso_Click(object sender, EventArgs e)
        {
            Frm_Equivalencias extningreso = new Frm_Equivalencias(codigo_user);
            extningreso.ShowDialog();
        }

        private void btnrectifi_Click(object sender, EventArgs e)
        {
            Frm_Otras_Notas_Reingreso notare = new Frm_Otras_Notas_Reingreso(codigo_user);
            notare.ShowDialog();
        }
    }
}
