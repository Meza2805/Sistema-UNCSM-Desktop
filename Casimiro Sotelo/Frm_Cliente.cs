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
using System.Media;


namespace Ginmasio
{
    public partial class Frm_Cliente : Form
    {
        CRUD_Cliente Estuante_Prematricua = new CRUD_Cliente();
        campus insertar = new campus();
        Mensaje_Suscripcion mensaje = new Mensaje_Suscripcion();
        Frm_Alerta mensaje_02 = new Frm_Alerta();
        //Variables Goblales********************************************
        public static string @GOVERMENT_ID, @NAME01, @NAME02, @LASTNAME01, @LASTNAME02, @GENDER, @ADDRES_COMPLETE, @ADDRES_MAIL, @HOUSE_NUMBER, @PHONE01, @P_DESCRIPTION01, @PHONE02, @P_DESCRIPTION02, @PHONE03, @P_DESCRIPTION03, @ACA_SESSION_P;

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        //private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        // Llamar a tu función aquí
        //        busqueda_insecto();
        //        // Indicar que se ha manejado la tecla para evitar su procesamiento adicional
        //        e.Handled = true;
        //    }
        //}

        public static int @ID_ETNIA, @ID_MARITAL_STATUS, @ID_REGLIGION, @ID_BIRTH_COUNTRY, @ID_COUNTRY_LIVE, @ID_DEPARTMENTO, @ID_MUNICIPIO, @PEOPLE_TYPE, @ID_CURRICULUM_P;
        public static DateTime @BIRTH_DATE;

        public static String genero = "", turno = "";


        //void busqueda_insecto()
        //{

        //    DataTable Respuesta = new DataTable();

        //    if (txtBusqueda.Text == "")
        //    {
        //        MessageBox.Show("DEBE INGRESAR UN VALOR PARA INICAR BUSQUEDA");
        //    }
        //    else
        //    {
        //        if (cbTipo.SelectedIndex == 1) //BUSQUEDA POR CEDULA
        //        {
        //            Respuesta = Estuante_Prematricua.Busca_Estudiante_Cedual(txtBusqueda.Text, "", 1);
        //            if (Respuesta.Rows.Count == 0)
        //            {
        //                MessageBox.Show("NO SE ENCONTRARON REGISTROS");
        //                txtBusqueda.Clear();
        //            }
        //            else
        //            {
        //                Obtener_valores();
        //            }

        //        }
        //        else if (cbTipo.SelectedIndex == 0)
        //        {
        //            Respuesta = Estuante_Prematricua.Busca_Estudiante_Cedual("", txtBusqueda.Text, 2);

        //            if (Respuesta.Rows.Count == 0)
        //            {
        //                MessageBox.Show("NO SE ENCONTRARON REGISTROS");
        //                txtBusqueda.Clear();
        //            }
        //            else
        //            {
        //                Obtener_valores();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("DEBE SELECCIONAR UNA OPCION PARA INICAR BUSQUEDA");
        //        }
        //    }

        //    void Obtener_valores()
        //    {
        //        foreach (DataRow row in Respuesta.Rows)
        //        {


        //            txtCedula.Text = Convert.ToString(row["GOVERMENT_ID"]);
        //            txtPrimer_Nombre.Text = Convert.ToString(row["NAME_01"]);
        //            txtSegundo_Nombre.Text = Convert.ToString(row["NAME_02"]);
        //            txtPrimerApellido.Text = Convert.ToString(row["LASTNAME01"]);
        //            txtSegundoApellido.Text = Convert.ToString(row["LAST_NAME02"]);
        //            genero = Convert.ToString(row["GENDER"]);
        //            if (genero == "F")
        //            {
        //                txtSexo.Text = "FEMENINO";
        //                cbSexo.Text = "FEMENINO";

