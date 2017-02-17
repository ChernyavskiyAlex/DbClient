using System;
using NUnit.Framework;
using Utils;

namespace Tests
{
    [TestFixture]
    public class Tests: BaseTests
    {
        [Test]
        public void CreateRequirement()
        {
            AlmConnetor.LoginAlm();
            var fromRest = AlmConnetor.GetRequirement(7);
            AlmConnetor.LogoutAlm();
            
            AlmDbConnector.Connect();
            var fromDb = AlmDbConnector.GetRequirementById(7);
            AlmDbConnector.Disconnect();

            TryAssertTrue(AlmConnetor.CompareRequired(fromRest, fromDb), "Compare two objects equality");
        }
    }
}
