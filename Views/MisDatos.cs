using MisCuentas_desk.Configurations;
using MisCuentas_desk.Entities;
using MisCuentas_desk.Model;
using MisCuentas_desk.Services.PersonalData;
using MisCuentas_desk.Services.Usuarios;
using MisCuentas_desk.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MisCuentas_desk.Views
{
    public partial class MisDatos : Form
    {
        #region ATRIBUTOS
        private Usuario usuario;
        private MisCuentasConnect conn = new MisCuentasConnect();
        private UsuarioServices usuarioServices;
        private PersonalDataServices personalDataServices;
        private FormMisCuentas formMisCuentas;
        private Navigation nav;
        private bool StateModificar = false;
        private bool StateCambioPass = false;
        #endregion


        #region CONSTRUCTOR
        public MisDatos(Usuario usuario, FormMisCuentas formMisCuentas)
        {
            InitializeComponent();
            string cadenaConexion = conn.Conexion();
            usuarioServices = new UsuarioServices(cadenaConexion);
            personalDataServices = new PersonalDataServices(cadenaConexion);
            this.formMisCuentas = formMisCuentas;
            this.nav = new Navigation(formMisCuentas);

            this.usuario = usuario;
            if (usuario != null)
            {
                CargaDatosPrincipales();
                if (usuario.Personal_Data != null) CargarDatosGenerales();
            }
        }
        #endregion

        #region CARGAR DATOS
        /// <summary>
        /// Metodo para cargar los datos principales del usuario logeado
        /// </summary>
        private void CargaDatosPrincipales()
        {
            lblMDUsuario.Text = usuario.Nombre;
            lblMDCorreo.Text = usuario.Correo;
            lblMDPerfil.Text = usuario.Perfil;
        }


        /// <summary>
        /// Metodo para cargar los datos generales del usuario logeado
        /// </summary>
        private void CargarDatosGenerales()
        {
            lblMDNombre.Text = usuario.Personal_Data.Nombre ?? "sin completar";
            lblMDApellidos.Text = usuario.Personal_Data.Apellidos ?? "sin completar";
            lblMDDireccion.Text = usuario.Personal_Data.Direccion ?? "sin completar";
            lblMDPais.Text = usuario.Personal_Data.Pais ?? "sin completar";
            if (usuario.Personal_Data.Telefono == null) lblMDTelefono.Text = "sin completar";
            else lblMDTelefono.Text = usuario.Personal_Data.Telefono.ToString();
        }


        /// <summary>
        /// Metodo que carga el comboBox de Paises.
        /// </summary>
        /// <param name="cargar">si debe cargarse o no</param>
        public void CargarPaises(bool cargar)
        {
            if (!cargar)
            {
                cbxMDPais.DataSource = null;
            }
            else cbxMDPais.DataSource = Pais.Todos;
        }
        #endregion


        #region MODIFICAR DATOS
        /// <summary>
        /// Metodo modifica el panel para poder introducir los datos
        /// </summary>
        private void pbxMDCompletarDatos_Click(object sender, EventArgs e)
        {
            if (StateModificar == false)
            {
                StateModificar = true;
                ModoModificarDatos(true);
            }
        }

        /// <summary>
        /// Metodo para adaptar la pantalla a los cambios de datos
        /// </summary>
        /// <param name="modificar"></param>
        private void ModoModificarDatos(bool modificar)
        {
            //Ocultar:
            lblMDNombre.Visible = !modificar;
            lblMDApellidos.Visible = !modificar;
            lblMDDireccion.Visible = !modificar;
            lblMDPais.Visible = !modificar;
            lblMDTelefono.Visible = !modificar;
            btnMDGuardar.Visible = !modificar;

            //Mostrar:
            tbxMDNombre.Visible = modificar;
            tbxMDApellidos.Visible = modificar;
            tbxMDDireccion.Visible = modificar;
            tbxMDTelefono.Visible = modificar;
            cbxMDPais.Visible = modificar;
            btnMDGuardar.Visible = modificar;

            //Datos:
            if (usuario.Personal_Data != null)
            {
                tbxMDNombre.Text = usuario.Personal_Data.Nombre;
                tbxMDApellidos.Text = usuario.Personal_Data.Apellidos;
                tbxMDDireccion.Text = usuario.Personal_Data.Direccion;
                cbxMDPais.Text = usuario.Personal_Data.Pais;
                tbxMDTelefono.Text = usuario.Personal_Data.Telefono.ToString();
            }

            CargarPaises(modificar);
        }

        /// <summary>
        /// Metodo que instnacia, realiza un Update de los datos y actualiza el objeto.
        /// </summary>
        private void btnMDGuardar_Click(object sender, EventArgs e)
        {
            //Instancia datos personales
            Personal_Data datos = InstanciaDatos();

            //Update
            bool actualizado = personalDataServices.Actualizar(datos);

            //Actualizar datos del modelo
            if (actualizado)
            {
                usuario.Personal_Data = datos;
                Usuario usuarioUpdate = Usuario.ObtenerInstancia(usuario);
                CargarDatosGenerales();
                //usuario = usuarioUpdate;
            }

            //Adaptar pantalla
            ModoModificarDatos(false);
            StateModificar = false;
        }

        /// <summary>
        /// Metodo para instanciar un objeto de Personal_Data
        /// </summary>
        /// <returns>Retorna el objeto Personal_Data</returns>
        private Personal_Data InstanciaDatos()
        {
            int id_usuario = usuario.Id_Usuario;
            string nombre = String.IsNullOrEmpty(tbxMDNombre.Text) ? null : tbxMDNombre.Text;
            string apellidos = String.IsNullOrEmpty(tbxMDApellidos.Text) ? null : tbxMDApellidos.Text;
            string direccion = String.IsNullOrEmpty(tbxMDDireccion.Text) ? null : tbxMDDireccion.Text;
            string pais = String.IsNullOrEmpty(cbxMDPais.Text) ? null : cbxMDPais.Text; ;
            int? telefono = null;
            if (!String.IsNullOrEmpty(tbxMDTelefono.Text)) telefono = int.Parse(tbxMDTelefono.Text);

            return new Personal_Data(id_usuario, nombre, apellidos, direccion, pais, telefono);
        }
        #endregion

        #region CAMBIO CONTRASEÑA
        /// <summary>
        /// Metodo para iniciar el cambio de contraseña
        /// </summary>
        private void pbxMDCambioPass_Click(object sender, EventArgs e)
        {
            panelCambioPass.Visible = true;
           
        }


        /// <summary>
        /// Metodo que muestra u oculta las contraseñas
        /// </summary>
        private void btnVerCambioPass_Click(object sender, EventArgs e)
        {

            if (tbxCanbioPass.PasswordChar == '*' || tbxCanbioPass2.PasswordChar == '*')
            {
                tbxCanbioPass.PasswordChar = '\0'; // Muestra la contraseña
                tbxCanbioPass2.PasswordChar = '\0';
                btnNoVerCambioPass.Visible = true;
                btnVerCambioPass.Visible = false;
            }
            else
            {
                tbxCanbioPass.PasswordChar = '*'; // Oculta la contraseña
                tbxCanbioPass2.PasswordChar = '*';
                btnNoVerCambioPass.Visible = false;
                btnVerCambioPass.Visible = true;
            }

        }


        /// <summary>
        /// Metodo para guardar la nueva pass en BBDD
        /// </summary>
        private void btnCambioPass_Click(object sender, EventArgs e)
        {
            if (!ValidarContraseñas()) MessageBox.Show("Error al introducir las contraseñas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else RegistrarNuevaPass();
        }


        /// <summary>
        /// Metodo para cancelar el cambio de contraseña.
        /// </summary>
        private void btnCancelarCambioPass_Click(object sender, EventArgs e)
        {
            MostrarDatosPrincipales();
        }


        /// <summary>
        /// Metodo que vuelve a mostrar el panel de datos principales.
        /// </summary>
        private void MostrarDatosPrincipales()
        {
            panelCambioPass.Visible = false;
            tbxCanbioPass.Text = null;
            tbxCanbioPass2.Text = null;
        }


        /// <summary>
        /// Metodo para validar las contraseñas introducidas introducidos.
        /// </summary>
        /// <returns>true o false segun corresponda</returns>
        private bool ValidarContraseñas()
        {
            bool valido = true;
            string pass1 = tbxCanbioPass.Text;
            string pass2 = tbxCanbioPass2.Text;
           

            while (valido)
            {
                if (String.IsNullOrEmpty(pass1) || String.IsNullOrEmpty(pass2)) return false;
                if (!Validaciones.ValidaPass(pass1) || !Validaciones.ValidaPass(pass2)) return false;
                if (!pass1.Equals(pass2)) return false;
                valido = false;
            }

            return true;
        }

        /// <summary>
        /// Metodo que registra la nueva contraseña.
        /// </summary>
        private void RegistrarNuevaPass()
        {
            usuario.Contrasenna = tbxCanbioPass.Text;
            CambioPassOK(usuarioServices.Actualizar(usuario));
        }


        /// <summary>
        /// Metodo que pinta mensaje segun el resultado del update
        /// </summary>
        /// <param name="exito">Resultado de la actualizacion de la Pass</param>
        private void CambioPassOK(bool exito)
        {
            if (!exito) MessageBox.Show("Error al actualizar la contraseña!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("Cambio de contraseña correcto!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDatosPrincipales();
            }
        }

        #endregion


        #region ELIMINAR CUENTA
        /// <summary>
        /// Metodo para eliminar la cuenta del usuario. CUIDADO CON ESTO! ELIMINA TODA LA INFO DEL USUAIRO DEL SISTEMA!
        /// </summary>
        private void pbxMDEliminarCuenta_Click(object sender, EventArgs e)
        {
            bool confirmarEliminacion = MensajesEliminarCuenta();

            if (confirmarEliminacion)
            {
                if (usuarioServices.Eliminar(usuario.Id_Usuario))
                {
                    this.Close();
                    formMisCuentas.RetornoLogin();
                    nav.AbrirFormEnPanel(new Login(formMisCuentas));
                    MessageBox.Show("La cuenta se ha eliminado correctamente!.",
                               "EXITO!",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                }
            }
        }


        /// <summary>
        /// Metodo que muestra el mensaje y recoge la confirmacion de la eliminacion de la cuenta.
        /// </summary>
        /// <returns>true si finalmente decide eliminarla o false si cancela</returns>
        private bool MensajesEliminarCuenta()
        {
            // Mostrar el primer mensaje de confirmación y recoger la respuesta
            DialogResult respuesta = MessageBox.Show("¿Estás seguro de que deseas eliminar la cuenta?",
                                                     "CONFIRMAR",
                                                     MessageBoxButtons.OKCancel,
                                                     MessageBoxIcon.Warning);

            // Evaluar la respuesta del usuario
            if (respuesta == DialogResult.OK)
            {
                // Si el usuario elige OK, mostrar un segundo mensaje de éxito
                DialogResult respuesta2 = MessageBox.Show("La cuenta será eliminada. Volver a confirmar...",
                                "VOLVER A CONFIRMAR",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Warning);

                if (respuesta2 == DialogResult.OK)
                { 
                    //Decide eliminar la cuenta con toda la info!!
                    return true;
                }
                else
                {
                    // Si el usuario elige Cancel, mostrar un mensaje de cancelación
                    MessageBox.Show("La eliminación de la cuenta ha sido cancelada.",
                                    "Operación cancelada!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return false;
                }

            }
            else
            {
                // Si el usuario elige Cancel, mostrar un mensaje de cancelación
                MessageBox.Show("La eliminación de la cuenta ha sido cancelada.",
                                "Operación cancelada!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return false;
            }
        }
        #endregion
    }
}
