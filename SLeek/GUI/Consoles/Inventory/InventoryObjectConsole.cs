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
    public partial class InventoryObjectConsole : UserControl
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;
        private InventoryItem item;

        public InventoryObjectConsole(SleekInstance instance, InventoryItem item)
        {
            InitializeComponent();

            this.instance = instance;
            netcom = this.instance.Netcom;
            client = this.instance.Client;
            this.item = item;
        }

        private void btnRezObject_Click(object sender, EventArgs e)
        {
            client.Inventory.RequestRezFromInventory(
                client.Network.CurrentSim, LLQuaternion.Identity, client.Self.SimPosition, (InventoryObject)item);
        }
    }
}
