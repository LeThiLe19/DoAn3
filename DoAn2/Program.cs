using DoAn2.Entities;
using DoAn2.View;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn2
{
    static class Program
    {
        public static string stcon;
        public static Users us;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            stcon = ConfigurationManager.ConnectionStrings["stconnection"].ConnectionString;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmDangNhap());
            

            Application.Run(new MDI());
        }
    }
}
