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
using System.Diagnostics;

namespace Test
{
    [TestFixture]
    public class HostTest
    {
        private IApplicationContext applicationContext;
        private ITestDataManager testDataManager;
        private IProductManager productManager;

        [SetUp]
        public void Init()
        {
            log4net.Config.XmlConfigurator.Configure();
            applicationContext = ContextRegistry.GetContext();
            testDataManager = (ITestDataManager)applicationContext.GetObject("Product.TestDataManager");
            productManager = (IProductManager)applicationContext.GetObject("Product.ProductManager");
        }

        [Test]
        public void InitData()
        {
            testDataManager.InitData();
        }

        [Test]
        public void BatchData_1K()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            testDataManager.BatchData(1000);
            sw.Stop();
            Console.WriteLine("BatchData 1000:{0}", sw.ElapsedMilliseconds);
        }

        [Test]
        public void BatchData_10K()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            testDataManager.BatchData(10000);
            sw.Stop();
            Console.WriteLine("BatchData 10000:{0}", sw.ElapsedMilliseconds);
        }

        [Test]
        public void BatchData_100K()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            testDataManager.BatchData(100000);
            sw.Stop();
            Console.WriteLine("BatchData 100000:{0}", sw.ElapsedMilliseconds);
        }

        [Test]
        public void DistributedUpdate()
        {
            ProductInfo product;
            //保存更新前的值
            product = productManager.Get(15);
            var priceBeforeUpdate = product.Price;
            var moneyBeforeUpdate = testDataManager.GetMoney();
            var dateBeforeUpdate = testDataManager.GetOrderDate();

            testDataManager.DistributedUpdate();

            //获取更新后的值
            product = productManager.Get(15);
            var priceAfterUpdate = product.Price;
            var moneyAfterUpdate = testDataManager.GetMoney();
            var dateAfterUpdate = testDataManager.GetOrderDate();

            //比较是否改变
            Assert.Less(priceBeforeUpdate, priceAfterUpdate);
            Assert.Greater(moneyBeforeUpdate, moneyAfterUpdate);
            Assert.Greater(dateAfterUpdate, dateBeforeUpdate);
        }

        [Test]
        public void DistributedUpdateException()
        {
            ProductInfo product;
            //保存更新前的值
            product = productManager.Get(15);
            var priceBeforeUpdate = product.Price;
            var moneyBeforeUpdate = testDataManager.GetMoney();
            var dateBeforeUpdate = testDataManager.GetOrderDate();

            try
            {
                testDataManager.DistributedUpdateException();
            }
            catch
            {
            }

            //获取更新后的值
            product = productManager.Get(15);
            var priceAfterUpdate = product.Price;
            var moneyAfterUpdate = testDataManager.GetMoney();
            var dateAfterUpdate = testDataManager.GetOrderDate();

            //比较是否改变
            Assert.AreEqual(priceBeforeUpdate, priceAfterUpdate);
            Assert.AreEqual(moneyBeforeUpdate, moneyAfterUpdate);
            Assert.AreEqual(dateBeforeUpdate, dateAfterUpdate);
        }
    }
}
