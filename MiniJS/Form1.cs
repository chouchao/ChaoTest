using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniJS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                var js = File.ReadAllText(textBox1.Text, Encoding.UTF8);
                textBox3.Text = string.Empty;
                Application.DoEvents();
                try
                {
                    Minifier minifier = new Minifier();
                    string content = minifier.MinifyJavaScript(js, new CodeSettings
                    {
                        EvalTreatment = EvalTreatment.MakeImmediateSafe,
                        PreserveImportantComments = false
                    });
                    if (minifier.ErrorList.Count > 0)
                    {
                        textBox2.Text = "Error list:\r\n";
                        foreach (var err in minifier.ErrorList)
                        {
                            textBox2.AppendText(err.ToString());
                        }
                    }
                    else
                    {
                        textBox2.Text = "No error";
                        if (checkBox1.Checked)
                        {
                            textBox3.Text = content;
                        }
                    }
                }
                catch (Exception ex)
                {
                    textBox2.Text = ex.ToString();
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }
    }
}
