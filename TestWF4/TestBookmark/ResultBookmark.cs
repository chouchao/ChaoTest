using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestBookmark
{
    public class ResultBookmark<T> : NativeActivity<T>
    {
        public InArgument<string> Name { get; set; }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        protected override void Execute(NativeActivityContext context)
        {
            var name = context.GetValue(Name);

            context.CreateBookmark(name, new BookmarkCallback(bookmarkCallback));

            Console.WriteLine("CreateBookmark {0}", name);
        }

        private void bookmarkCallback(NativeActivityContext context, Bookmark bookmark, object value)
        {
            this.Result.Set(context, (T)value);
        }
    }
}
