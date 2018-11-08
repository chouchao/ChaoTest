using Newtonsoft.Json;
using SFPConsole.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFPConsole.Gen
{
    public partial class Form1 : Form
    {
        string currentDir;
        string templatesDir;
        CommandItemInput[] inputGroup;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currentDir = Path.GetDirectoryName(this.GetType().Assembly.Location);
            comboBox1.Items.Add("");
            templatesDir = Path.Combine(currentDir, "templates");
            if (Directory.Exists(templatesDir))
            {
                foreach (var template in Directory.GetFiles(templatesDir))
                {
                    comboBox1.Items.Add(template);
                }
            }

            inputGroup = new CommandItemInput[]
            {
                commandItemInput1,
                commandItemInput2,
                commandItemInput3,
                commandItemInput4,
                commandItemInput5,
                commandItemInput6,
                commandItemInput7,
                commandItemInput8,
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var command = new SFPCommand()
            {
                Command = textBox1.Text,
                Data = new Dictionary<string, object>()
            };

            for (int i = 0; i < inputGroup.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(inputGroup[i].Label))
                {
                    command.Data.Add(inputGroup[i].Label, inputGroup[i].Value);
                }
            }

            var filename = Path.Combine(currentDir, Guid.NewGuid().ToString() + ".json");
            File.WriteAllText(filename, JsonConvert.SerializeObject(command), Encoding.UTF8);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                return;
            }
            var command = JsonConvert.DeserializeObject<SFPCommand>(File.ReadAllText(comboBox1.Text, Encoding.UTF8));
            textBox1.Text = command.Command;

            for (int i = 0; i < inputGroup.Length; i++)
            {
                inputGroup[i].Label = string.Empty;
                inputGroup[i].Value = string.Empty;
            }

            int j = 0;
            foreach (KeyValuePair<string,object> d in command.Data)
            {
                inputGroup[j].Label = d.Key;
                inputGroup[j].Value = (d.Value ?? string.Empty).ToString();
                j++;
            }
        }
    }
}
