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
    public partial class Mensaje_Exito : Form
    {
     
        public static string memb;
        public Mensaje_Exito()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       


    }
}
