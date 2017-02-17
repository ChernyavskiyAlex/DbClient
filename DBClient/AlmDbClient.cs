using System;
using System.Data;
using System.Runtime.Remoting.Messaging;
using ALMClient;
using ALMClient.Utils;
using DBClient.Utils;
using Utils;

namespace DBClient
{
    public class AlmDbClient
    {
        private static AlmDbClient _inst;
        private string _conStr = "";
        //private 
        private IDbClient _connector;
        public static AlmDbClient Init(DbProperties prop)
        {
            if (_inst != null)
            {
                return _inst;
            }
            _inst = new AlmDbClient();
            switch (prop.DbType)
            {
                //1-H2
                case 1:
                    throw new NotImplementedException("H2 database is not supported in ALM");
                //2-MSSQL
                case 2:
                    _inst._connector = _inst.SqlInit(prop);
                    break;
                //3-Oracle
                case 3:
                    _inst._connector = _inst.OraInit(prop);
                    break;
                default:
                    throw new NullReferenceException("Wrong DB Type");
            }

            return _inst;
        }

        private IDbClient OraInit(DbProperties prop)
        {
            //if (prop == null) throw new ArgumentNullException(nameof(prop));
            throw new NotImplementedException();
        }

        private IDbClient SqlInit(DbProperties prop)
        {
            //_conStr = $"user id={prop.DbUsername};" +
            //    $"password={prop.DbPassword};" +
            //    $"server=tcp:{prop.DbServer}, {prop.DbPort};" +
            //    "Trusted_Connection=false;" +
            //    $"database={prop.DbSchemaName}; " +
            //    "connection timeout=30";

            _conStr = String.Format("user id={0};password={1};server=tcp:{2}, {3};Trusted_Connection=false;database={4}; connection timeout=30" , prop.DbUsername, prop.DbPassword, prop.DbServer, prop.DbPort, prop.DbSchemaName);

            IDbClient inst = new SqlDbClient();
            return inst;
        }
        public bool Connect()
        {
            return Connect(_conStr);
        }

        /*public T Select<T>(string query)
        {
            T result = DeserializeDbResult<T>(_connector.Select(_conStr, query));
           return result;
        }*/


        public DataTable Select(string query)
        {
            return _connector.Select(_conStr, query);
        }


        public bool Connect(string connectionString)
        {
            Helper.WriteInfo("Trying connect to db");
            return _connector.Connect(connectionString);
        }

    
        //public List<Dictionary<string, string>> Select(string query) => _connector.Select(query);

        public void Disconnect()
        {
            Helper.WriteInfo("Disconecting from DB");
            _connector.Disconnect();
        }

        public Entity GetRequirementById(int id)
        {
            //Helper.WriteInfo($"Trying to get requirement by id: {id}");
            Helper.WriteInfo(string.Format("Trying to get requirement by id: {0}", id));
            var select = Select(string.Format(QueryLib.GetRequirementById, id));
            var result = DeserializeDbResult(select, Const.RequirementCustomizationName);
            if (result.TotalResults == 1)
                return result.Entity[0];
            //throw new Exception($"Wrong ammount of entities, Expected: 1 Actual: {result.TotalResults}");
            throw new Exception(string.Format("Wrong ammount of entities, Expected: 1 Actual: {0}", result.TotalResults));
            //return GetRequirements(string.Format(QueryLib.GetRequirementById, id));
        }
        private Entities DeserializeDbResult(DataTable result, string entityType)
        {
            var almConnector = AlmConnector.Instance;
            CustomizationFields entityCustomization;
            if (!almConnector.CustomizationData.TryGetValue(entityType, out entityCustomization))
                return null;
            if (result.Rows.Count < 1)
                return null;

            var entities = new Entities();
            foreach (DataRow row in result.Rows)
            {
                var entity = new Entity(entityType);
                foreach (DataColumn column in result.Columns)
                {
                    foreach (var field in entityCustomization.CustomizationField)
                    {
                        if (field.PhysicalName.Equals(column.ColumnName))
                        {
                            try
                            {
                                var value = row[column].ToString();
                                value = string.IsNullOrEmpty(value) ? "" : value;
                                entity.Add(field.Name, field.Type, value);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                    }
                    //Console.WriteLine(column.ColumnName);
                }
                entities.Add(entity);
            }
            return entities;
        }

        /*public Entities GetRequirements(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return null;
            }
            var dBresult = _connector.Select(query);
            return dBresult == null ? null : DeserializeDbResult(dBresult);
        }

        private T  DeserializeDbResult<T>(DataTable dBresult) where T : Entity  
        {
            if (dBresult == null)
                return null;
            var entities = new Entities(dBresult.Count);
            foreach (Dictionary<string, string> row in dBresult)
            {
                foreach (var item in row)
                {
                    var newColumnName = MapColumnName(item.Key);
                    if (newColumnName != null)
                        entities.Add(new Entity(newColumnName, item.Value));
                }
            }
            return entities;
        }*/

    }
}
