using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Customer.Domain;
using Customer.Service;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Transactions;

namespace Customer.Host.Implement
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class CustomerServer : ICustomerContract
    {
        public ICustomerManager Manager { get; set; }

        [OperationBehavior(TransactionScopeRequired = true)]
        public CustomerInfo Get(object id)
        {
            return Manager.Get(id);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public object Save(CustomerInfo entity)
        {

            return Manager.Save(entity);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void Update(CustomerInfo entity)
        {
            Manager.Update(entity);
        }
    }
}