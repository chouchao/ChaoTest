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

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                button1.Enabled = false;
                Application.DoEvents();
                textBox3.Text = await SendPost(txtUrl.Text, txtData.Text);
                button1.Enabled = true;
            }
        }

        private async Task<string> SendPost(string url, string data)
        {
            try
            {
                SetTLS();

                HttpClient client = new HttpClient();

                // url和post
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Post,
                };

                SetHeaders(request);
                SetContent(data, request);

                var response = await client.SendAsync(request);

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        private void SetTLS()
        {
            // TLS 1.2
            if (checkBox1.Checked)
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            }
        }

        private static void SetContent(string data, HttpRequestMessage request)
        {
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
            request.Content = new FormUrlEncodedContent(formData);
        }

        private void SetHeaders(HttpRequestMessage request)
        {
            var headers = txtHeaders.Lines;
            foreach (var header in headers)
            {
                var headerKV = header.Split(':');
                request.Headers.Add(headerKV[0], headerKV[1]);
            }
        }
    }
}
