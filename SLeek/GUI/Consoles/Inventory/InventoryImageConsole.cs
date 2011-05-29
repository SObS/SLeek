using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using SLNetworkComm;
using libsecondlife;

namespace SLeek
{
    public partial class InventoryImageConsole : UserControl
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;
        private InventoryItem item;

        public InventoryImageConsole(SleekInstance instance, InventoryItem item)
        {
            InitializeComponent();

            this.instance = instance;
            netcom = this.instance.Netcom;
            client = this.instance.Client;
            this.item = item;
            
            if (instance.ImageCache.ContainsImage(item.AssetUUID))
                SetFinalImage(instance.ImageCache.GetImage(item.AssetUUID));
            else
            {
                this.Disposed += new EventHandler(InventoryImageConsole_Disposed);
                client.Assets.OnImageReceived += new AssetManager.ImageReceivedCallback(Assets_OnImageReceived);
                client.Assets.RequestImage(item.AssetUUID, ImageType.Normal, 125000.0f, 0);
            }
        }

        private void InventoryImageConsole_Disposed(object sender, EventArgs e)
        {
            client.Assets.OnImageReceived -= new AssetManager.ImageReceivedCallback(Assets_OnImageReceived);
        }

        //comes in on separate thread
        private void Assets_OnImageReceived(ImageDownload image, AssetTexture texture)
        {
            if (image.ID != item.AssetUUID) return;

            BeginInvoke(new OnSetStatusText(SetStatusText), new object[] { "Image downloaded. Decoding..." });

            System.Drawing.Image decodedImage = ImageHelper.Decode(image.AssetData);

            if (decodedImage == null)
            {
                BeginInvoke(new OnSetStatusText(SetStatusText), new object[] { "D'oh! Error decoding image." });
                BeginInvoke(new MethodInvoker(DoErrorState));
                return;
            }

            instance.ImageCache.AddImage(image.ID, decodedImage);
            BeginInvoke(new OnSetFinalImage(SetFinalImage), new object[] { decodedImage });
        }

        //called on GUI thread
        private delegate void OnSetFinalImage(System.Drawing.Image finalImage);
        private void SetFinalImage(System.Drawing.Image finalImage)
        {
            pbxImage.Image = finalImage;

            pnlOptions.Visible = true;
            pnlStatus.Visible = false;
            
            if ((item.Permissions.OwnerMask & PermissionMask.Copy) == PermissionMask.Copy)
            {
                btnSave.Click += delegate(object sender, EventArgs e)
                {
                    if (sfdImage.ShowDialog() == DialogResult.OK)
                    {
                        switch (sfdImage.FilterIndex)
                        {
                            case 1: //BMP
                                pbxImage.Image.Save(sfdImage.FileName, ImageFormat.Bmp);
                                break;

                            case 2: //JPG
                                pbxImage.Image.Save(sfdImage.FileName, ImageFormat.Jpeg);
                                break;

                            case 3: //PNG
                                pbxImage.Image.Save(sfdImage.FileName, ImageFormat.Png);
                                break;

                            default:
                                pbxImage.Image.Save(sfdImage.FileName, ImageFormat.Bmp);
                                break;
                        }
                    }
                };

                btnSave.Enabled = true;
            }
        }

        //called on GUI thread
        private delegate void OnSetStatusText(string text);
        private void SetStatusText(string text)
        {
            lblStatus.Text = text;
        }

        private void DoErrorState()
        {
            lblStatus.Visible = true;
            lblStatus.ForeColor = Color.Red;
            proActivity.Visible = false;

            pnlStatus.Visible = true;
            pnlOptions.Visible = false;
        }
    }
}
