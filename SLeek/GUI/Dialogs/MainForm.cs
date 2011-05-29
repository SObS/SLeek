using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using SLNetworkComm;
using libsecondlife;

namespace SLeek
{
    public partial class frmMain : Form
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;

        private TabsConsole tabsConsole;
        private frmDebugLog debugLogForm;
        private System.Timers.Timer statusTimer;

        public frmMain(SleekInstance instance)
        {
            InitializeComponent();

            this.instance = instance;
            client = this.instance.Client;
            netcom = this.instance.Netcom;
            netcom.NetcomSync = this;
            AddNetcomEvents();
            client.Parcels.OnParcelProperties += new ParcelManager.ParcelPropertiesCallback(Parcels_OnParcelProperties);
            
            InitializeStatusTimer();
            RefreshWindowTitle();

            ApplyConfig(this.instance.Config.CurrentConfig, true);
            this.instance.Config.ConfigApplied += new EventHandler<ConfigAppliedEventArgs>(Config_ConfigApplied);
        }

        //Separate thread
        private void Parcels_OnParcelProperties(Parcel parcel, ParcelManager.ParcelResult result, int sequenceID, bool snapSelection)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Parcel: ");
            sb.Append(parcel.Name);

            if ((parcel.Flags & Parcel.ParcelFlags.AllowFly) != Parcel.ParcelFlags.AllowFly)
                sb.Append(" (no fly)");

            if ((parcel.Flags & Parcel.ParcelFlags.CreateObjects) != Parcel.ParcelFlags.CreateObjects)
                sb.Append(" (no build)");

            if ((parcel.Flags & Parcel.ParcelFlags.AllowOtherScripts) != Parcel.ParcelFlags.AllowOtherScripts)
                sb.Append(" (no scripts)");

            if ((parcel.Flags & Parcel.ParcelFlags.RestrictPushObject) == Parcel.ParcelFlags.RestrictPushObject)
                sb.Append(" (no push)");

            if ((parcel.Flags & Parcel.ParcelFlags.AllowDamage) == Parcel.ParcelFlags.AllowDamage)
                sb.Append(" (damage)");

