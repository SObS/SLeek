using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SLNetworkComm;
using libsecondlife;

namespace SLeek
{
    public partial class frmProfile : Form
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;
        private string fullName;
        private LLUUID agentID;

        private LLUUID FLImageID;
        private LLUUID SLImageID;

        public frmProfile(SleekInstance instance, string fullName, LLUUID agentID)
        {
            InitializeComponent();

            this.instance = instance;
            netcom = this.instance.Netcom;
            client = this.instance.Client;
            this.fullName = fullName;
            this.agentID = agentID;
            
            this.Text = fullName + " (profile) - SLeek";

            AddClientEvents();
            AddNetcomEvents();
            InitializeProfile();
        }

        private void CleanUp()
        {
            client.Avatars.OnAvatarNames -= new AvatarManager.AvatarNamesCallback(Avatars_OnAvatarNames);
            client.Avatars.OnAvatarProperties -= new AvatarManager.AvatarPropertiesCallback(Avatars_OnAvatarProperties);
            client.Assets.OnImageReceived -= new AssetManager.ImageReceivedCallback(Assets_OnImageReceived);
        }

        private void AddClientEvents()
        {
            client.Avatars.OnAvatarNames += new AvatarManager.AvatarNamesCallback(Avatars_OnAvatarNames);
            client.Avatars.OnAvatarProperties += new AvatarManager.AvatarPropertiesCallback(Avatars_OnAvatarProperties);
            client.Assets.OnImageReceived += new AssetManager.ImageReceivedCallback(Assets_OnImageReceived);
        }

        private void AddNetcomEvents()
        {
            netcom.ClientLoggedOut += new EventHandler(netcom_ClientLoggedOut);
        }

        private void netcom_ClientLoggedOut(object sender, EventArgs e)
        {
            Close();
        }

        private void Avatars_OnAvatarNames(Dictionary<LLUUID, string> names)
        {
            foreach (KeyValuePair<LLUUID, string> kvp in names)
            {
                BeginInvoke(new OnSetPartnerText(SetPartnerText), new object[] { kvp.Value });
                break;
            }
        }

        private delegate void OnSetPartnerText(string partner);
        private void SetPartnerText(string partner)
        {
            txtPartner.Text = partner;
        }

        //comes in on a separate thread
        private void Assets_OnImageReceived(ImageDownload image, AssetTexture texture)
        {
            if (image.ID != SLImageID && image.ID != FLImageID) return;
            
            System.Drawing.Image decodedImage = ImageHelper.Decode(image.AssetData);

            if (decodedImage == null)
            {
                if (image.ID == SLImageID) BeginInvoke(new MethodInvoker(SetBlankSLImage));
                else if (image.ID == FLImageID) BeginInvoke(new MethodInvoker(SetBlankFLImage));

                return;
            }

            instance.ImageCache.AddImage(image.ID, decodedImage);

            BeginInvoke(
                new OnSetProfileImage(SetProfileImage),
                new object[] { image.ID, decodedImage });
        }

        //called on GUI thread
        private delegate void OnSetProfileImage(LLUUID id, System.Drawing.Image image);
        private void SetProfileImage(LLUUID id, System.Drawing.Image image)
        {
            if (id == SLImageID)
            {
                picSLImage.Image = image;
                proSLImage.Visible = false;
            }
            else if (id == FLImageID)
            {
                picFLImage.Image = image;
                proFLImage.Visible = false;
            }
        }

        private void SetBlankSLImage()
        {
            picSLImage.BackColor = Color.FromKnownColor(KnownColor.Control);
            proSLImage.Visible = false;
        }

        private void SetBlankFLImage()
        {
            picFLImage.BackColor = Color.FromKnownColor(KnownColor.Control);
            proFLImage.Visible = false;
        }

        //comes in on separate thread
        private void Avatars_OnAvatarProperties(LLUUID avatarID, Avatar.AvatarProperties properties)
        {
            if (avatarID != agentID) return;

            FLImageID = properties.FirstLifeImage;
            SLImageID = properties.ProfileImage;

            if (SLImageID != LLUUID.Zero)
            {
                if (!instance.ImageCache.ContainsImage(SLImageID))
                    client.Assets.RequestImage(SLImageID, ImageType.Normal, 125000.0f, 0);
                else
                    BeginInvoke(
                        new OnSetProfileImage(SetProfileImage),
                        new object[] { SLImageID, instance.ImageCache.GetImage(SLImageID) });
            }
            else
            {
                BeginInvoke(new MethodInvoker(SetBlankSLImage));
            }

            if (FLImageID != LLUUID.Zero)
            {
                if (!instance.ImageCache.ContainsImage(FLImageID))
                    client.Assets.RequestImage(FLImageID, ImageType.Normal, 125000.0f, 0);
                else
                    BeginInvoke(
                        new OnSetProfileImage(SetProfileImage),
                        new object[] { FLImageID, instance.ImageCache.GetImage(FLImageID) });
            }
            else
            {
                BeginInvoke(new MethodInvoker(SetBlankFLImage));
            }

            this.BeginInvoke(
                new OnSetProfileProperties(SetProfileProperties),
                new object[] { properties });
        }

        //called on GUI thread
        private delegate void OnSetProfileProperties(Avatar.AvatarProperties properties);
        private void SetProfileProperties(Avatar.AvatarProperties properties)
        {
            txtBornOn.Text = properties.BornOn;
            if (properties.Partner != LLUUID.Zero) client.Avatars.RequestAvatarName(properties.Partner);
            
            if (fullName.EndsWith("Linden")) rtbAccountInfo.AppendText("Linden Lab Employee\n");
            if (properties.Identified) rtbAccountInfo.AppendText("Identified\n");
            if (properties.Transacted) rtbAccountInfo.AppendText("Transacted\n");

            rtbAbout.AppendText(properties.AboutText);
            
            txtWebURL.Text = properties.ProfileURL;
            btnWebView.Enabled = btnWebOpen.Enabled = (txtWebURL.TextLength > 0);

            rtbAboutFL.AppendText(properties.FirstLifeText);
        }

        private void InitializeProfile()
        {
            txtFullName.Text = fullName;
            btnOfferTeleport.Enabled = btnPay.Enabled = (agentID != client.Self.AgentID);

            client.Avatars.RequestAvatarProperties(agentID);
        }

        private void frmProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            CleanUp();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnWebView_Click(object sender, EventArgs e)
        {
            WebBrowser web = new WebBrowser();
            web.Dock = DockStyle.Fill;
            web.Url = new Uri(txtWebURL.Text);

            pnlWeb.Controls.Add(web);
        }

        private void ProcessWebURL(string url)
        {
            if (url.StartsWith("http://") || url.StartsWith("ftp://"))
                System.Diagnostics.Process.Start(url);
            else
                System.Diagnostics.Process.Start("http://" + url);
        }

        private void btnWebOpen_Click(object sender, EventArgs e)
        {
            ProcessWebURL(txtWebURL.Text);
        }

        private void rtbAbout_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            ProcessWebURL(e.LinkText);
        }

        private void rtbAboutFL_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            ProcessWebURL(e.LinkText);
        }

        private void btnOfferTeleport_Click(object sender, EventArgs e)
        {
            client.Self.SendTeleportLure(agentID, "Join me in " + client.Network.CurrentSim.Name + "!");
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            (new frmPay(instance, agentID, fullName)).ShowDialog();
        }
    }
}