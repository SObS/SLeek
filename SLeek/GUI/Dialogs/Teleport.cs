using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using libsecondlife;
using libsecondlife.Packets;
using SLNetworkComm;

namespace SLeek
{
    public partial class frmTeleport : Form
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;

        public frmTeleport(SleekInstance instance)
        {
            InitializeComponent();

            this.instance = instance;
            netcom = this.instance.Netcom;
            client = this.instance.Client;

            AddNetcomEvents();
            AddClientEvents();
            SetDefaultValues();
        }

        private void AddNetcomEvents()
        {
            netcom.Teleporting += new EventHandler<TeleportingEventArgs>(netcom_Teleporting);
            netcom.TeleportStatusChanged += new EventHandler<TeleportStatusEventArgs>(netcom_TeleportStatusChanged);
            netcom.ClientDisconnected += new EventHandler<ClientDisconnectEventArgs>(netcom_ClientDisconnected);
        }

        private void AddClientEvents()
        {
            client.Grid.OnGridRegion += new GridManager.GridRegionCallback(Grid_OnGridRegion);
        }

        private void RemoveClientEvents()
        {
            client.Grid.OnGridRegion -= new GridManager.GridRegionCallback(Grid_OnGridRegion);
        }

        //Separate thread
        private void Grid_OnGridRegion(GridRegion region)
        {
            BeginInvoke(new GridManager.GridRegionCallback(RegionSearchResult), new object[] { region });
        }

        //UI thread
        private void RegionSearchResult(GridRegion region)
        {
            RegionSearchResultItem item = new RegionSearchResultItem(instance, region, lbxRegionSearch);
            int index = lbxRegionSearch.Items.Add(item);
            item.ListIndex = index;
        }

        private void SetDefaultValues()
        {
            string region = client.Network.CurrentSim.Name;
            decimal x = (decimal)client.Self.SimPosition.X;
            decimal y = (decimal)client.Self.SimPosition.Y;
            decimal z = (decimal)client.Self.SimPosition.Z;

            if (x < 0) x = 0;
            if (x > 256) x = 256;
            if (y < 0) y = 0;
            if (y > 256) y = 256;

            txtRegion.Text = region;
            nudX.Value = x;
            nudY.Value = y;
            nudZ.Value = z;
        }

        private void netcom_TeleportStatusChanged(object sender, TeleportStatusEventArgs e)
        {
            switch (e.Status)
            {
                case AgentManager.TeleportStatus.Start:
                case AgentManager.TeleportStatus.Progress:
                    lblTeleportStatus.Text = e.Message;
                    break;

                case AgentManager.TeleportStatus.Failed:
                    RefreshControls();

                    MessageBox.Show(e.Message, "Teleport", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case AgentManager.TeleportStatus.Finished:
                    this.Close();
                    break;
            }
        }

        private void netcom_ClientDisconnected(object sender, ClientDisconnectEventArgs e)
        {
            this.Close();
        }

        private void netcom_Teleporting(object sender, TeleportingEventArgs e)
        {
            RefreshControls();
        }

        private void RefreshControls()
        {
            if (netcom.IsTeleporting)
            {
                pnlTeleportOptions.Enabled = false;
                btnTeleport.Enabled = false;
                pnlTeleporting.Visible = true;
            }
            else
            {
                pnlTeleportOptions.Enabled = true;
                btnTeleport.Enabled = true;
                pnlTeleporting.Visible = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRegion_TextChanged(object sender, EventArgs e)
        {
            btnTeleport.Enabled = (txtRegion.Text.Trim().Length > 0);
        }

        private void btnTeleport_Click(object sender, EventArgs e)
        {
            netcom.Teleport(txtRegion.Text, new LLVector3((float)nudX.Value, (float)nudY.Value, (float)nudZ.Value));
        }

        private void frmTeleport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (netcom.IsTeleporting && netcom.IsLoggedIn)
                e.Cancel = true;
            else
                RemoveClientEvents();
        }

        private void txtSearchFor_TextChanged(object sender, EventArgs e)
        {
            btnFind.Enabled = (txtSearchFor.Text.Trim().Length > 0);
        }

        private void lbxRegionSearch_DoubleClick(object sender, EventArgs e)
        {
            if (lbxRegionSearch.SelectedItem == null) return;
            RegionSearchResultItem item = (RegionSearchResultItem)lbxRegionSearch.SelectedItem;

            txtRegion.Text = item.Region.Name;
            nudX.Value = 128;
            nudY.Value = 128;
            nudZ.Value = 0;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            StartRegionSearch();
        }

        private void StartRegionSearch()
        {
            lbxRegionSearch.Items.Clear();

            client.Grid.RequestMapRegion(txtSearchFor.Text, GridLayerType.Terrain);
            
        }

        private void txtSearchFor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (!btnFind.Enabled) return;
            e.SuppressKeyPress = true;
            
            StartRegionSearch();
        }

        private void lbxRegionSearch_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index < 0) return;

