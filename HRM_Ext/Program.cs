using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_Ext
{
    internal class Program
    {
        const string CONNSTR_FILE = "data";
        static void Main(string[] args)
        {
            if(args != null && args.Length == 1)
            {
                string Content = args[0];

                if (Content == "DEL")
                {
                    if (File.Exists(CONNSTR_FILE))
                    {
                        File.Delete(CONNSTR_FILE);
                    }
                }
                else
                {

                    System.IO.File.WriteAllText(CONNSTR_FILE, Content);
                }
            }
        }
    }
}
