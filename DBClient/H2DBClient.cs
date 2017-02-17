using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using DBClient.Utils;
//using java.sql;

namespace DBClient
{
    class H2DbClient: IDbClient
    {
        /*
        public bool Connect(string connString)
        {
           org.h2.Driver.load();
            //string conString = DbUrl + ";USER=" + DbAdminUserName + ";PASSWORD=" + DbAdminPassword;
            using (var connection = DriverManager.getConnection(_dbUrl, _dbAdminUserName, _dbAdminPassword))
            {
                var checkCon = connection.isClosed();
                Console.WriteLine("IsClosed = " + checkCon);
                connection.close();
            }
            return true;
        }*/

        public bool Connect(string connectionString)
        {
            throw new NotImplementedException();
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
