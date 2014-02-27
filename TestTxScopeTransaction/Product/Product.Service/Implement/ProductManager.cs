using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Product.Dao;
using Product.Domain;
using Spring.Transaction.Interceptor;
using Product.Service.CustomerProxy;
using Product.Service.OrderProxy;

namespace Product.Service.Implement
{
    public class ProductManager : IProductManager
    {
        private IProductDao Dao { get; set; }

        [Transaction]
        public ProductInfo Get(object id)
        {
            return Dao.Get(id);
        }

        [Transaction]
        public object Save(ProductInfo entity)
        {
            return Dao.Save(entity);
        }

        [Transaction]
        public void Update(ProductInfo entity)
        {
            Dao.Update(entity);
        }
    }
}
