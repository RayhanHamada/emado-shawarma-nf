
namespace emado_shawarma_nf
{
    partial class TableForm
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
            this.BtnTambah = new System.Windows.Forms.Button();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.DgKaryawan = new System.Windows.Forms.DataGridView();
            this.col_hapus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TxtCari = new System.Windows.Forms.TextBox();
            this.ms_shawarma = new System.Windows.Forms.MenuStrip();
            this.TSMFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MiExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DgKaryawan)).BeginInit();
            this.ms_shawarma.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnTambah
            // 
            this.BtnTambah.Location = new System.Drawing.Point(23, 410);
            this.BtnTambah.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnTambah.Name = "BtnTambah";
            this.BtnTambah.Size = new System.Drawing.Size(241, 63);
            this.BtnTambah.TabIndex = 0;
            this.BtnTambah.Text = "Tambah Karyawan";
            this.BtnTambah.UseVisualStyleBackColor = true;
            this.BtnTambah.Click += new System.EventHandler(this.BtnTambah_Click);
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRefresh.Location = new System.Drawing.Point(1016, 46);
            this.BtnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(94, 23);
            this.BtnRefresh.TabIndex = 1;
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // DgKaryawan
            // 
            this.DgKaryawan.AllowUserToAddRows = false;
            this.DgKaryawan.AllowUserToDeleteRows = false;
            this.DgKaryawan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgKaryawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgKaryawan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_hapus,
            this.col_update});
            this.DgKaryawan.Location = new System.Drawing.Point(23, 74);
            this.DgKaryawan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DgKaryawan.Name = "DgKaryawan";
            this.DgKaryawan.RowHeadersWidth = 51;
            this.DgKaryawan.RowTemplate.Height = 29;
            this.DgKaryawan.Size = new System.Drawing.Size(1087, 330);
            this.DgKaryawan.TabIndex = 2;
            this.DgKaryawan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgKaryawan_CellContentClick);
            // 
            // col_hapus
            // 
            this.col_hapus.HeaderText = "Hapus";
            this.col_hapus.MinimumWidth = 6;
            this.col_hapus.Name = "col_hapus";
            this.col_hapus.ReadOnly = true;
            this.col_hapus.Text = "Hapus";
            this.col_hapus.UseColumnTextForButtonValue = true;
            this.col_hapus.Width = 75;
            // 
            // col_update
            // 
            this.col_update.HeaderText = "Update";
            this.col_update.MinimumWidth = 6;
            this.col_update.Name = "col_update";
            this.col_update.ReadOnly = true;
            this.col_update.Text = "Update";
            this.col_update.UseColumnTextForButtonValue = true;
            this.col_update.Width = 75;
            // 
            // TxtCari
            // 
            this.TxtCari.Location = new System.Drawing.Point(23, 48);
            this.TxtCari.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtCari.Name = "TxtCari";
            this.TxtCari.Size = new System.Drawing.Size(232, 22);
            this.TxtCari.TabIndex = 3;
            this.TxtCari.TextChanged += new System.EventHandler(this.TxtCari_TextChanged);
            // 
            // ms_shawarma
            // 
            this.ms_shawarma.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ms_shawarma.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMFile});
            this.ms_shawarma.Location = new System.Drawing.Point(0, 0);
            this.ms_shawarma.Name = "ms_shawarma";
            this.ms_shawarma.Size = new System.Drawing.Size(1131, 28);
            this.ms_shawarma.TabIndex = 4;
            this.ms_shawarma.Text = "menuStrip1";
            // 
            // TSMFile
            // 
            this.TSMFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MiExportExcel});
            this.TSMFile.Name = "TSMFile";
            this.TSMFile.Size = new System.Drawing.Size(46, 24);
            this.TSMFile.Text = "File";
            // 
            // MiExportExcel
            // 
            this.MiExportExcel.Name = "MiExportExcel";
            this.MiExportExcel.Size = new System.Drawing.Size(260, 26);
            this.MiExportExcel.Text = "Export Database To Excel";
            this.MiExportExcel.Click += new System.EventHandler(this.Mi_exportExcel_Click);
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1131, 538);
            this.Controls.Add(this.TxtCari);
            this.Controls.Add(this.DgKaryawan);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.BtnTambah);
            this.Controls.Add(this.ms_shawarma);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TableForm";
            this.Text = "Tabel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TableForm_FormClosed);
            this.Load += new System.EventHandler(this.TableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgKaryawan)).EndInit();
            this.ms_shawarma.ResumeLayout(false);
            this.ms_shawarma.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnTambah;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.DataGridView DgKaryawan;
        private System.Windows.Forms.TextBox TxtCari;
        private System.Windows.Forms.DataGridViewButtonColumn col_hapus;
        private System.Windows.Forms.DataGridViewButtonColumn col_update;
        private System.Windows.Forms.MenuStrip ms_shawarma;
        private System.Windows.Forms.ToolStripMenuItem TSMFile;
        private System.Windows.Forms.ToolStripMenuItem MiExportExcel;
    }
}