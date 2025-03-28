using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ClienteTCP
{
    public partial class ReservaForm : Form
    {
        private long identificacionCliente;

        public ReservaForm(long identificacion)
        {
            InitializeComponent();
            identificacionCliente = identificacion;
            CargarTiendas(); // Cargar las tiendas al abrir el formulario
        }

        // Método para cargar tiendas activas desde el servidor
        private void CargarTiendas()
        {
            try
            {
                using (TcpClient cliente = new TcpClient("127.0.0.1", 14100))
                using (NetworkStream stream = cliente.GetStream())
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    // Solicitar al servidor las tiendas activas
                    writer.WriteLine("CONSULTAR_TIENDA");

                    // Leer la respuesta (tiendas activas)
                    string respuesta = reader.ReadLine();

                    // Procesar la respuesta y llenar el ComboBox
                    if (!string.IsNullOrEmpty(respuesta))
                    {
                        var tiendas = respuesta.Split(',');
                        foreach (var tienda in tiendas)
                        {
                            cbTiendas.Items.Add(tienda);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tiendas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cargar los videojuegos disponibles en la tienda seleccionada
        private void cbTiendas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTiendas.SelectedItem != null)
            {
                string tiendaSeleccionada = cbTiendas.SelectedItem.ToString();
                CargarVideojuegos(tiendaSeleccionada);
            }
        }

        // Método para cargar los videojuegos disponibles en la tienda seleccionada
        private void CargarVideojuegos(string tienda)
        {
            try
            {
                using (TcpClient cliente = new TcpClient("127.0.0.1", 14100))
                using (NetworkStream stream = cliente.GetStream())
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    // Solicitar los videojuegos de la tienda seleccionada
                    writer.WriteLine($"CONSULTAR_VIDEOJUEGOS|{tienda}");

                    // Leer la respuesta (videojuegos disponibles)
                    string respuesta = reader.ReadLine();

                    if (!string.IsNullOrEmpty(respuesta))
                    {
                        var videojuegos = respuesta.Split(',');

                        // Llenar el DataGridView con los videojuegos
                        var dataTable = new DataTable();
                        dataTable.Columns.Add("ID Videojuego");
                        dataTable.Columns.Add("Nombre");
                        dataTable.Columns.Add("Existencias");

                        foreach (var videojuego in videojuegos)
                        {
                            var datos = videojuego.Split('|');
                            if (datos.Length == 3)
                            {
                                dataTable.Rows.Add(datos[0], datos[1], datos[2]);
                            }
                        }

                        dgvVideojuegos.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("No hay videojuegos disponibles en esta tienda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar videojuegos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para realizar la reserva
        private void btnRealizarReserva_Click(object sender, EventArgs e)
        {
            if (dgvVideojuegos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un videojuego para reservar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpFechaReserva.Value < DateTime.Now)
            {
                MessageBox.Show("La fecha de reserva no puede ser en el pasado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(txtCantidad.Text, out int cantidad) && cantidad > 0)
            {
                // Validar existencia de videojuegos disponibles
                var videojuegoId = dgvVideojuegos.SelectedRows[0].Cells[0].Value.ToString();
                var existencias = int.Parse(dgvVideojuegos.SelectedRows[0].Cells[2].Value.ToString());

                if (cantidad > existencias)
                {
                    MessageBox.Show("No hay suficientes existencias para realizar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear la reserva y enviar la información al servidor
                RealizarReserva(videojuegoId, cantidad);
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para realizar la reserva
        private void RealizarReserva(string videojuegoId, int cantidad)
        {
            try
            {
                using (TcpClient cliente = new TcpClient("127.0.0.1", 14100))
                using (NetworkStream stream = cliente.GetStream())
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    // Crear la solicitud de reserva
                    string reservaData = $"{identificacionCliente}|{videojuegoId}|{cantidad}|{dtpFechaReserva.Value}";

                    // Enviar al servidor
                    writer.WriteLine($"REALIZAR_RESERVA|{reservaData}");

                    // Leer respuesta del servidor
                    string respuesta = reader.ReadLine();
                    if (respuesta == "RESERVA_EXITOSA")
                    {
                        MessageBox.Show("Reserva realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al realizar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con el servidor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
