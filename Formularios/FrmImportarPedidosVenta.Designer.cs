namespace Requerimientos.Formularios
{
    partial class FrmImportarPedidosVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMaquina = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnResultados = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listHojaExcel = new System.Windows.Forms.DataGridView();
            this.ColNroDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMoneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFecEmis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFecVenc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodArt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArtDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodAlma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTipIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTransporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.listHojaExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaquina
            // 
            this.lblMaquina.AutoSize = true;
            this.lblMaquina.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaquina.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblMaquina.Location = new System.Drawing.Point(12, 406);
            this.lblMaquina.Name = "lblMaquina";
            this.lblMaquina.Size = new System.Drawing.Size(66, 17);
            this.lblMaquina.TabIndex = 19;
            this.lblMaquina.Text = "Maquina:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblUsuario.Location = new System.Drawing.Point(834, 376);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(103, 17);
            this.lblUsuario.TabIndex = 18;
            this.lblUsuario.Text = "Usuario actual:";
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSucursal.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblSucursal.Location = new System.Drawing.Point(476, 376);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(109, 17);
            this.lblSucursal.TabIndex = 17;
            this.lblSucursal.Text = "Sucursal actual:";
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblEmpresa.Location = new System.Drawing.Point(12, 375);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(110, 17);
            this.lblEmpresa.TabIndex = 16;
            this.lblEmpresa.Text = "Empresa actual:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Importar Pedidos de ventas desde excel.";
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(1014, 49);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(127, 34);
            this.btnExaminar.TabIndex = 14;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.BackColor = System.Drawing.Color.White;
            this.txtRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.Location = new System.Drawing.Point(12, 49);
            this.txtRuta.Multiline = true;
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(996, 34);
            this.txtRuta.TabIndex = 13;
            // 
            // btnResultados
            // 
            this.btnResultados.Enabled = false;
            this.btnResultados.Location = new System.Drawing.Point(12, 328);
            this.btnResultados.Name = "btnResultados";
            this.btnResultados.Size = new System.Drawing.Size(127, 40);
            this.btnResultados.TabIndex = 12;
            this.btnResultados.Text = "Ver Resultados";
            this.btnResultados.UseVisualStyleBackColor = true;
            this.btnResultados.Click += new System.EventHandler(this.btnResultados_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Enabled = false;
            this.btnProcesar.Location = new System.Drawing.Point(1014, 328);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(127, 40);
            this.btnProcesar.TabIndex = 11;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listHojaExcel
            // 
            this.listHojaExcel.AllowUserToAddRows = false;
            this.listHojaExcel.AllowUserToDeleteRows = false;
            this.listHojaExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listHojaExcel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNroDoc,
            this.ColMoneda,
            this.ColCodProveedor,
            this.ColFecEmis,
            this.ColFecVenc,
            this.ColCodArt,
            this.ColArtDes,
            this.ColCodAlma,
            this.ColCant,
            this.ColPrecio,
            this.ColTipIva,
            this.ColTransporte});
            this.listHojaExcel.Location = new System.Drawing.Point(12, 96);
            this.listHojaExcel.Name = "listHojaExcel";
            this.listHojaExcel.ReadOnly = true;
            this.listHojaExcel.RowHeadersVisible = false;
            this.listHojaExcel.RowHeadersWidth = 51;
            this.listHojaExcel.RowTemplate.Height = 24;
            this.listHojaExcel.Size = new System.Drawing.Size(1129, 226);
            this.listHojaExcel.TabIndex = 20;
            // 
            // ColNroDoc
            // 
            this.ColNroDoc.HeaderText = "Nro Documento";
            this.ColNroDoc.MinimumWidth = 6;
            this.ColNroDoc.Name = "ColNroDoc";
            this.ColNroDoc.ReadOnly = true;
            this.ColNroDoc.Width = 125;
            // 
            // ColMoneda
            // 
            this.ColMoneda.HeaderText = "Moneda";
            this.ColMoneda.MinimumWidth = 6;
            this.ColMoneda.Name = "ColMoneda";
            this.ColMoneda.ReadOnly = true;
            this.ColMoneda.Width = 125;
            // 
            // ColCodProveedor
            // 
            this.ColCodProveedor.HeaderText = "CodProveedor";
            this.ColCodProveedor.MinimumWidth = 6;
            this.ColCodProveedor.Name = "ColCodProveedor";
            this.ColCodProveedor.ReadOnly = true;
            this.ColCodProveedor.Width = 125;
            // 
            // ColFecEmis
            // 
            this.ColFecEmis.HeaderText = "Fecha Emision";
            this.ColFecEmis.MinimumWidth = 6;
            this.ColFecEmis.Name = "ColFecEmis";
            this.ColFecEmis.ReadOnly = true;
            this.ColFecEmis.Width = 125;
            // 
            // ColFecVenc
            // 
            this.ColFecVenc.HeaderText = "Fecha Vence";
            this.ColFecVenc.MinimumWidth = 6;
            this.ColFecVenc.Name = "ColFecVenc";
            this.ColFecVenc.ReadOnly = true;
            this.ColFecVenc.Width = 125;
            // 
            // ColCodArt
            // 
            this.ColCodArt.HeaderText = "CodArticulo";
            this.ColCodArt.MinimumWidth = 6;
            this.ColCodArt.Name = "ColCodArt";
            this.ColCodArt.ReadOnly = true;
            this.ColCodArt.Width = 125;
            // 
            // ColArtDes
            // 
            this.ColArtDes.HeaderText = "Descripcion";
            this.ColArtDes.MinimumWidth = 6;
            this.ColArtDes.Name = "ColArtDes";
            this.ColArtDes.ReadOnly = true;
            this.ColArtDes.Width = 125;
            // 
            // ColCodAlma
            // 
            this.ColCodAlma.HeaderText = "CodAlmacen";
            this.ColCodAlma.MinimumWidth = 6;
            this.ColCodAlma.Name = "ColCodAlma";
            this.ColCodAlma.ReadOnly = true;
            this.ColCodAlma.Width = 125;
            // 
            // ColCant
            // 
            this.ColCant.HeaderText = "Cantidad";
            this.ColCant.MinimumWidth = 6;
            this.ColCant.Name = "ColCant";
            this.ColCant.ReadOnly = true;
            this.ColCant.Width = 125;
            // 
            // ColPrecio
            // 
            this.ColPrecio.HeaderText = "Cost. Unitario";
            this.ColPrecio.MinimumWidth = 6;
            this.ColPrecio.Name = "ColPrecio";
            this.ColPrecio.ReadOnly = true;
            this.ColPrecio.Width = 125;
            // 
            // ColTipIva
            // 
            this.ColTipIva.HeaderText = "Tipo IVA";
            this.ColTipIva.MinimumWidth = 6;
            this.ColTipIva.Name = "ColTipIva";
            this.ColTipIva.ReadOnly = true;
            this.ColTipIva.Width = 125;
            // 
            // ColTransporte
            // 
            this.ColTransporte.HeaderText = "Transporte";
            this.ColTransporte.MinimumWidth = 6;
            this.ColTransporte.Name = "ColTransporte";
            this.ColTransporte.ReadOnly = true;
            this.ColTransporte.Width = 125;
            // 
            // FrmImportarPedidosVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1157, 451);
            this.Controls.Add(this.listHojaExcel);
            this.Controls.Add(this.lblMaquina);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.btnResultados);
            this.Controls.Add(this.btnProcesar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImportarPedidosVenta";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar datos";
            this.Load += new System.EventHandler(this.FrmImportarOrdenesCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listHojaExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblMaquina;
        public System.Windows.Forms.Label lblUsuario;
        public System.Windows.Forms.Label lblSucursal;
        public System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button btnResultados;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView listHojaExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNroDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMoneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFecEmis;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFecVenc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodArt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArtDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodAlma;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCant;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTipIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTransporte;
    }
}