using System;
using System.Collections.Generic;
using System.Linq;
using Entidades;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieMatch
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}
