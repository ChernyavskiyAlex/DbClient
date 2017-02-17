using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace DBClient.Utils
{
    public class DbProperties
    {
        public int DbType { get; set; }
        public string DbServer { get; set; }
        public int DbPort { get; set; }
        public string ServiceName { get; set; }
        public string DbSchemaName { get; set; }
        public string DbUsername { get; set; }
        public string DbPassword { get; set; }
    }
}
