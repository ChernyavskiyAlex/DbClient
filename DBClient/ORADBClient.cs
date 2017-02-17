using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using DBClient.Utils;

//using Oracle.DataAccess.Client; // ODP.NET Oracle managed provider
//using Oracle.DataAccess.Types;

namespace DBClient
{
    class OradbClient:IDbClient
    {
        public bool Connect()
        {
            throw new NotImplementedException();
        }

        public bool Connect(string connectionString)
        {
            throw new NotImplementedException();
            string oradb = "Data Source=ORCL;User Id=hr;Password=hr;";
            OracleConnection conn = new OracleConnection(oradb);  // C#
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select department_name from departments where department_id = 10";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            return true;
            //label1.Text = dr.GetString(0);
        }
       

        public DataTable Select(string connectionString, string query)
        {
            throw new NotImplementedException();
        }
      
        public void Disconnect()
        {
            throw new NotImplementedException();
        }
    }
}
