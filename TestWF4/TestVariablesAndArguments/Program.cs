using System;
using System.Collections.Generic;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace TestVariablesAndArguments
{

    class Program
    {
        static void Main(string[] args)
        {
            WorkflowInvoker.Invoke(new OutChangeWorkflow());
        }
    }
}
