using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Data.NHibernate.Generic.Support;
using Customer.Domain;

namespace Customer.Dao.Implement
{
    public class CustomerDao : HibernateDaoSupport, ICustomerDao
    {
        public virtual object Save(CustomerInfo entity)
        {
            return this.HibernateTemplate.Save(entity);
        }

        public virtual CustomerInfo Get(object id)
        {
            return this.HibernateTemplate.Get<CustomerInfo>(id);
        }


        public void Update(CustomerInfo entity)
        {
            this.HibernateTemplate.Update(entity);
        }
    }
}
