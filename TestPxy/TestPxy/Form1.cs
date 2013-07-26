using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TestPxy
{
    public partial class Form1 : Form
    {
        private object lockTestIndex = new object();
        private object lockTestCount = new object();
        private object lockThreadCount = new object();

        private int TestIndex = -1;
        private int TestCount = 0;
        private int ThreadCount = 0;

        private List<Pxy> pxyList = new List<Pxy>();

        private string url = "";

        private string vstr = "";

        private string enco = "";

        private bool IsStop = true;

        private Regex regIPPort = new Regex(
        @"[\s]*?(?<ip>[\d]{1,3}\.[\d]{1,3}\.[\d]{1,3}\.[\d]{1,3})[\s]*?:[\s]*?(?<port>[\d]{2,5})",
        RegexOptions.Compiled);

        public Form1()
        {
            InitializeComponent();
        }

        private string GetHttpPage(string url, string encode, Pxy pxy)
        {
            string result;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Proxy = new WebProxy(pxy.Ip, int.Parse(pxy.Port));
                CookieContainer cookieContainer = new CookieContainer();
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.Timeout = 5000;
                Stream responseStream = httpWebRequest.GetResponse().GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding(encode));
                result = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppendLog("read list file.");
            var ps = File.ReadAllLines("p.txt");
            pxyList.Clear();
            for (int i = 0; i < ps.Length; i++)
            {
                var pm = regIPPort.Match(ps[i]);
                if (pm.Success)
                {
                    pxyList.Add(
                        new Pxy()
                        {
                            Ip = pm.Groups["ip"].Value,
                            Port = pm.Groups["port"].Value
                        }
                    );
                }
            }

            url = textBox1.Text;
            vstr = textBox2.Text;
            enco = txtEncoding.Text;

            IsStop = false;

            AppendLog("start test.");

            var userThreadCount = int.Parse(txtThreadCount.Text);

            Thread[] ts = new Thread[userThreadCount];

            for (int i = 0; i < ts.Length; i++)
            {
                ts[i] = new Thread(new ThreadStart(TestProxy));
                ts[i].Name = "t" + i;
                ts[i].Start();
            }
        }

        private void TestProxy()
        {
            lock (lockThreadCount)
            {
                ThreadCount++;
                SetThreadCountLabel(ThreadCount);
            }

            Pxy pxy;
            while (!IsStop)
            {
                lock (lockTestIndex)
                {
                    TestIndex++;
                    if (TestIndex >= pxyList.Count)
                    {
                        break;
                    }

                    pxy = pxyList[TestIndex];
                }

                Stopwatch sw = new Stopwatch();

                sw.Start();
                var html = GetHttpPage(url, enco, pxy);
                sw.Stop();

                if (html != null && html.Contains(vstr))
                {
                    pxy.Success = true;

                    AppendLog(String.Format("[sucess] {0} : {1} {2}ms", pxy.Ip, pxy.Port, sw.ElapsedMilliseconds));
                }

                lock (lockTestCount)
                {
                    TestCount++;
                    AppendLog(String.Format("{0}/{1}", TestCount, pxyList.Count));
                }
            }

            AppendLog(String.Format("{0} stoping...", Thread.CurrentThread.Name));
            lock (lockThreadCount)
            {
                ThreadCount--;
                SetThreadCountLabel(ThreadCount);
            }
            Thread.CurrentThread.Abort();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IsStop = true;
        }

        private void AppendLog(string log)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendLog), log);
            }
            else
            {
                textBox3.AppendText(String.Format("[{0:HH:mm:ss}] {1}\r\n", DateTime.Now, log));
            }
        }

        private void SetThreadCountLabel(int tcount)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int>(SetThreadCountLabel), tcount);
            }
            else
            {
                lblThreadCount.Text = tcount.ToString();
            }
        }
    }

    class Pxy
    {
        public string Ip { get; set; }

        public string Port { get; set; }

        public bool Success { get; set; }
    }
}
