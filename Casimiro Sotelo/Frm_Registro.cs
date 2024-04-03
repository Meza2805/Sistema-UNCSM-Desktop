using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;

namespace Ginmasio
{
    public partial class Frm_Registro : Form
    {
        campus campo = new campus();
        CRUD_Cliente Estuante_Prematricua = new CRUD_Cliente();
        DataTable Tabla_02 = new DataTable();





        public Frm_Registro(DataTable Tabla)
        {
            //DataTable Contar = new DataTable();
            InitializeComponent();
            Tabla_02 = Tabla;
            dgvRegistro.DataSource = Tabla_02;
        }
   

        private void dgvRegistro_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRegistro.CurrentRow != null)
            {
                txtCarne.Text = dgvRegistro.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna fila");
            }


              
          



        }

        //private void btnCargar_Click(object sender, EventArgs e)
        //{
        //    // Deshabilita el botón de inicio mientras se ejecuta la tarea
        //    btnCargar.Enabled = false;

        //    // Configura la barra de progreso
        //    progressBar1.Minimum = 0;
        //    progressBar1.Maximum = 100;
        //    progressBar1.Value = 0;

        //    // Inicia la tarea en un hilo separado para no bloquear la interfaz de usuario
        //    Thread tareaThread = new Thread(new ThreadStart(RealizarTarea));
        //    tareaThread.Start();


        //     void RealizarTarea()
        //    {
        //        // Simula una tarea que lleva tiempo
        //        for (int i = 0; i <= 100; i++)
        //        {
        //            // Actualiza la barra de progreso desde el hilo de la interfaz de usuario
        //            this.Invoke((MethodInvoker)delegate
        //            {
        //                progressBar1.Value = i;
        //            });

        //            // Simula una pausa en la tarea
        //            Thread.Sleep(50);
        //        }

        //        // Habilita el botón después de que la tarea haya terminado
        //        this.Invoke((MethodInvoker)delegate
        //        {
        //            btnCargar.Enabled = true;
        //            progressBar1.Visible = false;
        //        });
        //    }
        //}

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            String filtro = txtBusqueda.Text;
            DataView dv = new DataView(Tabla_02);
            dv.RowFilter = $"NOMBRE LIKE '%{filtro}%'";
            dgvRegistro.DataSource = dv;
        }

        private void txtBusqueda_TextChanged_1(object sender, EventArgs e)
        {
            String filtro = txtBusqueda.Text;
            DataView dv = new DataView(Tabla_02);
            dv.RowFilter = $"NOMBRE LIKE '%{filtro}%'";
            dgvRegistro.DataSource = dv;
        }

        private void dgvRegistro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
