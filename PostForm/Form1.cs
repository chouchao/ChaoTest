using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                button1.Enabled = false;
                Application.DoEvents();
                textBox3.Text = SendPost(textBox1.Text, textBox2.Text);
                button1.Enabled = true;
            }
        }

        private string SendPost(string url, string data)
        {
            try
            {
                if (checkBox1.Checked)
                {
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                }

                HttpClient client = new HttpClient();
                Dictionary<string, string> formData = new Dictionary<string, string>();
                if (!string.IsNullOrWhiteSpace(data))
                {
                    data.Split('&').ToList().ForEach(param =>
                    {
                        var key = param.Split('=')[0];
                        var value = param.Split('=')[1];
                        formData.Add(key, value);
                    });
                }
                return client.PostAsync(url, new FormUrlEncodedContent(formData)).Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
