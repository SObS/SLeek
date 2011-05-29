using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using libsecondlife;
using libsecondlife.Packets;
using SLNetworkComm;

namespace SLeek
{
    public class RegionSearchResultItem
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;

        private GridRegion region;
        private System.Drawing.Image mapImage;

        private ListBox listBox;
        private int listIndex;

        private bool imageDownloading = false;
        private bool imageDownloaded = false;

        private bool gettingAgentCount = false;
        private bool gotAgentCount = false;
        private BackgroundWorker agentCountWorker;

        public RegionSearchResultItem(SleekInstance instance, GridRegion region, ListBox listBox)
        {
            this.instance = instance;
            netcom = this.instance.Netcom;
            client = this.instance.Client;
            this.region = region;
            this.listBox = listBox;

            agentCountWorker = new BackgroundWorker();
            agentCountWorker.DoWork += new DoWorkEventHandler(agentCountWorker_DoWork);
            agentCountWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(agentCountWorker_RunWorkerCompleted);

            AddClientEvents();
        }

        private void agentCountWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<libsecondlife.GridItem> items =
                client.Grid.MapItems(
                    region.RegionHandle,
                    libsecondlife.GridItemType.AgentLocations,
                    GridLayerType.Terrain, 500);

            if (items != null)
                e.Result = (byte)items.Count;
        }

        private void agentCountWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gettingAgentCount = false;
            gotAgentCount = true;

            if (e.Result != null)
                region.Agents = (byte)e.Result;

            RefreshListBox();
        }

        private void AddClientEvents()
        {
            client.Assets.OnImageReceived += new AssetManager.ImageReceivedCallback(Assets_OnImageReceived);
        }

        //Separate thread
        private void Assets_OnImageReceived(ImageDownload image, AssetTexture texture)
        {
            if (image.ID != region.MapImageID) return;
            if (image.AssetData == null) return;

            mapImage = ImageHelper.Decode(image.AssetData);
            if (mapImage == null) return;

            instance.ImageCache.AddImage(image.ID, mapImage);

            imageDownloading = false;
            imageDownloaded = true;
            listBox.BeginInvoke(new MethodInvoker(RefreshListBox));
            listBox.BeginInvoke(new OnMapImageRaise(OnMapImageDownloaded), new object[] { EventArgs.Empty });
        }

        //UI thread
        private void RefreshListBox()
        {
            listBox.Refresh();
        }

        public void RequestMapImage(float priority)
        {
            if (region.MapImageID == LLUUID.Zero || region.MapImageID == null)
            {
                imageDownloaded = true;
                OnMapImageDownloaded(EventArgs.Empty);
                return;
            }

            if (instance.ImageCache.ContainsImage(region.MapImageID))
            {
                mapImage = instance.ImageCache.GetImage(region.MapImageID);
                imageDownloaded = true;
                OnMapImageDownloaded(EventArgs.Empty);
                RefreshListBox();
            }
            else
            {
                client.Assets.RequestImage(region.MapImageID, ImageType.Normal, priority, 0);
                imageDownloading = true;
            }
        }

        public void RequestAgentLocations()
        {
            gettingAgentCount = true;
            agentCountWorker.RunWorkerAsync();
        }

        public override string ToString()
        {
            return region.Name;
        }

        public event EventHandler MapImageDownloaded;
        private delegate void OnMapImageRaise(EventArgs e);
        protected virtual void OnMapImageDownloaded(EventArgs e)
        {
            if (MapImageDownloaded != null) MapImageDownloaded(this, e);
        }

        public GridRegion Region
        {
            get { return region; }
        }

        public System.Drawing.Image MapImage
        {
            get { return mapImage; }
        }

        public bool IsImageDownloaded
        {
            get { return imageDownloaded; }
        }

        public bool IsImageDownloading
        {
            get { return imageDownloading; }
        }

        public bool GettingAgentCount
        {
            get { return gettingAgentCount; }
        }

        public bool GotAgentCount
        {
            get { return gotAgentCount; }
        }

        public int ListIndex
        {
            get { return listIndex; }
            set { listIndex = value; }
        }
    }
}
