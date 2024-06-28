using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNCSM;

namespace Ginmasio
{
    public partial class Frm_Docente : Form
    {

     
        campus insertar = new campus();
        CRUD_Cliente prematricula = new CRUD_Cliente();
        Mensaje_Suscripcion mensaje = new Mensaje_Suscripcion();
        CRUD_GDocentes Mostrar_rol = new CRUD_GDocentes();
        DataTable tbl_Departamento = new DataTable(); //DataTable para almacenar los departamentos
        DataTable tbl_Departamento02 = new DataTable(); //DataTable para almacenar los departamentos
        DataTable tbl_Municipio = new DataTable();  //DataTable para almacenar los municipios en base al ID de cada Departamento
        DataTable tbl_Municipio02 = new DataTable();
        Frm_Alerta mensaje_02 = new Frm_Alerta();
        Frm_Mensaje_Advertencia mensaje01;
        DataTable tabla_rol = new DataTable();
        
        //Variables Goblales********************************************
        public static string @GOVERMENT_ID,@PREFIX, @NAME01, @NAME02, @LASTNAME01, @LASTNAME02, @GENDER, @ADDRES_COMPLETE, @ADDRES_MAIL, @PHONE01, @P_DESCRIPTION01, @PHONE02, @P_DESCRIPTION02, @PHONE03, @P_DESCRIPTION03,@INSS;

        private void Frm_Docente_Load(object sender, EventArgs e)
        {

        }

        public static int @ID_ETNIA, @ID_MARITAL_STATUS, @ID_REGLIGION, @ID_BIRTH_COUNTRY, @ID_COUNTRY_LIVE, @ID_DEPARTMENTO, @ID_MUNICIPIO, @PEOPLE_TYPE;

      

        public static DateTime @BIRTH_DATE;

        private void txtinss_leave(object sender, EventArgs e)
        {
            // Expresión regular para validar números enteros de 9 dígitos
            string patron = @"^\d{9}$"; // ^ indica el inicio de la cadena, \d representa un dígito, {9} indica que debe haber exactamente 9 dígitos, $ indica el final de la cadena

            // Creamos una instancia de Regex con la expresión regular
            Regex regex = new Regex(patron);

            // Comprobamos si el input coincide con el patrón
            if (regex.IsMatch(txtinss.Text))
            {
                // El input es válido
                // Puedes colocar aquí cualquier acción adicional que necesites realizar cuando el INSS es válido
            }
            else
            {
                // El input no es válido
                Frm_Mensaje_Advertencia mensaje = new Frm_Mensaje_Advertencia("El formato de INSS es incorrecto. Debe contener exactamente 9 dígitos.");
                mensaje.ShowDialog();
                txtinss.Clear();
                txtinss.Focus();
            }
        }


        private void btnvalidar_Click(object sender, EventArgs e)
        {
            if (ValidarCamposTab01() == true)
            {
                btnguardar.Enabled=true;
                mensaje01 = new Frm_Mensaje_Advertencia("Datos validados correctamente");
                mensaje01.ShowDialog();
            }
            else
            {
                Frm_Mensaje_Advertencia mensaje = new Frm_Mensaje_Advertencia("¡CAMPOS INCOMPLETOS!");
                mensaje.ShowDialog();
            }
        }

        public static String genero = "";
        public Frm_Docente()
        {
            InitializeComponent();
            llenar_cbSexo();
            llenar_cbestadocivil();
            llenar_cbnivelacademico();
            llenar_rol();
            llenar_Departamento();
            txtConvencional.MaxLength = 8;
            txtClaro.MaxLength = 8;
            txtTigo.MaxLength = 8;
            txtTigo.KeyPress += txtTigo_KeyPress;
            txtConvencional.KeyPress += txtConvencional_KeyPress;
            txtClaro.KeyPress += txtClaro_KeyPress;
        }

       
        private void btnguardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

     
       
