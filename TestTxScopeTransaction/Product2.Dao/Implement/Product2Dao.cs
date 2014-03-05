using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Data.NHibernate.Generic.Support;
using Product2.Domain;

namespace Product2.Dao.Implement
{
    public class Product2Dao : HibernateDaoSupport, IProduct2Dao
    {
        public virtual object Save(Product2Info entity)
        {
            return this.HibernateTemplate.Save(entity);
        }

        public virtual Product2Info Get(object id)
        {
            return this.HibernateTemplate.Get<Product2Info>(id);
        }


        public void Update(Product2Info entity)
        {
            this.HibernateTemplate.Update(entity);
        }
    }
}
