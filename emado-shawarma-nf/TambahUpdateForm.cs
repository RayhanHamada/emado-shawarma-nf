using System;
using System.Windows.Forms;

namespace emado_shawarma_nf
{
    public partial class TambahUpdateForm : Form
    {
        private readonly Karyawan k;
        private readonly bool tambah;

        // nama karyawan sebelum di update
        private readonly string namaSebelum;

        //untuk tambah karyawan
        public TambahUpdateForm()
        {
            InitializeComponent();

            k = new Karyawan();
            tambah = true;
            InitializeCustom();
            BtnUpdateTambah.Text = "Tambah Karyawan";
        }

        //untuk update karyawan
        public TambahUpdateForm(long id)
        {
            InitializeComponent();

            k = Koneksi.GetKaryawan(id);
            if (k.Equals(null))
            {
                Close();
            }

            namaSebelum = k.Nama;
            tambah = false;
            InitializeCustom();
            BtnUpdateTambah.Text = "Update Karyawan";
            PopulateForm(k);
        }

        private void InitializeCustom()
        {
            DtTglLahir.CustomFormat = "dd-MM-yyyy";
        }

        private void TambahUpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        private void BtnUpdate_tambah_Click(object sender, EventArgs e)
        {
            if (TxtNama.Text == ""
                || CbGolongan.Text == ""
                || CbJabatan.Text == ""
                || CbDepartemen.Text == "")
            {
                MessageBox.Show("Kolom Nama, Golongan, Jabatan dan Departemen tidak boleh kosong", "Kesalahan Input");
                return;
            }

            k.Nama = TxtNama.Text;
            k.Golongan = CbGolongan.Text;
            k.Jabatan = CbJabatan.Text;
            k.Departemen = CbDepartemen.Text;

            try
            {
                k.Gaji = decimal.Parse(TxtGaji.Text);
            }
            catch
            {
                k.Gaji = 0;
            }

            try
            {
                k.Tunjangan = decimal.Parse(TxtTunjangan.Text);
            }
            catch
            {
                k.Tunjangan = 0;
            }

            k.TglLahir = DtTglLahir.Value;
            k.JenisKelamin = CbJK.Text;
            k.Alamat = RtbAlamat.Text;

            k.Norek = TxtNorek.Text;

            k.NPWP = TxtNPWP.Text;
            k.BPJS = TxtBPJS.Text;
            k.Lokasi = TxtLokasi.Text;

            if (PbFoto.ImageLocation != null)
            {
                k.UrlFoto = PbFoto.ImageLocation;
            }
            else
            {
                k.UrlFoto = "";
            }

            bool success;

            if (tambah)
            {
                //panggil Koneksi.AddKaryawan
                success = Koneksi.AddKaryawan(k);
            }
            else
            {
                //panggil Koneksi.UpdateKaryawan
                success = Koneksi.UpdateKaryawan(k);
            }

            if (success)
            {
                MessageBox.Show($"{(tambah ? "Tambah" : "Update")} karyawan {namaSebelum} berhasil !");
                Close();

                return;
            }

            MessageBox.Show($"{(tambah ? "Tambah" : "Update")} karyawan {namaSebelum} tidak berhasil");
        }

        private void PopulateForm(Karyawan k)
        {
            TxtNama.Text = k.Nama;
            CbGolongan.Text = k.Golongan;
            CbJabatan.Text = k.Jabatan;
            CbDepartemen.Text = k.Departemen;
            TxtGaji.Text = k.Gaji.ToString();
            TxtTunjangan.Text = k.Tunjangan.ToString();
            DtTglLahir.Value = k.TglLahir;
            CbJK.Text = k.JenisKelamin;
            RtbAlamat.Text = k.Alamat;
            TxtNorek.Text = k.Norek;
            TxtNPWP.Text = k.NPWP;
            TxtBPJS.Text = k.BPJS;
            TxtLokasi.Text = k.Lokasi;
            PbFoto.ImageLocation = k.UrlFoto;
        }

        private void BtnUploadFoto_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            DialogResult res = dialog.ShowDialog();

            if (res == DialogResult.OK || res == DialogResult.Yes)
            {
                PbFoto.ImageLocation = dialog.FileName;
            }
        }

        private void BtnResetForm_Click(object sender, EventArgs e)
        {
            TxtNama.Text = "";
            CbGolongan.Text = "";
            CbJabatan.Text = "";
            CbDepartemen.Text = "";
            TxtGaji.Text = "";
            TxtTunjangan.Text = "";
            DtTglLahir.Value = DateTime.Now;
            CbJK.Text = "";
            RtbAlamat.Text = "";
            TxtNorek.Text = "";
            TxtNPWP.Text = "";
            TxtBPJS.Text = "";
            TxtLokasi.Text = "";
            PbFoto.ImageLocation = "";
        }

        private void TxtGaji_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtTunjangan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtGaji_TextChanged(object sender, EventArgs e)
        {
            decimal gaji;

            try
            {
                gaji = decimal.Parse(TxtGaji.Text);
            }
            catch
            {
                gaji = 0;
            }

            LblRpGaji.Text = string.Format(
                System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
                "{0:C}", gaji);
        }

        private void TxtTunjangan_TextChanged(object sender, EventArgs e)
        {
            decimal tunjangan;

            try
            {
                tunjangan = decimal.Parse(TxtTunjangan.Text);
            }
            catch
            {
                tunjangan = 0;
            }

            LblRpTunjangan.Text = string.Format(
                System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
                "{0:C}", tunjangan);
        }
    }
}