        void guardar()
        {

          
            int salida = 0;
            @P_DESCRIPTION01 = "CLARO";
            @PHONE02 = txtTigo.Text;
            @P_DESCRIPTION02 = "TIGO";
            @PHONE03 = txtConvencional.Text;
            @P_DESCRIPTION03 = "CONVENCIONAL";
            @PHONE01 = txtClaro.Text;
            @ID_BIRTH_COUNTRY = 404;
            @ID_COUNTRY_LIVE = 404;
            @ID_REGLIGION = 1002;
            @GOVERMENT_ID = txtCedula.Text;
            @PREFIX = cbnivelacademico.Text;
            @NAME01 = txtPrimer_Nombre.Text;
            @NAME02 = txtSegundo_Nombre.Text;
            @LASTNAME01 = txtPrimerApellido.Text;
            @LASTNAME02 = txtSegundoApellido.Text;
            @ID_ETNIA = 1007;
            if (cbSexo.Text == "FEMENINO")
            {
                genero = "F";
            }else
            {
                genero = "M";
            }
            @GENDER = genero;
            @ADDRES_COMPLETE = txtDireccion.Text;
            @ADDRES_MAIL = txtMail.Text;

            //tabla_rol
            String rol = cbtipousuario.Text;
            foreach (DataRow row in tabla_rol.Rows)
            {
                if (rol == Convert.ToString(row["TIPO_ROL"]))
                {
                    @PEOPLE_TYPE = Convert.ToInt32(row["ID_USUARIO"]);
                }
               
            }


           
            @BIRTH_DATE = Convert.ToDateTime(DtpFecha_Nac.Text);
            @INSS = txtinss.Text;
          

            try
            {
                salida = insertar.Insertar_Usuario(@GOVERMENT_ID, @PREFIX, @NAME01, @NAME02, @LASTNAME01, @LASTNAME02, @ID_ETNIA, @GENDER, @ID_MARITAL_STATUS, @ID_REGLIGION, @ADDRES_COMPLETE, @BIRTH_DATE, @ID_BIRTH_COUNTRY, @ID_COUNTRY_LIVE, @ID_DEPARTMENTO, @ID_MUNICIPIO, @ADDRES_MAIL, @PHONE01, @P_DESCRIPTION01, @PHONE02, @P_DESCRIPTION02, @PHONE03, @P_DESCRIPTION03, @PEOPLE_TYPE, @INSS);

                // Verificar el valor de salida y mostrar mensajes según corresponda
                if (salida == 1)
                {
                    mensaje.ShowDialog(); // Mostrar mensaje de éxito
                }
                else
                {
                    mensaje_02.ShowDialog(); // Mostrar otro mensaje de error
                }
            }
            catch (Exception ex)
            {
                string mensajePersonalizado = "NO SE PUEDE REGISTRAR AL USUARIO, COMUNÍQUESE CON EL ÁREA DE SISTEMAS UNCSM";
                MessageBox.Show(mensajePersonalizado);
         
            }

            //MessageBox.Show("OPERACION FINALIZADA");

            limpiar_texbox();

        }

        void llenar_Departamento()
        {

            tbl_Departamento.Clear();
            tbl_Departamento = prematricula.Mostrar_Departamento();
            foreach (DataRow row in tbl_Departamento.Rows)
            {
                cbDepartamento.Items.Add(Convert.ToString(row["Nombre"]));
            }


            // Establecer el modo de autocompletado
            cbDepartamento.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbDepartamento.AutoCompleteSource = AutoCompleteSource.ListItems;

            tbl_Departamento.Clear();
            tbl_Departamento = prematricula.Mostrar_Departamento();
            foreach (DataRow row in tbl_Departamento.Rows)
            {
                cbDepartamento.Items.Add(Convert.ToString(row["Nombre"]));
            }

           
        }

        void llenar_rol()
        {
            tabla_rol = Mostrar_rol.Mostrar_Roles();

            // Limpiamos el ComboBox antes de agregar elementos
            cbtipousuario.Items.Clear();

            foreach (DataRow row in tabla_rol.Rows)
            {
                cbtipousuario.Items.Add(Convert.ToString(row["TIPO_ROL"]));
            }

        }


        public void llenar_cbSexo()
        {
            cbSexo.Text = "Sexo";
            //cbSexo.Items.Add("--------------");
            cbSexo.Items.Add("FEMENINO");
            cbSexo.Items.Add("MASCULINO");
        }

        public void llenar_cbestadocivil()
        {
            cbestadocivil.Text = "Estado Civil";
            //cbSexo.Items.Add("--------------");
            cbestadocivil.Items.Add("SOLTER@");
            cbestadocivil.Items.Add("CASAD@");
            cbestadocivil.Items.Add("VIUD@");
            cbestadocivil.Items.Add("DIVORCIAD@");
            cbestadocivil.Items.Add("UNIÒN LIBRE");
        }

        public void llenar_cbnivelacademico()
        {
            cbnivelacademico.Text = "Titulo";
            cbnivelacademico.Items.Add("Lic.");
            cbnivelacademico.Items.Add("Msc.");
            cbnivelacademico.Items.Add("Tec.");
            cbnivelacademico.Items.Add("Arq.");
            cbnivelacademico.Items.Add("Ing.");
        }


