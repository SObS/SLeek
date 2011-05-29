using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SLNetworkComm;
using libsecondlife;

namespace SLeek
{
    public partial class frmScriptEditor : Form
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;
        private InventoryItem item;
        private LLUUID uploadID;
        private LLUUID transferID;
        private AssetScriptText receivedAsset;

        private bool closePending = false;
        private bool saving = false;

        public frmScriptEditor(SleekInstance instance, InventoryItem item)
        {
            InitializeComponent();

            this.instance = instance;
            netcom = this.instance.Netcom;
            client = this.instance.Client;
            this.item = item;
            AddNetcomEvents();
            
            this.Text = item.Name + " (script) - SLeek";

            client.Assets.OnAssetReceived += new AssetManager.AssetReceivedCallback(Assets_OnAssetReceived);
            transferID = client.Assets.RequestInventoryAsset(item.AssetUUID, item.UUID, LLUUID.Zero, item.OwnerID, item.AssetType, false);
        }

        //Separate thread
        private void Assets_OnAssetReceived(AssetDownload transfer, Asset asset)
        {
            if (transfer.ID != transferID) return;

            string scriptContent;

            if (!transfer.Success)
            {
                scriptContent = "Unable to download script. Make sure you have the proper permissions!";
                BeginInvoke(new OnSetScriptText(SetScriptText), new object[] { scriptContent, true });
                return;
            }

            receivedAsset = (AssetScriptText)asset;
            scriptContent = Helpers.FieldToUTF8String(transfer.AssetData);
            BeginInvoke(new OnSetScriptText(SetScriptText), new object[] { scriptContent, false });
        }

        //UI thread
        private delegate void OnSetScriptText(string text, bool readOnly);
        private void SetScriptText(string text, bool readOnly)
        {
            rtbScript.Clear();
            rtbScript.Text = text;

            if (readOnly)
            {
                rtbScript.ReadOnly = true;
                rtbScript.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            else
            {
                rtbScript.ReadOnly = false;
                rtbScript.BackColor = Color.White;
            }

            btnClose.Enabled = true;
        }

        private void AddNetcomEvents()
        {
            netcom.ClientLoggedOut += new EventHandler(netcom_ClientLoggedOut);
        }

        private void netcom_ClientLoggedOut(object sender, EventArgs e)
        {
            closePending = false;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rtbScript_TextChanged(object sender, EventArgs e)
        {
            if (!rtbScript.ReadOnly)
                btnSave.Enabled = true;
        }

        private DialogResult AskForSave()
        {
            return MessageBox.Show(
                "Your changes have not been saved. Save the script?",
                "SLeek",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
        }

        private void SaveScript()
        {
            saving = true;

            rtbScript.ReadOnly = true;
            rtbScript.BackColor = Color.FromKnownColor(KnownColor.Control);

            lblSaveStatus.Text = "Saving script...";
            lblSaveStatus.Visible = true;
            btnSave.Enabled = false;
            btnClose.Enabled = false;

            receivedAsset.Source = rtbScript.Text;
            
            client.Assets.OnAssetUploaded += new AssetManager.AssetUploadedCallback(Assets_OnAssetUploaded);
            uploadID = client.Assets.RequestUpload(receivedAsset, false, false, true);
        }

        //Separate thread
        private void Assets_OnAssetUploaded(AssetUpload upload)
        {
            if (upload.ID != uploadID) return;

            saving = false;
            if (closePending)
            {
                closePending = false;
                this.Close();
                return;
            }

            BeginInvoke(new MethodInvoker(SaveComplete));
        }

        //UI thread
        private void SaveComplete()
        {
            rtbScript.ReadOnly = false;
            rtbScript.BackColor = Color.White;
            btnClose.Enabled = true;

            lblSaveStatus.Text = "Save completed.";
            lblSaveStatus.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveScript();
        }

        private void frmScriptEditor_FormClosing(object sender, FormClosingEventArgs e)
        {            
            if (closePending || saving)
                e.Cancel = true;
            else if (btnSave.Enabled)
            {
                DialogResult result = AskForSave();

                switch (result)
                {
                    case DialogResult.Yes:
                        e.Cancel = true;
                        closePending = true;
                        SaveScript();
                        break;

                    case DialogResult.No:
                        e.Cancel = false;
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }
    }
}