// frmPrincipalCliente.cs
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.Json;
using Entities;

namespace Cliente45GAMES4U
{
    public partial class frmPrincipalCliente : Form
    {
        private readonly ClienteTCP _clienteTCP;
        private readonly ClienteEntidad _cliente;
        private List<TiendaEntidad> _tiendas = new List<TiendaEntidad>();
        private List<VideojuegoEntidad> _videojuegos = new List<VideojuegoEntidad>();

        public frmPrincipalCliente(ClienteTCP clienteTCP, ClienteEntidad cliente)
        {
            InitializeComponent();
            _clienteTCP = clienteTCP;
            _cliente = cliente;

            _clienteTCP.OnMensajeRecibido += ManejarMensajeRecibido;
            _clienteTCP.OnError += ManejarError;
            _clienteTCP.OnDesconectado += ManejarDesconexion;

            lblNombreCliente.Text = _cliente.NombreCompleto;
            ConfigurarControles();
        }


        private void ConfigurarControles()
        {
            // Configurar DataGridView de videojuegos
            dgvVideojuegos.AutoGenerateColumns = false;
            dgvVideojuegos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Configurar DataGridView de reservas
            dgvReservas.AutoGenerateColumns = false;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Configurar DateTimePicker
            dtpFechaReserva.MinDate = DateTime.Today;
            dtpFechaReserva.Value = DateTime.Today;
        }

        private void frmPrincipalCliente_Load(object sender, EventArgs e)
        {
            if (!_clienteTCP.Conectado)
            {
                MessageBox.Show("No hay conexión con el servidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Solicitar lista de tiendas al cargar el formulario
            _clienteTCP.EnviarMensaje("CONSULTAR_TIENDAS");
        }

        private void btnRealizarReserva_Click(object sender, EventArgs e)
        {
            if (cmbTiendas.SelectedItem == null || dgvVideojuegos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una tienda y un videojuego", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var tienda = (TiendaEntidad)cmbTiendas.SelectedItem;
            var videojuego = (VideojuegoEntidad)dgvVideojuegos.SelectedRows[0].DataBoundItem;

           /* if (cantidad > videojuego.Existencias)
            {
                MessageBox.Show($"No hay suficientes existencias. Disponibles: {videojuego.Existencias}",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/

            string mensaje = $"RESERVA|{tienda.Id}|{videojuego.Id}|{_cliente.Identificacion}|{dtpFechaReserva.Value:yyyy-MM-dd}|{cantidad}";
            _clienteTCP.EnviarMensaje(mensaje);
        }

        private void btnConsultarReservas_Click(object sender, EventArgs e)
        {
            _clienteTCP.EnviarMensaje($"CONSULTAR_RESERVAS|{_cliente.Identificacion}");
        }

        private void btnConsultarPorId_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdReserva.Text, out int idReserva))
            {
                _clienteTCP.EnviarMensaje($"CONSULTAR_RESERVA_ID|{_cliente.Identificacion}|{idReserva}");
            }
            else
            {
                MessageBox.Show("Ingrese un ID de reserva válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            _clienteTCP.Desconectar();
            this.Close();
        }

        private void cmbTiendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTiendas.SelectedItem != null)
            {
                var tienda = (TiendaEntidad)cmbTiendas.SelectedItem;
                _clienteTCP.EnviarMensaje($"CONSULTAR_VIDEOJUEGOS|{tienda.Id}");
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
                string tipo = partes[0];

                switch (tipo)
                {
                    case "LISTA_TIENDAS":
                        CargarTiendas(JsonSerializer.Deserialize<List<TiendaEntidad>>(partes[1]));
                        break;

                    case "LISTA_VIDEOJUEGOS":
                        CargarVideojuegos(JsonSerializer.Deserialize<List<VideojuegoEntidad>>(partes[1]));
                        break;

                    case "RESPUESTA_RESERVA":
                        var resultado = JsonSerializer.Deserialize<ResultadoReserva>(partes[1]);
                        MostrarResultadoReserva(resultado);
                        break;

                    case "LISTA_RESERVAS":
                        CargarReservas(JsonSerializer.Deserialize<List<ReservaEntidad>>(partes[1]));
                        break;

                    case "DETALLE_RESERVA":
                        MostrarDetalleReserva(JsonSerializer.Deserialize<ReservaEntidad>(partes[1]));
                        break;

                    default:
                        txtBitacora.AppendText($"{mensaje}{Environment.NewLine}");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar mensaje: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTiendas(List<TiendaEntidad> tiendas)
        {
            _tiendas = tiendas;
            cmbTiendas.DataSource = null;
            cmbTiendas.DataSource = _tiendas;
            cmbTiendas.DisplayMember = "Nombre";
            cmbTiendas.ValueMember = "Id";
        }

        private void CargarVideojuegos(List<VideojuegoEntidad> videojuegos)
        {
            _videojuegos = videojuegos;
            dgvVideojuegos.DataSource = null;
            dgvVideojuegos.DataSource = _videojuegos;
        }

        private void CargarReservas(List<ReservaEntidad> reservas)
        {
            dgvReservas.DataSource = null;
            dgvReservas.DataSource = reservas;
        }

        private void MostrarResultadoReserva(ResultadoReserva resultado)
        {
            MessageBox.Show(resultado.Mensaje,
                          resultado.Exito ? "Éxito" : "Error",
                          MessageBoxButtons.OK,
                          resultado.Exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (resultado.Exito)
            {
                // Actualizar lista de reservas después de una reserva exitosa
                _clienteTCP.EnviarMensaje($"CONSULTAR_RESERVAS|{_cliente.Identificacion}");

                // Actualizar lista de videojuegos para reflejar las existencias actualizadas
                if (cmbTiendas.SelectedItem != null)
                {
                    var tienda = (TiendaEntidad)cmbTiendas.SelectedItem;
                    _clienteTCP.EnviarMensaje($"CONSULTAR_VIDEOJUEGOS|{tienda.Id}");
                }
            }
        }

        private void MostrarDetalleReserva(ReservaEntidad reserva)
        {
            var reservas = new List<ReservaEntidad> { reserva };
            dgvReservas.DataSource = null;
            dgvReservas.DataSource = reservas;
        }

        private void ManejarError(string mensajeError)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ManejarError), mensajeError);
                return;
            }

            MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ManejarDesconexion()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ManejarDesconexion));
                return;
            }

            MessageBox.Show("Se ha perdido la conexión con el servidor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }

        private void frmPrincipalCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            _clienteTCP.OnMensajeRecibido -= ManejarMensajeRecibido;
            _clienteTCP.OnError -= ManejarError;
            _clienteTCP.OnDesconectado -= ManejarDesconexion;

            if (_clienteTCP.Conectado)
            {
                _clienteTCP.Desconectar();
            }
        }
    }

    public class ResultadoReserva
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public int IdReserva { get; set; }
        public int ExistenciasDisponibles { get; set; }
    }
}