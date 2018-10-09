using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aeternum_Faucet
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string Ip()
        {
            return txtIp.Text;
        }

        public int Port()
        {
            return int.Parse(txtPort.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(txtIp.Text, int.Parse(txtPort.Text));
            form1.Show();
            this.Hide();
        }
    }
}