            BeginInvoke(new MethodInvoker(delegate()
            {
                tlblParcel.Text = sb.ToString();
            }));
        }

        private void Config_ConfigApplied(object sender, ConfigAppliedEventArgs e)
        {
            ApplyConfig(e.AppliedConfig, false);
        }

        private void ApplyConfig(Config config, bool doingInit)
        {
            if (doingInit)
                this.WindowState = (FormWindowState)config.MainWindowState;

            if (config.InterfaceStyle == 0) //System
                toolStrip1.RenderMode = ToolStripRenderMode.System;
            else if (config.InterfaceStyle == 1) //Office 2003
                toolStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
        }

        public void InitializeControls()
        {
            InitializeTabsConsole();
            InitializeDebugLogForm();
        }

        private void statusTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RefreshWindowTitle();
            RefreshStatusBar();
        }

        private void AddNetcomEvents()
        {
            netcom.ClientLoginStatus += new EventHandler<ClientLoginEventArgs>(netcom_ClientLoginStatus);
            netcom.ClientLoggedOut += new EventHandler(netcom_ClientLoggedOut);
            netcom.ClientDisconnected += new EventHandler<ClientDisconnectEventArgs>(netcom_ClientDisconnected);
            netcom.InstantMessageReceived += new EventHandler<InstantMessageEventArgs>(netcom_InstantMessageReceived);
        }

        private void netcom_InstantMessageReceived(object sender, InstantMessageEventArgs e)
        {
            if (e.IM.Dialog == InstantMessageDialog.StartTyping ||
                e.IM.Dialog == InstantMessageDialog.StopTyping)
                return;

            if (!this.Focused) FormFlash.Flash(this);
        }

        private void netcom_ClientLoginStatus(object sender, ClientLoginEventArgs e)
        {
            if (e.Status != LoginStatus.Success) return;

            tbtnStatus.Enabled = tbtnControl.Enabled = tbtnTeleport.Enabled = tbtnObjects.Enabled = true;
            statusTimer.Start();
            RefreshWindowTitle();
        }

        private void netcom_ClientLoggedOut(object sender, EventArgs e)
        {
            tbtnStatus.Enabled = tbtnControl.Enabled = tbtnTeleport.Enabled = tbtnObjects.Enabled = false;

            statusTimer.Stop();

            RefreshStatusBar();
            RefreshWindowTitle();
        }

        private void netcom_ClientDisconnected(object sender, ClientDisconnectEventArgs e)
        {
            if (e.Type == NetworkManager.DisconnectType.ClientInitiated) return;

            tbtnStatus.Enabled = tbtnControl.Enabled = tbtnTeleport.Enabled = tbtnObjects.Enabled = false;

            statusTimer.Stop();

            RefreshStatusBar();
            RefreshWindowTitle();

            (new frmDisconnected(instance, e)).ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (instance.IsFirstInstance && instance.OtherInstancesOpen)
            {
                if (MessageBox.Show("You are about to close the first instance of SLeek. This may cause any other open instances of SLeek to close. Are you sure you want to continue?",
                    "SLeek", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            debugLogForm.Dispose();
            debugLogForm.Close();
            debugLogForm = null;
            
            if (netcom.IsLoggedIn) netcom.Logout();

            instance.Config.CurrentConfig.MainWindowState = (int)this.WindowState;
        }

        private void RefreshStatusBar()
        {
            if (netcom.IsLoggedIn)
            {
                tlblLoginName.Text = netcom.LoginOptions.FullName;
                tlblMoneyBalance.Text = "L$" + client.Self.Balance.ToString();
                tlblHealth.Text = "Health: " + client.Self.Health.ToString();

                tlblRegionInfo.Text =
                    client.Network.CurrentSim.Name +
                    " (" + Math.Floor(client.Self.SimPosition.X).ToString() + ", " +
                    Math.Floor(client.Self.SimPosition.Y).ToString() + ", " +
                    Math.Floor(client.Self.SimPosition.Z).ToString() + ")";

                int totalPrims = 0;
                int totalAvatars = 0;

                foreach (Simulator sim in client.Network.Simulators)
                {
                    totalPrims += sim.ObjectsPrimitives.Count;
                    totalAvatars += sim.ObjectsAvatars.Count;
                }

                toolTip1.SetToolTip(
                    statusStrip1,
                    "Region: " + client.Network.CurrentSim.Name + "\n" +
                    "X: " + client.Self.SimPosition.X.ToString() + "\n" +
                    "Y: " + client.Self.SimPosition.Y.ToString() + "\n" +
                    "Z: " + client.Self.SimPosition.Z.ToString() + "\n\n" +
                    "Nearby prims: " + totalPrims.ToString() + "\n" +
                    "Nearby avatars: " + totalAvatars.ToString());
            }
            else
            {
                tlblLoginName.Text = "Offline";
                tlblMoneyBalance.Text = "L$0";
                tlblHealth.Text = "Health: 0";
                tlblRegionInfo.Text = "No Region";
                tlblParcel.Text = "No Parcel";
                toolTip1.SetToolTip(statusStrip1, string.Empty);
            }
        }

        private void RefreshWindowTitle()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SLeek - ");

            if (netcom.IsLoggedIn)
            {
                sb.Append("[" + netcom.LoginOptions.FullName + "]");

                if (instance.State.IsAway)
                {
                    sb.Append(" - Away");
                    if (instance.State.IsBusy) sb.Append(", Busy");
                }
                else if (instance.State.IsBusy)
                {
                    sb.Append(" - Busy");
                }

                if (instance.State.IsFollowing)
                {
                    sb.Append(" - Following ");
                    sb.Append(instance.State.FollowName);
                }
            }
            else
            {
                sb.Append("Logged Out");
            }

            this.Text = sb.ToString();
            sb = null;
        }

        private void InitializeStatusTimer()
        {
            statusTimer = new System.Timers.Timer(250);
            statusTimer.SynchronizingObject = this;
            statusTimer.Elapsed += new ElapsedEventHandler(statusTimer_Elapsed);
        }

        private void InitializeTabsConsole()
        {
            tabsConsole = new TabsConsole(instance);
            tabsConsole.Dock = DockStyle.Fill;
            toolStripContainer1.ContentPanel.Controls.Add(tabsConsole);
        }

        private void InitializeDebugLogForm()
        {
            debugLogForm = new frmDebugLog(instance);
        }

        private void tmnuAbout_Click(object sender, EventArgs e)
        {
            (new frmAbout()).ShowDialog();
        }

        private void tmnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.D)
                tbtnDebug.Visible = !tbtnDebug.Visible;
        }

        private void tbtnTeleport_Click(object sender, EventArgs e)
        {
            (new frmTeleport(instance)).ShowDialog();
        }

        private void tmnuStatusAway_Click(object sender, EventArgs e)
        {
            instance.State.SetAway(tmnuStatusAway.Checked);
        }

        private void tmnuHelpReadme_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + @"\Readme.txt");
        }

        private void tmnuStatusBusy_Click(object sender, EventArgs e)
        {
            instance.State.SetBusy(tmnuStatusBusy.Checked);
        }

        private void tmnuControlFly_Click(object sender, EventArgs e)
        {
            instance.State.SetFlying(tmnuControlFly.Checked);
        }

        private void tmnuControlAlwaysRun_Click(object sender, EventArgs e)
        {
            instance.State.SetAlwaysRun(tmnuControlAlwaysRun.Checked);
        }

        private void tmnuDebugLog_Click(object sender, EventArgs e)
        {
            debugLogForm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tabsConsole.SelectTab("Main");
        }

        public TabsConsole TabConsole
        {
            get { return tabsConsole; }
        }

        private void tmnuNewWindow_Click(object sender, EventArgs e)
        {
            instance.Config.SaveCurrentConfig();
            if (instance.IsFirstInstance) instance.OtherInstancesOpen = true;

            (new SleekInstance(false)).MainForm.Show();
        }

        private void tmnuPrefs_Click(object sender, EventArgs e)
        {
            (new frmPreferences(instance)).ShowDialog();
        }

        private void tmnuDonate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://delta.slinked.net/donate/");
        }

        private void tbtnObjects_Click(object sender, EventArgs e)
        {
            (new frmObjects(instance)).Show();
        }
    }
}