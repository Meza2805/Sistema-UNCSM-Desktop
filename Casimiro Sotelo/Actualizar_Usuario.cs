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

namespace UNCSM
{
    public partial class Actualizar_Usuario : Form
    {
        campus bd = new campus();
        DataTable Tabla = new DataTable();
        public Actualizar_Usuario()
        {
            InitializeComponent();
            llenar();
            cbSexo.Items.Add("MASCULINO");
            cbSexo.Items.Add("FEMENINO");
        }

        Frm_Mensaje_Advertencia mensaje;

        void llenar()
        {
            Tabla = bd.Mostrar_listado_2024();
            dgvMatricula.DataSource = Tabla;
        }
         
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            String filtro = txtBusqueda.Text;
            DataView dv = new DataView(Tabla);
            dv.RowFilter = $"PRIMER_NOMBRE LIKE '%{filtro}%'";
            dgvMatricula.DataSource = dv;
        }

        private void dgvMatricula_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMatricula.CurrentRow != null)
            {
                txtCedula.Clear();
                txtCedula.Clear();
                txtPrimerNombre.Clear();
                txtSegundoNombre.Clear();
                txtPrimerApellido.Clear();
                txtSegundoApellido.Clear();

                txtCedula.Text = dgvMatricula.CurrentRow.Cells[0].Value.ToString();
                txtPrimerNombre.Text = dgvMatricula.CurrentRow.Cells[1].Value.ToString();
                txtSegundoNombre.Text = dgvMatricula.CurrentRow.Cells[2].Value.ToString();
                txtPrimerApellido.Text = dgvMatricula.CurrentRow.Cells[3].Value.ToString();
                txtSegundoApellido.Text = dgvMatricula.CurrentRow.Cells[4].Value.ToString();
                cbSexo.Text = dgvMatricula.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna fila");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            bloquear(false);
            string s = "";
            string cedula = txtCedula.Text, primer_nombre = txtPrimerNombre.Text, segundo_nombre = txtSegundoNombre.Text, primer_apellido = txtPrimerApellido.Text, segundo_apellido = txtSegundoApellido.Text;

             if (cbSexo.Text == "MASCULINO")
            {
                s = "M";
            }  else
            { s = "F"; }

            bd.Actualizar_Usuario(cedula,  primer_nombre,segundo_nombre ,primer_apellido,segundo_apellido,s);
            llenar();
            bloquear(true);
            mensaje = new Frm_Mensaje_Advertencia("USUARIO ACTUALIZADO");
            mensaje.ShowDialog();
            
       
        }


        void bloquear(bool bandera)
        {
            this.Enabled = bandera;
            txtBusqueda.Enabled = bandera;
            txtPrimerApellido.Enabled = bandera;
            txtPrimerNombre.Enabled = bandera;
            txtSegundoNombre.Enabled = bandera;
            txtPrimerNombre.Enabled = bandera;
            cbSexo.Enabled = bandera;
            dgvMatricula.Enabled = bandera;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            llenar();
        }
    }
}
