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
    public partial class ChatConsole : UserControl
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;
        private ChatTextManager chatManager;
        private TabsConsole tabConsole;
        private int previousChannel = 0;

        private Dictionary<uint, Avatar> avatars = new Dictionary<uint, Avatar>();

        public ChatConsole(SleekInstance instance)
        {
            InitializeComponent();

            this.instance = instance;
            netcom = this.instance.Netcom;
            client = this.instance.Client;
            AddNetcomEvents();
            AddClientEvents();

            chatManager = new ChatTextManager(instance, new RichTextBoxPrinter(rtbChat));
            chatManager.PrintStartupMessage();

            this.instance.MainForm.Load += new EventHandler(MainForm_Load);

            ApplyConfig(this.instance.Config.CurrentConfig);
            this.instance.Config.ConfigApplied += new EventHandler<ConfigAppliedEventArgs>(Config_ConfigApplied);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tabConsole = instance.TabConsole;
        }

        private void Config_ConfigApplied(object sender, ConfigAppliedEventArgs e)
        {
            ApplyConfig(e.AppliedConfig);
        }

        private void ApplyConfig(Config config)
        {
            if (config.InterfaceStyle == 0) //System
                toolStrip1.RenderMode = ToolStripRenderMode.System;
            else if (config.InterfaceStyle == 1) //Office 2003
                toolStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
        }

        private void AddNetcomEvents()
        {
            netcom.ClientLoginStatus += new EventHandler<ClientLoginEventArgs>(netcom_ClientLoginStatus);
            netcom.ClientLoggedOut += new EventHandler(netcom_ClientLoggedOut);
            netcom.ChatReceived += new EventHandler<ChatEventArgs>(netcom_ChatReceived);
        }

        private void AddClientEvents()
        {
            client.Objects.OnNewAvatar += new ObjectManager.NewAvatarCallback(Objects_OnNewAvatar);
            client.Objects.OnObjectKilled += new ObjectManager.KillObjectCallback(Objects_OnObjectKilled);
        }

        //Separate thread
        private void Objects_OnObjectKilled(Simulator simulator, uint objectID)
        {
            if (!avatars.ContainsKey(objectID)) return;

            Avatar av = avatars[objectID];
            BeginInvoke(new OnRemoveAvatar(RemoveAvatarName), new object[] { av.Name });
            avatars.Remove(objectID);
            av = null;
        }

        //Separate thread
        private void Objects_OnNewAvatar(Simulator simulator, Avatar avatar, ulong regionHandle, ushort timeDilation)
        {
            if (!avatars.ContainsKey(avatar.LocalID))
                avatars.Add(avatar.LocalID, avatar);
            
            BeginInvoke(new OnAddAvatar(AddAvatar), new object[] { avatar });
        }

        private void netcom_ClientLoginStatus(object sender, ClientLoginEventArgs e)
        {
            if (e.Status != LoginStatus.Success) return;

            cbxInput.Enabled = true;
            btnSay.Enabled = true;
            btnShout.Enabled = true;
        }

        private void netcom_ClientLoggedOut(object sender, EventArgs e)
        {
            cbxInput.Enabled = false;
            btnSay.Enabled = false;
            btnShout.Enabled = false;

            lvwObjects.Items.Clear();
        }

        private delegate void OnAddAvatar(Avatar av);
        public void AddAvatar(Avatar av)
        {
            if (av == null) return;
            string name = av.Name;

            if (lvwObjects.Items.ContainsKey(name)) return;

            ListViewItem item = lvwObjects.Items.Add(name, name, string.Empty);
            if (name == client.Self.Name) item.Font = new Font(item.Font, FontStyle.Bold);
            item.Tag = av;
        }

        private delegate void OnRemoveAvatar(string name);
        public void RemoveAvatarName(string name)
        {
            int index = lvwObjects.Items.IndexOfKey(name);
            if (index == -1) return;

            lvwObjects.Items.RemoveAt(index);
        }

        private void netcom_ChatReceived(object sender, ChatEventArgs e)
        {
            if (e.SourceType != ChatSourceType.Agent) return;
            if (e.FromName == netcom.LoginOptions.FullName) return;

            int index = lvwObjects.Items.IndexOfKey(e.FromName);
            if (index == -1) return;

            if (e.Type == ChatType.StartTyping)
                lvwObjects.Items[index].ForeColor = Color.DarkBlue;
            else
                lvwObjects.Items[index].ForeColor = Color.FromKnownColor(KnownColor.ControlText);
        }

        private void cbxInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;

            if (e.Control && e.Shift)
                ProcessChatInput(cbxInput.Text, ChatType.Whisper);
            else if (e.Control)
                ProcessChatInput(cbxInput.Text, ChatType.Shout);
            else
                ProcessChatInput(cbxInput.Text, ChatType.Normal);
        }

        private void ProcessChatInput(string input, ChatType type)
        {
            if (string.IsNullOrEmpty(input)) return;

            string[] inputArgs = input.Split(' ');

            if (inputArgs[0].StartsWith("//")) //Chat on previously used channel
            {
                string message = string.Join(" ", inputArgs).Substring(2);
                netcom.ChatOut(message, type, previousChannel);
            }
            else if (inputArgs[0].StartsWith("/")) //Chat on specific channel
            {
                string number = inputArgs[0].Substring(1);
                
                int channel = 0;
                int.TryParse(number, out channel);
                if (channel < 0) channel = 0;

                string message = string.Join(" ", inputArgs, 1, inputArgs.GetUpperBound(0) - 1);
                netcom.ChatOut(message, type, channel);

                previousChannel = channel;
            }
            else //Chat on channel 0 (public chat)
            {
                netcom.ChatOut(input, type, 0);
            }

            ClearChatInput();
        }

        private void ClearChatInput()
        {
            cbxInput.Items.Add(cbxInput.Text);
            cbxInput.Text = string.Empty;
        }

        private void btnSay_Click(object sender, EventArgs e)
        {
            ProcessChatInput(cbxInput.Text, ChatType.Normal);
        }

        private void btnShout_Click(object sender, EventArgs e)
        {
            ProcessChatInput(cbxInput.Text, ChatType.Shout);
        }

        private void cbxInput_TextChanged(object sender, EventArgs e)
        {
            if (cbxInput.Text.Length > 0)
            {
                btnSay.Enabled = btnShout.Enabled = true;

                if (!cbxInput.Text.StartsWith("/"))
                {
                    if (!instance.State.IsTyping)
                        instance.State.SetTyping(true);
                }
            }
            else
            {
                btnSay.Enabled = btnShout.Enabled = false;
                instance.State.SetTyping(false);
            }
        }

        public ChatTextManager ChatManager
        {
            get { return chatManager; }
        }

        private void tbtnStartIM_Click(object sender, EventArgs e)
        {
            Avatar av = ((ListViewItem)lvwObjects.SelectedItems[0]).Tag as Avatar;
            if (av == null) return;

            if (tabConsole.TabExists(av.Name))
            {
                tabConsole.SelectTab(av.Name);
                return;
            }
            
            tabConsole.AddIMTab(av.ID, client.Self.SessionID ^ av.ID, av.Name);
            tabConsole.SelectTab(av.Name);
        }

        private void tbtnFollow_Click(object sender, EventArgs e)
        {
            Avatar av = ((ListViewItem)lvwObjects.SelectedItems[0]).Tag as Avatar;
            if (av == null) return;

            if (instance.State.FollowName != av.Name)
                instance.State.Follow(av.Name);
            else
                instance.State.Follow(string.Empty);
        }

        private void lvwObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwObjects.SelectedItems.Count == 0)
            {
                tbtnStartIM.Enabled = tbtnFollow.Enabled = tbtnProfile.Enabled = false;
            }
            else
            {
                tbtnStartIM.Enabled = tbtnFollow.Enabled = tbtnProfile.Enabled =
                    (lvwObjects.SelectedItems[0].Name != client.Self.Name);
            }
        }

        private void rtbChat_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (e.LinkText.StartsWith("http://") || e.LinkText.StartsWith("ftp://"))
                System.Diagnostics.Process.Start(e.LinkText);
            else
                System.Diagnostics.Process.Start("http://" + e.LinkText);
        }

        private void tbtnProfile_Click(object sender, EventArgs e)
        {
            Avatar av = ((ListViewItem)lvwObjects.SelectedItems[0]).Tag as Avatar;
            if (av == null) return;
            
            (new frmProfile(instance, av.Name, av.ID)).Show();
        }

        private void cbxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) e.SuppressKeyPress = true;
        }
    }
}
