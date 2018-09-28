using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SimpleWifi;
using System;
using System.Text;
using SimpleWifi.Win32;
using SimpleWifi.Win32.Interop;

namespace WifiForms
{
    public partial class Form1 : Form
    {

        public static Wifi wifi;
      
        public Form1()
        {
            InitializeComponent();
            wifi = new Wifi();
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    loadWifi();
        //   // wifi.;
        //}
        //private AccessPoint ac;
        //private void button1_Click(object sender, System.EventArgs e)
        //{
        //    if (listView1.SelectedItems.Count > 0 && textBox1.Text.Length > 0)
        //    {
        //        ListViewItem selecteditem = listView1.SelectedItems[0];
        //        AccessPoint ap = (AccessPoint)selecteditem.Tag;
        //        ac = ap;
        //        if (ConnectWifi(ap, textBox1.Text))
        //        {
        //            label1.Text = "Connect Success!" + ap.Name + " " ;
        //            textBox1.Focus();
                  
        //        }
        //        else
        //        {
        //            label1.Text = "Connect Failed!";
        //            textBox1.Focus();
        //        }   

        //    }
        //    else
        //    {

        //        label1.Text = "Please select a network or Input the wifi password.";
        //        textBox1.Focus();
        //    }
        //    textBox1.Text = null;
        //}

        private bool ConnectWifi(AccessPoint ap,string passwrod)
        {
            AuthRequest autherequest = new AuthRequest(ap);
            autherequest.Password = passwrod;

            return ap.Connect(autherequest);
        }
     
     
        private void timer1_Tick(object sender, System.EventArgs e)
        {

            if (wifi.ConnectionStatus == WifiStatus.Connected)
            {
                lblSignal.Text = GetSignal().ToString();
            }
            else
            { lblSignal.Text =null; }
        }


        private int GetSignal()
        {
          AccessPoint aplist = wifi.GetAccessPoints().Find(x => x.Name == "Hovid Inc");
          return  int.Parse(aplist.SignalStrength.ToString());
        
        }


        private void button2_Click(object sender, System.EventArgs e)
        {
          
            AccessPoint aplist = wifi.GetAccessPoints().Find(x => x.Name == "Hovid Inc");
            if (ConnectWifi(aplist, textBox1.Text))
            {
                label1.Text = "Connect Success!" + aplist.Name + " ";
                textBox1.Focus();

            }
            else
            {
                label1.Text = "Connect Failed!";
                textBox1.Focus();
            }   
        }
    }
}
