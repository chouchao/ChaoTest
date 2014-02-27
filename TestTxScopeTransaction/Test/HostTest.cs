using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Transactions;
using Spring.Context;
using Spring.Context.Support;
using Product.Service;
using Product.Domain;

namespace Test
{
    [TestFixture]
    public class HostTest
    {
        private IApplicationContext applicationContext;
        private ITestDataManager testDataManager;

        [SetUp]
        public void Init()
        {
            log4net.Config.XmlConfigurator.Configure();
            applicationContext = ContextRegistry.GetContext();
            testDataManager = (ITestDataManager)applicationContext.GetObject("Product.TestDataManager");
        }

        [Test]
        public void InitData()
        {
            testDataManager.InitData();
        }

        [Test]
        public void DistributedUpdate()
        {
            var moneyBeforeUpdate = testDataManager.GetMoney();
            var dateBeforeUpdate = testDataManager.GetOrderDate();

            testDataManager.DistributedUpdate();

            var moneyAfterUpdate = testDataManager.GetMoney();
            var dateAfterUpdate = testDataManager.GetOrderDate();

            Assert.Greater(moneyBeforeUpdate, moneyAfterUpdate);
            Assert.Greater(dateAfterUpdate, dateBeforeUpdate);
        }

        [Test]
        public void DistributedUpdateException()
        {
            var moneyBeforeUpdate = testDataManager.GetMoney();
            var dateBeforeUpdate = testDataManager.GetOrderDate();

            try
            {
                testDataManager.DistributedUpdateException();
            }
            catch
            {
            }

            var moneyAfterUpdate = testDataManager.GetMoney();
            var dateAfterUpdate = testDataManager.GetOrderDate();

            Assert.AreEqual(moneyBeforeUpdate, moneyAfterUpdate);
            Assert.AreEqual(dateBeforeUpdate, dateAfterUpdate);
        }
    }
}
