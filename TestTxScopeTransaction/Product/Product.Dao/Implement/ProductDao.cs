using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Data.NHibernate.Generic.Support;
using Product.Domain;

namespace Product.Dao.Implement
{
    public class ProductDao : HibernateDaoSupport, IProductDao
    {
        public virtual object Save(ProductInfo entity)
        {
            return this.HibernateTemplate.Save(entity);
        }

        public virtual ProductInfo Get(object id)
        {
            return this.HibernateTemplate.Get<ProductInfo>(id);
        }


        public void Update(ProductInfo entity)
        {
            this.HibernateTemplate.Update(entity);
        }
    }
}
