using Kasir_TokoBuku.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasir_TokoBuku
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new ManagementStock());
=======
            Application.Run(new TransaksiPenjualan());
>>>>>>> e75af223137f89b7655b1f4e064c2b0bcd4b1230
        }
    }
}
