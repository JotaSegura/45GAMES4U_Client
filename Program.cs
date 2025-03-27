using System;
using System.Windows.Forms;

namespace Cliente45GAMES4U
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Configurar el manejo de excepciones no controladas
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // Iniciar con el formulario de validación
            Application.Run(new frmValidacionCliente());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ManejarError(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ManejarError(e.ExceptionObject as Exception);
        }

        private static void ManejarError(Exception ex)
        {
            string mensajeError = "Ocurrió un error inesperado. La aplicación se cerrará.\n\n" +
                                $"Error: {ex?.Message}\n\n" +
                                $"Detalles: {ex?.StackTrace}";

            MessageBox.Show(mensajeError, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1);
        }
    }
}