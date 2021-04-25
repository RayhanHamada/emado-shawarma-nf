using System;
using System.Windows.Forms;

namespace emado_shawarma_nf
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Koneksi();
            Application.Run(new LoginForm());
        }
    }
}
