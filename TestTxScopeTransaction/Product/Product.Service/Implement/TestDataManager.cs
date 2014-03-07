using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Product.Service.CustomerProxy;
using Product.Service.OrderProxy;
using Spring.Transaction.Interceptor;
using Product.Domain;
using Order.Domain;
using Spring.Transaction;
using Product2.Domain;

namespace Product.Service.Implement
{
    public class TestDataManager : ITestDataManager
    {
        public IProductManager ProductManager { get; set; }

        public IProduct2Manager Product2Manager { get; set; }

        [Transaction]
        public void InitData()
        {
            //var customerProxy = new CustomerContractClient();
            var orderProxy = new OrderContractClient();
            orderProxy.ClientCredentials.UserName.UserName = "admin";
            orderProxy.ClientCredentials.UserName.Password = "123456";
            var remoteOrderProxy = new Product.Service.RemoteOrderProxy.OrderContractClient();
            remoteOrderProxy.ClientCredentials.UserName.UserName = "admin";
            remoteOrderProxy.ClientCredentials.UserName.Password = "123456";

            //var id = customerProxy.Save(new CustomerInfo
            //{
            //    Name = "张三"
            //});

            orderProxy.Save(new OrderInfo
            {
                Address = "大连市",
                OrderDate = DateTime.Now,
                CustomerId = Convert.ToInt32(1)
            });

            remoteOrderProxy.Save(new OrderInfo
            {
                Address = "大连市",
                OrderDate = DateTime.Now,
                CustomerId = Convert.ToInt32(1)
            });

            ProductManager.Save(new ProductInfo
            {
                Name = "产品" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                Price = 200
            });

            Product2Manager.Save(new Product2Info
            {
                Name = "产品" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                Price = 200
            });
            orderProxy.Close();
            remoteOrderProxy.Close();
        }

        [Transaction]
        public void BatchData(int count)
        {
            //var customerProxy = new CustomerContractClient();
            var orderProxy = new OrderContractClient();
            orderProxy.ClientCredentials.UserName.UserName = "admin";
            orderProxy.ClientCredentials.UserName.Password = "123456";
            var remoteOrderProxy = new Product.Service.RemoteOrderProxy.OrderContractClient();
            remoteOrderProxy.ClientCredentials.UserName.UserName = "admin";
            remoteOrderProxy.ClientCredentials.UserName.Password = "123456";

            //var id = customerProxy.Save(new CustomerInfo
            //{
            //    Name = "张三"
            //});
            for (int i = 0; i < count; i++)
            {
                orderProxy.Save(new OrderInfo
                {
                    Address = "大连市",
                    OrderDate = DateTime.Now,
                    CustomerId = Convert.ToInt32(1)
                });
            }

            for (int i = 0; i < count; i++)
            {
                remoteOrderProxy.Save(new OrderInfo
                {
                    Address = "大连市",
                    OrderDate = DateTime.Now,
                    CustomerId = Convert.ToInt32(1)
                });
            }
            for (int i = 0; i < count; i++)
            {
                ProductManager.Save(new ProductInfo
                {
                    Name = "产品" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                    Price = 200
                });
            }

            for (int i = 0; i < count; i++)
            {
                Product2Manager.Save(new Product2Info
                {
                    Name = "产品" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                    Price = 200
                });
            }

            orderProxy.Close();
            remoteOrderProxy.Close();
        }

        [Transaction]
        public void DistributedUpdate()
        {
            var product = ProductManager.Get(15);
            product.Price += 1;
            ProductManager.Update(product);

            var customerProxy = new CustomerContractClient();
            var orderProxy = new OrderContractClient();

            OrderInfo order = orderProxy.Get(2);
            order.OrderDate = DateTime.Now;
            orderProxy.Update(order);

            CustomerInfo customer = customerProxy.Get(1);
            customer.Money -= 100;
            customerProxy.Update(customer);
        }

        [Transaction]
        public void DistributedUpdateException()
        {
            var product = ProductManager.Get(15);
            product.Price += 1;
            ProductManager.Update(product);

            var customerProxy = new CustomerContractClient();
            var orderProxy = new OrderContractClient();

            OrderInfo order = orderProxy.Get(2);
            order.OrderDate = DateTime.Now;
            orderProxy.Update(order);

            CustomerInfo customer = customerProxy.Get(1);
            customer.Money += 3000;
            customerProxy.Update(customer);
        }

        [Transaction(ReadOnly = true)]
        public decimal GetMoney()
        {
            var customerProxy = new CustomerContractClient();

            CustomerInfo customer = customerProxy.Get(1);

            return customer.Money;
        }

        [Transaction(ReadOnly = true)]
        public DateTime GetOrderDate()
        {
            var orderProxy = new OrderContractClient();

            var customer = orderProxy.Get(2);

            return customer.OrderDate;
        }
    }
}
