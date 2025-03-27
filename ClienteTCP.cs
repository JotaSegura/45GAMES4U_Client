// ClienteTCP.cs
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Cliente45GAMES4U
{
    public class ClienteTCP
    {
        private TcpClient _cliente;
        private NetworkStream _stream;
        private readonly string _ip = "127.0.0.1";
        private readonly int _puerto = 14100;

        public bool Conectado { get; private set; }
        public string UltimoError { get; private set; }

        public event Action<string> OnMensajeRecibido;
        public event Action<string> OnError;
        public event Action OnDesconectado;

        public void Conectar()
        {
            try
            {
                _cliente = new TcpClient();
                _cliente.Connect(_ip, _puerto);
                _stream = _cliente.GetStream();
                Conectado = true;
                UltimoError = null;

                Thread hiloEscucha = new Thread(EscucharServidor);
                hiloEscucha.IsBackground = true;
                hiloEscucha.Start();

                OnMensajeRecibido?.Invoke("Conectado al servidor");
            }
            catch (Exception ex)
            {
                Conectado = false;
                UltimoError = ex.Message;
                OnError?.Invoke($"Error al conectar: {ex.Message}");
            }
        }

        public void Desconectar()
        {
            try
            {
                if (Conectado)
                {
                    Conectado = false;
                    _stream?.Close();
                    _cliente?.Close();
                    OnDesconectado?.Invoke();
                    OnMensajeRecibido?.Invoke("Desconectado del servidor");
                }
            }
            catch (Exception ex)
            {
                OnError?.Invoke($"Error al desconectar: {ex.Message}");
            }
        }

        public bool EnviarMensaje(string mensaje)
        {
            try
            {
                if (!Conectado) return false;

                byte[] buffer = Encoding.UTF8.GetBytes(mensaje);
                _stream.Write(buffer, 0, buffer.Length);
                return true;
            }
            catch (Exception ex)
            {
                Conectado = false;
                UltimoError = ex.Message;
                OnError?.Invoke($"Error al enviar mensaje: {ex.Message}");
                return false;
            }
        }

        private void EscucharServidor()
        {
            try
            {
                byte[] buffer = new byte[4096];
                int bytesLeidos;

                while ((bytesLeidos = _stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesLeidos);
                    OnMensajeRecibido?.Invoke(mensaje);
                }
            }
            catch (Exception)
            {
                // Conexión cerrada
            }
            finally
            {
                Conectado = false;
                OnDesconectado?.Invoke();
            }
        }
    }
}