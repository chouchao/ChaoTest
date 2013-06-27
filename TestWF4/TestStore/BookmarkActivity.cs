using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace TestStore
{

    public sealed class BookmarkActivity<T> : NativeActivity<T>
    {
        protected override bool CanInduceIdle { get { return true; } }

        public string BookmarkName { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(BookmarkName,
                new BookmarkCallback(this.Continue));
        }

        private void Continue(NativeActivityContext context, Bookmark bookmark,
            object obj)
        {
            context.SetValue(this.Result, (T)obj);
        }
    }
}
