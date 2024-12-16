using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.LogIn
{
    public class Login_Sql_Model
    {
        public string ServerName { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IntegratedSecurity { get; set; } = false;

        public string CONNSTR
        {
            get
            {
                //DESKTOP-U0JHR1S\SQLEXPRESS;initial catalog=HRM;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework
                //if(IntegratedSecurity)
                if (true)
                {
                    //Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;
                    //return $"Server={ServerName};Database={DatabaseName};Trusted_Connection=True";
                    return  $"data source={ServerName};initial catalog={DatabaseName};Trusted_Connection=True;TrustServerCertificate=True; integrated security=True;Encrypt=True;";
                }
                else
                {
                    return $"Server={ServerName};Database={DatabaseName};User Id={UserName};Password={Password};";
                }
            }
        }



        public string CONNSTR_INIT
        {
            get
            {
                //DESKTOP-U0JHR1S\SQLEXPRESS;initial catalog=HRM;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework
                if (IntegratedSecurity)
                {
                    //Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;
                    //return $"Server={ServerName};Database={DatabaseName};Trusted_Connection=True";
                    return $"data source={ServerName};initial catalog=master;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework";
                }
                else
                {
                    return $"Server={ServerName};Database=master;User Id={UserName};Password={Password};";
                }
            }
        }
    }


}
