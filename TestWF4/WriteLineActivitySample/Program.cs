using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace WriteLineActivitySample
{

    class Program
    {
        static void Main(string[] args)
        {
            WriteLine cwActivity = new WriteLine();
            InArgument<string> inArgument = new InArgument<string>(getValue("WF2"));
            cwActivity.Text = inArgument;

            //WorkflowInvoker.Invoke(new Workflow1());
            WorkflowInvoker.Invoke(cwActivity);
        }

        static string getValue(string p)
        {
            return "WF1:" + p;
        }
    }
}
