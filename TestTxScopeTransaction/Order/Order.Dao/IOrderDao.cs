using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Order.Domain;

namespace Order.Dao
{
    public interface IOrderDao
    {
        OrderInfo Get(object id);

        object Save(OrderInfo entity);

        void Update(OrderInfo entity);
    }
}
