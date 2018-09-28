using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WifiForms
{
    public partial class Test : Form
    {
        private static WifiConfig wifi;
        public Test()
        {
            InitializeComponent();
            wifi = new WifiConfig();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            wifi.AccessPointName = "Hovid Inc";
            wifi.Password = "TH69P161FC";


            label1.Text = wifi.ConnectWifi().ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            wifi.AccessPointName = "Hovid Inc";
            label2.Text = wifi.GetSignal().ToString();
        }
    }
}
