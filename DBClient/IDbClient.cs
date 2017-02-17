using System.Data;

namespace DBClient
{
    interface IDbClient
    {
        bool Connect(string connectionString);
        
        DataTable Select(string connectionString, string query);

        void Disconnect();
    }
}
