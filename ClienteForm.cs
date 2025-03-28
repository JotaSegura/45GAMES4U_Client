using _45GAMES4U_Client;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ClienteTCP
{
    public partial class ClienteForm : Form
    {
        private const string IP_SERVIDOR = "127.0.0.1";
        private const int PUERTO_SERVIDOR = 14100;
        public ClienteForm()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            string identificacion = txtIdentificacion.Text;

            if (string.IsNullOrEmpty(identificacion))
            {
                MessageBox.Show("Ingrese una identificación válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Llamar al servidor TCP para verificar si el cliente existe
            bool clienteExiste = VerificarClienteEnServidor(identificacion);

            if (clienteExiste)
            {
                // Llamar nuevamente para obtener los datos del cliente
                string respuesta = ObtenerDatosCliente();

                if (!string.IsNullOrEmpty(respuesta) && respuesta.StartsWith("CLIENTE_EXISTE"))
                {
                    // Extraer los datos del cliente (nombre, apellido1, apellido2)
                    string[] datosCliente = respuesta.Split('|');
                    string nombre = datosCliente[1];
                    string apellido1 = datosCliente[2];
                    string apellido2 = datosCliente[3];

                    // Mostrar los datos en los controles del formulario
                    lblNombreValor.Text = nombre;
                    lblApellido1Valor.Text = apellido1;
                    lblApellido2Valor.Text = apellido2;

                    // Hacer visibles los campos
                    lblNombre.Visible = true;
                    lblNombreValor.Visible = true;
                    lblApellido1.Visible = true;
                    lblApellido1Valor.Visible = true;
                    lblApellido2.Visible = true;
                    lblApellido2Valor.Visible = true;
                    btnReservar.Visible = true;
                    btnConsultar.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerificarClienteEnServidor(string identificacion)
        {
            try
            {
                using (TcpClient cliente = new TcpClient(IP_SERVIDOR, PUERTO_SERVIDOR))
                using (NetworkStream stream = cliente.GetStream())
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    // Enviar la identificación al servidor
                    writer.WriteLine($"VALIDAR_CLIENTE|{identificacion}");

                    // Leer respuesta del servidor
                    string respuesta = reader.ReadLine();

                    if (respuesta.StartsWith("CLIENTE_EXISTE"))
                    {
                        // Extraer los datos del cliente
                        string[] partes = respuesta.Split('|');
                        string nombre = partes[1];
                        string apellido1 = partes[2];
                        string apellido2 = partes[3];

                        // Llenar los campos del formulario
                        lblNombreValor.Text = nombre;
                        lblApellido1Valor.Text = apellido1;
                        lblApellido2Valor.Text = apellido2;

                        // Mostrar los campos y botones
                        lblNombre.Visible = true;
                        lblNombreValor.Visible = true;
                        lblApellido1.Visible = true;
                        lblApellido1Valor.Visible = true;
                        lblApellido2.Visible = true;
                        lblApellido2Valor.Visible = true;
                        btnReservar.Visible = true;
                        btnConsultar.Visible = true;

                        return true;
                    }
                    else
                    {
                        // El cliente no existe
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con el servidor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string ObtenerDatosCliente()
        {
            try
            {
                using (TcpClient cliente = new TcpClient(IP_SERVIDOR, PUERTO_SERVIDOR))
                using (NetworkStream stream = cliente.GetStream())
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    // Enviar solicitud para obtener los datos del cliente
                    writer.WriteLine("OBTENER_DATOS_CLIENTE");

                    // Leer respuesta del servidor con los datos del cliente
                    return reader.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            string identificacion = txtIdentificacion.Text;

            // Abre el formulario de reserva, pasando la identificación del cliente
            ReservaForm reservaForm = new ReservaForm(long.Parse(identificacion));
            reservaForm.ShowDialog();
        }
    }
}