using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace emado_shawarma_nf
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            Koneksi.FillTable();
            DgKaryawan.DataSource = Koneksi.Table;
            DgKaryawan.Columns["id"].Visible = false;

            DataGridViewCellStyle styleHapus = new DataGridViewCellStyle
            {
                ForeColor = Color.Red
            };

            DgKaryawan.Columns["col_hapus"].DefaultCellStyle = styleHapus;

            DataGridViewCellStyle styleUpdate = new DataGridViewCellStyle
            {
                ForeColor = Color.Green
            };

            using (DataGridViewColumn colGaji = DgKaryawan.Columns["gaji"])
            {
                colGaji.DefaultCellStyle.Format = "C";
                colGaji.DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID");
            }

            using (DataGridViewColumn colTunjangan = DgKaryawan.Columns["tunjangan"])
            {
                colTunjangan.DefaultCellStyle.Format = "C";
                colTunjangan.DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("id-ID");
            }

            MiExportExcel.Click += Mi_exportExcel_Click;
            FormClosed += TableForm_FormClosed;
        }

        private void TableForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose(true);
            Environment.Exit(0);
        }

        private void Mi_exportExcel_Click(object sender, EventArgs e)
        {
            var workbook = new XLWorkbook();
            workbook.AddWorksheet(Koneksi.Table, "data_karyawan");
            workbook.Worksheet("data_karyawan").ColumnWidth = 25.0;

            var sfd = new SaveFileDialog
            {
                FileName = $"export_data_karyawan_{ DateTime.Now:dd_MM_yyyy}.xlsx",
                Filter = "Excel |*.xlsx"
            };

            sfd.ShowDialog(this);
            workbook.SaveAs(sfd.FileName);
        }

        private void DgKaryawan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;

            // buat delete karyawan
            if (senderGrid.Columns[colIndex] is DataGridViewButtonColumn
                && senderGrid.Columns[colIndex].Name == "col_hapus")
            {
                var name = (string)senderGrid.Rows[rowIndex].Cells["nama"].Value;

                // konfirmasi penghapusan
                DialogResult dialogResult = MessageBox.Show($"Apa anda yakin untuk menghapus {name} ?", "Konfirmasi Hapus", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    var id = (long)senderGrid.Rows[rowIndex].Cells["id"].Value;
                    bool success = Koneksi.DeleteKaryawan(id);

                    if (success)
                    {
                        MessageBox.Show($"karyawan bernama {name} berhasil terhapus !");
                        ResetTextCari();
                        return;
                    }

                    MessageBox.Show($"karyawan bernama {name} tidak berhasil terhapus !");
                }
            }
            //buat update karyawan
            else if (senderGrid.Columns[colIndex] is DataGridViewButtonColumn
                && senderGrid.Columns[colIndex].Name == "col_update")
            {
                var id = (long)senderGrid.Rows[rowIndex].Cells["id"].Value;

                var formUpdate = new TambahUpdateForm(id);
                formUpdate.Show(this);
                ResetTextCari();
            }
        }

        private void BtnTambah_Click(object sender, EventArgs e)
        {
            var formTambah = new TambahUpdateForm();
            formTambah.Show(this);
            ResetTextCari();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (TxtCari.Text != "")
            {
                Koneksi.SearchRefresh(TxtCari.Text);
                return;
            }

            Koneksi.RefreshTable();
        }

        private async void TxtCari_TextChanged(object sender, EventArgs e)
        {
            // this inner method checks if user is still typing
            async Task<bool> UserKeepsTyping()
            {
                string txt = TxtCari.Text;   // remember text
                await Task.Delay(500);        // wait some
                return txt != TxtCari.Text;  // return that text chaged or not
            }
            if (await UserKeepsTyping()) return;
            // user is done typing, do your stuff
            Koneksi.SearchRefresh(TxtCari.Text);
        }

        private void ResetTextCari()
        {
            if (TxtCari.Text != "") TxtCari.Text = "";
        }
    }
}
