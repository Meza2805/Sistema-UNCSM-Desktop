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

namespace Ginmasio
{
    public partial class Matricula : Form
    {
        CRUD_Cliente prematricula = new CRUD_Cliente();
        campus campusBD = new campus();
        DataTable tbl_Departamento = new DataTable(); //DataTable para almacenar los departamentos
        DataTable tbl_Departamento02 = new DataTable(); //DataTable para almacenar los departamentos
        DataTable tbl_Municipio = new DataTable();  //DataTable para almacenar los municipios en base al ID de cada Departamento
        DataTable tbl_Municipio02 = new DataTable();  //DataTable para almacenar los municipios en base al ID de cada Departamento
        DataTable tbl_Centro_Estudios = new DataTable();  //DataTable para almacenar los centros de estudios segun cada municipio
        DataTable tbl_Etnia = new DataTable();
        DataTable tbl_Discapacidad = new DataTable();
        DataTable tbl_Bachillerato = new DataTable();
        DataTable tbl_Carrera = new DataTable();
        DataTable tbl_area = new DataTable();
        DataTable tbl_Matricula_Consolidado = new DataTable();
        DataTable tbl_nacionalidad;
        DataTable tbl_Instituciones_Estatles = new DataTable();
        DataTable tbl_Estado_Marital = new DataTable();
        DataTable turno;
        DataTable tbl_Sexo = new DataTable();
        Estudiante Est = new Estudiante();
        Frm_Mensaje_Advertencia mensaje;
        DataTable dtProveedor = new DataTable();
        int salida = 0;

        public Matricula() //Constructor
        {
            InitializeComponent();
            llenar_etnia();
            llenar_Estado_Civil();
            llenar_Sexo();
            llenar_Departamento();
            llenar_Departamento02();
            llenar_mano();
            llenarAccesoInternet();
            llenarDiscapacidad();
            llenarTipoBachillerato();
            llenar_anio();
            llenar_turno(1);
            llenar_Area();
            llenar_matricula();
            llenar_Nacionalidad();
            llenar_Instituciones_Estatales();

            txtCedula.TextChanged += ConvertirAMayusculas;
            txtPrimerNombre.TextChanged += ConvertirAMayusculas;
            txtPrimerApellido.TextChanged += ConvertirAMayusculas;
          
        }




        //==================================EVENTOS==================================   ---->  INCIO

        private void txtMat4_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }

