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
    public partial class TabsConsole : UserControl
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;

        //IM buttons are stored with a key corresponding to the person's name
        //TP buttons are stored with a key corresponding to the person's UUID
        private Dictionary<string, SleekTab> tabs = new Dictionary<string, SleekTab>();

        private SleekTab selectedTab;
        private Form owner;

        public TabsConsole(SleekInstance instance)
        {
            InitializeComponent();

            this.instance = instance;
            netcom = this.instance.Netcom;
            client = this.instance.Client;
            AddNetcomEvents();

            InitializeMainTab();
            InitializeChatTab();

            ApplyConfig(this.instance.Config.CurrentConfig);
            this.instance.Config.ConfigApplied += new EventHandler<ConfigAppliedEventArgs>(Config_ConfigApplied);
        }

        private void Config_ConfigApplied(object sender, ConfigAppliedEventArgs e)
        {
            ApplyConfig(e.AppliedConfig);
        }

        private void ApplyConfig(Config config)
        {
            if (config.InterfaceStyle == 0) //System
                tstTabs.RenderMode = ToolStripRenderMode.System;
            else if (config.InterfaceStyle == 1) //Office 2003
                tstTabs.RenderMode = ToolStripRenderMode.ManagerRenderMode;
        }

        private void AddNetcomEvents()
        {
            netcom.ClientLoginStatus += new EventHandler<ClientLoginEventArgs>(netcom_ClientLoginStatus);
            netcom.ClientLoggedOut += new EventHandler(netcom_ClientLoggedOut);
            netcom.ClientDisconnected += new EventHandler<ClientDisconnectEventArgs>(netcom_ClientDisconnected);
            netcom.ChatReceived += new EventHandler<ChatEventArgs>(netcom_ChatReceived);
            netcom.ChatSent += new EventHandler<ChatSentEventArgs>(netcom_ChatSent);
            netcom.AlertMessageReceived += new EventHandler<AlertMessageEventArgs>(netcom_AlertMessageReceived);
            netcom.InstantMessageReceived += new EventHandler<InstantMessageEventArgs>(netcom_InstantMessageReceived);
        }

        private void netcom_ClientLoginStatus(object sender, ClientLoginEventArgs e)
        {
            if (e.Status != LoginStatus.Success) return;

            InitializeFriendsTab();
            InitializeInventoryTab();
            InitializeSearchTab();

            if (selectedTab.Name == "main")
                tabs["chat"].Select();

            client.Self.RetrieveInstantMessages();
        }

        private void netcom_ClientLoggedOut(object sender, EventArgs e)
        {
            DisposeSearchTab();
            DisposeInventoryTab();
            DisposeFriendsTab();

            tabs["main"].Select();
        }

        private void netcom_ClientDisconnected(object sender, ClientDisconnectEventArgs e)
        {
            if (e.Type == NetworkManager.DisconnectType.ClientInitiated) return;

            DisposeSearchTab();
            DisposeInventoryTab();
            DisposeFriendsTab();

            tabs["main"].Select();
        }

        private void netcom_AlertMessageReceived(object sender, AlertMessageEventArgs e)
        {
            tabs["chat"].Highlight();
        }

        private void netcom_ChatSent(object sender, ChatSentEventArgs e)
        {
            tabs["chat"].Highlight();
        }

        private void netcom_ChatReceived(object sender, ChatEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Message)) return;

            tabs["chat"].Highlight();
        }

        private void netcom_InstantMessageReceived(object sender, InstantMessageEventArgs e)
        {
            switch (e.IM.Dialog)
            {
                case InstantMessageDialog.MessageFromAgent:
                case InstantMessageDialog.MessageFromObject:
                    HandleIM(e);
                    break;

                case InstantMessageDialog.StartTyping:
                    if (TabExists(e.IM.FromAgentName))
                    {
                        SleekTab tab = tabs[e.IM.FromAgentName.ToLower()];
                        if (!tab.Highlighted) tab.PartialHighlight();
                    }

                    break;

                case InstantMessageDialog.StopTyping:
                    if (TabExists(e.IM.FromAgentName))
                    {
                        SleekTab tab = tabs[e.IM.FromAgentName.ToLower()];
                        if (!tab.Highlighted) tab.Unhighlight();
                    }

                    break;

                case InstantMessageDialog.RequestTeleport:
                    HandleTP(e);
                    break;
            }
        }

        private void HandleIM(InstantMessageEventArgs e)
        {
            if (TabExists(e.IM.FromAgentName))
            {
                SleekTab tab = tabs[e.IM.FromAgentName.ToLower()];
                if (!tab.Selected) tab.Highlight();
                return;
            }

            IMTabWindow imTab = AddIMTab(e);
            tabs[imTab.TargetName.ToLower()].Highlight();
        }

        private void HandleTP(InstantMessageEventArgs e)
        {
            string fromAgentID = e.IM.FromAgentID.ToString();

            if (TabExists(fromAgentID))
                tabs[fromAgentID].Close();

            TPTabWindow tpTab = AddTPTab(e);
            tabs[tpTab.TargetUUID.ToString()].Highlight();
        }

        private void InitializeMainTab()
        {
            MainConsole mainConsole = new MainConsole(instance);
            mainConsole.Dock = DockStyle.Fill;
            mainConsole.Visible = false;

            toolStripContainer1.ContentPanel.Controls.Add(mainConsole);

            SleekTab tab = AddTab("main", "Main", mainConsole);
            tab.AllowClose = false;
            tab.AllowDetach = false;
            tab.AllowMerge = false;

            mainConsole.RegisterTab(tab);
        }

        private void InitializeChatTab()
        {
            ChatConsole chatConsole = new ChatConsole(instance);
            chatConsole.Dock = DockStyle.Fill;
            chatConsole.Visible = false;

            toolStripContainer1.ContentPanel.Controls.Add(chatConsole);

            SleekTab tab = AddTab("chat", "Chat", chatConsole);
            tab.AllowClose = false;
            tab.AllowDetach = false;
        }

        private void InitializeFriendsTab()
        {
            FriendsConsole friendsConsole = new FriendsConsole(instance);
            friendsConsole.Dock = DockStyle.Fill;
            friendsConsole.Visible = false;

            toolStripContainer1.ContentPanel.Controls.Add(friendsConsole);

            SleekTab tab = AddTab("friends", "Friends", friendsConsole);
            tab.AllowClose = false;
            tab.AllowDetach = false;
        }

        private void InitializeSearchTab()
        {
            SearchConsole searchConsole = new SearchConsole(instance);
            searchConsole.Dock = DockStyle.Fill;
            searchConsole.Visible = false;

            toolStripContainer1.ContentPanel.Controls.Add(searchConsole);

            SleekTab tab = AddTab("search", "Search", searchConsole);
            tab.AllowClose = false;
            tab.AllowDetach = false;
        }

        private void InitializeInventoryTab()
        {
            InventoryConsole invConsole = new InventoryConsole(instance);
            invConsole.Dock = DockStyle.Fill;
            invConsole.Visible = false;

            toolStripContainer1.ContentPanel.Controls.Add(invConsole);

            SleekTab tab = AddTab("inventory", "Inventory", invConsole);
            tab.AllowClose = false;
            tab.AllowDetach = false;
        }

        private void DisposeFriendsTab()
        {
            ForceCloseTab("friends");
        }

        private void DisposeSearchTab()
        {
            ForceCloseTab("search");
        }

        private void DisposeInventoryTab()
        {
            ForceCloseTab("inventory");
        }

        private void ForceCloseTab(string name)
        {
            if (!TabExists(name)) return;

            SleekTab tab = tabs[name];
            if (tab.Merged) SplitTab(tab);

            tab.AllowClose = true;
            tab.Close();
            tab = null;
        }

        public void AddTab(SleekTab tab)
        {
            ToolStripButton button = (ToolStripButton)tstTabs.Items.Add(tab.Label);
            button.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            button.Image = null;
            button.AutoToolTip = false;
            button.Tag = tab.Name;
            button.Click += new EventHandler(TabButtonClick);

            tab.Button = button;
            tabs.Add(tab.Name, tab);
        }

        public SleekTab AddTab(string name, string label, Control control)
        {
            ToolStripButton button = (ToolStripButton)tstTabs.Items.Add(label);
            button.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            button.Image = null;
            button.AutoToolTip = false;
            button.Tag = name.ToLower();
            button.Click += new EventHandler(TabButtonClick);

            SleekTab tab = new SleekTab(button, control, name.ToLower(), label);
            tab.TabAttached += new EventHandler(tab_TabAttached);
            tab.TabDetached += new EventHandler(tab_TabDetached);
            tab.TabSelected += new EventHandler(tab_TabSelected);
            tab.TabClosed += new EventHandler(tab_TabClosed);
            tabs.Add(name.ToLower(), tab);

            return tab;
        }

        private void tab_TabAttached(object sender, EventArgs e)
        {
            SleekTab tab = (SleekTab)sender;
            tab.Select();
        }

        private void tab_TabDetached(object sender, EventArgs e)
        {
            SleekTab tab = (SleekTab)sender;
            frmDetachedTab form = (frmDetachedTab)tab.Owner;

            form.ReattachStrip = tstTabs;
            form.ReattachContainer = toolStripContainer1.ContentPanel;
        }

        private void tab_TabSelected(object sender, EventArgs e)
        {
            SleekTab tab = (SleekTab)sender;

            if (selectedTab != null &&
                selectedTab != tab)
            { selectedTab.Deselect(); }
            
            selectedTab = tab;

            tbtnCloseTab.Enabled = tab.AllowClose;
            owner.AcceptButton = tab.DefaultControlButton;
        }

        private void tab_TabClosed(object sender, EventArgs e)
        {
            SleekTab tab = (SleekTab)sender;
            
            tabs.Remove(tab.Name);
            tab = null;
        }

        private void TabButtonClick(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;

            SleekTab tab = tabs[button.Tag.ToString()];
            tab.Select();
        }

        public void RemoveTabEntry(SleekTab tab)
        {
            tab.Button.Dispose();
            tabs.Remove(tab.Name);
        }

        //Used for outside classes that have a reference to TabsConsole
        public void SelectTab(string name)
        {
            tabs[name.ToLower()].Select();
        }

        public bool TabExists(string name)
        {
            return tabs.ContainsKey(name.ToLower());
        }

        public SleekTab GetTab(string name)
        {
            return tabs[name.ToLower()];
        }

        public List<SleekTab> GetOtherTabs()
        {
            List<SleekTab> otherTabs = new List<SleekTab>();

            foreach (ToolStripItem item in tstTabs.Items)
            {
                if (item.Tag == null) continue;
                if ((ToolStripButton)item == selectedTab.Button) continue;

                SleekTab tab = tabs[item.Tag.ToString()];
                if (!tab.AllowMerge) continue;
                if (tab.Merged) continue;
                
                otherTabs.Add(tab);
            }

            return otherTabs;
        }

        public IMTabWindow AddIMTab(LLUUID target, LLUUID session, string targetName)
        {
            IMTabWindow imTab = new IMTabWindow(instance, target, session, targetName);
            imTab.Dock = DockStyle.Fill;

            toolStripContainer1.ContentPanel.Controls.Add(imTab);
            SleekTab tab = AddTab(targetName, "IM: " + targetName, imTab);
            imTab.SelectIMInput();

            return imTab;
        }

        public IMTabWindow AddIMTab(InstantMessageEventArgs e)
        {
            IMTabWindow imTab = AddIMTab(e.IM.FromAgentID, e.IM.IMSessionID, e.IM.FromAgentName);
            imTab.TextManager.ProcessIM(e);
            return imTab;
        }

        public TPTabWindow AddTPTab(InstantMessageEventArgs e)
        {
            TPTabWindow tpTab = new TPTabWindow(instance, e);
            tpTab.Dock = DockStyle.Fill;

            toolStripContainer1.ContentPanel.Controls.Add(tpTab);
            SleekTab tab = AddTab(tpTab.TargetUUID.ToString(), "TP: " + tpTab.TargetName, tpTab);

            return tpTab;
        }

        private void tbtnTabOptions_Click(object sender, EventArgs e)
        {
            tmnuMergeWith.Enabled = selectedTab.AllowMerge;
            tmnuDetachTab.Enabled = selectedTab.AllowDetach;

            tmnuMergeWith.DropDown.Items.Clear();

            if (!selectedTab.AllowMerge) return;
            if (!selectedTab.Merged)
            {
                tmnuMergeWith.Text = "Merge With";

                List<SleekTab> otherTabs = GetOtherTabs();

                tmnuMergeWith.Enabled = (otherTabs.Count > 0);
                if (!tmnuMergeWith.Enabled) return;

                foreach (SleekTab tab in otherTabs)
                {
                    ToolStripItem item = tmnuMergeWith.DropDown.Items.Add(tab.Label);
                    item.Tag = tab.Name;
                    item.Click += new EventHandler(MergeItemClick);
                }
            }
            else
            {
                tmnuMergeWith.Text = "Split";
                tmnuMergeWith.Click += new EventHandler(SplitClick);
            }
        }

        private void MergeItemClick(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            SleekTab tab = tabs[item.Tag.ToString()];

            selectedTab.MergeWith(tab);

            SplitContainer container = (SplitContainer)selectedTab.Control;
            toolStripContainer1.ContentPanel.Controls.Add(container);

            selectedTab.Select();
            RemoveTabEntry(tab);

            tabs.Add(tab.Name, selectedTab);
        }

        private void SplitClick(object sender, EventArgs e)
        {
            SplitTab(selectedTab);
            selectedTab.Select();
        }

        public void SplitTab(SleekTab tab)
        {
            SleekTab otherTab = tab.Split();
            if (otherTab == null) return;

            toolStripContainer1.ContentPanel.Controls.Add(tab.Control);
            toolStripContainer1.ContentPanel.Controls.Add(otherTab.Control);

            tabs.Remove(otherTab.Name);
            AddTab(otherTab);
        }

        private void tmnuDetachTab_Click(object sender, EventArgs e)
        {
            if (!selectedTab.AllowDetach) return;

            tstTabs.Items.Remove(selectedTab.Button);
            selectedTab.Detach(instance);
            selectedTab.Owner.Show();

            tabs["chat"].Select();
        }

        private void tbtnCloseTab_Click(object sender, EventArgs e)
        {
            SleekTab tab = selectedTab;

            tabs["chat"].Select();
            tab.Close();
            
            tab = null;
        }

        private void TabsConsole_Load(object sender, EventArgs e)
        {
            owner = this.FindForm();
        }
    }
}