            RegionSearchResultItem itemToDraw = (RegionSearchResultItem)lbxRegionSearch.Items[e.Index];
            Brush textBrush = null;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                textBrush = new SolidBrush(Color.FromKnownColor(KnownColor.HighlightText));
            else
                textBrush = new SolidBrush(Color.FromKnownColor(KnownColor.ControlText));
            
            Font newFont = new Font(e.Font, FontStyle.Bold);
            SizeF stringSize = e.Graphics.MeasureString(itemToDraw.Region.Name, newFont);
            
            float iconSize = (float)trkIconSize.Value;
            float leftTextMargin = e.Bounds.Left + iconSize + 6.0f;
            float topTextMargin = e.Bounds.Top + 4.0f;

            if (itemToDraw.IsImageDownloaded)
            {
                if (itemToDraw.MapImage != null)
                    e.Graphics.DrawImage(itemToDraw.MapImage, new RectangleF(e.Bounds.Left + 4.0f, e.Bounds.Top + 4.0f, iconSize, iconSize));
            }
            else
            {
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(200, 200, 200)), e.Bounds.Left + 4.0f, e.Bounds.Top + 4.0f, iconSize, iconSize);

                if (!itemToDraw.IsImageDownloading)
                    itemToDraw.RequestMapImage(125000.0f);
            }
            
            e.Graphics.DrawString(itemToDraw.Region.Name, newFont, textBrush, new PointF(leftTextMargin, topTextMargin));

            if (itemToDraw.GotAgentCount)
            {
                e.Graphics.DrawString(itemToDraw.Region.Agents.ToString() + " people", e.Font, textBrush, new PointF(leftTextMargin + stringSize.Width + 6.0f, topTextMargin));
            }
            else
            {
                if (!itemToDraw.GettingAgentCount)
                    itemToDraw.RequestAgentLocations();
            }

            switch (itemToDraw.Region.Access)
            {
                case Simulator.SimAccess.PG:
                    e.Graphics.DrawString("PG", e.Font, textBrush, new PointF(leftTextMargin, topTextMargin + stringSize.Height));
                    break;

                case Simulator.SimAccess.Mature:
                    e.Graphics.DrawString("Mature", e.Font, textBrush, new PointF(leftTextMargin, topTextMargin + stringSize.Height));
                    break;

                case Simulator.SimAccess.Down:
                    e.Graphics.DrawString("Offline", e.Font, new SolidBrush(Color.Red), new PointF(leftTextMargin, topTextMargin + stringSize.Height));
                    break;
            }

            e.Graphics.DrawLine(new Pen(Color.FromArgb(200, 200, 200)), new Point(e.Bounds.Left, e.Bounds.Bottom - 1), new Point(e.Bounds.Right, e.Bounds.Bottom - 1));
            e.DrawFocusRectangle();

            textBrush.Dispose();
            newFont.Dispose();
            textBrush = null;
            newFont = null;
        }

        private void txtSearchFor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
        }

        private void trkIconSize_Scroll(object sender, EventArgs e)
        {
            lbxRegionSearch.ItemHeight = trkIconSize.Value + 10;
        }
    }
}