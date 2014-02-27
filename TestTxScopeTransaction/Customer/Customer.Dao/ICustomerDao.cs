using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Customer.Domain;

namespace Customer.Dao
{
    public interface ICustomerDao
    {
        CustomerInfo Get(object id);

        object Save(CustomerInfo entity);

        void Update(CustomerInfo entity);
    }
}