        //            }
        //            else
        //            {
        //                txtSexo.Text = "MASCULINO";
        //                cbSexo.Text = "MASCULINO";
        //            }
        //            txtDireccion.Text = Convert.ToString(row["ADDRES_COMPLETE"]);
        //            DtpFecha_Nac.Text = Convert.ToString(row["BIRTH_DATE"]);
        //            txtEstadoCivil.Text = Convert.ToString(row["ESTADO_CIVIL"]);
        //            txtDepartamento.Text = Convert.ToString(row["DEPARTAMENTO"]);
        //            txtMunicip.Text = Convert.ToString(row["MUNICIPIO"]);
        //            txtCasa.Text = Convert.ToString(row["HOUSE_NUMBER"]);
        //            txtCovencional.Text = Convert.ToString(row["TeleConvencional"]);
        //            txtClaro.Text = Convert.ToString(row["telefclaro"]);
        //            txtTigo.Text = Convert.ToString(row["teleftigo"]);
        //            txtMail.Text = Convert.ToString(row["ADDRES_MAIL"]);
        //            txtFacultad.Text = Convert.ToString(row["AREA"]);
        //            txtCarrera.Text = Convert.ToString(row["NOMBRE_CARRERA"]);

        //            turno = Convert.ToString(row["ID_TURNO"]);
        //            if (turno == "3")
        //            {
        //                txtTurno.Text = "MATUTINO";
        //            }
        //            else
        //            {
        //                txtTurno.Text = "VESPERTINO";
        //            }

        //            ///CARGANDO LOS DATOS PARA INSERTAR LA MATRICULA

        //            @ID_MARITAL_STATUS = Convert.ToInt32(row["ID_MARITAL_STATUS"]);

        //            @ADDRES_COMPLETE = txtDireccion.Text;
        //            @ID_DEPARTMENTO = Convert.ToInt32(row["ID_DEPARTAMENTO"]);
        //            @ID_MUNICIPIO = Convert.ToInt32(row["ID_MUNICIPIO"]);
        //            @ADDRES_MAIL = Convert.ToString(row["ADDRES_MAIL"]);
        //            @HOUSE_NUMBER = Convert.ToString(row["HOUSE_NUMBER"]);


        //            @ID_CURRICULUM_P = Convert.ToInt32(row["id_carrera"]);
        //            @ACA_SESSION_P = Convert.ToString(row["ID_TURNO"]);



        //        }

        //    }
        //}

        //private void btnBusqueda_Click(object sender, EventArgs e)
        //{
        //    busqueda_insecto();
        //}


        //private void btnConfirmar_Click(object sender, EventArgs e)
        //{
        //    guardar();
        //}



        ////void guardar()
        ////{
        ////    int salida = 0;
        ////    @P_DESCRIPTION01 = "CLARO";
        ////    @PHONE02 = txtTigo.Text;
        ////    @P_DESCRIPTION02 = "TIGO";
        ////    @PHONE03 = txtCovencional.Text;
        ////    @P_DESCRIPTION03 = "CONVENCIONAL";
        ////    @PHONE01 = txtClaro.Text;
        ////    @ID_BIRTH_COUNTRY = 404;
        ////    @ID_COUNTRY_LIVE = 404;
        ////    @ID_REGLIGION = 1002;
        ////    @GOVERMENT_ID = txtCedula.Text;
        ////    @NAME01 = txtPrimer_Nombre.Text;
        ////    @NAME02 = txtSegundo_Nombre.Text;
        ////    @LASTNAME01 = txtPrimerApellido.Text;
        ////    @LASTNAME02 = txtSegundoApellido.Text;
        ////    @ID_ETNIA = 1007;
        ////    if (cbSexo.Text == "FEMENINO")
        ////    {
        ////        genero = "F";
        ////    }
        ////    else
        ////    {
        ////        genero = "M";
        ////    }
        ////    @GENDER = genero;
        ////    @PEOPLE_TYPE = 32;
        ////    @BIRTH_DATE = Convert.ToDateTime(DtpFecha_Nac.Text);
        ////    salida = insertar.Insertar_Estudiante(@GOVERMENT_ID, @NAME02, @LASTNAME01, @LASTNAME02, @ID_ETNIA, @GENDER, @ID_MARITAL_STATUS, @ID_REGLIGION, @ADDRES_COMPLETE, @BIRTH_DATE, @ID_BIRTH_COUNTRY, @ID_COUNTRY_LIVE, @ID_DEPARTMENTO, @ID_MUNICIPIO, @ADDRES_MAIL, @HOUSE_NUMBER, @PHONE01, @P_DESCRIPTION01, @PHONE02, @P_DESCRIPTION02, @PHONE03, @P_DESCRIPTION03, @PEOPLE_TYPE, @ID_CURRICULUM_P, @ACA_SESSION_P, @NAME01);

