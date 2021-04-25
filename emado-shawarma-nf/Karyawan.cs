﻿using System;

namespace emado_shawarma_nf
{
    class Karyawan
    {
        public long Id { get; set; }
        public string Nama { get; set; }
        public string Golongan { get; set; }
        public string Jabatan { get; set; }
        public string Departemen { get; set; }
        public DateTime TglLahir { get; set; }
        public string JenisKelamin { get; set; }
        public string Alamat { get; set; }
        public string Norek { get; set; }
        public string NPWP { get; set; }
        public string BPJS { get; set; }
        public string Lokasi { get; set; }
        public decimal Gaji { get; set; }
        public decimal Tunjangan { get; set; }
        public string UrlFoto { get; set; }

        //untuk tambah data
        public Karyawan() { }

        //untuk update data
        public Karyawan(long id) => Id = id;
    }
}
