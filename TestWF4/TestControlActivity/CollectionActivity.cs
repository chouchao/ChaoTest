using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace TestControlActivity
{
    public class CollectionActivity : CodeActivity
    {
        public OutArgument<List<string>> OutList { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var list = new List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            list.Add("d");
            list.Add("e");
            context.SetValue(OutList, list);
        }
    }
}
