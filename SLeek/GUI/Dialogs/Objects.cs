using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using libsecondlife;

namespace SLeek
{
    public partial class frmObjects : Form
    {
        private SleekInstance instance;
        private SecondLife client;

        private Dictionary<uint, ObjectsListItem> listItems = new Dictionary<uint,ObjectsListItem>();

        public frmObjects(SleekInstance instance)
        {
            InitializeComponent();

            this.instance = instance;
            client = this.instance.Client;
            
            client.Network.OnDisconnected += new NetworkManager.DisconnectedCallback(Network_OnDisconnected);

            btnPointAt.Text = (this.instance.State.IsPointing ? "Unpoint" : "Point At");
            btnSitOn.Text = (this.instance.State.IsSitting ? "Stand Up" : "Sit On");
        }

        private void AddObjectEvents()
        {
            client.Objects.OnNewPrim += new ObjectManager.NewPrimCallback(Objects_OnNewPrim);
            client.Objects.OnObjectKilled += new ObjectManager.KillObjectCallback(Objects_OnObjectKilled);
        }

        private void RemoveObjectEvents()
        {
            client.Objects.OnNewPrim -= new ObjectManager.NewPrimCallback(Objects_OnNewPrim);
            client.Objects.OnObjectKilled -= new ObjectManager.KillObjectCallback(Objects_OnObjectKilled);
        }

        private void Network_OnDisconnected(NetworkManager.DisconnectType reason, string message)
        {
            this.Close();
        }

        private void lbxPrims_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index < 0) return;

