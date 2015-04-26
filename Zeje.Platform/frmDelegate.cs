using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeje.Platform
{
    public partial class frmDelegate : Form
    {
        public delegate void WriteTextBox(char ch);
        public WriteTextBox writeTextBox;
        public frmDelegate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Clear();
                textBox1.Refresh();
                // 实例化委托
                writeTextBox = new WriteTextBox(WriteTextBox1);
                // 作为参数
                WriteText(writeTextBox);

                textBox3.Focus();
                textBox3.SelectAll();
            }
            if (checkBox2.Checked == true)
            {
                textBox2.Clear();
                textBox2.Refresh();
                // 实例化委托
                writeTextBox = new WriteTextBox(WriteTextBox2);
                // 作为参数
                WriteText(writeTextBox);

                textBox3.Focus();
                textBox3.SelectAll();
            }
        }


        private void WriteText(WriteTextBox writetextbox)
        {
            string data = textBox3.Text;
            for (int i = 0; i < data.Length; i++)
            {
                // 使用委托
                writetextbox(data[i]);
                DateTime now = DateTime.Now;
                while (now.AddSeconds(1) > DateTime.Now)
                { }
            }
        }

        private void WriteTextBox1(char ch)
        {
            textBox1.AppendText(ch.ToString());
        }
        private void WriteTextBox2(char ch)
        {
            textBox2.AppendText(ch.ToString());
        }

    }
}
