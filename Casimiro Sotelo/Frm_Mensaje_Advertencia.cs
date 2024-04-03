﻿using System;
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
    public partial class Frm_Mensaje_Advertencia : Form
    {
        public Frm_Mensaje_Advertencia(String mensaje)
        {
            InitializeComponent();
            lbMensaje.Text = mensaje.ToUpper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
