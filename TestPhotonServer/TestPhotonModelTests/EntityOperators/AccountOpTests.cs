using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestPhotonModel.EntityOperators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPhotonModel.EntityOperators.Tests
{
    [TestClass()]
    public class AccountOpTests
    {
        [TestMethod()]
        public void GetAccountTest()
        {
            Assert.IsNull(AccountOp.GetAccount(3));
            Assert.AreEqual(AccountOp.GetAccount(1).UserName, "xiezaikui");
        }
    }
}