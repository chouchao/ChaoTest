using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Customer.Dao;
using Customer.Domain;

namespace Customer.Service.Implement
{
    public class CustomerManager : ICustomerManager
    {
        private ICustomerDao Dao { get; set; }

        public CustomerInfo Get(object id)
        {
            return Dao.Get(id);
        }

        public object Save(CustomerInfo entity)
        {
            return Dao.Save(entity);
        }

        public void Update(CustomerInfo entity)
        {
            if (entity.Money > 3000)
            {
                throw new Exception("订金上限");
            }
            Dao.Update(entity);
        }
    }
}