        ////    if (salida == 1)
        ////    {
        ////        mensaje.ShowDialog();
        ////    }
        ////    else
        ////    {
        ////        mensaje_02.ShowDialog();
        ////    }

        ////    //MessageBox.Show("OPERACION FINALIZADA");

        ////    limpiar_texbox();

        ////}

        //public void limpiar_texbox()
        //{
        //    txtBusqueda.Clear();
        //    txtCedula.Clear();
        //    txtPrimer_Nombre.Clear();
        //    txtSegundo_Nombre.Clear();
        //    txtPrimerApellido.Clear();
        //    txtSegundoApellido.Clear();
        //    txtSexo.Clear();
        //    txtEstadoCivil.Clear();
        //    txtDepartamento.Clear();
        //    txtMunicip.Clear();
        //    txtDireccion.Clear();
        //    txtCasa.Clear();
        //    txtCovencional.Clear();
        //    txtClaro.Clear();
        //    txtTigo.Clear();
        //    txtMail.Clear();
        //    txtFacultad.Clear();
        //    txtTurno.Clear();
        //    txtCarrera.Clear();

        //    DtpFecha_Nac.Text = "";
        //    cbSexo.SelectedIndex = -1;
        //}

        //public Frm_Cliente()
        //{
        //    InitializeComponent();
        //    llenar_cb();
        //    llenar_cbSexo();
        //    DtpFecha_Nac.Text = "";
        //    ////mostrar_clientes();
        //    //limpiar_texbox();
        //    //Cantidad_Cliente();

        //}


        /*EVENTO DE BOTON BUSCAR ESTUDIANTE*/
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //DgvCliente.DataSource =  Estuante_Prematricua.Busca_Estudiante_Cedual(txtCedula.Text);
        }

        //public void llenar_cb()
        //{
        //    cbTipo.Text = "SELECCIONE TIPO";
        //    //cbSexo.Items.Add("--------------");
        //    cbTipo.Items.Add("NO. CEDULA");
        //    cbTipo.Items.Add("CODIGO DE BOLETA");


        //}


        //public void llenar_cbSexo()
        //{
        //    cbSexo.Text = "SEXO";
        //    //cbSexo.Items.Add("--------------");
        //    cbSexo.Items.Add("FEMENINO");
        //    cbSexo.Items.Add("MASCULINO");


        //}


        //Metodos implementados************************************************
        //*********************************************************************


        //public void sonido_boton ()
        //{
        //    SoundPlayer boton = new SoundPlayer(@"C:\BD\Repositorio para Base de Datos Sql Server\Gimnasio\Base-de-Datos-Gimnasio\Proyecto de Visual Studio C#\Ginmasio\Resources\Sonido_boton.wav");
        //    boton.Play();
        //}
        //public void mostrar_clientes()
        //{

        //    DgvCliente.DataSource = CCliente.Mostrar_Cliente();

        //}



        //public void DgvCliente_SelectionChanged(object sender, EventArgs e)  //metodo para colocar los datos de la tabla en los textboxs
        //{
        //    try
        //    {
        //        string sexo, f;
        //        DateTime fecha_nac;
        //        txtCedula.Text = DgvCliente.CurrentRow.Cells[0].Value.ToString();
        //        txtPrimer_Nombre.Text = DgvCliente.CurrentRow.Cells[1].Value.ToString();
        //        txtSegundo_Nombre.Text = DgvCliente.CurrentRow.Cells[2].Value.ToString();
        //        txtPrimerApellido.Text = DgvCliente.CurrentRow.Cells[3].Value.ToString();
        //        txtSegundoApellido.Text = DgvCliente.CurrentRow.Cells[4].Value.ToString();
        //        sexo = DgvCliente.CurrentRow.Cells[5].Value.ToString();
        //        if (sexo.Equals("F"))
        //        {
        //            cbSexo.SelectedIndex = 1;
        //        }
        //        else
        //        {
        //            cbSexo.SelectedIndex = 2;
        //        }
        //        //txtFechaNac.Text = DgvCliente.CurrentRow.Cells[7].Value.ToString();
        //        txtFechaRegistro.Text = DgvCliente.CurrentRow.Cells[6].Value.ToString();
        //        f = DgvCliente.CurrentRow.Cells[7].Value.ToString();
        //        fecha_nac = Convert.ToDateTime(f);
        //        DtpFecha_Nac.Text = fecha_nac.ToShortDateString();
        //        txtEstado.Text = DgvCliente.CurrentRow.Cells[8].Value.ToString();
        //    }
        //    catch (NullReferenceException)
        //    {

