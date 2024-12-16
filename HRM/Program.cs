using DevExpress.Skins;
using DevExpress.UserSkins;
using HRM.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace HRM
{
    public static class RequestAdministrator
    {
        public static bool request = false;
    }

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            ////Application.Run(new MainForm());
            //Application.Run(new formLogIn());


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new formLogIn());

            //try
            //{
            //    // request admin
            //    //RequestAdministrator.request = true;

                
            //}
            //catch (Exception ex) 
            //{ 
            
            //}
        }
    }
}
