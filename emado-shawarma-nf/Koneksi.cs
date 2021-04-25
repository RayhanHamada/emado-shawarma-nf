using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;

namespace emado_shawarma_nf
{
    class Koneksi
    {
        public static SQLiteConnection Conn { get; set; }
        public static DataTable Table { get; set; }

        public Koneksi()
        {
            try
            {
                string dbPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\emado_shawarma";

                // cek apakah di folder app ini sudah ada database emado_shawarma
                if (!File.Exists($"{dbPath}\\emado_shawarma.sqlite"))
                {
                    string AppDir = AppDomain.CurrentDomain.BaseDirectory;
                    Directory.CreateDirectory(dbPath);
                    SQLiteConnection.CreateFile($"{dbPath}\\emado_shawarma.sqlite");
                    Conn = new SQLiteConnection($"Data Source={dbPath}\\emado_shawarma.sqlite; Version=3;");
                    Conn.Open();

                    string createTableCmd = File.ReadAllText($"{AppDir}\\db\\db_init.sql", System.Text.Encoding.UTF8);
                    var cmd = new SQLiteCommand(createTableCmd, Conn);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    Conn = new SQLiteConnection($"Data Source={dbPath}\\emado_shawarma.sqlite;Version=3;");
                    Connect();
                }

                Table = new DataTable();
            }
            catch
            {

            }
        }

        public static void Connect()
        {
            if (Conn.State != ConnectionState.Open)
            {
                Conn.Open();
                return;
            }
        }

        public static bool IsConnected()
        {
            if (Conn == null) return false;
            return Conn.State == ConnectionState.Open;
        }

        public static void FillTable()
        {
            if (!IsConnected())
            {
                return;
            }

            var query = "SELECT id, nama, golongan, jabatan," +
                "departemen, gaji, tunjangan, STRFTIME('%d-%m-%Y', DATETIME(tgl_lahir)) as tgl_lahir," +
                "jenis_kelamin, alamat, no_rek, no_npwp, no_bpjs, lokasi, url_foto FROM tbl_karyawan";

            var selectAllKaryawan = new SQLiteDataAdapter(query, Conn);
            selectAllKaryawan.Fill(Table);
        }

        public static void RefreshTableWithNewCommand(string cmd)
        {
            if (!IsConnected())
            {
                // make handler on not connecting
                return;
            }

            var adapter = new SQLiteDataAdapter(cmd, Conn);
            Table.Clear();
            adapter.Fill(Table);
        }

        public static void SearchRefresh(string name)
        {
            if (!IsConnected())
            {
                // make handler on not connecting
                return;
            }

            var query = "SELECT id, nama, golongan, jabatan," +
                "departemen, gaji, tunjangan, STRFTIME('%d-%m-%Y', DATETIME(tgl_lahir)) as tgl_lahir," +
                $"jenis_kelamin, alamat, no_rek, no_npwp, no_bpjs, lokasi, url_foto FROM tbl_karyawan WHERE nama LIKE '%{name}%'";

            var adapter = new SQLiteDataAdapter(query, Conn);
            Table.Clear();
            adapter.Fill(Table);
        }

        public static void RefreshTable()
        {
            if (!IsConnected())
            {
                // make handler on not connecting
                return;
            }

            var query = "SELECT id, nama, golongan, jabatan," +
                "departemen, gaji, tunjangan, STRFTIME('%d-%m-%Y', DATETIME(tgl_lahir)) as tgl_lahir," +
                "jenis_kelamin, alamat, no_rek, no_npwp, no_bpjs, lokasi, url_foto FROM tbl_karyawan";

            var adapter = new SQLiteDataAdapter(query, Conn);
            Table.Clear();
            adapter.Fill(Table);
        }

        public static bool DeleteKaryawan(long id)
        {
            if (!IsConnected())
            {
                MessageBox.Show("Hapus data gagal, aplikasi tidak terkoneksi ke database !");
                return false;
            }

            var cmd = new SQLiteCommand($"DELETE FROM tbl_karyawan WHERE id = {id}", Conn);
            var affected = cmd.ExecuteNonQuery();
            RefreshTable();

            return affected > 0;
        }

