using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace TestVariablesAndArguments
{
    public class InChangeActivity : CodeActivity
    {
        public InArgument<string> MyIn { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var s1 = context.GetValue(MyIn);

            Console.WriteLine(s1);

            context.SetValue(MyIn, "sssss");

            var s2 = context.GetValue(MyIn);

            Console.WriteLine(s2);
        }
    }
}
