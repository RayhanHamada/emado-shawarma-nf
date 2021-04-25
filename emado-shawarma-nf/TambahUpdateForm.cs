﻿using System;
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
            btn_update_tambah.Text = "Tambah Karyawan";
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
            btn_update_tambah.Text = "Update Karyawan";
            PopulateForm(k);
        }

        private void InitializeCustom()
        {
            dt_tgl_lahir.CustomFormat = "dd-MM-yyyy";
            FormClosed += TambahUpdateForm_FormClosed;
        }

        private void TambahUpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        private void btn_update_tambah_Click(object sender, EventArgs e)
        {
            if (txt_nama.Text == ""
                || cb_golongan.Text == ""
                || cb_jabatan.Text == ""
                || cb_departemen.Text == "")
            {
                MessageBox.Show("Kolom Nama, Golongan, Jabatan dan Departemen tidak boleh kosong", "Kesalahan Input");
                return;
            }

            k.Nama = txt_nama.Text;
            k.Golongan = cb_golongan.Text;
            k.Jabatan = cb_jabatan.Text;
            k.Departemen = cb_departemen.Text;

            try
            {
                k.Gaji = decimal.Parse(txt_gaji.Text);
            }
            catch
            {
                k.Gaji = 0;
            }

            try
            {
                k.Tunjangan = decimal.Parse(txt_tunjangan.Text);
            }
            catch
            {
                k.Tunjangan = 0;
            }

            k.TglLahir = dt_tgl_lahir.Value;
            k.JenisKelamin = cb_jk.Text;
            k.Alamat = rtb_alamat.Text;

            k.Norek = txt_norek.Text;

            k.NPWP = txt_npwp.Text;
            k.BPJS = txt_bpjs.Text;
            k.Lokasi = txt_lokasi.Text;

            if (pb_foto.ImageLocation != null)
            {
                k.UrlFoto = pb_foto.ImageLocation;
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
            txt_nama.Text = k.Nama;
            cb_golongan.Text = k.Golongan;
            cb_jabatan.Text = k.Jabatan;
            cb_departemen.Text = k.Departemen;
            txt_gaji.Text = k.Gaji.ToString();
            txt_tunjangan.Text = k.Tunjangan.ToString();
            dt_tgl_lahir.Value = k.TglLahir;
            cb_jk.Text = k.JenisKelamin;
            rtb_alamat.Text = k.Alamat;
            txt_norek.Text = k.Norek;
            txt_npwp.Text = k.NPWP;
            txt_bpjs.Text = k.BPJS;
            txt_lokasi.Text = k.Lokasi;
            pb_foto.ImageLocation = k.UrlFoto;
        }

        private void btn_upload_foto_Click(object sender, EventArgs e)
        {
            FileDialog dialog = new OpenFileDialog();
            var res = dialog.ShowDialog();
            if (res == DialogResult.OK || res == DialogResult.Yes)
            {
                pb_foto.ImageLocation = dialog.FileName;
            }
        }

        private void btn_reset_form_Click(object sender, EventArgs e)
        {
            txt_nama.Text = "";
            cb_golongan.Text = "";
            cb_jabatan.Text = "";
            cb_departemen.Text = "";
            txt_gaji.Text = "";
            txt_tunjangan.Text = "";
            dt_tgl_lahir.Value = DateTime.Now;
            cb_jk.Text = "";
            rtb_alamat.Text = "";
            txt_norek.Text = "";
            txt_npwp.Text = "";
            txt_bpjs.Text = "";
            txt_lokasi.Text = "";
            pb_foto.ImageLocation = "";
        }

        private void txt_gaji_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_tunjangan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_gaji_TextChanged(object sender, EventArgs e)
        {
            decimal gaji;

            try
            {
                gaji = decimal.Parse(txt_gaji.Text);
            }
            catch
            {
                gaji = 0;
            }

            lbl_rpGaji.Text = string.Format(
                System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
                "{0:C}", gaji);
        }

        private void txt_tunjangan_TextChanged(object sender, EventArgs e)
        {
            decimal tunjangan;

            try
            {
                tunjangan = decimal.Parse(txt_tunjangan.Text);
            }
            catch
            {
                tunjangan = 0;
            }

            lbl_rpTunjangan.Text = string.Format(
                System.Globalization.CultureInfo.GetCultureInfo("id-ID"),
                "{0:C}", tunjangan);
        }
    }
}
