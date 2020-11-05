namespace Requerimientos.Formularios
{
    partial class FrmImportarProveedores
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
            this.ColCodCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCliDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDirec1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDirEnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTelefonos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColResponsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColContrib = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTipoCli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTipoPer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodTab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodZona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCtaIngrEgre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodPais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodSegmento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFormaPag = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.label1.Size = new System.Drawing.Size(301, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Importar Proveedores desde excel.";
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
            this.ColCodCliente,
            this.ColCliDes,
            this.ColDirec1,
            this.ColDirEnt,
            this.ColTelefonos,
            this.ColResponsable,
            this.ColRif,
            this.ColNit,
            this.ColContrib,
            this.ColCorreo,
            this.ColCiudad,
            this.ColTipoCli,
            this.ColTipoPer,
            this.ColCodTab,
            this.ColCodZona,
            this.ColCtaIngrEgre,
            this.ColCodPais,
            this.ColCodSegmento,
            this.ColCodVendedor,
            this.ColFormaPag});
            this.listHojaExcel.Location = new System.Drawing.Point(12, 94);
            this.listHojaExcel.Name = "listHojaExcel";
            this.listHojaExcel.ReadOnly = true;
            this.listHojaExcel.RowHeadersVisible = false;
            this.listHojaExcel.RowHeadersWidth = 51;
            this.listHojaExcel.RowTemplate.Height = 24;
            this.listHojaExcel.Size = new System.Drawing.Size(1129, 226);
            this.listHojaExcel.TabIndex = 20;
            // 
            // ColCodCliente
            // 
            this.ColCodCliente.HeaderText = "Codigo";
            this.ColCodCliente.MinimumWidth = 6;
            this.ColCodCliente.Name = "ColCodCliente";
            this.ColCodCliente.ReadOnly = true;
            this.ColCodCliente.Width = 125;
            // 
            // ColCliDes
            // 
            this.ColCliDes.HeaderText = "Descripcion";
            this.ColCliDes.MinimumWidth = 6;
            this.ColCliDes.Name = "ColCliDes";
            this.ColCliDes.ReadOnly = true;
            this.ColCliDes.Width = 125;
            // 
            // ColDirec1
            // 
            this.ColDirec1.HeaderText = "Direccion 1";
            this.ColDirec1.MinimumWidth = 6;
            this.ColDirec1.Name = "ColDirec1";
            this.ColDirec1.ReadOnly = true;
            this.ColDirec1.Width = 125;
            // 
            // ColDirEnt
            // 
            this.ColDirEnt.HeaderText = "Direccion Entrega";
            this.ColDirEnt.MinimumWidth = 6;
            this.ColDirEnt.Name = "ColDirEnt";
            this.ColDirEnt.ReadOnly = true;
            this.ColDirEnt.Width = 125;
            // 
            // ColTelefonos
            // 
            this.ColTelefonos.HeaderText = "Telefonos";
            this.ColTelefonos.MinimumWidth = 6;
            this.ColTelefonos.Name = "ColTelefonos";
            this.ColTelefonos.ReadOnly = true;
            this.ColTelefonos.Width = 125;
            // 
            // ColResponsable
            // 
            this.ColResponsable.HeaderText = "Responsable";
            this.ColResponsable.MinimumWidth = 6;
            this.ColResponsable.Name = "ColResponsable";
            this.ColResponsable.ReadOnly = true;
            this.ColResponsable.Width = 125;
            // 
            // ColRif
            // 
            this.ColRif.HeaderText = "Rif";
            this.ColRif.MinimumWidth = 6;
            this.ColRif.Name = "ColRif";
            this.ColRif.ReadOnly = true;
            this.ColRif.Width = 125;
            // 
            // ColNit
            // 
            this.ColNit.HeaderText = "Nit";
            this.ColNit.MinimumWidth = 6;
            this.ColNit.Name = "ColNit";
            this.ColNit.ReadOnly = true;
            this.ColNit.Width = 125;
            // 
            // ColContrib
            // 
            this.ColContrib.HeaderText = "Es Nacional?";
            this.ColContrib.MinimumWidth = 6;
            this.ColContrib.Name = "ColContrib";
            this.ColContrib.ReadOnly = true;
            this.ColContrib.Width = 125;
            // 
            // ColCorreo
            // 
            this.ColCorreo.HeaderText = "Correo";
            this.ColCorreo.MinimumWidth = 6;
            this.ColCorreo.Name = "ColCorreo";
            this.ColCorreo.ReadOnly = true;
            this.ColCorreo.Width = 125;
            // 
            // ColCiudad
            // 
            this.ColCiudad.HeaderText = "Ciudad";
            this.ColCiudad.MinimumWidth = 6;
            this.ColCiudad.Name = "ColCiudad";
            this.ColCiudad.ReadOnly = true;
            this.ColCiudad.Width = 125;
            // 
            // ColTipoCli
            // 
            this.ColTipoCli.HeaderText = "Tipo";
            this.ColTipoCli.MinimumWidth = 6;
            this.ColTipoCli.Name = "ColTipoCli";
            this.ColTipoCli.ReadOnly = true;
            this.ColTipoCli.Width = 125;
            // 
            // ColTipoPer
            // 
            this.ColTipoPer.HeaderText = "Tipo Persona";
            this.ColTipoPer.MinimumWidth = 6;
            this.ColTipoPer.Name = "ColTipoPer";
            this.ColTipoPer.ReadOnly = true;
            this.ColTipoPer.Width = 125;
            // 
            // ColCodTab
            // 
            this.ColCodTab.HeaderText = "Tabulador";
            this.ColCodTab.MinimumWidth = 6;
            this.ColCodTab.Name = "ColCodTab";
            this.ColCodTab.ReadOnly = true;
            this.ColCodTab.Width = 125;
            // 
            // ColCodZona
            // 
            this.ColCodZona.HeaderText = "Zona";
            this.ColCodZona.MinimumWidth = 6;
            this.ColCodZona.Name = "ColCodZona";
            this.ColCodZona.ReadOnly = true;
            this.ColCodZona.Width = 125;
            // 
            // ColCtaIngrEgre
            // 
            this.ColCtaIngrEgre.HeaderText = "CtaIngresoEgreso";
            this.ColCtaIngrEgre.MinimumWidth = 6;
            this.ColCtaIngrEgre.Name = "ColCtaIngrEgre";
            this.ColCtaIngrEgre.ReadOnly = true;
            this.ColCtaIngrEgre.Width = 125;
            // 
            // ColCodPais
            // 
            this.ColCodPais.HeaderText = "Pais";
            this.ColCodPais.MinimumWidth = 6;
            this.ColCodPais.Name = "ColCodPais";
            this.ColCodPais.ReadOnly = true;
            this.ColCodPais.Width = 125;
            // 
            // ColCodSegmento
            // 
            this.ColCodSegmento.HeaderText = "Segmento";
            this.ColCodSegmento.MinimumWidth = 6;
            this.ColCodSegmento.Name = "ColCodSegmento";
            this.ColCodSegmento.ReadOnly = true;
            this.ColCodSegmento.Width = 125;
            // 
            // ColCodVendedor
            // 
            this.ColCodVendedor.HeaderText = "Vendedor";
            this.ColCodVendedor.MinimumWidth = 6;
            this.ColCodVendedor.Name = "ColCodVendedor";
            this.ColCodVendedor.ReadOnly = true;
            this.ColCodVendedor.Width = 125;
            // 
            // ColFormaPag
            // 
            this.ColFormaPag.HeaderText = "Forma Pago";
            this.ColFormaPag.MinimumWidth = 6;
            this.ColFormaPag.Name = "ColFormaPag";
            this.ColFormaPag.ReadOnly = true;
            this.ColFormaPag.Width = 125;
            // 
            // FrmImportarProveedores
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
            this.Name = "FrmImportarProveedores";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCliDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDirec1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDirEnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTelefonos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColResponsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRif;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColContrib;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCiudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTipoCli;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTipoPer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodTab;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodZona;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCtaIngrEgre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodPais;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodSegmento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFormaPag;
    }
}