        //        //mostrar_clientes();
        //    }
        //}

        //public Boolean validar_Espacios_vacios() //Metodo para validar que los campos importantes no estan vacios
        //{
        //    Boolean band = true;
        //    if (txtCedula.Text.Length < 16)
        //    {
        //        band = false;
        //        Error_Provider.SetError(txtCedula, "Cedula Incompleta o Espacio vacio");
        //    }
        //    if (txtPrimer_Nombre.Text.Length == 0)
        //    {
        //        band = false;
        //        Error_Provider.SetError(txtPrimer_Nombre,"Este campo no puede estar vacio");
        //    }
        //    if (txtPrimerApellido.Text.Length == 0)
        //    {
        //        band = false;
        //        Error_Provider.SetError(txtPrimerApellido, "Este campo no puede estar vacio");
        //    }
        //    if (cbSexo.SelectedIndex == 0)
        //    {
        //        Error_Provider.SetError(cbSexo,"Seleccione un Sexo");
        //        band = false;
        //    }
        //        DateTime fecha = DateTime.Now;
        //    if (DtpFecha_Nac.Text == fecha.ToShortDateString())
        //    {
        //        Error_Provider.SetError(DtpFecha_Nac,"Ingrese Fecha de Nacimiento");
        //        band = false;
        //    }
        //    return band;
        //}

        //public Boolean validar_Cedula() //Metodo para validar si el campo de ceudla esta vacio o incompleto
        //{
        //    Boolean band = true;
        //    if (txtCedula.Text.Length < 16)
        //    {
        //        band = false;
        //        Error_Provider.SetError(txtCedula, "Cedula Incompleta o Espacio vacio");
        //    }
        //    return band;
        //}
        //public void Borrar_ErrorProvider ()
        //{
        //    Error_Provider.SetError(txtCedula,"");
        //    Error_Provider.SetError(txtPrimer_Nombre, "");
        //    Error_Provider.SetError(txtPrimerApellido, "");
        //    Error_Provider.SetError(cbSexo, "");
        //    Error_Provider.SetError(DtpFecha_Nac, "");
        //}







        //public void Cantidad_Cliente()
        //{
        //    txtTotalClientes.Text = Convert.ToString(CCliente.Cantidad_Cliente().total);
        //    txtMembresiaActiva.Text = Convert.ToString(CCliente.Cantidad_Cliente().activo);
        //    txtMembresiaInactiva.Text = Convert.ToString(CCliente.Cantidad_Cliente().inactivo);
        //}





        private void btnSalirCliente_Click(object sender, EventArgs e)
        {
            //sonido_boton();
            this.Close();
        }

        //private void btnActualizar_Click(object sender, EventArgs e)
        //{
        //    //sonido_boton();
        //    Borrar_ErrorProvider();
        //    if ((validar_Espacios_vacios() == true))
        //    {
        //        Cedula = txtCedula.Text;
        //        PNombre = txtPrimer_Nombre.Text;
        //        SNombre = txtSegundo_Nombre.Text;
        //        PApellido = txtPrimerApellido.Text;
        //        SApellido = txtSegundoApellido.Text;
        //        if (cbSexo.SelectedIndex == 1)
        //        {
        //            sexo_char = 'F';
        //        }
        //        else
        //        {
        //            sexo_char = 'M';
        //        }
        //        Fecha_Nac = DtpFecha_Nac.Text;
        //        if (CCliente.Actualizar_cliente(Cedula, PNombre, SNombre, PApellido, SApellido, sexo_char, Fecha_Nac) == true)
        //        {
        //            MessageBox.Show("CLIENTE ACTUALIZADO", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            //mostrar_clientes();
        //            Cantidad_Cliente();
        //        }
        //        else
        //        {
        //           MessageBox.Show("ERROR AL ACTUALIZAR", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //           limpiar_texbox();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("ERROR", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }


