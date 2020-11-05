namespace Requerimientos.Formularios
{
    partial class FrmResultados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.listResultados = new System.Windows.Forms.DataGridView();
            this.colFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.listResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // listResultados
            // 
            this.listResultados.AllowUserToAddRows = false;
            this.listResultados.AllowUserToDeleteRows = false;
            this.listResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFactura,
            this.colMonto});
            this.listResultados.Location = new System.Drawing.Point(12, 11);
            this.listResultados.Name = "listResultados";
            this.listResultados.ReadOnly = true;
            this.listResultados.RowHeadersVisible = false;
            this.listResultados.RowHeadersWidth = 51;
            this.listResultados.RowTemplate.Height = 24;
            this.listResultados.Size = new System.Drawing.Size(405, 428);
            this.listResultados.TabIndex = 1;
            // 
            // colFactura
            // 
            this.colFactura.HeaderText = "Nro Documento";
            this.colFactura.MinimumWidth = 6;
            this.colFactura.Name = "colFactura";
            this.colFactura.ReadOnly = true;
            this.colFactura.Width = 150;
            // 
            // colMonto
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.colMonto.DefaultCellStyle = dataGridViewCellStyle1;
            this.colMonto.HeaderText = "Monto";
            this.colMonto.MinimumWidth = 6;
            this.colMonto.Name = "colMonto";
            this.colMonto.ReadOnly = true;
            this.colMonto.Width = 160;
            // 
            // FrmResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(428, 450);
            this.Controls.Add(this.listResultados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmResultados";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resultados";
            ((System.ComponentModel.ISupportInitialize)(this.listResultados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView listResultados;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMonto;
    }
}