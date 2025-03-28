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
                lblNombre.Visible = true;
                lblNombreValor.Visible = true;
                lblApellido1.Visible = true;
                lblApellido1Valor.Visible = true;
                lblApellido2.Visible = true;
                lblApellido2Valor.Visible = true;
                btnReservar.Visible = true;
                btnConsultar.Visible = true;
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

                    // Verificar si la respuesta indica que el cliente existe
                    return respuesta != null && respuesta.Equals("CLIENTE_EXISTE", StringComparison.OrdinalIgnoreCase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con el servidor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
