// frmValidacionCliente.cs
using System;
using System.Windows.Forms;
using System.Text.Json;
using Entities;

namespace Cliente45GAMES4U
{
    public partial class frmValidacionCliente : Form
    {
        private readonly ClienteTCP _clienteTCP;

        public frmValidacionCliente()
        {
            InitializeComponent();
            _clienteTCP = new ClienteTCP();

            _clienteTCP.OnMensajeRecibido += ManejarMensajeRecibido;
            _clienteTCP.OnError += ManejarError;
            _clienteTCP.OnDesconectado += ManejarDesconexion;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdentificacion.Text, out int idCliente))
            {
                MessageBox.Show("Ingrese una identificación válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_clienteTCP.Conectado)
            {
                _clienteTCP.Conectar();

                if (!_clienteTCP.Conectado)
                {
                    MessageBox.Show($"No se pudo conectar al servidor: {_clienteTCP.UltimoError}",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Enviar solicitud de validación
            if (!_clienteTCP.EnviarMensaje($"VALIDAR_CLIENTE|{idCliente}"))
            {
                MessageBox.Show("Error al enviar solicitud de validación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManejarMensajeRecibido(string mensaje)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ManejarMensajeRecibido), mensaje);
                return;
            }

            try
            {
                string[] partes = mensaje.Split('|');

                if (partes[0] == "RESPUESTA_VALIDACION")
                {
                    if (partes[1] == "OK")
                    {
                        // Mostrar formulario principal del cliente
                        var cliente = new ClienteEntidad
                        {
                            Identificacion = int.Parse(txtIdentificacion.Text),
                            Nombre = partes[2],
                            PrimerApellido = partes[3],
                            SegundoApellido = partes[4]
                        };

                        var frmPrincipal = new frmPrincipalCliente(_clienteTCP, cliente);
                        this.Hide();
                        frmPrincipal.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        _clienteTCP.Desconectar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar respuesta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManejarError(string mensajeError)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ManejarError), mensajeError);
                return;
            }

            MessageBox.Show(mensajeError, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ManejarDesconexion()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ManejarDesconexion));
                return;
            }

            if (!this.IsDisposed)
            {
                MessageBox.Show("Se ha perdido la conexión con el servidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmValidacionCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            _clienteTCP.Desconectar();
        }
    }
}