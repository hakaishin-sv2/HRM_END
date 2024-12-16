using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class SingleConnection
    {
        public string Connect(string cnn)
        {
            EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder()
            {
                Provider = "System.Data.SqlClient",
                Metadata = "res://*/HRMData.csdl|res://*/HRMData.ssdl|res://*/HRMData.msl",
                ProviderConnectionString = cnn
            };
            return entityString.ConnectionString;
        }
    }


    public partial class HRMEntities : DbContext
    {
        public HRMEntities(string cnn)
            : base(new SingleConnection().Connect(cnn))
        {

        }
    }
}
