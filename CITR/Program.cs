using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CITR
{
    static class DataTransport
    {
        public static string name_IDE { get; set; }
        public static string data_puth { get; set; }

        public static string name { get; set; }

        public static string Application { get; set; }

        public static int progress { get; set; }
    }
    static class Program
    {
        static public Form1 frm1;
        static public Form2 frm2;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool b_form = true;
            Microsoft.Win32.RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey helloKey = currentUserKey.CreateSubKey("CITR");
            if (helloKey.GetValue("last_Form") != null)
                b_form = Convert.ToBoolean(helloKey.GetValue("last_Form").ToString());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frm1 = new Form1();
            frm2 = new Form2();
            if (b_form)
                Application.Run(frm1);
            else
                Application.Run(frm2);
        }
    }

}
