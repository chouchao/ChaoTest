namespace TestPxy
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblThreadCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.txtEncoding = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "http://www.qq.com";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(132, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "soso";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 77);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(274, 310);
            this.textBox3.TabIndex = 4;
            // 
            // lblThreadCount
            // 
            this.lblThreadCount.AutoSize = true;
            this.lblThreadCount.Location = new System.Drawing.Point(194, 43);
            this.lblThreadCount.Name = "lblThreadCount";
            this.lblThreadCount.Size = new System.Drawing.Size(13, 13);
            this.lblThreadCount.TabIndex = 5;
            this.lblThreadCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "/";
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Location = new System.Drawing.Point(238, 40);
            this.txtThreadCount.Name = "txtThreadCount";
            this.txtThreadCount.Size = new System.Drawing.Size(35, 20);
            this.txtThreadCount.TabIndex = 7;
            this.txtThreadCount.Text = "50";
            // 
            // txtEncoding
            // 
            this.txtEncoding.Location = new System.Drawing.Point(239, 13);
            this.txtEncoding.Name = "txtEncoding";
            this.txtEncoding.Size = new System.Drawing.Size(47, 20);
            this.txtEncoding.TabIndex = 8;
            this.txtEncoding.Text = "utf-8";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 399);
            this.Controls.Add(this.txtEncoding);
            this.Controls.Add(this.txtThreadCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblThreadCount);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "TestPxy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblThreadCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtThreadCount;
        private System.Windows.Forms.TextBox txtEncoding;
    }
}

