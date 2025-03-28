namespace ClienteTCP 
{ 
    partial class ReservaForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">True si los recursos administrados deben ser eliminados; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.cbTiendas = new System.Windows.Forms.ComboBox();
            this.dgvVideojuegos = new System.Windows.Forms.DataGridView();
            this.dtpFechaReserva = new System.Windows.Forms.DateTimePicker();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnRealizarReserva = new System.Windows.Forms.Button();
            this.lblTienda = new System.Windows.Forms.Label();
            this.lblVideojuegos = new System.Windows.Forms.Label();
            this.lblFechaReserva = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideojuegos)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTiendas
            // 
            this.cbTiendas.FormattingEnabled = true;
            this.cbTiendas.Location = new System.Drawing.Point(132, 30);
            this.cbTiendas.Name = "cbTiendas";
            this.cbTiendas.Size = new System.Drawing.Size(200, 21);
            this.cbTiendas.TabIndex = 0;
            this.cbTiendas.SelectedIndexChanged += new System.EventHandler(this.cbTiendas_SelectedIndexChanged);
            // 
            // dgvVideojuegos
            // 
            this.dgvVideojuegos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVideojuegos.Location = new System.Drawing.Point(132, 80);
            this.dgvVideojuegos.Name = "dgvVideojuegos";
            this.dgvVideojuegos.Size = new System.Drawing.Size(400, 200);
            this.dgvVideojuegos.TabIndex = 1;
            // 
            // dtpFechaReserva
            // 
            this.dtpFechaReserva.Location = new System.Drawing.Point(132, 300);
            this.dtpFechaReserva.Name = "dtpFechaReserva";
            this.dtpFechaReserva.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaReserva.TabIndex = 2;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(132, 340);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 3;
            // 
            // btnRealizarReserva
            // 
            this.btnRealizarReserva.Location = new System.Drawing.Point(132, 380);
            this.btnRealizarReserva.Name = "btnRealizarReserva";
            this.btnRealizarReserva.Size = new System.Drawing.Size(200, 30);
            this.btnRealizarReserva.TabIndex = 4;
            this.btnRealizarReserva.Text = "Realizar Reserva";
            this.btnRealizarReserva.UseVisualStyleBackColor = true;
            this.btnRealizarReserva.Click += new System.EventHandler(this.btnRealizarReserva_Click);
            // 
            // lblTienda
            // 
            this.lblTienda.AutoSize = true;
            this.lblTienda.Location = new System.Drawing.Point(50, 30);
            this.lblTienda.Name = "lblTienda";
            this.lblTienda.Size = new System.Drawing.Size(42, 13);
            this.lblTienda.TabIndex = 5;
            this.lblTienda.Text = "Tienda:";
            // 
            // lblVideojuegos
            // 
            this.lblVideojuegos.AutoSize = true;
            this.lblVideojuegos.Location = new System.Drawing.Point(50, 80);
            this.lblVideojuegos.Name = "lblVideojuegos";
            this.lblVideojuegos.Size = new System.Drawing.Size(69, 13);
            this.lblVideojuegos.TabIndex = 6;
            this.lblVideojuegos.Text = "Videojuegos:";
            // 
            // lblFechaReserva
            // 
            this.lblFechaReserva.AutoSize = true;
            this.lblFechaReserva.Location = new System.Drawing.Point(50, 300);
            this.lblFechaReserva.Name = "lblFechaReserva";
            this.lblFechaReserva.Size = new System.Drawing.Size(87, 13);
            this.lblFechaReserva.TabIndex = 7;
            this.lblFechaReserva.Text = "Fecha Reserva:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(50, 340);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(54, 13);
            this.lblCantidad.TabIndex = 8;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // ReservaForm
            // 
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblFechaReserva);
            this.Controls.Add(this.lblVideojuegos);
            this.Controls.Add(this.lblTienda);
            this.Controls.Add(this.btnRealizarReserva);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.dtpFechaReserva);
            this.Controls.Add(this.dgvVideojuegos);
            this.Controls.Add(this.cbTiendas);
            this.Name = "ReservaForm";
            this.Text = "Reserva de Videojuego";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideojuegos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTiendas;
        private System.Windows.Forms.DataGridView dgvVideojuegos;
        private System.Windows.Forms.DateTimePicker dtpFechaReserva;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnRealizarReserva;
        private System.Windows.Forms.Label lblTienda;
        private System.Windows.Forms.Label lblVideojuegos;
        private System.Windows.Forms.Label lblFechaReserva;
        private System.Windows.Forms.Label lblCantidad;
    }
}
