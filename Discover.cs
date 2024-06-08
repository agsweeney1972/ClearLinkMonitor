using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace WinUI_ClearCore
{
    public partial class Discover : Form
    {
        public Discover()
        {
            InitializeComponent();
            



        }

        private void Discover_Load(object sender, EventArgs e)
        {

            Sres.Net.EEIP.EEIPClient eipClient = new Sres.Net.EEIP.EEIPClient();


            List<Sres.Net.EEIP.Encapsulation.CIPIdentityItem> cipIdentityItem = eipClient.ListIdentity();

            for (int i = 0; i < cipIdentityItem.Count; i++)
            {




                listBox1.Items.Add("Ethernet/IP Device Found: " + cipIdentityItem[i].ProductName1);
                listBox1.Items.Add("IP-Address: " + Sres.Net.EEIP.Encapsulation.CIPIdentityItem.getIPAddress(cipIdentityItem[i].SocketAddress.SIN_Address));
                listBox1.Items.Add("Port: " + cipIdentityItem[i].SocketAddress.SIN_port);
                listBox1.Items.Add("Vendor ID: " + cipIdentityItem[i].VendorID1);
                listBox1.Items.Add("Product-code: " + cipIdentityItem[i].ProductCode1);
                listBox1.Items.Add("Type-Code: " + cipIdentityItem[i].ItemTypeCode);
                listBox1.Items.Add("Serial Number: " + cipIdentityItem[i].SerialNumber1);
                listBox1.Items.Add("---");


            }

        }


    }
}