        //}



        ///Metodos de eventos de Botones*************************************************************************************
        ///******************************************************************************************************************
        //private void btnCerrar_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show("SE CERRARA LA VENTANA DE CLIENTES", "ATENCION", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == (System.Windows.Forms.DialogResult.Yes))
        //    {
        //        this.Close();
        //    }
        //}
        //private void btnInsertar_Click(object sender, EventArgs e) //Evento de Boton Insertar
        //{
        //    //sonido_boton();
        //    Borrar_ErrorProvider();
        //   if ((validar_Espacios_vacios() ==  true) )
        //    {
        //        Cedula = txtCedula.Text;
        //        PNombre = txtPrimer_Nombre.Text;
        //        SNombre = txtSegundo_Nombre.Text;
        //        PApellido = txtPrimerApellido.Text;
        //        SApellido = txtSegundoApellido.Text;
        //        if (cbSexo.SelectedIndex == 1)
        //        {
        //            sexo_char = 'F';
        //        }
        //        else
        //        {
        //            sexo_char = 'M';
        //        }
        //        Fecha_Nac = DtpFecha_Nac.Text;
        //        if (CCliente.Insertar_Cliente(Cedula, PNombre, SNombre, PApellido, SApellido, sexo_char, Fecha_Nac) == true)
        //        {
        //            MessageBox.Show("CLIENTE INGRESADO", "ATENCION",MessageBoxButtons.OK,MessageBoxIcon.Information);

        //            mostrar_clientes();
        //            Cantidad_Cliente();
        //        }
        //        else
        //        {
        //            MessageBox.Show("EL CLIENTE YA EXISTE EN LA BASE DE DATOS", "ATENCION",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        //            limpiar_texbox();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("ERROR", "ADVERTENCIA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        //    }



        //}

        //private void btnBuscar_Click(object sender, EventArgs e)
        //{
        //    //sonido_boton();
        //    Borrar_ErrorProvider();
        //    int Fila;
        //    bool band=false;
        //    String Cedula;
        //    if (validar_Cedula()==true)
        //    {
        //        foreach (DataGridViewRow Row in DgvCliente.Rows)
        //        {
        //            Fila = Row.Index;
        //            Cedula = Row.Cells["NO. CEDULA"].Value.ToString();
        //            if (Cedula.Equals(txtCedula.Text))
        //            {
        //                DgvCliente.ClearSelection();
        //                DgvCliente.CurrentCell = DgvCliente.Rows[Fila].Cells[0];
        //                band = true;
        //            }
        //        }

        //        if (band == false)
        //        {
        //            MessageBox.Show("EL CLIENTE SOLICITADO NO SE ENCUENTA EN LA BASE DE DATOS", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("ERROR", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        //private void btnEliminar_Click(object sender, EventArgs e)
        //{
        //    //sonido_boton();
        //    Borrar_ErrorProvider();
        //    if ((validar_Cedula() == true))
        //    {
        //        if (MessageBox.Show("¿ESTA SEGURO QUE DESEA ELIMINAR ESTE CLIENTE?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (System.Windows.Forms.DialogResult.Yes))
        //        {
        //            Cedula = txtCedula.Text;
        //            if (CCliente.Eliminar_Cliente(Cedula) == true)
        //            {
        //                MessageBox.Show("CLIENTE ELIMINADO", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                mostrar_clientes();
        //                Cantidad_Cliente();
        //            }
        //            else
        //            {
        //                MessageBox.Show("EL CLIENTE NO EXISTE EN LA BASE DE DATOS", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                limpiar_texbox();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("ERROR", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}

        //private void btnLimpiar_Click(object sender, EventArgs e)
        //{
        //    //sonido_boton();
        //    Borrar_ErrorProvider();
        //    limpiar_texbox();
        //}
    }
}
