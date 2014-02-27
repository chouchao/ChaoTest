using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Order.Domain;

namespace Order.Host
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IOrderContract
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        OrderInfo Get(object id);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        object Save(OrderInfo entity);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void Update(OrderInfo entity);
    }
}
