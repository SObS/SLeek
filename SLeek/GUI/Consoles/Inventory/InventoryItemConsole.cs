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
    public partial class InventoryItemConsole : UserControl
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;
        private InventoryItem item;

        public InventoryItemConsole(SleekInstance instance, InventoryItem item)
        {
            InitializeComponent();

            this.instance = instance;
            netcom = this.instance.Netcom;
            client = this.instance.Client;
            this.item = item;
            
            this.Disposed += new EventHandler(InventoryItemConsole_Disposed);

            AddClientEvents();
            FillItemProperties();
        }

        private void InventoryItemConsole_Disposed(object sender, EventArgs e)
        {
            CleanUp();
        }

        public void CleanUp()
        {
            client.Avatars.OnAvatarNames -= new AvatarManager.AvatarNamesCallback(Avatars_OnAvatarNames);
        }

        private void AddClientEvents()
        {
            client.Avatars.OnAvatarNames += new AvatarManager.AvatarNamesCallback(Avatars_OnAvatarNames);
        }

        //comes up in a separate thread
        private void Avatars_OnAvatarNames(Dictionary<LLUUID, string> names)
        {
            //using parent to invoke for avoiding race condition between this event and whether this control is disposed
            this.Parent.BeginInvoke(
                new AvatarManager.AvatarNamesCallback(CreatorOwnerReceived),
                new object[] { names });
        }

        //runs on the GUI thread
        private void CreatorOwnerReceived(Dictionary<LLUUID, string> names)
        {
            foreach (KeyValuePair<LLUUID, string> kvp in names)
            {
                if (kvp.Key == item.CreatorID)
                    txtItemCreator.Text = kvp.Value;
                else if (kvp.Key == item.OwnerID)
                    txtItemOwner.Text = kvp.Value;
            }

            if (item.CreatorID == item.OwnerID) txtItemOwner.Text = txtItemCreator.Text;
        }

        private void FillItemProperties()
        {
            txtItemName.Text = item.Name;
            txtItemCreator.Text = txtItemOwner.Text = "Retreiving name...";
            txtItemDescription.Text = item.Description;

            List<LLUUID> avIDs = new List<LLUUID>();
            avIDs.Add(item.CreatorID);
            avIDs.Add(item.OwnerID);
            client.Avatars.RequestAvatarNames(avIDs);

            switch (item.InventoryType)
            {
                case InventoryType.Object:
                    InventoryObjectConsole objectConsole = new InventoryObjectConsole(instance, item);
                    objectConsole.Dock = DockStyle.Fill;
                    pnlItemTypeProp.Controls.Add(objectConsole);
                    break;

                case InventoryType.Notecard:
                    InventoryNotecardConsole notecardConsole = new InventoryNotecardConsole(instance, item);
                    notecardConsole.Dock = DockStyle.Fill;
                    pnlItemTypeProp.Controls.Add(notecardConsole);
                    break;

                case InventoryType.LSL:
                    InventoryScriptConsole scriptConsole = new InventoryScriptConsole(instance, item);
                    scriptConsole.Dock = DockStyle.Fill;
                    pnlItemTypeProp.Controls.Add(scriptConsole);
                    break;

                case InventoryType.Snapshot:
                case InventoryType.Texture:
                    InventoryImageConsole imageConsole = new InventoryImageConsole(instance, item);
                    imageConsole.Dock = DockStyle.Fill;
                    pnlItemTypeProp.Controls.Add(imageConsole);
                    break;
            }
        }
    }
}
