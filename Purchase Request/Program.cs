using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Purchase_Request
{
    static class Program
    {
        public static LoginForm loginForm;

        public static mainPage form1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginForm = new LoginForm();
            form1 = new mainPage();
            Permission.LoadPermission();
            Application.Run(loginForm);
        }
    }
}
