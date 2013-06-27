using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using TestStoreHost.MS.Models;
using TestStoreHost.MS.Services;

namespace TestStore
{

    public sealed class UpdateStatusActivity : CodeActivityBase
    {
        public InArgument<long> RequestId { get; set; }

        public InArgument<RequestStatus> Status { get; set; }

        public InArgument<bool> AllowUpdateId { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            var requestId = context.GetValue(this.RequestId);

            IRequestService requestService = GetObject<IRequestService>("RequestService");

            var request = requestService.GetById(requestId);

            if(request != null)
            {
                var status = context.GetValue(this.Status);
                request.Status = status;
                var allowUpdateId = context.GetValue(this.AllowUpdateId);
                if (allowUpdateId)
                {
                    request.WokflowId = context.WorkflowInstanceId;
                }
                requestService.Update(request);
            }

        }
    }
}