        public void limpiar_texbox()
        {
            txtCedula.Clear();
            txtPrimer_Nombre.Clear();
            txtSegundo_Nombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            cbDepartamento.SelectedIndex = -1; ;
            cbMunicipio.SelectedIndex = -1;
            txtDireccion.Clear();
            txtConvencional.Clear();
            txtClaro.Clear();
            txtTigo.Clear();
            txtMail.Clear();
            txtinss.Clear();

            DtpFecha_Nac.Text = "";
            cbSexo.SelectedIndex = -1;
            cbestadocivil.SelectedIndex = -1;
            cbnivelacademico.SelectedIndex = -1;
            cbtipousuario.SelectedIndex = -1;
        }
        private void txtCedula_Leave(object sender, EventArgs e)
        {
            // Expresión regular para validar números enteros positivos
            string patron = @"^\d{13}[A-Za-z]$";

            // Creamos una instancia de Regex con la expresión regular
            Regex regex = new Regex(patron);


            mensaje01 = new Frm_Mensaje_Advertencia("El formato de cèdula es incorrecto");

            // Comprobamos si el input coincide con el patrón
            if (regex.IsMatch(txtCedula.Text))
            {

                //MessageBox.Show("El input es válido."); // Si coincide, el input es válido
            }
            else
            {
                /// MessageBox.Show("El input no es válido."); // Si no coincide, el input no es válido
                mensaje01.ShowDialog();
                //txtCedula.Clear();
                txtCedula.Focus();
            }

        }

      

        private void txtTigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }

        private void txtConvencional_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }
        private void txtClaro_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }


        void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni la tecla de retroceso, se ignora la tecla presionada
                e.Handled = true;
            }
        }
        // validando todos los campos //
        public bool ValidarCamposTab01()
        {
            bool bandera = true;

            // Llamadas a las funciones para validar cada campo
            if (false == ValidarCampo(txtCedula, epCedula, "INGRESE CÉDULA, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = false;
            }
            if (false == ValidarCampo(txtinss, epinss, "INGRESE NO INSS, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = false;
            }
            if (false == ValidarComboBox(cbtipousuario, epUsuario, "INGRESE TIPO DE USUARIO, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = false;
            }
            if (false == ValidarCampo(txtPrimer_Nombre, epCedula, "INGRESE PRIMER NOMBRE, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = false;
            }
            if (false == ValidarCampo(txtPrimerApellido, epPrimerApellido, "INGRESE PRIMER APELLIDO, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = false;
            }
            
            if (false == ValidarComboBox(cbSexo, epSexo, "SELECCIONE SEXO, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = true;
            }
            if (false == ValidarComboBox(cbDepartamento, epDepartamento, "SELECCIONE DEPARTAMENTO, ¡ES UN CAMPO OBLIGATORIO!"))
            { bandera = false; }
            if (false == ValidarComboBox(cbMunicipio, epMunicipio, "SELECCIONE MUNICIPIO, ¡ES UN CAMPO OBLIGATORIO!"))
            { bandera = false; }
            if (false == ValidarCampo(txtDireccion, epDireccion, "INGRESE DIRECCION, ¡ES UN CAMPO OBLIGATORIO!"))
            { bandera = false; }
            
            if (false == ValidarComboBox(cbestadocivil, epEstadoCivil, "SELECCIONE ESTADO CIVIL, ¡ES UN CAMPO OBLIGATORIO!"))
            { bandera = false; }

            return bandera;
        }

        bool ValidarCampo(TextBoxBase control, ErrorProvider errorProvider, string mensajeError)
        {
            bool bandera = true;
            if (control.Text == string.Empty)
            {
                errorProvider.SetError(control, mensajeError);
                bandera = false;
            }
            else
            {
                errorProvider.Clear();
                bandera = true;
            }
            return bandera;
        }

        bool ValidarComboBox(ComboBox control, ErrorProvider errorProvider, string mensajeError)
        {
            bool bandera = true;
            if (control.SelectedIndex == -1)
            {
                errorProvider.SetError(control, mensajeError);
                bandera = false;
            }
            else
            {
                errorProvider.Clear();
            }
            return bandera;
        }


        private void cbDepartamento_TextChanged(object sender, EventArgs e)
        {
            cbDepartamento.Text = cbDepartamento.Text.ToUpper();
            // Mover el cursor al final del texto
            cbDepartamento.SelectionStart = cbDepartamento.Text.Length;
        }


        private void cbDepartamento_SelectedValueChanged(object sender, EventArgs e)
        {
            //se utiliza este evento para encontrar el departemanto seleccionado y asi obtener los municipios de dicho departamento
            string departamento;
            departamento = cbDepartamento.Text;

            foreach (DataRow row in tbl_Departamento.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == departamento)
                {
                    tbl_Municipio = prematricula.Mostrar_Municipio(Convert.ToInt32(row["id"]));
                }
            }

            cbMunicipio.Items.Clear();
            cbMunicipio.Text = "";
            foreach (DataRow row in tbl_Municipio.Rows)
            {
                cbMunicipio.Items.Add(Convert.ToString(row["Nombre"]));
            }
            // Establecer el modo de autocompletado
            cbMunicipio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMunicipio.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
       


    }
}
