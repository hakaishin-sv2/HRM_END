using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
using BusinessLayer;
namespace BusinessLayer
{
    public static class Session
    {
       
        public static User User { get; set; }

        public static string CONN_STR = "";

        public static string CONN_STR_INIT = "";
    }
}
