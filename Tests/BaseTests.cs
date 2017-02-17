using System;
using ALMClient;
using DBClient;
using DBClient.Utils;
using ALMClient.Utils;
using NUnit.Framework;
using Utils;

namespace Tests
{
    public class BaseTests
    {
        public AlmDbClient AlmDbConnector;
        public AlmConnector AlmConnetor;
        public DbProperties DbProp;
        public AlmProperies AlmProp;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            DbProp = new DbProperties
            {
                DbType = TestSettings.Default.DbType,
                DbServer = TestSettings.Default.DbServer,
                DbPort = TestSettings.Default.DbPort,
                ServiceName = TestSettings.Default.ServiceName,
                DbSchemaName = TestSettings.Default.DbSchemaName,
                DbUsername = TestSettings.Default.DbUsername,
                DbPassword = TestSettings.Default.DbPassword,
            };

            AlmProp = new AlmProperies
            {
                AlmServer = TestSettings.Default.AlmServer,
                AlmPort = TestSettings.Default.AlmPort,
                Domain = TestSettings.Default.Domain,
                Project = TestSettings.Default.Project,
                AlmAdminName = TestSettings.Default.AlmAdminName,
                AlmAdminPassword = TestSettings.Default.AlmAdminPassword,
                IsHttps = TestSettings.Default.IsHttps
            };

            AlmConnetor = AlmConnector.Instance;
            AlmConnetor.Init(AlmProp);
            AlmConnetor.GetCustomizationData();
        }


        [SetUp]
        public void SetUp()
        {
            AlmDbConnector = AlmDbClient.Init(DbProp);
        }

        [TearDown]
        public void TearDown()
        {
            AlmDbConnector = null;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }

        public void TryAssertTrue(bool result, string actionName)
        {
            try
            {
                Helper.WriteCheck(actionName);
                Assert.True(result);
                Helper.WriteSuccess(actionName);
            }
            catch (AssertionException e)
            {
                Helper.WriteError(string.Format("{0} failed", actionName));
                throw e;
            }
           
        }
    }
}