        public static bool UpdateKaryawan(Karyawan k)
        {
            if (!IsConnected())
            {
                MessageBox.Show("Update data gagal, aplikasi tidak terkoneksi ke database !");
                return false;
            }

            var query = $"UPDATE tbl_karyawan SET " +
                $"nama = '{k.Nama}'," +
                $"golongan = '{k.Golongan}'," +
                $"jabatan = '{k.Jabatan}'," +
                $"departemen = '{k.Departemen}'," +
                $"gaji = {k.Gaji}," +
                $"tunjangan = {k.Tunjangan}," +
                $"tgl_lahir = '{k.TglLahir:yyyy-MM-dd}'," +
                $"jenis_kelamin = '{k.JenisKelamin}'," +
                $"alamat = '{k.Alamat}'," +
                $"no_rek = '{k.Norek}'," +
                $"no_npwp = '{k.NPWP}'," +
                $"no_bpjs = '{k.BPJS}'," +
                $"lokasi = '{k.Lokasi}'," +
                $"url_foto = '{k.UrlFoto}'" +
                $"WHERE id = {k.Id}";

            var cmd = new SQLiteCommand(query, Conn);
            int affected = cmd.ExecuteNonQuery();
            RefreshTable();

            return affected > 0;
        }

        public static Karyawan GetKaryawan(long id)
        {
            if (!IsConnected())
            {
                MessageBox.Show("Ambil data gagal, aplikasi tidak terkoneksi ke database !");
                return null;
            }

            var cmd = new SQLiteCommand($"SELECT id, nama, golongan, jabatan," +
                "departemen, gaji, tunjangan, tgl_lahir," +
                "jenis_kelamin, alamat, no_rek, no_npwp, no_bpjs, lokasi, url_foto" +
                $" FROM tbl_karyawan WHERE id = '{id}'", Conn);

            SQLiteDataReader result = cmd.ExecuteReader();
            var k = new Karyawan();

            result.Read();

            k.Id = result.GetInt64(0);
            k.Nama = result.GetString(1);
            k.Golongan = result.GetString(2);
            k.Jabatan = result.GetString(3);
            k.Departemen = result.GetString(4);
            k.Gaji = result.GetInt32(5);
            k.Tunjangan = result.GetInt32(6);
            k.TglLahir = DateTime.ParseExact(result.GetString(7),
                "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture);
            k.JenisKelamin = result.GetString(8);
            k.Alamat = result.GetString(9);
            k.Norek = result.GetString(10);
            k.NPWP = result.GetString(11);
            k.BPJS = result.GetString(12);
            k.Lokasi = result.GetString(13);
            k.UrlFoto = result.GetString(14);
            result.Close();

            return k;
        }

        public static bool AddKaryawan(Karyawan k)
        {
            if (!IsConnected())
            {
                MessageBox.Show("Tambah data gagal, aplikasi tidak terkoneksi ke database !");
                return false;
            }

            // cari karyawan dengan nama sama
            var cmdCari = new SQLiteCommand($"SELECT COUNT(nama) as banyak FROM tbl_karyawan WHERE nama = '{k.Nama}'", Conn);
            var banyak = (long)cmdCari.ExecuteScalar();

            if (banyak > 0)
            {
                MessageBox.Show($"Tambah data gagal, karyawan dengan nama {k.Nama} sudah ada !");
                return false;
            }

            var query = $"INSERT INTO tbl_karyawan VALUES (" +
                $"NULL," +
                $"'{k.Nama}'," +
                $"'{k.Golongan}'," +
                $"'{k.Jabatan}'," +
                $"'{k.Departemen}'," +
                $"{k.Gaji}," +
                $"{k.Tunjangan}," +
                $"'{k.TglLahir:yyyy-MM-dd}'," +
                $"'{k.JenisKelamin}'," +
                $"'{k.Alamat}'," +
                $"'{k.Norek}'," +
                $"'{k.NPWP}'," +
                $"'{k.BPJS}'," +
                $"'{k.Lokasi}'," +
                $"'{k.UrlFoto.Replace("\\", "\\\\")}')";

            var cmd = new SQLiteCommand(query, Conn);
            var result = cmd.ExecuteNonQuery();
            RefreshTable();

            return result > 0;
        }
    }
}
