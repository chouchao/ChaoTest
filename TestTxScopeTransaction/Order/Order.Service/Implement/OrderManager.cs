using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Order.Domain;
using Order.Dao;

namespace Order.Service.Implement
{
    public class OrderManager : IOrderManager
    {
        public IOrderDao Dao { get; set; }

        public OrderInfo Get(object id)
        {
            return Dao.Get(id);
        }

        public object Save(OrderInfo entity)
        {
            return Dao.Save(entity);
        }

        public void Update(OrderInfo entity)
        {
            Dao.Update(entity);
        }
    }
}
