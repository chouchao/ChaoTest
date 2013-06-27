using System;
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
using System.IO;
using System.Reflection;

namespace TestSerialize
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

        private string GetNextName(Random rnd)
        {
            string result = String.Empty;
            for (int i = 0; i < rnd.Next(5, 10); i++)
            {
                result += ((char)(97 + rnd.Next(0, 25))).ToString();
            }
            return result;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Assembly a = Assembly.Load("TestSerialize.Models");
            Type t = a.GetType("TestSerialize.Models.BookService");
            dynamic bookService = a.CreateInstance(t.FullName);

            //Random rnd = new Random();
            //var list = new List<Book>();
            //for (int i = 0; i < 20; i++)
            //{
            //    list.Add(new Book()
            //    {
            //        Id = i,
            //        Name = GetNextName(rnd),
            //        Price = (decimal)(rnd.Next(1, 100) * rnd.NextDouble()),
            //        IsNew = i > 8,
            //        Url = "http://www.google.com.hk/#newwindow=1&safe=strict&site=&source=hp&q=c%23+xml+serialization&oq=c%23+xml+&gs_l=hp.1.1.0i19l10.1128.4369.0.6549.7.6.0.1.1.0.186.837.0j6.6.0...0.0.0..1c.1.17.hp.MX6XD-ybolM&bav=on.2,or.&bvm=bv.48340889,d.aGc&fp=3845a69d6d424846&biw=1280&bih=675"
            //    });
            //}

            var xml = XmlSerializer.Serialize(bookService.GetAll());
            File.WriteAllText("books.xml", xml, Encoding.UTF8);

            MessageBox.Show("Ok");
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //var xml = File.ReadAllText("books.xml", Encoding.UTF8);
            //var list = XmlSerializer.Deserialize<List<Book>>(xml);
            //MessageBox.Show(list.Count.ToString());
        }
    }
}
