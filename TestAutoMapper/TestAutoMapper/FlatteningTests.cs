using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using NUnit.Framework;

namespace TestAutoMapper
{
    
    [TestFixture]
    public class FlatteningTests
    {
        [Test]
        public void Flattening()
        {
            var customer = new Customer
            {
                Name = "George Costanza"
            };
            var order = new Order
            {
                Customer = customer
            };
            var bosco = new Product
            {
                Name = "Bosco",
                Price = 4.99m
            };
            order.AddOrderLineItem(bosco, 15);

            // Configure AutoMapper

            Mapper.CreateMap<Order, OrderDto>();

            // Perform mapping

            OrderDto dto = Mapper.Map<Order, OrderDto>(order);

            Assert.AreEqual("George Costanza", dto.CustomerName);
            Assert.AreEqual(74.85m, dto.Total);
        }

        internal class Order
        {
            private readonly IList<OrderLineItem> _orderLineItems = new List<OrderLineItem>();

            public Customer Customer { get; set; }

            public OrderLineItem[] GetOrderLineItems()
            {
                return _orderLineItems.ToArray();
            }

            public void AddOrderLineItem(Product product, int quantity)
            {
                _orderLineItems.Add(new OrderLineItem(product, quantity));
            }

            public decimal GetTotal()
            {
                return _orderLineItems.Sum(li => li.GetTotal());
            }
        }

        internal class Product
        {
            public decimal Price { get; set; }
            public string Name { get; set; }
        }

        internal class OrderLineItem
        {
            public OrderLineItem(Product product, int quantity)
            {
                Product = product;
                Quantity = quantity;
            }

            public Product Product { get; private set; }
            public int Quantity { get; private set; }

            public decimal GetTotal()
            {
                return Quantity * Product.Price;
            }
        }

        internal class Customer
        {
            public string Name { get; set; }
        }

        internal class OrderDto
        {
            public string CustomerName { get; set; }
            public decimal Total { get; set; }
        }


    }
}
