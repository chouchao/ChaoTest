using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Customer.Domain;

namespace Customer.Host
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ICustomerContract
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        CustomerInfo Get(object id);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        object Save(CustomerInfo entity);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void Update(CustomerInfo entity);
    }
}
