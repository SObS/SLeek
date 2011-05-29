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
    public partial class frmNotecardEditor : Form
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;
        private InventoryItem item;
        private LLUUID uploadID;
        private LLUUID transferID;
        private AssetNotecard receivedAsset;

        private bool closePending = false;
        private bool saving = false;

        public frmNotecardEditor(SleekInstance instance, InventoryItem item)
        {
            InitializeComponent();

            this.instance = instance;
            netcom = this.instance.Netcom;
            client = this.instance.Client;
            this.item = item;
            AddNetcomEvents();
            
            this.Text = item.Name + " (notecard) - SLeek";

            client.Assets.OnAssetReceived += new AssetManager.AssetReceivedCallback(Assets_OnAssetReceived);
            transferID = client.Assets.RequestInventoryAsset(item.AssetUUID, item.UUID, LLUUID.Zero, item.OwnerID, item.AssetType, false);
        }

        //Separate thread
        private void Assets_OnAssetReceived(AssetDownload transfer, Asset asset)
        {
            if (transfer.ID != transferID) return;

            string notecardContent;

            if (!transfer.Success)
            {
                notecardContent = "Unable to download notecard.";
                BeginInvoke(new OnSetNotecardText(SetNotecardText), new object[] { notecardContent, true });
                return;
            }

            receivedAsset = (AssetNotecard)asset;
            notecardContent = Helpers.FieldToUTF8String(transfer.AssetData);
            BeginInvoke(new OnSetNotecardText(SetNotecardText), new object[] { notecardContent, false });
        }

        //UI thread
        private delegate void OnSetNotecardText(string text, bool readOnly);
        private void SetNotecardText(string text, bool readOnly)
        {
            rtbNotecard.Clear();
            rtbNotecard.Text = text;

            if (readOnly)
            {
                rtbNotecard.ReadOnly = true;
                rtbNotecard.BackColor = Color.FromKnownColor(KnownColor.Control);
            }
            else
            {
                rtbNotecard.ReadOnly = false;
                rtbNotecard.BackColor = Color.White;
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

        private void rtbNotecard_TextChanged(object sender, EventArgs e)
        {
            if (!rtbNotecard.ReadOnly)
                btnSave.Enabled = true;
        }

        private DialogResult AskForSave()
        {
            return MessageBox.Show(
                "Your changes have not been saved. Save the notecard?",
                "SLeek",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
        }

        private void SaveNotecard()
        {
            saving = true;

            rtbNotecard.ReadOnly = true;
            rtbNotecard.BackColor = Color.FromKnownColor(KnownColor.Control);

            lblSaveStatus.Text = "Saving notecard...";
            lblSaveStatus.Visible = true;
            btnSave.Enabled = false;
            btnClose.Enabled = false;

            receivedAsset.Text = rtbNotecard.Text;

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

        private void SaveComplete()
        {
            rtbNotecard.ReadOnly = false;
            rtbNotecard.BackColor = Color.White;
            btnClose.Enabled = true;

            lblSaveStatus.Text = "Save completed.";
            lblSaveStatus.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveNotecard();
        }

        private void frmNotecardEditor_FormClosing(object sender, FormClosingEventArgs e)
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
                        SaveNotecard();
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