using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SLNetworkComm;
using libsecondlife;

namespace SLeek
{
    public partial class InventoryScriptConsole : UserControl
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;
        private InventoryItem item;

        public InventoryScriptConsole(SleekInstance instance, InventoryItem item)
        {
            InitializeComponent();

            this.instance = instance;
            netcom = this.instance.Netcom;
            client = this.instance.Client;
            this.item = item;
        }

        private void btnEditScript_Click(object sender, EventArgs e)
        {
            (new frmScriptEditor(instance, item)).Show();
        }
    }
}