            ObjectsListItem itemToDraw = (ObjectsListItem)lbxPrims.Items[e.Index];
            Brush textBrush = null;
            Font boldFont = new Font(e.Font, FontStyle.Bold);
            Font regularFont = new Font(e.Font, FontStyle.Regular);

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                textBrush = new SolidBrush(Color.FromKnownColor(KnownColor.HighlightText));
            }
            else
            {
                textBrush = new SolidBrush(Color.FromKnownColor(KnownColor.ControlText));
            }

            string name;
            string description;

            if (string.IsNullOrEmpty(itemToDraw.Prim.PropertiesFamily.Name))
            {
                name = "...";
                description = "...";
            }
            else
            {
                name = itemToDraw.Prim.PropertiesFamily.Name;
                description = itemToDraw.Prim.PropertiesFamily.Description;
            }

            SizeF nameSize = e.Graphics.MeasureString(name, boldFont);
            float nameX = e.Bounds.Left + 4;
            float nameY = e.Bounds.Top + 2;

            e.Graphics.DrawString(name, boldFont, textBrush, nameX, nameY);
            e.Graphics.DrawString(description, regularFont, textBrush, nameX + nameSize.Width + 8, nameY);

            e.DrawFocusRectangle();

            boldFont.Dispose();
            regularFont.Dispose();
            textBrush.Dispose();
            boldFont = null;
            regularFont = null;
            textBrush = null;
        }

        private void AddAllObjects()
        {
            client.Network.CurrentSim.ObjectsPrimitives.ForEach(
                new Action<Primitive>(
                delegate(Primitive prim)
                {
                    if (prim.ParentID == 0) //root prims only
                    {
                        ObjectsListItem item = new ObjectsListItem(prim, client, lbxPrims);
                        listItems.Add(prim.LocalID, item);

                        item.PropertiesReceived += new EventHandler(item_PropertiesReceived);
                        item.RequestProperties();
                    }
                }
                ));
        }

        private void item_PropertiesReceived(object sender, EventArgs e)
        {
            lbxPrims.Items.Add(sender);
        }

        private void ResetObjects()
        {
            lbxPrims.Items.Clear();
            listItems.Clear();
            AddAllObjects();
        }

        private void frmObjects_Load(object sender, EventArgs e)
        {
            lbxPrims.BeginUpdate();

            AddAllObjects();
            AddObjectEvents();
        }

        //Separate thread
        private void Objects_OnNewPrim(Simulator simulator, Primitive prim, ulong regionHandle, ushort timeDilation)
        {
            if (prim.ParentID != 0) return;

            lock (listItems)
            {
                if (listItems.ContainsKey(prim.LocalID)) return;

                BeginInvoke(new MethodInvoker(delegate()
                {
                    ObjectsListItem item = new ObjectsListItem(prim, client, lbxPrims);
                    listItems.Add(prim.LocalID, item);

                    item.PropertiesReceived += new EventHandler(item_PropertiesReceived);
                    item.RequestProperties();
                }));
            }
        }

        //Separate thread
        private void Objects_OnObjectKilled(Simulator simulator, uint objectID)
        {
            lock (listItems)
            {
                if (!listItems.ContainsKey(objectID)) return;

                BeginInvoke(new MethodInvoker(delegate()
                {
                    ObjectsListItem item = listItems[objectID];
                    lbxPrims.Items.Remove(item);
                    listItems.Remove(objectID);
                }));
            }
        }

        private void lbxPrims_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbxInworld.Enabled = (lbxPrims.SelectedItem != null);
        }

        private void btnPointAt_Click(object sender, EventArgs e)
        {
            ObjectsListItem item = lbxPrims.SelectedItem as ObjectsListItem;
            if (item == null) return;

            if (btnPointAt.Text == "Point At")
            {
                instance.State.SetPointing(true, item.Prim.ID);
                btnPointAt.Text = "Unpoint";
            }
            else if (btnPointAt.Text == "Unpoint")
            {
                instance.State.SetPointing(false, item.Prim.ID);
                btnPointAt.Text = "Point At";
            }
        }

        private void btnSitOn_Click(object sender, EventArgs e)
        {
            ObjectsListItem item = lbxPrims.SelectedItem as ObjectsListItem;
            if (item == null) return;

            if (btnSitOn.Text == "Sit On")
            {
                instance.State.SetSitting(true, item.Prim.ID);
                btnSitOn.Text = "Stand Up";
            }
            else if (btnSitOn.Text == "Stand Up")
            {
                instance.State.SetSitting(false, item.Prim.ID);
                btnSitOn.Text = "Sit On";
            }
        }

        private void btnTouch_Click(object sender, EventArgs e)
        {
            ObjectsListItem item = lbxPrims.SelectedItem as ObjectsListItem;
            if (item == null) return;

            client.Self.Touch(item.Prim.LocalID);
        }

        private void frmObjects_FormClosing(object sender, FormClosingEventArgs e)
        {
            RemoveObjectEvents();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim();

            if (query.Length == 0)
            {
                lbxPrims.BeginUpdate();

                RemoveObjectEvents();
                ResetObjects();
                AddObjectEvents();

                lbxPrims.EndUpdate();
            }
            else
            {
                SearchFor(query);
            }
        }

        private void SearchFor(string text)
        {
            RemoveObjectEvents();

            lbxPrims.BeginUpdate();
            lbxPrims.Items.Clear();
            listItems.Clear();

            string query = text.ToLower();

            List<Primitive> results =
                client.Network.CurrentSim.ObjectsPrimitives.FindAll(
                new Predicate<Primitive>(delegate(Primitive prim)
                {
                    //evil comparison of death!
                    return (prim.ParentID == 0 && prim.PropertiesFamily.Name != null) &&
                        (prim.PropertiesFamily.Name.ToLower().Contains(query) ||
                        prim.PropertiesFamily.Description.ToLower().Contains(query));
                }));

            lock (listItems)
            {
                foreach (Primitive prim in results)
                {
                    ObjectsListItem item = new ObjectsListItem(prim, client, lbxPrims);
                    listItems.Add(prim.LocalID, item);
                    lbxPrims.Items.Add(item);
                }
            }

            lbxPrims.EndUpdate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            lblStatus.Visible = false;
            lbxPrims.EndUpdate();
            lbxPrims.Visible = true;
            txtSearch.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Select();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}