namespace ClienteTCP
{
    partial class ClienteForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblIdentificacion;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNombreValor;
        private System.Windows.Forms.Label lblApellido1;
        private System.Windows.Forms.Label lblApellido1Valor;
        private System.Windows.Forms.Label lblApellido2;
        private System.Windows.Forms.Label lblApellido2Valor;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Button btnConsultar;

        private void InitializeComponent()
        {
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.btnValidar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNombreValor = new System.Windows.Forms.Label();
            this.lblApellido1 = new System.Windows.Forms.Label();
            this.lblApellido1Valor = new System.Windows.Forms.Label();
            this.lblApellido2 = new System.Windows.Forms.Label();
            this.lblApellido2Valor = new System.Windows.Forms.Label();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIdentificacion
            // 
            this.lblIdentificacion.Location = new System.Drawing.Point(20, 20);
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Size = new System.Drawing.Size(100, 23);
            this.lblIdentificacion.TabIndex = 0;
            this.lblIdentificacion.Text = "Identificación:";
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(120, 20);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(200, 20);
            this.txtIdentificacion.TabIndex = 1;
            // 
            // btnValidar
            // 
            this.btnValidar.Location = new System.Drawing.Point(330, 20);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(75, 23);
            this.btnValidar.TabIndex = 2;
            this.btnValidar.Text = "Validar";
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(20, 60);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 23);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Visible = false;
            // 
            // lblNombreValor
            // 
            this.lblNombreValor.Location = new System.Drawing.Point(120, 60);
            this.lblNombreValor.Name = "lblNombreValor";
            this.lblNombreValor.Size = new System.Drawing.Size(100, 23);
            this.lblNombreValor.TabIndex = 4;
            this.lblNombreValor.Visible = false;
            // 
            // lblApellido1
            // 
            this.lblApellido1.Location = new System.Drawing.Point(20, 90);
            this.lblApellido1.Name = "lblApellido1";
            this.lblApellido1.Size = new System.Drawing.Size(100, 23);
            this.lblApellido1.TabIndex = 5;
            this.lblApellido1.Text = "Apellido 1:";
            this.lblApellido1.Visible = false;
            // 
            // lblApellido1Valor
            // 
            this.lblApellido1Valor.Location = new System.Drawing.Point(120, 90);
            this.lblApellido1Valor.Name = "lblApellido1Valor";
            this.lblApellido1Valor.Size = new System.Drawing.Size(100, 23);
            this.lblApellido1Valor.TabIndex = 6;
            this.lblApellido1Valor.Visible = false;
            // 
            // lblApellido2
            // 
            this.lblApellido2.Location = new System.Drawing.Point(20, 120);
            this.lblApellido2.Name = "lblApellido2";
            this.lblApellido2.Size = new System.Drawing.Size(100, 23);
            this.lblApellido2.TabIndex = 7;
            this.lblApellido2.Text = "Apellido 2:";
            this.lblApellido2.Visible = false;
            // 
            // lblApellido2Valor
            // 
            this.lblApellido2Valor.Location = new System.Drawing.Point(120, 120);
            this.lblApellido2Valor.Name = "lblApellido2Valor";
            this.lblApellido2Valor.Size = new System.Drawing.Size(100, 23);
            this.lblApellido2Valor.TabIndex = 8;
            this.lblApellido2Valor.Visible = false;
            // 
            // btnReservar
            // 
            this.btnReservar.Location = new System.Drawing.Point(20, 160);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(138, 23);
            this.btnReservar.TabIndex = 9;
            this.btnReservar.Text = "Reservar Videojuego";
            this.btnReservar.Visible = false;
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(20, 200);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(138, 23);
            this.btnConsultar.TabIndex = 10;
            this.btnConsultar.Text = "Consultar Reservas";
            this.btnConsultar.Visible = false;
            // 
            // ClienteForm
            // 
            this.ClientSize = new System.Drawing.Size(534, 261);
            this.Controls.Add(this.lblIdentificacion);
            this.Controls.Add(this.txtIdentificacion);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblNombreValor);
            this.Controls.Add(this.lblApellido1);
            this.Controls.Add(this.lblApellido1Valor);
            this.Controls.Add(this.lblApellido2);
            this.Controls.Add(this.lblApellido2Valor);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.btnConsultar);
            this.Name = "ClienteForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
