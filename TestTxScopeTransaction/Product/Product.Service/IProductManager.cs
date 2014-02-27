using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Product.Domain;

namespace Product.Service
{
    public interface IProductManager
    {
        ProductInfo Get(object id);

        object Save(ProductInfo entity);

        void Update(ProductInfo entity);
    }
}
