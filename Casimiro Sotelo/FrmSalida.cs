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
    public partial class FrmSalida : Form
    {
        public FrmSalida()
        {
            InitializeComponent();
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
