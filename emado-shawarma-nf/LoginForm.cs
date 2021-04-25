using System;
using System.Windows.Forms;

namespace emado_shawarma_nf
{
    public partial class LoginForm : Form
    {
        private TableForm tableForm;

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;

            //username dan password harus admin atau tidak kosong
            if (username == "" || password == "")
            {
                MessageBox.Show("Username atau password tidak boleh kosong");
                return;
            }

            if (username != "admin" || password != "admin")
            {
                MessageBox.Show("Username atau password salah");
                return;
            }

            if (Koneksi.IsConnected())
            {
                tableForm = new TableForm();
                tableForm.Show(this);
                Visible = false;
                return;
            }

            MessageBox.Show("Aplikasi tidak terkoneksi ke database !");
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose(true);
            Environment.Exit(0);
        }
    }
}
