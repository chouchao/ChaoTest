using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace TestVariablesAndArguments
{
    public class OutChangeActivity : CodeActivity
    {
        public OutArgument<string> MyOut { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var s1 = context.GetValue(MyOut);

            Console.WriteLine("内部 传入 {0}", s1);

            context.SetValue(MyOut, "out 33");

            var s2 = context.GetValue(MyOut);

            Console.WriteLine("内部 更改 {0}", s2);
        }
    }
}
