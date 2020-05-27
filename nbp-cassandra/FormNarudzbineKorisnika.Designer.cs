namespace NBP_Cassandra
{
    partial class FormNarudzbineKorisnika
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.narudzbinaIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restoranIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iznosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusObradeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.narudzbinaIdDataGridViewTextBoxColumn,
            this.restoranIdDataGridViewTextBoxColumn,
            this.datumDataGridViewTextBoxColumn,
            this.adresaDataGridViewTextBoxColumn,
            this.iznosDataGridViewTextBoxColumn,
            this.statusObradeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(-1, -1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(650, 455);
            this.dataGridView1.TabIndex = 0;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(DataLayer.QueryEntities.Narudzbina);
            // 
            // narudzbinaIdDataGridViewTextBoxColumn
            // 
            this.narudzbinaIdDataGridViewTextBoxColumn.DataPropertyName = "NarudzbinaId";
            this.narudzbinaIdDataGridViewTextBoxColumn.HeaderText = "NarudzbinaId";
            this.narudzbinaIdDataGridViewTextBoxColumn.Name = "narudzbinaIdDataGridViewTextBoxColumn";
            // 
            // restoranIdDataGridViewTextBoxColumn
            // 
            this.restoranIdDataGridViewTextBoxColumn.DataPropertyName = "RestoranId";
            this.restoranIdDataGridViewTextBoxColumn.HeaderText = "RestoranId";
            this.restoranIdDataGridViewTextBoxColumn.Name = "restoranIdDataGridViewTextBoxColumn";
            // 
            // datumDataGridViewTextBoxColumn
            // 
            this.datumDataGridViewTextBoxColumn.DataPropertyName = "Datum";
            this.datumDataGridViewTextBoxColumn.HeaderText = "Datum";
            this.datumDataGridViewTextBoxColumn.Name = "datumDataGridViewTextBoxColumn";
            // 
            // adresaDataGridViewTextBoxColumn
            // 
            this.adresaDataGridViewTextBoxColumn.DataPropertyName = "Adresa";
            this.adresaDataGridViewTextBoxColumn.HeaderText = "Adresa";
            this.adresaDataGridViewTextBoxColumn.Name = "adresaDataGridViewTextBoxColumn";
            // 
            // iznosDataGridViewTextBoxColumn
            // 
            this.iznosDataGridViewTextBoxColumn.DataPropertyName = "Iznos";
            this.iznosDataGridViewTextBoxColumn.HeaderText = "Iznos";
            this.iznosDataGridViewTextBoxColumn.Name = "iznosDataGridViewTextBoxColumn";
            // 
            // statusObradeDataGridViewTextBoxColumn
            // 
            this.statusObradeDataGridViewTextBoxColumn.DataPropertyName = "StatusObrade";
            this.statusObradeDataGridViewTextBoxColumn.HeaderText = "StatusObrade";
            this.statusObradeDataGridViewTextBoxColumn.Name = "statusObradeDataGridViewTextBoxColumn";
            // 
            // FormNarudzbineKorisnika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormNarudzbineKorisnika";
            this.Text = "Narudzbine korisnika";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormNarudzbineKorisnika_FormClosed);
            this.Load += new System.EventHandler(this.FormNarudzbineKorisnika_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn narudzbinaIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn restoranIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iznosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusObradeDataGridViewTextBoxColumn;
    }
}