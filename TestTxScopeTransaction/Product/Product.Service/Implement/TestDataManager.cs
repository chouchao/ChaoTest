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

namespace Product.Service.Implement
{
    public class TestDataManager : ITestDataManager
    {
        public IProductManager ProductManager { get; set; }

        [Transaction]
        public void InitData()
        {
            //var customerProxy = new CustomerContractClient();
            var orderProxy = new OrderContractClient();

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

            ProductManager.Save(new ProductInfo
            {
                Name = "产品" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                Price = 200
            });

        }

        [Transaction]
        public void DistributedUpdate()
        {
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
