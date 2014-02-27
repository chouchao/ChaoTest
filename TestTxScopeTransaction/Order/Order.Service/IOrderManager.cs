using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Order.Domain;

namespace Order.Service
{
    public interface IOrderManager
    {
        OrderInfo Get(object id);

        object Save(OrderInfo entity);

        void Update(OrderInfo entity);
    }
}
