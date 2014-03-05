using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Product2.Domain;

namespace Product2.Dao
{
    public interface IProduct2Dao
    {
        Product2Info Get(object id);

        object Save(Product2Info entity);

        void Update(Product2Info entity);
    }
}
