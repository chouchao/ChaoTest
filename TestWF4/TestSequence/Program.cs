using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace TestSequence
{

    class Program
    {
        static void Main(string[] args)
        {
            //WorkflowInvoker.Invoke(new Workflow1());

            UseCode();
        }

        static void UseCode()
        {
            Sequence container = new Sequence();

            WriteLine wla = new WriteLine() { Text = new InArgument<string>("a_c") };
            WriteLine wlb = new WriteLine() { Text = new InArgument<string>("b_c") };
            WriteLine wlc = new WriteLine() { Text = new InArgument<string>("c_c") };

            container.Activities.Add(wla);
            container.Activities.Add(wlb);
            container.Activities.Add(wlc);

            WorkflowInvoker.Invoke(container);
        }
    }
}
