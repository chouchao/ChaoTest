using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Order.Domain;
using Order.Service;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Order.Host.Implement
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class OrderServer : IOrderContract
    {
        public IOrderManager Manager { get; set; }

        [OperationBehavior(TransactionScopeRequired = true)]
        public OrderInfo Get(object id)
        {
            return Manager.Get(id);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public object Save(OrderInfo entity)
        {

            return Manager.Save(entity);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void Update(OrderInfo entity)
        {
            Manager.Update(entity);
        }
    }
}