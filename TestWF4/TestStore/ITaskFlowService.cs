using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStoreHost.MS.Models;

namespace TestStore
{
    public interface ITaskFlowService
    {
        void Create(Request request);

        void RunInstance(Request request, string bookmark);
    }
}
