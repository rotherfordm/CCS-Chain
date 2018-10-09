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
        public static string serverIpAdress;
        public static string serverPort;

        public Form2()
        {
            InitializeComponent();
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {


            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
