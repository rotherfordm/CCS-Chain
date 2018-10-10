using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Miner
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(textBox1.Text, int.Parse(textBox2.Text));
            form1.Show();
            this.Hide();
        }

        //public string Ip()
        //{
        //    return textBox1.Text;
        //}

        //public int Port()
        //{
        //    return int.Parse(textBox2.Text);
        //}
    }
}
