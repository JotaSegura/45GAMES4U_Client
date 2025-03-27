namespace Cliente45GAMES4U
{
    partial class frmPrincipalCliente
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.gbTienda = new System.Windows.Forms.GroupBox();
            this.cmbTiendas = new System.Windows.Forms.ComboBox();
            this.gbVideojuegos = new System.Windows.Forms.GroupBox();
            this.dgvVideojuegos = new System.Windows.Forms.DataGridView();
            this.gbReserva = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaReserva = new System.Windows.Forms.DateTimePicker();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnRealizarReserva = new System.Windows.Forms.Button();
            this.gbMisReservas = new System.Windows.Forms.GroupBox();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.btnConsultarReservas = new System.Windows.Forms.Button();
            this.gbBuscarReserva = new System.Windows.Forms.GroupBox();
            this.btnConsultarPorId = new System.Windows.Forms.Button();
            this.txtIdReserva = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDesconectar = new System.Windows.Forms.Button();
            this.txtBitacora = new System.Windows.Forms.TextBox();
            this.gbTienda.SuspendLayout();
            this.gbVideojuegos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideojuegos)).BeginInit();
            this.gbReserva.SuspendLayout();
            this.gbMisReservas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.gbBuscarReserva.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCliente.Location = new System.Drawing.Point(12, 9);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(107, 15);
            this.lblNombreCliente.TabIndex = 0;
            this.lblNombreCliente.Text = "Nombre Cliente";
            // 
            // gbTienda
            // 
            this.gbTienda.Controls.Add(this.cmbTiendas);
            this.gbTienda.Location = new System.Drawing.Point(12, 37);
            this.gbTienda.Name = "gbTienda";
            this.gbTienda.Size = new System.Drawing.Size(300, 55);
            this.gbTienda.TabIndex = 1;
            this.gbTienda.TabStop = false;
            this.gbTienda.Text = "Seleccionar Tienda";
            // 
            // cmbTiendas
            // 
            this.cmbTiendas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTiendas.FormattingEnabled = true;
            this.cmbTiendas.Location = new System.Drawing.Point(6, 19);
            this.cmbTiendas.Name = "cmbTiendas";
            this.cmbTiendas.Size = new System.Drawing.Size(288, 21);
            this.cmbTiendas.TabIndex = 0;
            this.cmbTiendas.SelectedIndexChanged += new System.EventHandler(this.cmbTiendas_SelectedIndexChanged);
            // 
            // gbVideojuegos
            // 
            this.gbVideojuegos.Controls.Add(this.dgvVideojuegos);
            this.gbVideojuegos.Location = new System.Drawing.Point(12, 98);
            this.gbVideojuegos.Name = "gbVideojuegos";
            this.gbVideojuegos.Size = new System.Drawing.Size(300, 200);
            this.gbVideojuegos.TabIndex = 2;
            this.gbVideojuegos.TabStop = false;
            this.gbVideojuegos.Text = "Videojuegos Disponibles";
            // 
            // dgvVideojuegos
            // 
            this.dgvVideojuegos.AllowUserToAddRows = false;
            this.dgvVideojuegos.AllowUserToDeleteRows = false;
            this.dgvVideojuegos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVideojuegos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVideojuegos.Location = new System.Drawing.Point(3, 16);
            this.dgvVideojuegos.MultiSelect = false;
            this.dgvVideojuegos.Name = "dgvVideojuegos";
            this.dgvVideojuegos.ReadOnly = true;
            this.dgvVideojuegos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVideojuegos.Size = new System.Drawing.Size(294, 181);
            this.dgvVideojuegos.TabIndex = 0;
            // 
            // gbReserva
            // 
            this.gbReserva.Controls.Add(this.label2);
            this.gbReserva.Controls.Add(this.label1);
            this.gbReserva.Controls.Add(this.dtpFechaReserva);
            this.gbReserva.Controls.Add(this.txtCantidad);
            this.gbReserva.Controls.Add(this.btnRealizarReserva);
            this.gbReserva.Location = new System.Drawing.Point(12, 304);
            this.gbReserva.Name = "gbReserva";
            this.gbReserva.Size = new System.Drawing.Size(300, 100);
            this.gbReserva.TabIndex = 3;
            this.gbReserva.TabStop = false;
            this.gbReserva.Text = "Realizar Reserva";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cantidad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha:";
            // 
            // dtpFechaReserva
            // 
            this.dtpFechaReserva.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaReserva.Location = new System.Drawing.Point(52, 16);
            this.dtpFechaReserva.Name = "dtpFechaReserva";
            this.dtpFechaReserva.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaReserva.TabIndex = 2;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(64, 48);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(50, 20);
            this.txtCantidad.TabIndex = 1;
            // 
            // btnRealizarReserva
            // 
            this.btnRealizarReserva.Location = new System.Drawing.Point(158, 32);
            this.btnRealizarReserva.Name = "btnRealizarReserva";
            this.btnRealizarReserva.Size = new System.Drawing.Size(136, 23);
            this.btnRealizarReserva.TabIndex = 0;
            this.btnRealizarReserva.Text = "Realizar Reserva";
            this.btnRealizarReserva.UseVisualStyleBackColor = true;
            this.btnRealizarReserva.Click += new System.EventHandler(this.btnRealizarReserva_Click);
            // 
            // gbMisReservas
            // 
            this.gbMisReservas.Controls.Add(this.dgvReservas);
            this.gbMisReservas.Controls.Add(this.btnConsultarReservas);
            this.gbMisReservas.Location = new System.Drawing.Point(318, 37);
            this.gbMisReservas.Name = "gbMisReservas";
            this.gbMisReservas.Size = new System.Drawing.Size(450, 300);
            this.gbMisReservas.TabIndex = 4;
            this.gbMisReservas.TabStop = false;
            this.gbMisReservas.Text = "Mis Reservas";
            // 
            // dgvReservas
            // 
            this.dgvReservas.AllowUserToAddRows = false;
            this.dgvReservas.AllowUserToDeleteRows = false;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Location = new System.Drawing.Point(6, 45);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservas.Size = new System.Drawing.Size(438, 249);
            this.dgvReservas.TabIndex = 1;
            // 
            // btnConsultarReservas
            // 
            this.btnConsultarReservas.Location = new System.Drawing.Point(6, 16);
            this.btnConsultarReservas.Name = "btnConsultarReservas";
            this.btnConsultarReservas.Size = new System.Drawing.Size(136, 23);
            this.btnConsultarReservas.TabIndex = 0;
            this.btnConsultarReservas.Text = "Consultar Todas";
            this.btnConsultarReservas.UseVisualStyleBackColor = true;
            this.btnConsultarReservas.Click += new System.EventHandler(this.btnConsultarReservas_Click);
            // 
            // gbBuscarReserva
            // 
            this.gbBuscarReserva.Controls.Add(this.btnConsultarPorId);
            this.gbBuscarReserva.Controls.Add(this.txtIdReserva);
            this.gbBuscarReserva.Controls.Add(this.label3);
            this.gbBuscarReserva.Location = new System.Drawing.Point(318, 343);
            this.gbBuscarReserva.Name = "gbBuscarReserva";
            this.gbBuscarReserva.Size = new System.Drawing.Size(450, 61);
            this.gbBuscarReserva.TabIndex = 5;
            this.gbBuscarReserva.TabStop = false;
            this.gbBuscarReserva.Text = "Buscar Reserva por ID";
            // 
            // btnConsultarPorId
            // 
            this.btnConsultarPorId.Location = new System.Drawing.Point(158, 19);
            this.btnConsultarPorId.Name = "btnConsultarPorId";
            this.btnConsultarPorId.Size = new System.Drawing.Size(136, 23);
            this.btnConsultarPorId.TabIndex = 2;
            this.btnConsultarPorId.Text = "Consultar";
            this.btnConsultarPorId.UseVisualStyleBackColor = true;
            this.btnConsultarPorId.Click += new System.EventHandler(this.btnConsultarPorId_Click);
            // 
            // txtIdReserva
            // 
            this.txtIdReserva.Location = new System.Drawing.Point(44, 21);
            this.txtIdReserva.Name = "txtIdReserva";
            this.txtIdReserva.Size = new System.Drawing.Size(100, 20);
            this.txtIdReserva.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ID:";
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.Location = new System.Drawing.Point(678, 9);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(84, 23);
            this.btnDesconectar.TabIndex = 6;
            this.btnDesconectar.Text = "Desconectar";
            this.btnDesconectar.UseVisualStyleBackColor = true;
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // txtBitacora
            // 
            this.txtBitacora.Location = new System.Drawing.Point(12, 410);
            this.txtBitacora.Multiline = true;
            this.txtBitacora.Name = "txtBitacora";
            this.txtBitacora.ReadOnly = true;
            this.txtBitacora.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBitacora.Size = new System.Drawing.Size(756, 100);
            this.txtBitacora.TabIndex = 7;
            // 
            // frmPrincipalCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 522);
            this.Controls.Add(this.txtBitacora);
            this.Controls.Add(this.btnDesconectar);
            this.Controls.Add(this.gbBuscarReserva);
            this.Controls.Add(this.gbMisReservas);
            this.Controls.Add(this.gbReserva);
            this.Controls.Add(this.gbVideojuegos);
            this.Controls.Add(this.gbTienda);
            this.Controls.Add(this.lblNombreCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPrincipalCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "45GAMES4U - Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipalCliente_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipalCliente_Load);
            this.gbTienda.ResumeLayout(false);
            this.gbVideojuegos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideojuegos)).EndInit();
            this.gbReserva.ResumeLayout(false);
            this.gbReserva.PerformLayout();
            this.gbMisReservas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.gbBuscarReserva.ResumeLayout(false);
            this.gbBuscarReserva.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.GroupBox gbTienda;
        private System.Windows.Forms.ComboBox cmbTiendas;
        private System.Windows.Forms.GroupBox gbVideojuegos;
        private System.Windows.Forms.DataGridView dgvVideojuegos;
        private System.Windows.Forms.GroupBox gbReserva;
        private System.Windows.Forms.Button btnRealizarReserva;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.DateTimePicker dtpFechaReserva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbMisReservas;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.Button btnConsultarReservas;
        private System.Windows.Forms.GroupBox gbBuscarReserva;
        private System.Windows.Forms.Button btnConsultarPorId;
        private System.Windows.Forms.TextBox txtIdReserva;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDesconectar;
        private System.Windows.Forms.TextBox txtBitacora;
    }
}
