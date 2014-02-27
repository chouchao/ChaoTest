using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Data.NHibernate.Generic.Support;
using Order.Domain;

namespace Order.Dao.Implement
{
    public class OrderDao : HibernateDaoSupport, IOrderDao
    {
        public virtual object Save(OrderInfo entity)
        {
            return this.HibernateTemplate.Save(entity);
        }

        public virtual OrderInfo Get(object id)
        {
            return this.HibernateTemplate.Get<OrderInfo>(id);
        }


        public void Update(OrderInfo entity)
        {
            this.HibernateTemplate.Update(entity);
        }
    }
}
