using System;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace DBClient
{
    class SqlDbClient : IDbClient
    {
        private SqlConnection _conn;

        public bool Connect(string connectionStr)
        {
            try
            {
                _conn = new SqlConnection(connectionStr);
                _conn.Open();
            }
            catch (Exception e)
            {
                //throw new Exception($"Could not connect to Db Server: {connectionStr}; Stacktrace: {e}");
                throw new Exception(string.Format("Could not connect to Db Server: {0}; Stacktrace: {1}", connectionStr, e));
            }
            return true;
        }


        public void Disconnect()
        {
            try
            {
                _conn.Close();}
            catch (Exception e)
            {
                //throw new Exception($"Could not connect to Db Server: {_conn.ConnectionString}; Stacktrace: {e}");
                throw new Exception(string.Format("Could not connect to Db Server: {0}; Stacktrace: {1}", _conn.ConnectionString, e));
            }
        }
      
        public DataTable Select(string connectionString, string query)
        {
            DataTable dt = null;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (var dataReader = command.ExecuteReader())
                        {
                            dt = new DataTable();
                            dt.Load(dataReader);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return dt;
        }
    }
}
