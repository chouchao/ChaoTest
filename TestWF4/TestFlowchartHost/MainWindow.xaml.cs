using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestFlowchart;

namespace TestFlowchartHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WorkflowApplication instance;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            instance = new WorkflowApplication(new ResultBookmarkWorkflow());
            instance.Completed = instance_Completed;
            instance.OnUnhandledException = instance_UnhandledException;
            instance.Aborted = instance_Aborted;
            instance.Idle = instance_Idle;
            instance.Run();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string bookName = "after_input";
            string inputValue = textBox1.Text;

            if (instance != null)
            {

                if (instance.GetBookmarks().Count(p => p.BookmarkName == bookName) == 1)
                {
                    instance.ResumeBookmark(bookName, inputValue);
                }
            }

            else
            {
                MessageBox.Show("没有创建实例");
            }
        }

        private void instance_Completed(WorkflowApplicationCompletedEventArgs e)
        {
            instance = null;
            Console.WriteLine("workflow completed {0}", e.CompletionState);
        }

        private UnhandledExceptionAction instance_UnhandledException(WorkflowApplicationUnhandledExceptionEventArgs e)
        {
            System.Console.WriteLine("unhandledException:{0}", e.UnhandledException.Message);
            return UnhandledExceptionAction.Cancel;
        }

        private void instance_Aborted(WorkflowApplicationAbortedEventArgs e)
        {
            instance = null;
            System.Console.WriteLine("aborted ,Reason:{0}", e.Reason.Message);
        }

        private void instance_Idle(WorkflowApplicationIdleEventArgs e)
        {
            Console.WriteLine("Idle:{0}", e.InstanceId);

            Console.WriteLine("-- start bookmarks --");
            foreach (var bm in e.Bookmarks)
            {
                Console.WriteLine(bm.BookmarkName);
            }
            Console.WriteLine("-- end bookmarks --");
        }
    }
}
