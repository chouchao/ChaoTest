using System;
using System.IO;
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
using System.Activities;
using System.Activities.XamlIntegration;

namespace WFHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            Encoding utf8 = Encoding.UTF8;

            byte[] bs = utf8.GetBytes(txtXaml.Text);

            var stream = new MemoryStream(bs);

            Activity activity = ActivityXamlServices.Load(stream);

            WorkflowApplication wfInstance = new WorkflowApplication(activity);

            wfInstance.Run();

        }
    }
}
