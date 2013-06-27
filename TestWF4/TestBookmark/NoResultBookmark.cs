using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestBookmark
{
    public class NoResultBookmark : NativeActivity
    {
        public InArgument<string> Name { get; set; }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }


        protected override void Execute(NativeActivityContext context)
        {
            var name = context.GetValue(Name);

            context.CreateBookmark(name);

            Console.WriteLine("CreateBookmark {0}", name);
        }
    }
}