        private void txtLL4_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }

        private void txtGeo4_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }

        private void txtFis4_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }

        private void txtQuimi4_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }

        private void txtMat4_Leave(object sender, EventArgs e)
        {
            if (Valida_Nota(txtMat4.Text) == false)
            {
                txtMat4.Clear();
                txtMat4.Focus();
            }
        }

        private void txtLL4_Leave(object sender, EventArgs e)
        {
            if (Valida_Nota(txtLL4.Text) == false)
            {
                txtLL4.Clear();
                txtLL4.Focus();
            }
        }

        private void txtGeo4_Leave(object sender, EventArgs e)
        {
            if (Valida_Nota(txtGeo4.Text) == false)
            {
                txtGeo4.Clear();
                txtGeo4.Focus();
            }
        }

        private void txtFis4_Leave(object sender, EventArgs e)
        {
            if (Valida_Nota(txtFis4.Text) == false)
            {
                txtFis4.Clear();
                txtFis4.Focus();
            }
        }

        private void txtQuimi4_Leave(object sender, EventArgs e)
        {
            if (Valida_Nota(txtQuimi4.Text) == false)
            {
                txtQuimi4.Clear();
                txtQuimi4.Focus();
            }
        }

        private void txtMat5_Leave(object sender, EventArgs e)
        {
            if (Valida_Nota(txtMat5.Text) == false)
            {
                txtMat5.Clear();
                txtMat5.Focus();
            }
        }

        private void txtLL5_Leave(object sender, EventArgs e)
        {
            if (Valida_Nota(txtLL5.Text) == false)
            {
                txtLL5.Clear();
                txtLL5.Focus();
            }
        }

        private void txtHistoria5_Leave(object sender, EventArgs e)
        {
            if (Valida_Nota(txtHistoria5.Text) == false)
            {
                txtHistoria5.Clear();
                txtHistoria5.Focus();
            }
        }

        private void txtFisica5_Leave(object sender, EventArgs e)
        {
            if (Valida_Nota(txtFisica5.Text) == false)
            {
                txtFisica5.Clear();
                txtFisica5.Focus();
            }
        }

        private void txtQuimi5_Leave(object sender, EventArgs e)
        {
            if (Valida_Nota(txtQuimi5.Text) == false)
            {
                txtQuimi5.Clear();
                txtQuimi5.Focus();
            }
            else
            {
                Calcular_Promedio();
            }

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

        private void cbAccesoInternet_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbAccesoInternet.Text == "NO")
            {

                cbProveedor.Enabled = false;
                cbTipoConexion.Enabled = false;
                chkCelular.Enabled = false;
                chkCompu.Enabled = false;
                chkTableta.Enabled = false;

                cbProveedor.SelectedIndex = -1;
                cbTipoConexion.SelectedIndex = -1;
            }
            else
            {
                cbProveedor.Enabled = true;
                cbTipoConexion.Enabled = true;
                chkCelular.Enabled = true;
                chkCompu.Enabled = true;
                chkTableta.Enabled = true;
            }
        }

        private void btnValidar01_Click(object sender, EventArgs e)
        {
            if (ValidarCamposTab01() == true)
            {
                btnSiguiente01.Enabled = true;
                valida_segundo_tab(true);
            }
            else
            {
                Frm_Mensaje_Advertencia mensaje = new Frm_Mensaje_Advertencia("¡CAMPOS INCOMPLETOS!");
                mensaje.ShowDialog();
            }
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            // Expresión regular para validar números enteros positivos
            string patron = @"^\d{13}[A-Za-z]$";

            // Creamos una instancia de Regex con la expresión regular
            Regex regex = new Regex(patron);


            mensaje = new Frm_Mensaje_Advertencia("El formato de cèdula es incorrecto");

            // Comprobamos si el input coincide con el patrón
            if (regex.IsMatch(txtCedula.Text))
            {

                //MessageBox.Show("El input es válido."); // Si coincide, el input es válido
            }
            else
            {
                /// MessageBox.Show("El input no es válido."); // Si no coincide, el input no es válido
                mensaje.ShowDialog();
                //txtCedula.Clear();
                txtCedula.Focus();
            }

        }

        private void ConvertirAMayusculas(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.Text = textBox.Text.ToUpper();
            }
        }

        private void txtClaro_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }

        private void txtTigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }

        private void txtConvencional_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(sender, e);
        }

        private void btnSiguiente01_Click(object sender, EventArgs e)
        {

        }

        //==================================EVENTOS==================================   ---->  FIN





        //==================================FUNCIONES================================== ---->  INICIO

        //Funcion para evitar que se ingresen letras, solo numeros
        void SoloNumeros(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada es un número o la tecla de retroceso (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Si no es un número ni la tecla de retroceso, se ignora la tecla presionada
                e.Handled = true;
            }
        }

        //Funcion para evitar que el usuario ingrese valores mayores que 100
        bool Valida_Nota(String Texbox)
        {
            bool bandera;
            int nota;
            if (Texbox == "")
            {
                Frm_Mensaje_Advertencia mensaje = new Frm_Mensaje_Advertencia("DEBE INGRESAR UNA NOTA!");
                mensaje.ShowDialog();
                //MessageBox.Show("DEBE INGRESAR UNA NOTA!");
                bandera = false;
            }
            else
            {
                nota = Convert.ToInt32(Texbox);
                if (nota <= 100 && nota >= 60)
                {
                    bandera = true;
                }

                else
                {
                    Frm_Mensaje_Advertencia mensaje = new Frm_Mensaje_Advertencia("LA NOTA REGISTRADA NO PUEDE SER MAYOR QUE 100 NI MERNOR QUE 60!");
                    mensaje.ShowDialog();
                    //MessageBox.Show("LA NOTA REGISTRADA NO PUEDE SER MAYOR QUE 100");
                    bandera = false;
                }
            }
            return bandera;
        }

        void llenarDiscapacidad()
        {
            tbl_Discapacidad = prematricula.Mostrar_Discapacidad();
            foreach (DataRow row in tbl_Discapacidad.Rows)
            {
                cbDiscapacidad.Items.Add(Convert.ToString(row["Nombre"]).ToUpper());
            }
            // Establecer el modo de autocompletado
            cbDiscapacidad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbDiscapacidad.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        void llenarAccesoInternet()
        {
        
            cbAccesoInternet.Items.Add("SI");
            cbAccesoInternet.Items.Add("NO");
            dtProveedor = prematricula.Mostrar_Proveedor_Internet();
            foreach (DataRow row in dtProveedor.Rows)
            {
                cbProveedor.Items.Add(Convert.ToString(row["ProveedorIntenet"]).ToUpper());
            }
            // Establecer el modo de autocompletado
            cbAccesoInternet.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbAccesoInternet.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        void llenar_mano()
        {
            cbMano.Items.Add("DIESTRO");
            cbMano.Items.Add("ZURDO");

            cbTipoConexion.Items.Add("INTERNET MOVIL");
            cbTipoConexion.Items.Add("INTERNET RESINDENCIAL");

            // Establecer el modo de autocompletado
            cbMano.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMano.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Establecer el modo de autocompletado
            cbTipoConexion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTipoConexion.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        void llenar_Departamento()
        {

            tbl_Departamento.Clear();
            tbl_Departamento = prematricula.Mostrar_Departamento();
            foreach (DataRow row in tbl_Departamento.Rows)
            {
                cbDepartamento.Items.Add(Convert.ToString(row["Nombre"]));
                //cbeCentros.Properties.Items.Add(Convert.ToString(row["Nombre"]));
            }


            // Establecer el modo de autocompletado
            cbDepartamento.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbDepartamento.AutoCompleteSource = AutoCompleteSource.ListItems;

            tbl_Departamento02.Clear();
            tbl_Departamento02 = prematricula.Mostrar_Departamento();
            foreach (DataRow row in tbl_Departamento02.Rows)
            {
                cbDepartamento02.Items.Add(Convert.ToString(row["Nombre"]));
            }

            // Establecer el modo de autocompletado
            cbDepartamento02.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbDepartamento02.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        void llenar_Departamento02()
        {

            tbl_Departamento.Clear();
            tbl_Departamento = prematricula.Mostrar_Departamento();
            foreach (DataRow row in tbl_Departamento.Rows)
            {
                cbDepartamento02.Items.Add(Convert.ToString(row["Nombre"]));
            }
            // Establecer el modo de autocompletado
            cbDepartamento02.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbDepartamento02.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        void llenar_Sexo()
        {
            tbl_Sexo.Clear();
            tbl_Sexo = prematricula.Mostrar_Sexo();
            foreach (DataRow row in tbl_Sexo.Rows)
            {
                cbSexo.Items.Add(Convert.ToString(row["Nombre"]));
            }
            // Establecer el modo de autocompletado
            cbSexo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbSexo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        void llenar_Nacionalidad()
        {

            tbl_nacionalidad = new DataTable();
            tbl_nacionalidad = prematricula.Mostrar_Nacionalidad();


            foreach (DataRow row in tbl_nacionalidad.Rows)
            {
                cbNacionalidad.Items.Add(Convert.ToString(row["Nombre"]));
            }
            // Establecer el modo de autocompletado
            cbNacionalidad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbNacionalidad.AutoCompleteSource = AutoCompleteSource.ListItems;
        }


        void llenar_Instituciones_Estatales()
        {
            tbl_Instituciones_Estatles.Clear();
            tbl_Instituciones_Estatles = new DataTable();
            tbl_Instituciones_Estatles = prematricula.Mostrar_Instituciones_Estatales();

            cbeEstado.Items.Clear();
            foreach (DataRow row in tbl_Instituciones_Estatles.Rows)
            {
                //be.items.add(convert.tostring(row["nombre"]));
                cbeEstado.Items.Add(Convert.ToString(row["nombre"]));
            }

        }

        void llenar_etnia()
        {
            tbl_Etnia.Clear();
            tbl_Etnia = prematricula.Mostrar_Etnia();
            foreach (DataRow row in tbl_Etnia.Rows)
            {
                cbEtnia.Items.Add(Convert.ToString(row["Nombre"]));
            }
            // Establecer el modo de autocompletado
            cbEtnia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbEtnia.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        void llenar_turno(int rol) //1 para todos los turnos, 0 para solo sabado y domingo
        {
            turno = new DataTable();
            turno.Clear();
            turno = campusBD.Mostrar_Turno(rol);
            foreach (DataRow row in turno.Rows)
            {
                cbTurno.Items.Add(Convert.ToString(row["nombre"]));
            }
            // Establecer el modo de autocompletado
            cbTurno.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTurno.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        void llenar_carrera(int id_carrera)
        {
            DataTable carrera = new DataTable();
            carrera.Clear();
            carrera = campusBD.Mostrar_Turno(id_carrera);
            foreach (DataRow row in carrera.Rows)
            {
                cbCarrera.Items.Add(Convert.ToString(row["CARRERA"]));
            }
            // Establecer el modo de autocompletado
            cbCarrera.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbCarrera.AutoCompleteSource = AutoCompleteSource.ListItems;
        }



        void llenar_Estado_Civil()
        {
            tbl_Estado_Marital.Clear();
            tbl_Estado_Marital = prematricula.Mostrar_Estado_Civil();
            foreach (DataRow row in tbl_Estado_Marital.Rows)
            {
                cbEstadoCivil.Items.Add(Convert.ToString(row["Nombre"]));
            }
            // Establecer el modo de autocompletado
            cbEstadoCivil.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbEstadoCivil.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        void llenar_matricula()
        {
            tbl_Matricula_Consolidado = campusBD.Matricula_Consolidado();
            dgvMatricula.DataSource = tbl_Matricula_Consolidado;

            // Sumar los valores de la columna "Valor" en base al valor de la columna "Factor"
            int sumaTotal = 0;
            int ciencias_economicas = 0;
            int ciencias_tecnologia = 0;
            int ciencias_humanidades = 0;
            foreach (DataRow row in tbl_Matricula_Consolidado.Rows)
            {
                if (Convert.ToString(row["ID_AREA"]) == "FCEE")
                {
                    ciencias_economicas += Convert.ToInt32(row["CANTIDAD"]);
                }
                if (Convert.ToString(row["ID_AREA"]) == "FCTA")
                {
                    ciencias_tecnologia += Convert.ToInt32(row["CANTIDAD"]);
                }
                if (Convert.ToString(row["ID_AREA"]) == "FHC")
                {
                    ciencias_humanidades += Convert.ToInt32(row["CANTIDAD"]);
                }

            }

            txteconomicas.Text = ciencias_economicas.ToString();
            txtTecnologia.Text = ciencias_tecnologia.ToString();
            txtHumanidades.Text = ciencias_humanidades.ToString();

            txtMatricula.Text = Convert.ToString(ciencias_economicas + ciencias_humanidades + ciencias_tecnologia);

            dgvMatricula.Columns[0].Visible = false;
            dgvMatricula.Columns[2].Visible = false;
        }

        void llenar_Area()
        {

            tbl_area = campusBD.Mostrar_Area();
            foreach (DataRow row in tbl_area.Rows)
            {
                cbAreaConocimiento.Items.Add(Convert.ToString(row["nombre"]));
            }
            // Establecer el modo de autocompletado
            cbAreaConocimiento.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbAreaConocimiento.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void cbAreaConocimiento_SelectedValueChanged(object sender, EventArgs e)
        {
            string area;
            area = cbAreaConocimiento.Text;
            cbCarrera.Text = "";
            cbCarrera.Items.Clear();


            foreach (DataRow row in tbl_area.Rows)
            {
                if (Convert.ToString(row["nombre"]) == area)
                {
                    tbl_Carrera = campusBD.Carrera_por_Area(Convert.ToInt32(row["CollegeId"]));
                }
            }

            foreach (DataRow row in tbl_Carrera.Rows)
            {
                cbCarrera.Items.Add(Convert.ToString(row["CARRERA"]).ToUpper());
            }

        }
        void llenar_anio()
        {
            List<int> numeros = new List<int>();

            for (int i = 1980; i <= 2023; i++)
            {
                numeros.Add(i);
            }

            // Invertir el orden de la lista
            numeros.Reverse();

            // Convertir los números a objetos y agregarlos al ComboBox
            foreach (int numero in numeros)
            {
                cbAnioFin.Items.Add(numero);
            }

            // Establecer el modo de autocompletado
            cbAnioFin.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbAnioFin.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        void llenarTipoBachillerato()
        {
            tbl_Bachillerato = prematricula.Mostrar_Tipo_Bachillerato();
            foreach (DataRow row in tbl_Bachillerato.Rows)
            {
                cbTipoBachillerato.Items.Add(Convert.ToString(row["tipo"]).ToUpper());
            }
            // Establecer el modo de autocompletado
            cbTipoBachillerato.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbTipoBachillerato.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public bool ValidarCamposTab01()
        {
            bool bandera = true;

            // Llamadas a las funciones para validar cada campo
            if (false == ValidarCampo(txtCedula, epCedula, "INGRESE CÉDULA, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = false;
            }
            if (false == ValidarCampo(txtPrimerNombre, epCedula, "INGRESE PRIMER NOMBRE, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = false;
            }
            if (false == ValidarCampo(txtPrimerApellido, epPrimerApellido, "INGRESE PRIMER APELLIDO, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = false;
            }
            if (false == ValidarComboBox(cbEtnia, epEtnia, "SELECCIONE ETNIA, ¡ES UN CAMPO OBLIGATORIO!"))
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
            if (false == ValidarCampo(txtBarrio, epBarrio, "INGRESE BARRIO O COMARCA, ¡ES UN CAMPO OBLIGATORIO!"))
            { bandera = false; }
            if (false == ValidarComboBox(cbAccesoInternet, epAccesoInternet, "SELECCIONE OPCION, ¡ES UN CAMPO OBLIGATORIO!"))
            { bandera = false; }
            if (false == ValidarComboBox(cbMano, epZurdoDiestro, "SELECCIONE OPCION, ¡ES UN CAMPO OBLIGATORIO!"))
            { bandera = false; }
            if (false == ValidarComboBox(cbDiscapacidad, epDiscapacidad, "SELECCIONE DISCAPACIDAD, ¡ES UN CAMPO OBLIGATORIO!"))
            { bandera = false; }

            if (false == ValidarComboBox(cbEstadoCivil, epEstadoCivil, "SELECCIONE ESTADO CIVIL, ¡ES UN CAMPO OBLIGATORIO!"))
            { bandera = false; }


            if (validar_fecha() == false) { bandera = false; }
            return bandera;
        }

        public bool ValidarCamposTab02()
        {
            bool bandera = true;


            if (false == ValidarComboBox(cbDepartamento02, epDepartamento02, "SELECCIONE DEPARTAMENTO, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = false;
            }

            if (false == ValidarComboBox(cbTipoBachillerato, epBachillerato, "SELECCIONE TIPO DE BACHILLERATO, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = false;
            }

            if (false == ValidarComboBox(cbMunicipio02, epMunicipio02, "SELECCIONE MUNICIPIO, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = false;
            }

            if (false == ValidarComboBox(cbAnioFin, epAnioFIN, "SELECCIONE AÑO DE FINALIZACIÓN DE ESTUDIOS, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = false;
            }

            if (validacentro() == false)
            {
                bandera = false;
            }

            if (validaEstatal() == false)
            {
                bandera = false;
            }

            if (valida_notas() == false)
            {
                bandera = false;
            }
            return bandera;
        }

        public bool ValidarCamposTab03()
        {
            bool bandera = true;


            if (false == ValidarComboBox(cbAreaConocimiento, epArea, "SELECCIONE ÁREA DE CONOCIMIENTO, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = false;
            }

            if (false == ValidarComboBox(cbCarrera, epCarrera, "SELECCIONE CARRERA, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = false;
            }

            if (false == ValidarComboBox(cbTurno, epTurno, "SELECCIONE TURNO, ¡ES UN CAMPO OBLIGATORIO!"))
            {
                bandera = false;
            }





            return bandera;
        }


        bool valida_notas()
        {
            bool bandera = true;
            if (txtMat4.Text == string.Empty)
            {
                bandera = false;
            }

            if (txtMat5.Text == string.Empty)
            {
                bandera = false;
            }

            if (txtLL4.Text == string.Empty)
            {
                bandera = false;
            }

            if (txtLL5.Text == string.Empty)
            {
                bandera = false;
            }

            if (txtQuimi4.Text == string.Empty)
            {
                bandera = false;
            }

            if (txtQuimi5.Text == string.Empty)
            {
                bandera = false;
            }


            if (txtFis4.Text == string.Empty)
            {
                bandera = false;
            }
            if (txtFisica5.Text == string.Empty)
            {
                bandera = false;
            }

            if (txtHistoria5.Text == string.Empty)
            {
                bandera = false;
            }

            if (txtGeo4.Text == string.Empty)
            {
                bandera = false;
            }

            if (txtProm4.Text == string.Empty)
            {
                bandera = false;
            }


            if (txtProm5.Text == string.Empty)
            {
                bandera = false;
            }

            if (txtPromG.Text == string.Empty)
            {
                bandera = false;
            }
            return bandera;
        }

        bool validacentro()
        {
            bool bandera = false;
            string centro = cbeCentros.Text;
            foreach (DataRow row in tbl_Centro_Estudios.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == centro)
                {
                    bandera = true;
                }
            }
            return bandera;
        }


        bool validaEstatal()
        {
            bool bandera = false;
            string estado = cbeEstado.Text;
            foreach (DataRow row in tbl_Instituciones_Estatles.Rows)
            {
                if (Convert.ToString(row["nombre"]) == estado)
                {
                    bandera = true;
                }
            }
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


        bool validar_fecha()
        {
            bool bandera;
            if (txtCedula.Text != string.Empty)
            {
                String cedula = txtCedula.Text;
                DateTime fecha = Convert.ToDateTime(dtFecha.Text);
                string subcadena = cedula.Substring(3, 6);
                string fechaHoraString = fecha.ToString("ddMMyy");

                if (subcadena.Equals(fechaHoraString))
                {
                    bandera = true;
                    epFechaNac.Clear();
                }
                else
                {
                    bandera = false;
                    epFechaNac.SetError(dtFecha, "LA FECHA DE NACIMIENTO NO COINCIDE CON EL NUMERO DE CÉDULA");
                }


            }
            else
            {
                epFechaNac.SetError(dtFecha, "LA FECHA DE NACIMIENTO NO COINCIDE CON EL NUMERO DE CÉDULA");
                bandera = false;
            }


            return bandera;

        }

        //Funcion para validar eñ segundo TAB
        void valida_segundo_tab(bool bandera)
        {
            cbTipoBachillerato.Enabled = bandera;
            cbDepartamento02.Enabled = bandera;
            cbAnioFin.Enabled = bandera;
            cbMunicipio02.Enabled = bandera;
            cbCentroEstudios.Enabled = bandera;
            cbeEstado.Enabled = bandera;
            cbeCentros.Enabled = bandera;
            txtMat4.Enabled = bandera;
            txtMat5.Enabled = bandera;
            txtLL4.Enabled = bandera;
            txtLL5.Enabled = bandera;
            txtGeo4.Enabled = bandera;
            txtHistoria5.Enabled = bandera;
            txtFis4.Enabled = bandera;
            txtFisica5.Enabled = bandera;
            txtQuimi4.Enabled = bandera;
            txtQuimi5.Enabled = bandera;
            btnLimpiar.Enabled = bandera;
            btnValidar02.Enabled = bandera;
            Frm_Mensaje_Advertencia mensaje = new Frm_Mensaje_Advertencia("LA OPCIÓN DE DATOS EDUCATIVOS SE HA HABILITADO!");
            mensaje.ShowDialog();

        }


        void valida_tercer_tab(bool bandera)
        {
            cbAreaConocimiento.Enabled = true;
            cbCarrera.Enabled = true;
            cbTurno.Enabled = true;
            btnValidarFinal.Enabled = true;
            
            Frm_Mensaje_Advertencia mensaje = new Frm_Mensaje_Advertencia("LA OPCIÓN DE REGISTRO UNIVERSITARIO SE HA HABILITADO!");
            mensaje.ShowDialog();

        }
        private void btnValidar02_Click(object sender, EventArgs e)
        {
            if (ValidarCamposTab02() == true)
            {
                btnSiguiente.Enabled = true;
                valida_tercer_tab(true);
            }
            else
            {
                Frm_Mensaje_Advertencia mensaje = new Frm_Mensaje_Advertencia("¡CAMPOS INCOMPLETOS!");
                mensaje.ShowDialog();
            }
        }

        void Calcular_Promedio()
        {
            double mat04, mat05, lengua04, lengua05, geografia04, historia05, fisica04, fisica05, quimica04, quimica05, prom4, prom5, promt;
            mat04 = Convert.ToDouble(txtMat4.Text);
            mat05 = Convert.ToDouble(txtMat5.Text);
            lengua04 = Convert.ToDouble(txtLL4.Text);
            lengua05 = Convert.ToDouble(txtLL5.Text);
            geografia04 = Convert.ToDouble(txtGeo4.Text);
            historia05 = Convert.ToDouble(txtHistoria5.Text);
            fisica04 = Convert.ToDouble(txtFis4.Text);
            fisica05 = Convert.ToDouble(txtFisica5.Text);
            quimica04 = Convert.ToDouble(txtQuimi4.Text);
            quimica05 = Convert.ToDouble(txtQuimi5.Text);
            prom4 = (mat04 + lengua04 + geografia04 + fisica04 + quimica04) / 5;
            prom5 = (mat05 + lengua05 + historia05 + fisica05 + quimica05) / 5;
            promt = (prom4 + prom5) / 2;
            txtProm4.Text = Convert.ToString(prom4);
            txtProm5.Text = Convert.ToString(prom5);
            txtPromG.Text = Convert.ToString(promt);
        }

        private void cbDepartamento02_SelectedValueChanged(object sender, EventArgs e)
        {
            //se utiliza este evento para encontrar el departemanto seleccionado y asi obtener los municipios de dicho departamento
            string departamento;
            departamento = cbDepartamento02.Text;
            cbMunicipio02.Items.Clear();
            cbMunicipio02.Text = "";

            foreach (DataRow row in tbl_Departamento02.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == departamento)
                {
                    tbl_Municipio02 = prematricula.Mostrar_Municipio(Convert.ToInt32(row["id"]));
                }
            }

            cbMunicipio.Items.Clear();
            foreach (DataRow row in tbl_Municipio02.Rows)
            {
                cbMunicipio02.Items.Add(Convert.ToString(row["Nombre"]));
            }


            cbMunicipio02.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbMunicipio02.AutoCompleteSource = AutoCompleteSource.ListItems;
            //llenar el cb de Municipio
        }

        private void cbMunicipio02_SelectedValueChanged(object sender, EventArgs e)
        {
            string municipio;
            municipio = cbMunicipio02.Text;
            cbeCentros.Text = "";

            cbCentroEstudios.Text = "";
            cbCentroEstudios.Items.Clear();
            cbeCentros.Items.Clear();


            foreach (DataRow row in tbl_Municipio02.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == municipio)
                {
                    tbl_Centro_Estudios = prematricula.Mostrar_Centro_Estudios(Convert.ToInt32(row["Id"]));
                }
            }

            cbCentroEstudios.Items.Clear();
            foreach (DataRow row in tbl_Centro_Estudios.Rows)
            {
                cbCentroEstudios.Items.Add(Convert.ToString(row["Nombre"]));
                cbeCentros.Items.Add(Convert.ToString(row["Nombre"]));
            }
            //llenar el cb de Municipio
        }

        //private void cbDepartamento_TextChanged(object sender, EventArgs e)
        //{
        //    cbDepartamento.Text = cbDepartamento.Text.ToUpper();
        //    // Mover el cursor al final del texto
        //    cbDepartamento.SelectionStart = cbDepartamento.Text.Length;



        //    string searchText = cbDepartamento.Text; // Convertir el texto a minúsculas para hacer la búsqueda insensible a mayúsculas/minúsculas

        //    // Limpiar la lista de elementos del ComboBox
        //    cbDepartamento.Items.Clear();
        //    List<string> departamentos = new List<string>();


        //    foreach (DataRow row in tbl_Departamento.Rows)
        //    {
        //        departamentos.Add(Convert.ToString( row["nombre"]));

        //    }


        //    // Agregar de nuevo los elementos que coinciden con la búsqueda
        //    foreach (string item in departamentos)
        //    {
        //        if (item.Contains(searchText))
        //        {
        //            cbDepartamento.Items.Add(item);
        //        }
        //    }



        //    // Seleccionar el texto buscado para resaltar la coincidencia
        //    cbDepartamento.SelectionStart = searchText.Length;
        //    //cbDepartamento.SelectionLength = cbDepartamento.Text.Length - searchText.Length;
        //}

        //private void comboBoxEdit1_Properties_KeyUp(object sender, KeyEventArgs e)
        //{
        //    string searchText = cbeCentros.Text.ToLower(); // Convertir el texto a minúsculas para hacer la búsqueda insensible a mayúsculas/minúsculas

        //    // Limpiar los elementos del ComboBoxEdit
        //    cbeCentros.Items.Clear();

        //    List<string> CentroEstudios = new List<string>();


        //    foreach (DataRow row in tbl_Centro_Estudios.Rows)
        //    {
        //        CentroEstudios.Add(Convert.ToString(row["nombre"]));
        //    }

        //    // Crear una expresión regular para buscar cualquier coincidencia en cualquier parte de la cadena
        //    Regex regex = new Regex($".*{Regex.Escape(searchText)}.*");


        //    // Agregar de nuevo los elementos que coinciden con la búsqueda
        //    foreach (string item in CentroEstudios)
        //    {
        //        if (regex.IsMatch(item.ToLower()))
        //        {
        //            cbeCentros.Items.Add(item.ToUpper());
        //        }

        //        //if (item.Contains(searchText))
        //        //{
        //        //    cbeDepartamento.Properties.Items.Add(item);
        //        //}
        //    }
        //}

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMat4.Clear();
            txtMat5.Clear();
            txtLL4.Clear();
            txtLL5.Clear();
            txtHistoria5.Clear();
            txtGeo4.Clear();
            txtFis4.Clear();
            txtFisica5.Clear();
            txtQuimi4.Clear();
            txtQuimi5.Clear();
            txtProm4.Clear();
            txtProm5.Clear();
            txtPromG.Clear();

        }

        private void btnValidarFinal_Click(object sender, EventArgs e)
        {
            if (ValidarCamposTab03() == true)
            {
                btnMatricular_Final.Enabled = true;

            }
            else
            {
                Frm_Mensaje_Advertencia mensaje = new Frm_Mensaje_Advertencia("¡CAMPOS INCOMPLETOS!");
                mensaje.ShowDialog();
            }
        }

        void cargar_barra (bool bandera)
        {

            pgCarga.Visible = bandera;
            lbCarga.Visible = bandera;

         
        }

        private void btnMatricular_Final_Click(object sender, EventArgs e)
        {

            //cargar_barra(true);
     
            //lbCarga.Visible = true;
         


            //this.Enabled = false;
            Frm_Mensaje_Advertencia mensaje;
            DataTable tabla = new DataTable();
            String carne = "";

            int Id_turno = 0 ,id_carrera = 0, recibir = 0, valor = 0;
            pgCarga.Visible = true;
            pgCarga.Visible = true;
            foreach (DataRow row in turno.Rows)
            {
                if (Convert.ToString(row["nombre"]) == cbTurno.Text)
                {
                    Id_turno = (Convert.ToInt32(row["CODE_VALUE_KEY"]));
                }
            }
            foreach (DataRow row in tbl_Carrera.Rows)
            {
                if (Convert.ToString(row["CARRERA"]) == cbCarrera.Text)
                {
                    id_carrera = (Convert.ToInt32(row["CurriculumId"]));
                }
            }


            //recibir =  campusBD.Contar_Estudiantes(id_carrera,Id_turno);
            valor = Matricular();
            pgCarga.Value = 70;
            if (valor == 1)
            {
                tabla = Buscar_Carne(txtCedula.Text);
                pgCarga.Value = 80;
                foreach (DataRow row in tabla.Rows)
                {
                    carne = (Convert.ToString(row["CARNE_CSM"]));
                }
                pgCarga.Value = 100;
                Frm_Mensaje_Carne Carne_Mensaje = new Frm_Mensaje_Carne("SE HA COMPLETO LA MATRICULA DE: " + txtPrimerNombre.Text + " " + txtPrimerApellido.Text, carne);
                cargar_barra(false);
                Carne_Mensaje.ShowDialog();
            } else if (valor == 2)
            {
                pgCarga.Value = 100;
                cargar_barra(false);
                mensaje = new Frm_Mensaje_Advertencia("EXCEPCIÓN CONTROLADA, EL REGISTRO NO SE COMPLETO UNCSM");
            }
            else
            {
                pgCarga.Value = 100;
                cargar_barra(false);
                mensaje = new Frm_Mensaje_Advertencia("NO SE PUEDE REGISTRAR EL ESTUDIANTE, COMUNIQUESE CON EL ÁREA SISTEMAS UNCSM");
                mensaje.ShowDialog();
            }


           

            // bool bandera = false;

            // if (Id_turno == 3 || Id_turno == 4)
            // {
            //     Realizar_Matricula_UNCSM();
            // }
            // else
            // {
            //     switch (id_carrera)
            //     {
            //         case 1468:
            //             Valida_Ingles();
            //         break;
            //         default:
            //             Realizar_Matricula_UNCSM();
            //          break;

            //     }

            // }


            //void Valida_Ingles()
            // {
            //     if (recibir <= 120)
            //     {
            //         Realizar_Matricula_UNCSM();
            //     }
            //     else
            //     {
            //         mensaje = new Frm_Mensaje_Advertencia("LA MATRÍCULA PARA ESTA CARRERA ESTÁ COMPLETA, ¡NO HAY CUPO!");
            //         mensaje.ShowDialog();
            //     }
            // }

            // void Valida_Demas()
            // {
            //     if (recibir <= 80)
            //     {
            //         Realizar_Matricula_UNCSM();
            //     }
            //     else
            //     {
            //         mensaje = new Frm_Mensaje_Advertencia("LA MATRÍCULA PARA ESTA CARRERA ESTÁ COMPLETA, ¡NO HAY CUPO!");
            //         mensaje.ShowDialog();
            //     }
            // }
        }

        void Realizar_Matricula_UNCSM()
        {
            if (cargar_datos() == 1)
            {
                Thread tareaThread = new Thread(new ThreadStart(RealizarTarea));
                tareaThread.Start();
                this.Enabled = false;
                int valor = 0;
                valor = cargar_prematricula();
            }
            else
            {
                mensaje = new Frm_Mensaje_Advertencia("ERROR, COMUNIQUESE CON EL ÁREA SISTEMAS UNCSM");
                mensaje.ShowDialog();
            }

            void RealizarTarea()
            {
                this.Invoke((MethodInvoker)delegate
                {
                    DataTable tabla = new DataTable();
                    tabla = Buscar_Carne(txtCedula.Text);
                    String carne = "";
                    foreach (DataRow row in tabla.Rows)
                    {
                        carne = (Convert.ToString(row["CARNE_CSM"]));
                    }
                    Frm_Mensaje_Carne Carne_Mensaje = new Frm_Mensaje_Carne("SE HA COMPLETO LA MATRICULA DE: " + txtPrimerNombre.Text + " " + txtPrimerApellido.Text, carne);
                    // mensaje = new Frm_Mensaje_Advertencia("SE HA COMPLETO LA MATRICULA DE: " + txtPrimerNombre.Text + " " + txtPrimerApellido.Text);
                    //  mensaje.ShowDialog();
                    Carne_Mensaje.ShowDialog();
                    this.Close();
                });
            }
        }


        DataTable Buscar_Carne(string cedula)
        {
            DataTable tabla = new DataTable();
            tabla=  campusBD.Buscar_Carne(cedula); //REVISAR
            return tabla;
        }

        int cargar_prematricula()
        {
            String cedula = "", nombres = "", PrimerApellido = "", SegundoApellido = "";
            int Id_genero=0, Id_Estado_Civil=0, Id_Departamento=0, Id_Municipio=0,Id_Etnia=0, Id_Procedencia= 0,Id_Estatal = 0;
            int Id_centro_estudio = 0,IdCarrera= 0,IdCarrera_02= 0,IdTurno=0, IdTurno_02=0;
            DateTime Fecha_Nacimiento;

            cedula = txtCedula.Text;
            nombres = txtPrimerNombre.Text + " " + txtSegundoNombre.Text;
            PrimerApellido = txtPrimerApellido.Text;
            SegundoApellido = txtSegundoApellido.Text;

            ///genero
            foreach (DataRow row in tbl_Sexo.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == cbSexo.Text)
                {
                    Id_genero = (Convert.ToInt32(row["Id"]));
                }
            }

            Fecha_Nacimiento = Convert.ToDateTime(dtFecha.Text);

            //Estado civil
            foreach (DataRow row in tbl_Estado_Marital.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == cbEstadoCivil.Text)
                {
                    Id_Estado_Civil = (Convert.ToInt32(row["Id"]));
                }
            }

            //Departamento
            foreach (DataRow row in tbl_Departamento.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == cbDepartamento.Text)
                {
                    Id_Municipio = (Convert.ToInt32(row["Id"]));
                }
            }

            //Municipio
            foreach (DataRow row in tbl_Municipio.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == cbMunicipio.Text)
                {
                    Id_Municipio = (Convert.ToInt32(row["Id"]));
                }
            }

            //ID_ETNIA
            foreach (DataRow row in tbl_Etnia.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == cbEtnia.Text)
                {
                    Id_Etnia = (Convert.ToInt32(row["id"]));
                }
            }

            //ID_Procedencia
            foreach (DataRow row in tbl_nacionalidad.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == cbNacionalidad.Text)
                {
                    Id_Procedencia = (Convert.ToInt32(row["Id"]));
                }
            }

            //ID_Institucion_Estatal
            foreach (DataRow row in tbl_Instituciones_Estatles.Rows)
            {
                if (Convert.ToString(row["nombre"]) == cbeEstado.Text)
                {
                    Id_Estatal = (Convert.ToInt32(row["ID"]));
                }
            }

            //ID_Centro_Estudio
            foreach (DataRow row in tbl_Centro_Estudios.Rows)
            {
                if (Convert.ToString(row["nombre"]) == cbeCentros.Text)
                {
                    Id_centro_estudio = (Convert.ToInt32(row["Id"]));
                }
            }


            //Carrera
            foreach (DataRow row in tbl_Carrera.Rows)
            {
                if (Convert.ToString(row["CARRERA"]) == cbCarrera.Text)
                {
                    IdCarrera = (Convert.ToInt32(row["CurriculumId"]));
                }
            }

            switch (IdCarrera)
            {
                case 1461:
                    IdCarrera_02 = 16;
                  break;
                case 1462:
                    IdCarrera_02 = 8;
                    break;
                case 1463:
                    IdCarrera_02 = 6;
                    break;
                case 1464:
                    IdCarrera_02 = 18;
                    break;
                case 1465:
                    IdCarrera_02 = 1;
                    break;
                case 1466:
                    IdCarrera_02 = 3;
                    break;
                case 1467:
                    IdCarrera_02 = 17;
                    break;
                case 1468:
                    IdCarrera_02 = 5;
                    break;
                case 1469:
                    IdCarrera_02 = 20;
                    break;
                case 1472:
                    IdCarrera_02 = 9;
                    break;
                case 1473:
                    IdCarrera_02 = 13;
                    break;
                case 1475:
                    IdCarrera_02 = 11;
                    break;
                case 1476:
                    IdCarrera_02 = 10;
                    break;
                case 1477:
                    IdCarrera_02 = 19;
                    break;
                case 1478:
                    IdCarrera_02 = 4;
                    break;
            }

            //Turno
            foreach (DataRow row in turno.Rows)
            {
                if (Convert.ToString(row["nombre"]) == cbTurno.Text)
                {
                    IdTurno = (Convert.ToInt32(row["CODE_VALUE_KEY"]));
                }
            }


            switch (IdTurno)
            {
                case 3:
                    IdTurno_02 = 1;
                    break;
                case 4:
                    IdTurno_02 = 2;
                    break;
                case 8:
                    IdTurno = 3;
                    break;
                case 9:
                    IdTurno_02 = 4;
                    break;
           
            }
          
            //Zurdo o Diestro
            int Id_Izquierdo = 0, IdDerecho = 0;
            if (cbMano.Text == "ZURDO")
            {
                Id_Izquierdo = 2;
            }
            else
            {
                IdDerecho = 1;
            }

            //Discapacidad
            int IdSordera = 0, IdCeguera = 0, IdMotora = 0;
            int IdTEA = 0, IdTDAH = 0, IdSordo_Mudo = 0, IdNinguna = 0;
            foreach (DataRow row in tbl_Discapacidad.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == cbDiscapacidad.Text)
                {
                    if ((Convert.ToInt32(row["Id"])== 4))
                    {
                        IdCeguera = 4;
                    }

                    if ((Convert.ToInt32(row["Id"]) == 5))
                    {
                        IdMotora = 5;
                    }
                    if ((Convert.ToInt32(row["Id"]) == 8))
                    {
                        IdSordo_Mudo = 8;
                    }

                    if ((Convert.ToInt32(row["Id"]) == 9))
                    {
                        IdNinguna = 9;
                    }

                    if ((Convert.ToInt32(row["Id"]) == 3))
                    {
                        IdSordera = 3;
                    }

                    if ((Convert.ToInt32(row["Id"]) == 7))
                    {
                        IdTDAH = 7;
                    }
                    if ((Convert.ToInt32(row["Id"]) == 6))
                    {
                        IdTEA = 6;
                    }

                }
            }

            //Cuenta Acceso Internte
            int Id_Acceso = 2;

            if (cbAccesoInternet.Text == "SI")
            {
                Id_Acceso = 4;
            }

            //Proveedor de Internet
            int Id_Proveedor = 0;
            foreach (DataRow row in dtProveedor.Rows)
            {
                if (Convert.ToString(row["ProveedorIntenet"]) == cbTurno.Text)
                {
                    Id_Proveedor = (Convert.ToInt32(row["id"]));
                }
            }


            //Dispositivos
            int Idcomputadora = 0, Idtablet = 0, Idcelular = 0;

            if (chkCompu.Checked == true)
            {
                Idcomputadora = 1;
            }

            if (chkTableta.Checked == true)
            {
                Idtablet = 3;
            }

            if (chkCelular.Checked == true)
            {
                Idcelular = 2;
            }

            //Tipo de Conexion
            int IdTipoConexion = 0;

            if (cbTipoConexion.Text == "INTERNET MOVIL")
            {
                IdTipoConexion = 1;
            }
            else
            {
                IdTipoConexion = 2;
            }
            //cbTipoConexion.Items.Add("INTERNET MOVIL");
            //cbTipoConexion.Items.Add("INTERNET RESINDENCIAL");

            int salida_P = 0;
          salida_P=  prematricula.Insertar_Estudiante_Prematricula(cedula, nombres, PrimerApellido, SegundoApellido, Id_genero,
                Fecha_Nacimiento, Id_Estado_Civil, Id_Departamento, Id_Municipio, Id_Etnia, Id_Procedencia, txtConvencional.Text,
                txtClaro.Text, txtTigo.Text, txtDireccion.Text, txtBarrio.Text, Id_Estatal, Id_centro_estudio, IdCarrera_02,
                IdTurno_02, Convert.ToInt32(cbAnioFin.Text), float.Parse(txtPromG.Text), txtOtroCentro.Text, Id_Izquierdo, IdDerecho,
                IdSordera, IdCeguera, IdMotora, IdTEA, IdTDAH, IdSordo_Mudo, IdNinguna, Id_Acceso, Id_Proveedor, Idcomputadora,
                Idtablet, Idcelular, IdTipoConexion, Convert.ToInt32(txtMat4.Text), Convert.ToInt32(txtLL4.Text), 
                Convert.ToInt32(txtGeo4.Text), Convert.ToInt32(txtFis4.Text), Convert.ToInt32(txtQuimi4.Text), 
                Convert.ToInt32(txtMat5.Text), Convert.ToInt32(txtLL5.Text), Convert.ToInt32(txtHistoria5.Text), 
                Convert.ToInt32(txtFisica5.Text), Convert.ToInt32(txtQuimi5.Text));

            return salida_P;


        }

        /*Seccion para nuevo Metodo en donde se enviaran todos los campos de ambas base de datos en un solo procedimiento almacenado*/
        int Matricular()
        {
            Est.GOVERMENT_ID = txtCedula.Text;
            Est.NAME01 = txtPrimerNombre.Text;
            Est.NAME02 = txtSegundoNombre.Text;
            Est.LASTANAME01 = txtPrimerApellido.Text;
            Est.LASTANAME02 = txtSegundoApellido.Text;
            pgCarga.Value = 5;
            int id_etnia = 0, id_etnia_campus = 0, Id_Procedencia= 0;
            foreach (DataRow row in tbl_Etnia.Rows)
            {
                if (Convert.ToString(row["nombre"]) == cbEtnia.Text)
                {
                    id_etnia = (Convert.ToInt32(row["id"]));
                }
            }
            switch (id_etnia)
            {
                case 1:
                    id_etnia_campus = 1004;
                    break;
                case 2:
                    id_etnia_campus = 1002;
                    break;
                case 3:
                    id_etnia_campus = 1003;
                    break;
                case 4:
                    id_etnia_campus = 1008;
                    break;
                case 5:
                    id_etnia_campus = 1005;
                    break;
                case 6:
                    id_etnia_campus = 1006;
                    break;


            }

            Est.ID_ETNIA = id_etnia_campus;

            String genero = "";
            if (cbSexo.Text == "MASCULINO")
            {
                genero = "M";
            }
            else
            {
                genero = "F";
            }
            pgCarga.Value = 10;
            Est.GENDER = genero;

            int id_martial = 0, id_marital_campus = 0;
            foreach (DataRow row in tbl_Estado_Marital.Rows)
            {
                if (Convert.ToString(row["nombre"]) == cbEstadoCivil.Text)
                {
                    id_martial = (Convert.ToInt32(row["Id"]));
                }
            }

            switch (id_martial)
            {
                case 1:
                    id_marital_campus = 1;
                    break;

                case 2:
                    id_marital_campus = 3;
                    break;
                case 3:
                    id_marital_campus = 2;
                    break;
                case 4:
                    id_marital_campus = 4;
                    break;
                case 5:
                    id_marital_campus = 5;
                    break;

            }
            pgCarga.Value = 15;

            Est.ID_MARITAL_STATUS = id_marital_campus;
            Est.ID_RELEGION = 1002;
            Est.ADDRES_COMPLETE = txtDireccion.Text;
            Est.ID_BIRTH_COUNTRY = 404;
            Est.ID_COUNTRY_LIVE = 404;
            Est.BIRTH_DATE = Convert.ToDateTime(dtFecha.Text);

            int id_departamento = 0;
            int id_departamento_campus = 0;

            foreach (DataRow row in tbl_Departamento.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == cbDepartamento.Text)
                {
                    id_departamento = (Convert.ToInt32(row["id"]));
                }
            }

            switch (id_departamento)
            {
                case 11:
                    id_departamento_campus = 1012;
                    break;
                case 8:
                    id_departamento_campus = 1009;
                    break;
                case 4:
                    id_departamento_campus = 1005;
                    break;
                case 12:
                    id_departamento_campus = 1013;
                    break;
                case 3:
                    id_departamento_campus = 1004;
                    break;
                case 18:
                    id_departamento_campus = 1024;
                    break;
                case 9:
                    id_departamento_campus = 1010;
                    break;
                case 13:
                    id_departamento_campus = 1014;
                    break;
                case 5:
                    id_departamento_campus = 1006;
                    break;
                case 2:
                    id_departamento_campus = 1003;
                    break;
                case 6:
                    id_departamento_campus = 1007;
                    break;
                case 7:
                    id_departamento_campus = 1008;
                    break;
                case 14:
                    id_departamento_campus = 1015;
                    break;
                case 1:
                    id_departamento_campus = 1002;
                    break;
                case 15:
                    id_departamento_campus = 1016;
                    break;
                case 16:
                    id_departamento_campus = 1017;
                    break;
                case 17:
                    id_departamento_campus = 1020;
                    break;
                case 10:
                    id_departamento_campus = 1011;
                    break;
                case 44:
                    id_departamento_campus = 1021;
                    break;
                case 45:
                    id_departamento_campus = 1023;
                    break;
            }
            pgCarga.Value = 20;
            Est.ID_DEPARTAMENTO = id_departamento_campus;

            int id_municipio = 0;
            int id_municipio_campus = 0;


            foreach (DataRow row in tbl_Municipio.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == cbMunicipio.Text)
                {
                    id_municipio_campus = (Convert.ToInt32(row["Id"]));
                }
            }
            switch (id_municipio_campus)
            {
                case 61:
                    id_municipio = 48;
                    break;
                case 36:
                    id_municipio = 117;
                    break;
                case 167:
                    id_municipio = 104;
                    break;
                case 159:
                    id_municipio = 96;
                    break;
                case 150:
                    id_municipio = 161;
                    break;
                case 4:
                    id_municipio = 108;
                    break;
                case 132:
                    id_municipio = 143;
                    break;
                case 5:
                    id_municipio = 109;
                    break;
                case 165:
                    id_municipio = 102;
                    break;
                case 102:
                    id_municipio = 79;
                    break;
                case 26:
                    id_municipio = 41;
                    break;
                case 23:
                    id_municipio = 38;
                    break;
                case 19:
                    id_municipio = 34;
                    break;
                case 125:
                    id_municipio = 8;
                    break;
                case 108:
                    id_municipio = 131;
                    break;
                case 83:
                    id_municipio = 60;
                    break;
                case 30:
                    id_municipio = 111;
                    break;
                case 39:
                    id_municipio = 25;
                    break;
                case 25:
                    id_municipio = 40;
                    break;
                case 151:
                    id_municipio = 162;
                    break;
                case 140:
                    id_municipio = 151;
                    break;
                case 121:
                    id_municipio = 4;
                    break;
                case 45:
                    id_municipio = 92;
                    break;
                case 10:
                    id_municipio = 84;
                    break;
                case 46:
                    id_municipio = 93;
                    break;
                case 89:
                    id_municipio = 66;
                    break;
                case 90:
                    id_municipio = 67;
                    break;
                case 91:
                    id_municipio = 68;
                    break;
                case 92:
                    id_municipio = 69;
                    break;
                case 93:
                    id_municipio = 70;
                    break;
                case 94:
                    id_municipio = 71;
                    break;
                case 95:
                    id_municipio = 72;
                    break;
                case 11:
                    id_municipio = 85;
                    break;
                case 153:
                    id_municipio = 165;
                    break;
                case 142:
                    id_municipio = 153;
                    break;
                case 156:
                    id_municipio = 168;
                    break;
                case 173:
                    id_municipio = 120;
                    break;
                case 87:
                    id_municipio = 64;
                    break;
                case 49:
                    id_municipio = 122;
                    break;
                case 126:
                    id_municipio = 9;
                    break;
                case 174:
                    id_municipio = 158;
                    break;
                case 24:
                    id_municipio = 39;
                    break;
                case 13:
                    id_municipio = 87;
                    break;
                case 60:
                    id_municipio = 47;
                    break;
                case 141:
                    id_municipio = 152;
                    break;
                case 15:
                    id_municipio = 30;
                    break;
                case 111:
                    id_municipio = 134;
                    break;
                case 41:
                    id_municipio = 27;
                    break;
                case 44:
                    id_municipio = 91;
                    break;
                case 127:
                    id_municipio = 10;
                    break;
                case 63:
                    id_municipio = 50;
                    break;
                case 54:
                    id_municipio = 127;
                    break;
                case 12:
                    id_municipio = 86;
                    break;
                case 31:
                    id_municipio = 112;
                    break;
                case 146:
                    id_municipio = 157;
                    break;
                case 96:
                    id_municipio = 73;
                    break;
                case 51:
                    id_municipio = 124;
                    break;
                case 8:
                    id_municipio = 90;
                    break;
                case 144:
                    id_municipio = 155;
                    break;
                case 32:
                    id_municipio = 113;
                    break;
                case 64:
                    id_municipio = 51;
                    break;
                case 14:
                    id_municipio = 88;
                    break;
                case 42:
                    id_municipio = 28;
                    break;
                case 145:
                    id_municipio = 156;
                    break;
                case 66:
                    id_municipio = 53;
                    break;
                case 105:
                    id_municipio = 82;
                    break;
                case 74:
                    id_municipio = 21;
                    break;
                case 56:
                    id_municipio = 43;
                    break;
                case 120:
                    id_municipio = 3;
                    break;
                case 76:
                    id_municipio = 23;
                    break;
                case 59:
                    id_municipio = 46;
                    break;
                case 88:
                    id_municipio = 65;
                    break;



            }
            pgCarga.Value = 25;
            Est.ID_MUNICIPIO = id_municipio;
            Est.ADDRES_MAIL = txtCorreoElectronico.Text;
            Est.HOUSE_NUMBER = txtCasa.Text;
            Est.PHONE01 = txtClaro.Text;
            Est.P_DESCRIPTION01 = "CLARO";
            Est.PHONE02 = txtTigo.Text;
            Est.P_DESCRIPTION02 = "TIGO";
            Est.PHONE03 = txtConvencional.Text;
            Est.P_DESCRIPTION03 = "CONVENCIONAL";
            Est.PEOPLE_TYPE = 32;

            int id_carrera = 0;
            foreach (DataRow row in tbl_Carrera.Rows)
            {
                if (Convert.ToString(row["CARRERA"]) == cbCarrera.Text)
                {
                    id_carrera = (Convert.ToInt32(row["CurriculumId"]));
                }
            }
            Est.ID_CURRICULUM = id_carrera;
            pgCarga.Value = 30;
            String Id_turno = "";
            foreach (DataRow row in turno.Rows)
            {
                if (Convert.ToString(row["nombre"]) == cbTurno.Text)
                {
                    Id_turno = (Convert.ToString(row["CODE_VALUE_KEY"]));
                }
            }

            Est.ACA_SESSION_P = Id_turno;


            //salida = campusBD.Insertar_Est_Recudiante_campus(Est.GOVERMENT_ID, Est.NAME01, Est.NAME02, Est.LASTANAME01, Est.LASTANAME02, Est.ID_ETNIA, Est.GENDER, Est.ID_MARITAL_STATUS, Est.ID_RELEGION, Est.ADDRES_COMPLETE, Est.BIRTH_DATE, Est.ID_BIRTH_COUNTRY, Est.ID_COUNTRY_LIVE, Est.ID_DEPARTAMENTO, Est.ID_MUNICIPIO, Est.ADDRES_MAIL, Est.HOUSE_NUMBER, Est.PHONE01, Est.P_DESCRIPTION01, Est.PHONE02, Est.P_DESCRIPTION02, Est.PHONE03, Est.P_DESCRIPTION03, Est.PEOPLE_TYPE, Est.ID_CURRICULUM, Est.ACA_SESSION_P);



            int Id_Estatal = 0, Id_centro_estudio= 0;
            pgCarga.Value = 35;
            //ID_Institucion_Estatal
            foreach (DataRow row in tbl_Instituciones_Estatles.Rows)
            {
                if (Convert.ToString(row["nombre"]) == cbeEstado.Text)
                {
                    Id_Estatal = (Convert.ToInt32(row["ID"]));
                }
            }

            //ID_Centro_Estudio
            foreach (DataRow row in tbl_Centro_Estudios.Rows)
            {
                if (Convert.ToString(row["nombre"]) == cbeCentros.Text)
                {
                    Id_centro_estudio = (Convert.ToInt32(row["Id"]));
                }
            }
            pgCarga.Value = 40;
            //Zurdo o Diestro
            int Id_Izquierdo = 0, IdDerecho = 0;
            if (cbMano.Text == "ZURDO")
            {
                Id_Izquierdo = 2;
            }
            else
            {
                IdDerecho = 1;
            }

            //Discapacidad
            int IdSordera = 0, IdCeguera = 0, IdMotora = 0;
            int IdTEA = 0, IdTDAH = 0, IdSordo_Mudo = 0, IdNinguna = 0;
            foreach (DataRow row in tbl_Discapacidad.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == cbDiscapacidad.Text)
                {
                    if ((Convert.ToInt32(row["Id"]) == 4))
                    {
                        IdCeguera = 4;
                    }

                    if ((Convert.ToInt32(row["Id"]) == 5))
                    {
                        IdMotora = 5;
                    }
                    if ((Convert.ToInt32(row["Id"]) == 8))
                    {
                        IdSordo_Mudo = 8;
                    }

                    if ((Convert.ToInt32(row["Id"]) == 9))
                    {
                        IdNinguna = 9;
                    }

                    if ((Convert.ToInt32(row["Id"]) == 3))
                    {
                        IdSordera = 3;
                    }

                    if ((Convert.ToInt32(row["Id"]) == 7))
                    {
                        IdTDAH = 7;
                    }
                    if ((Convert.ToInt32(row["Id"]) == 6))
                    {
                        IdTEA = 6;
                    }

                }
            }

            //Cuenta Acceso Internte
            int Id_Acceso = 2;

            if (cbAccesoInternet.Text == "SI")
            {
                Id_Acceso = 4;
            }

            //Proveedor de Internet
            int Id_Proveedor = 0;
            foreach (DataRow row in dtProveedor.Rows)
            {
                if (Convert.ToString(row["ProveedorIntenet"]) == cbTurno.Text)
                {
                    Id_Proveedor = (Convert.ToInt32(row["id"]));
                }
            }

            pgCarga.Value = 45;
            //Dispositivos
            int Idcomputadora = 0, Idtablet = 0, Idcelular = 0;

            if (chkCompu.Checked == true)
            {
                Idcomputadora = 1;
            }

            if (chkTableta.Checked == true)
            {
                Idtablet = 3;
            }

            if (chkCelular.Checked == true)
            {
                Idcelular = 2;
            }

            //Tipo de Conexion
            int IdTipoConexion = 0;

            if (cbTipoConexion.Text == "INTERNET MOVIL")
            {
                IdTipoConexion = 1;
            }
            else
            {
                IdTipoConexion = 2;
            }


            //ID_Procedencia
            foreach (DataRow row in tbl_nacionalidad.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == cbNacionalidad.Text)
                {
                    Id_Procedencia = (Convert.ToInt32(row["Id"]));
                }
            }

            pgCarga.Value = 50;

            salida = campusBD.Insertar_Estudiante_2(Est.GOVERMENT_ID, Est.NAME01, Est.NAME02, Est.LASTANAME01, Est.LASTANAME02, Est.ID_ETNIA,
                                                        Est.GENDER, Est.ID_MARITAL_STATUS, Est.ID_RELEGION, Est.ADDRES_COMPLETE, Est.BIRTH_DATE,
                                                        Est.ID_BIRTH_COUNTRY, Est.ID_COUNTRY_LIVE, Est.ID_DEPARTAMENTO, Est.ID_MUNICIPIO, Est.ADDRES_MAIL,
                                                        Est.HOUSE_NUMBER, Est.PHONE01, Est.P_DESCRIPTION01, Est.PHONE02, Est.P_DESCRIPTION02, Est.PHONE03,
                                                        Est.P_DESCRIPTION03, Est.PEOPLE_TYPE, Est.ID_CURRICULUM, Est.ACA_SESSION_P, txtBarrio.Text, Id_Procedencia,
                                                        Id_Estatal, Id_centro_estudio, Convert.ToInt32(cbAnioFin.Text), float.Parse(txtPromG.Text), txtOtroCentro.Text, Id_Izquierdo, IdDerecho
                                                        , IdSordera, IdCeguera, IdMotora, IdTEA, IdTDAH, IdSordo_Mudo, IdNinguna, Id_Acceso, Id_Proveedor, Idcomputadora,
                                                       Idtablet, Idcelular, IdTipoConexion, Convert.ToInt32(txtMat4.Text), Convert.ToInt32(txtLL4.Text),
                                                       Convert.ToInt32(txtGeo4.Text), Convert.ToInt32(txtFis4.Text), Convert.ToInt32(txtQuimi4.Text),
                                                       Convert.ToInt32(txtMat5.Text), Convert.ToInt32(txtLL5.Text), Convert.ToInt32(txtHistoria5.Text),
                                                        Convert.ToInt32(txtFisica5.Text), Convert.ToInt32(txtQuimi5.Text));
            pgCarga.Value = 70;
            //txtOtroCentro.Text, Id_Izquierdo, IdDerecho,
            //                                            IdSordera, IdCeguera, IdMotora, IdTEA, IdTDAH, IdSordo_Mudo, IdNinguna, Id_Acceso, Id_Proveedor, Idcomputadora,
            //                                            Idtablet, Idcelular, IdTipoConexion, Convert.ToInt32(txtMat4.Text), Convert.ToInt32(txtLL4.Text),
            //                                            Convert.ToInt32(txtGeo4.Text), Convert.ToInt32(txtFis4.Text), Convert.ToInt32(txtQuimi4.Text),
            //                                            Convert.ToInt32(txtMat5.Text), Convert.ToInt32(txtLL5.Text), Convert.ToInt32(txtHistoria5.Text),
            //                                            Convert.ToInt32(txtFisica5.Text), Convert.ToInt32(txtQuimi5.Text));

            return salida;
        }



        /*Seccion para nuevo Metodo en donde se enviaran todos los campos de ambas base de datos en un solo procedimiento almacenado*/


        int cargar_datos()
        {
            Est.GOVERMENT_ID = txtCedula.Text;
            Est.NAME01 = txtPrimerNombre.Text;
            Est.NAME02 = txtSegundoNombre.Text;
            Est.LASTANAME01 = txtPrimerApellido.Text;
            Est.LASTANAME02 = txtSegundoApellido.Text;

            int id_etnia = 0, id_etnia_campus = 0;
            foreach (DataRow row in tbl_Etnia.Rows)
            {
                if (Convert.ToString(row["nombre"]) == cbEtnia.Text)
                {
                    id_etnia = (Convert.ToInt32(row["id"]));
                }
            }

            switch (id_etnia)
            {
                case 1:
                    id_etnia_campus = 1004;
                    break;
                case 2:
                    id_etnia_campus = 1002;
                    break;
                case 3:
                    id_etnia_campus = 1003;
                    break;
                case 4:
                    id_etnia_campus = 1008;
                    break;
                case 5:
                    id_etnia_campus = 1005;
                    break;
                case 6:
                    id_etnia_campus = 1006;
                    break;


            }

            Est.ID_ETNIA = id_etnia_campus;

            String genero = "";
            if (cbSexo.Text == "MASCULINO")
            {
                genero = "M";
            }
            else
            {
                genero = "F";
            }

            Est.GENDER = genero;

            int id_martial = 0,id_marital_campus = 0;
            foreach (DataRow row in tbl_Estado_Marital.Rows)
            {
                if (Convert.ToString(row["nombre"]) == cbEstadoCivil.Text)
                {
                    id_martial = (Convert.ToInt32(row["Id"]));
                }
            }

            switch(id_martial)
            {
                case 1 :
                    id_marital_campus = 1;
                 break;

                case 2:
                    id_marital_campus = 3;
                    break;
                case 3:
                    id_marital_campus = 2;
                    break;
                case 4:
                    id_marital_campus = 4;
                    break;
                case 5:
                    id_marital_campus = 5;
                    break;

            }


            Est.ID_MARITAL_STATUS = id_marital_campus;
            Est.ID_RELEGION = 1002;
            Est.ADDRES_COMPLETE = txtDireccion.Text;
            Est.ID_BIRTH_COUNTRY = 404;
            Est.ID_COUNTRY_LIVE = 404;
            Est.BIRTH_DATE = Convert.ToDateTime(dtFecha.Text);

            int id_departamento = 0;
            int id_departamento_campus = 0;

            foreach (DataRow row in tbl_Departamento.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == cbDepartamento.Text)
                {
                    id_departamento = (Convert.ToInt32(row["id"]));
                }
            }

            switch (id_departamento)
            {
                case 11:
                    id_departamento_campus = 1012;
                    break;
                case 8:
                    id_departamento_campus = 1009;
                    break;
                case 4:
                    id_departamento_campus = 1005;
                    break;
                case 12:
                    id_departamento_campus = 1013;
                    break;
                case 3:
                    id_departamento_campus = 1004;
                    break;
                case 18:
                    id_departamento_campus = 1024;
                    break;
                case 9:
                    id_departamento_campus = 1010;
                    break;
                case 13:
                    id_departamento_campus = 1014;
                    break;
                case 5:
                    id_departamento_campus = 1006;
                    break;
                case 2:
                    id_departamento_campus = 1003;
                    break;
                case 6:
                    id_departamento_campus = 1007;
                    break;
                case 7:
                    id_departamento_campus = 1008;
                    break;
                case 14:
                    id_departamento_campus = 1015;
                    break;
                case 1:
                    id_departamento_campus = 1002;
                    break;
                case 15:
                    id_departamento_campus = 1016;
                    break;
                case 16:
                    id_departamento_campus = 1017;
                    break;
                case 17:
                    id_departamento_campus = 1020;
                    break;
                case 10:
                    id_departamento_campus = 1011;
                    break;
                case 44:
                    id_departamento_campus = 1021;
                    break;
                case 45:
                    id_departamento_campus = 1023;
                    break;
            }

            Est.ID_DEPARTAMENTO = id_departamento_campus;

            int id_municipio = 0;
            int id_municipio_campus = 0;


            foreach (DataRow row in tbl_Municipio.Rows)
            {
                if (Convert.ToString(row["Nombre"]) == cbMunicipio.Text)
                {
                    id_municipio_campus = (Convert.ToInt32(row["Id"]));
                }
            }
            switch (id_municipio_campus)
            {
                case 61:
                    id_municipio = 48;
                    break;
                case 36:
                    id_municipio = 117;
                    break;
                case 167:
                    id_municipio = 104;
                    break;
                case 159:
                    id_municipio = 96;
                    break;
                case 150:
                    id_municipio = 161;
                    break;
                case 4:
                    id_municipio = 108;
                    break;
                case 132:
                    id_municipio = 143;
                    break;
                case 5:
                    id_municipio = 109;
                    break;
                case 165:
                    id_municipio = 102;
                    break;
                case 102:
                    id_municipio = 79;
                    break;
                case 26:
                    id_municipio = 41;
                    break;
                case 23:
                    id_municipio = 38;
                    break;
                case 19:
                    id_municipio = 34;
                    break;
                case 125:
                    id_municipio = 8;
                    break;
                case 108:
                    id_municipio = 131;
                    break;
                case 83:
                    id_municipio = 60;
                    break;
                case 30:
                    id_municipio = 111;
                    break;
                case 39:
                    id_municipio = 25;
                    break;
                case 25:
                    id_municipio = 40;
                    break;
                case 151:
                    id_municipio = 162;
                    break;
                case 140:
                    id_municipio = 151;
                    break;
                case 121:
                    id_municipio = 4;
                    break;
                case 45:
                    id_municipio = 92;
                    break;
                case 10:
                    id_municipio = 84;
                    break;
                case 46:
                    id_municipio = 93;
                    break;
                case 89:
                    id_municipio = 66;
                    break;
                case 90:
                    id_municipio = 67;
                    break;
                case 91:
                    id_municipio = 68;
                    break;
                case 92:
                    id_municipio = 69;
                    break;
                case 93:
                    id_municipio = 70;
                    break;
                case 94:
                    id_municipio = 71;
                    break;
                case 95:
                    id_municipio = 72;
                    break;
                case 11:
                    id_municipio = 85;
                    break;
                case 153:
                    id_municipio = 165;
                    break;
                case 142:
                    id_municipio = 153;
                    break;
                case 156:
                    id_municipio = 168;
                    break;
                case 173:
                    id_municipio = 120;
                    break;
                case 87:
                    id_municipio = 64;
                    break;
                case 49:
                    id_municipio = 122;
                    break;
                case 126:
                    id_municipio = 9;
                    break;
                case 174:
                    id_municipio = 158;
                    break;
                case 24:
                    id_municipio = 39;
                    break;
                case 13:
                    id_municipio = 87;
                    break;
                case 60:
                    id_municipio = 47;
                    break;
                case 141:
                    id_municipio = 152;
                    break;
                case 15:
                    id_municipio = 30;
                    break;
                case 111:
                    id_municipio = 134;
                    break;
                case 41:
                    id_municipio = 27;
                    break;
                case 44:
                    id_municipio = 91;
                    break;
                case 127:
                    id_municipio = 10;
                    break;
                case 63:
                    id_municipio = 50;
                    break;
                case 54:
                    id_municipio = 127;
                    break;
                case 12:
                    id_municipio = 86;
                    break;
                case 31:
                    id_municipio = 112;
                    break;
                case 146:
                    id_municipio = 157;
                    break;
                case 96:
                    id_municipio = 73;
                    break;
                case 51:
                    id_municipio = 124;
                    break;
                case 8:
                    id_municipio = 90;
                    break;
                case 144:
                    id_municipio = 155;
                    break;
                case 32:
                    id_municipio = 113;
                    break;
                case 64:
                    id_municipio = 51;
                    break;
                case 14:
                    id_municipio = 88;
                    break;
                case 42:
                    id_municipio = 28;
                    break;
                case 145:
                    id_municipio = 156;
                    break;
                case 66:
                    id_municipio = 53;
                    break;
                case 105:
                    id_municipio = 82;
                    break;
                case 74:
                    id_municipio = 21;
                    break;
                case 56:
                    id_municipio = 43;
                    break;
                case 120:
                    id_municipio = 3;
                    break;
                case 76:
                    id_municipio = 23;
                    break;
                case 59:
                    id_municipio = 46;
                    break;
                case 88:
                    id_municipio = 65;
                    break;
   

           
        }

            Est.ID_MUNICIPIO = id_municipio;
            Est.ADDRES_MAIL = txtCorreoElectronico.Text;
            Est.HOUSE_NUMBER = txtCasa.Text;
            Est.PHONE01 = txtClaro.Text;
            Est.P_DESCRIPTION01 = "CLARO";
            Est.PHONE02 = txtTigo.Text;
            Est.P_DESCRIPTION02 = "TIGO";
            Est.PHONE03 = txtConvencional.Text;
            Est.P_DESCRIPTION03 = "CONVENCIONAL";
            Est.PEOPLE_TYPE = 32;

            int id_carrera = 0;
            foreach (DataRow row in tbl_Carrera.Rows)
            {
                if (Convert.ToString(row["CARRERA"]) == cbCarrera.Text)
                {
                    id_carrera = (Convert.ToInt32(row["CurriculumId"]));
                }
            }
            Est.ID_CURRICULUM = id_carrera;

            String Id_turno="";
            foreach (DataRow row in turno.Rows)
            {
                if (Convert.ToString(row["nombre"]) == cbTurno.Text)
                {
                    Id_turno = (Convert.ToString(row["CODE_VALUE_KEY"]));
                }
            }

            Est.ACA_SESSION_P = Id_turno;

          
            salida = campusBD.Insertar_Est_Recudiante_campus(Est.GOVERMENT_ID, Est.NAME01, Est.NAME02, Est.LASTANAME01, Est.LASTANAME02,  Est.ID_ETNIA, Est. GENDER, Est.ID_MARITAL_STATUS, Est.ID_RELEGION, Est.ADDRES_COMPLETE, Est.BIRTH_DATE, Est.ID_BIRTH_COUNTRY, Est.ID_COUNTRY_LIVE, Est.ID_DEPARTAMENTO, Est.ID_MUNICIPIO, Est.ADDRES_MAIL, Est.HOUSE_NUMBER, Est.PHONE01, Est.P_DESCRIPTION01, Est.PHONE02, Est.P_DESCRIPTION02, Est.PHONE03, Est.P_DESCRIPTION03, Est.PEOPLE_TYPE, Est.ID_CURRICULUM, Est.ACA_SESSION_P);
            return salida;
        }

        private void cbeCentros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbeCentros.Text == "CENTRO NO REGISTRADO")
            {
                lbOtroCentro.Visible = true;
                txtOtroCentro.Visible = true;
            }
            else
            {
                lbOtroCentro.Visible = false;
                txtOtroCentro.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            pgCarga.Visible = true;
            lbCarga.Visible = true;
        }

        private void proPanel_Click(object sender, EventArgs e)
        {

        }

        private void cbeCentros_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbeCentros.Text == "CENTRO NO REGISTRADO")
                { txtOtroCentro.Visible = true;
                lbOtroCentro.Visible = true;
            }
            else
            {
                txtOtroCentro.Visible = false;
                lbOtroCentro.Visible = false;
            }

            //se utiliza este evento para encontrar el departemanto seleccionado y asi obtener los municipios de dicho departamento
            //string centro;
            //centro = cbeCentros.Text;

            //foreach (DataRow row in tbl_Departamento.Rows)
            //{
            //    if (Convert.ToString(row["Nombre"]) == departamento)
            //    {
            //        tbl_Municipio = prematricula.Mostrar_Municipio(Convert.ToInt32(row["id"]));
            //    }
            //}

            //cbeCentros.Items.Clear();
            //cbeCentros.Text = "";
            //foreach (DataRow row in tbl_Centro_Estudios.Rows)
            //{
            //    cbCentroEstudios.Items.Add(Convert.ToString(row["nombre"]));
            //}
            //// Establecer el modo de autocompletado
            //cbCentroEstudios.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbCentroEstudios.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void cbeCentros_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void cbeEstado_Click(object sender, EventArgs e)
        {
            llenar_Instituciones_Estatales();
        }
    }
}
