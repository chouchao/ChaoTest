using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Product.Domain;

namespace Product.Dao
{
    public interface IProductDao
    {
        ProductInfo Get(object id);

        object Save(ProductInfo entity);

        void Update(ProductInfo entity);
    }
}
