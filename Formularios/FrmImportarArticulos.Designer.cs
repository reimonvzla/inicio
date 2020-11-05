namespace Requerimientos.Formularios
{
    partial class FrmImportarArticulos
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
            this.listHojaExcel = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ColCoArt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColArtDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodSubl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodProcedencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodUbicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCodUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTipoArt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCampo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColComentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTipoImp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFecRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.label1.Size = new System.Drawing.Size(271, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Importar Articulos desde excel.";
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
            // listHojaExcel
            // 
            this.listHojaExcel.AllowUserToAddRows = false;
            this.listHojaExcel.AllowUserToDeleteRows = false;
            this.listHojaExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listHojaExcel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCoArt,
            this.ColArtDes,
            this.ColCodLinea,
            this.ColCodSubl,
            this.ColCodCat,
            this.ColCodColor,
            this.ColCodProcedencia,
            this.ColCodUbicacion,
            this.ColCodUnidad,
            this.ColTipoArt,
            this.ColPrecio,
            this.ColCampo1,
            this.ColComentario,
            this.ColTipoImp,
            this.ColFecRegistro});
            this.listHojaExcel.Location = new System.Drawing.Point(12, 96);
            this.listHojaExcel.Name = "listHojaExcel";
            this.listHojaExcel.ReadOnly = true;
            this.listHojaExcel.RowHeadersVisible = false;
            this.listHojaExcel.RowHeadersWidth = 51;
            this.listHojaExcel.RowTemplate.Height = 24;
            this.listHojaExcel.Size = new System.Drawing.Size(1129, 226);
            this.listHojaExcel.TabIndex = 10;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ColCoArt
            // 
            this.ColCoArt.HeaderText = "Codigo";
            this.ColCoArt.MinimumWidth = 6;
            this.ColCoArt.Name = "ColCoArt";
            this.ColCoArt.ReadOnly = true;
            this.ColCoArt.Width = 125;
            // 
            // ColArtDes
            // 
            this.ColArtDes.HeaderText = "Descripcion";
            this.ColArtDes.MinimumWidth = 6;
            this.ColArtDes.Name = "ColArtDes";
            this.ColArtDes.ReadOnly = true;
            this.ColArtDes.Width = 125;
            // 
            // ColCodLinea
            // 
            this.ColCodLinea.HeaderText = "CodLinea";
            this.ColCodLinea.MinimumWidth = 6;
            this.ColCodLinea.Name = "ColCodLinea";
            this.ColCodLinea.ReadOnly = true;
            this.ColCodLinea.Width = 125;
            // 
            // ColCodSubl
            // 
            this.ColCodSubl.HeaderText = "CodSublinea";
            this.ColCodSubl.MinimumWidth = 6;
            this.ColCodSubl.Name = "ColCodSubl";
            this.ColCodSubl.ReadOnly = true;
            this.ColCodSubl.Width = 125;
            // 
            // ColCodCat
            // 
            this.ColCodCat.HeaderText = "CodCategoria";
            this.ColCodCat.MinimumWidth = 6;
            this.ColCodCat.Name = "ColCodCat";
            this.ColCodCat.ReadOnly = true;
            this.ColCodCat.Width = 125;
            // 
            // ColCodColor
            // 
            this.ColCodColor.HeaderText = "CodColor";
            this.ColCodColor.MinimumWidth = 6;
            this.ColCodColor.Name = "ColCodColor";
            this.ColCodColor.ReadOnly = true;
            this.ColCodColor.Width = 125;
            // 
            // ColCodProcedencia
            // 
            this.ColCodProcedencia.HeaderText = "CodProcedencia";
            this.ColCodProcedencia.MinimumWidth = 6;
            this.ColCodProcedencia.Name = "ColCodProcedencia";
            this.ColCodProcedencia.ReadOnly = true;
            this.ColCodProcedencia.Width = 125;
            // 
            // ColCodUbicacion
            // 
            this.ColCodUbicacion.HeaderText = "CodUbicacion";
            this.ColCodUbicacion.MinimumWidth = 6;
            this.ColCodUbicacion.Name = "ColCodUbicacion";
            this.ColCodUbicacion.ReadOnly = true;
            this.ColCodUbicacion.Width = 125;
            // 
            // ColCodUnidad
            // 
            this.ColCodUnidad.HeaderText = "CodUnidad";
            this.ColCodUnidad.MinimumWidth = 6;
            this.ColCodUnidad.Name = "ColCodUnidad";
            this.ColCodUnidad.ReadOnly = true;
            this.ColCodUnidad.Width = 125;
            // 
            // ColTipoArt
            // 
            this.ColTipoArt.HeaderText = "Tipo";
            this.ColTipoArt.MinimumWidth = 6;
            this.ColTipoArt.Name = "ColTipoArt";
            this.ColTipoArt.ReadOnly = true;
            this.ColTipoArt.Width = 125;
            // 
            // ColPrecio
            // 
            this.ColPrecio.HeaderText = "Precio";
            this.ColPrecio.MinimumWidth = 6;
            this.ColPrecio.Name = "ColPrecio";
            this.ColPrecio.ReadOnly = true;
            this.ColPrecio.Width = 125;
            // 
            // ColCampo1
            // 
            this.ColCampo1.HeaderText = "Campo1";
            this.ColCampo1.MinimumWidth = 6;
            this.ColCampo1.Name = "ColCampo1";
            this.ColCampo1.ReadOnly = true;
            this.ColCampo1.Width = 125;
            // 
            // ColComentario
            // 
            this.ColComentario.HeaderText = "Comentario";
            this.ColComentario.MinimumWidth = 6;
            this.ColComentario.Name = "ColComentario";
            this.ColComentario.ReadOnly = true;
            this.ColComentario.Width = 125;
            // 
            // ColTipoImp
            // 
            this.ColTipoImp.HeaderText = "Tipo Impuesto";
            this.ColTipoImp.MinimumWidth = 6;
            this.ColTipoImp.Name = "ColTipoImp";
            this.ColTipoImp.ReadOnly = true;
            this.ColTipoImp.Width = 125;
            // 
            // ColFecRegistro
            // 
            this.ColFecRegistro.HeaderText = "Fecha Registro";
            this.ColFecRegistro.MinimumWidth = 6;
            this.ColFecRegistro.Name = "ColFecRegistro";
            this.ColFecRegistro.ReadOnly = true;
            this.ColFecRegistro.Width = 125;
            // 
            // FrmImportarArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1157, 451);
            this.Controls.Add(this.lblMaquina);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.btnResultados);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.listHojaExcel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImportarArticulos";
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
        private System.Windows.Forms.DataGridView listHojaExcel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCoArt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArtDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodSubl;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodProcedencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodUbicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCodUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTipoArt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCampo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColComentario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTipoImp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFecRegistro;
    }
}