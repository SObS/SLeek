using System;
using System.Collections;
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
    public partial class InventoryConsole : UserControl
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;
        
        private Dictionary<LLUUID, TreeNode> treeLookup = new Dictionary<LLUUID, TreeNode>();
        private InventoryTreeSorter treeSorter = new InventoryTreeSorter();

        private InventoryClipboard clip;
        private InventoryItemConsole currentProperties;

        private InventoryManager.FolderUpdatedCallback folderUpdate;
        private InventoryManager.ItemReceivedCallback itemReceived;
        private InventoryManager.ObjectOfferedCallback objectOffer;

        public InventoryConsole(SleekInstance instance)
        {
            InitializeComponent();

            this.instance = instance;
            netcom = this.instance.Netcom;
            client = this.instance.Client;
            clip = new InventoryClipboard(client);
            
            ApplyConfig(this.instance.Config.CurrentConfig);
            this.instance.Config.ConfigApplied += new EventHandler<ConfigAppliedEventArgs>(Config_ConfigApplied);
            
            this.Disposed += new EventHandler(InventoryConsole_Disposed);
            InitializeImageList();
            InitializeTree();
            GetRoot();
        }

        private void InitializeImageList()
        {
            ilsInventory.Images.Add("ArrowForward", Properties.Resources.arrow_forward_16);
            ilsInventory.Images.Add("ClosedFolder", Properties.Resources.folder_closed_16);
            ilsInventory.Images.Add("OpenFolder", Properties.Resources.folder_open_16);
            ilsInventory.Images.Add("Gear", Properties.Resources.applications_16);
            ilsInventory.Images.Add("Notecard", Properties.Resources.documents_16);
            ilsInventory.Images.Add("Script", Properties.Resources.lsl_scripts_16);
        }
        
        private void InitializeTree()
        {
            foreach (ITreeSortMethod method in treeSorter.GetSortMethods())
            {
                ToolStripMenuItem item = (ToolStripMenuItem)tbtnSort.DropDown.Items.Add(method.Name);
                item.ToolTipText = method.Description;
                item.Name = method.Name;
                item.Click += new EventHandler(SortMethodClick);
            }

            ((ToolStripMenuItem)tbtnSort.DropDown.Items[0]).PerformClick();
            treInventory.TreeViewNodeSorter = treeSorter;

            folderUpdate = new InventoryManager.FolderUpdatedCallback(Inventory_OnFolderUpdated);
            itemReceived = new InventoryManager.ItemReceivedCallback(Inventory_OnItemReceived);
            objectOffer = new InventoryManager.ObjectOfferedCallback(Inventory_OnObjectOffered);
            client.Inventory.OnFolderUpdated += folderUpdate;
            client.Inventory.OnItemReceived += itemReceived;
            client.Inventory.OnObjectOffered += objectOffer;
        }

        //Seperate thread
        private void Inventory_OnItemReceived(InventoryItem item)
        {
            BeginInvoke(
                new InventoryManager.ItemReceivedCallback(ReceivedInventoryItem),
                new object[] { item });
        }

        //UI thread
        private void ReceivedInventoryItem(InventoryItem item)
        {
            ProcessIncomingObject(item);
        }

        //Separate thread
        private bool Inventory_OnObjectOffered(LLUUID fromAgentID, string fromAgentName, uint parentEstateID, LLUUID regionID, LLVector3 position, DateTime timestamp, AssetType type, LLUUID objectID, bool fromTask)
        {
            BeginInvoke(
                new InventoryManager.ObjectOfferedCallback(ReceivedInventoryOffer),
                new object[] { fromAgentID, fromAgentName, parentEstateID, regionID, position, timestamp, type, objectID, fromTask });

            return true;
        }

        //UI thread
        private bool ReceivedInventoryOffer(LLUUID fromAgentID, string fromAgentName, uint parentEstateID, LLUUID regionID, LLVector3 position, DateTime timestamp, AssetType type, LLUUID objectID, bool fromTask)
        {
            if (!client.Inventory.Store.Contains(objectID)) return true;

            InventoryBase invObj = client.Inventory.Store[objectID];
            ProcessIncomingObject(invObj);
            
            return true;
        }

        //Seperate thread
        private void Inventory_OnFolderUpdated(LLUUID folderID)
        {
            BeginInvoke(
                new InventoryManager.FolderUpdatedCallback(FolderDownloadFinished),
                new object[] { folderID });
        }

        //UI thread
        private void FolderDownloadFinished(LLUUID folderID)
        {
            InventoryBase invObj = client.Inventory.Store[folderID];
            ProcessIncomingObject(invObj);
        }

        private void GetRoot()
        {
            InventoryFolder rootFolder = client.Inventory.Store.RootFolder;
            TreeNode rootNode = treInventory.Nodes.Add(rootFolder.UUID.ToString(), "My Inventory");
            rootNode.Tag = rootFolder;
            rootNode.ImageKey = "ClosedFolder";

            treeLookup.Add(rootFolder.UUID, rootNode);
            
            //Triggers treInventory's AfterExpand event, thus triggering the root content request
            rootNode.Nodes.Add("Requesting folder contents...");
            rootNode.Expand();
        }

        private void Config_ConfigApplied(object sender, ConfigAppliedEventArgs e)
        {
            ApplyConfig(e.AppliedConfig);
        }

        private void ApplyConfig(Config config)
        {
            if (config.InterfaceStyle == 0)
                tstInventory.RenderMode = ToolStripRenderMode.System;
            else if (config.InterfaceStyle == 1)
                tstInventory.RenderMode = ToolStripRenderMode.ManagerRenderMode;
        }

        private void InventoryConsole_Disposed(object sender, EventArgs e)
        {
            CleanUp();
        }

        public void CleanUp()
        {
            ClearCurrentProperties();

            client.Inventory.OnFolderUpdated -= folderUpdate;
            client.Inventory.OnObjectOffered -= objectOffer;
        }

        private void SortMethodClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(treeSorter.CurrentSortName))
                ((ToolStripMenuItem)tbtnSort.DropDown.Items[treeSorter.CurrentSortName]).Checked = false;

            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            treeSorter.CurrentSortName = item.Text;

            treInventory.BeginUpdate();
            treInventory.Sort();
            treInventory.EndUpdate();

            item.Checked = true;
        }


        private void ProcessIncomingObject(InventoryBase io)
        {
            if (io is InventoryFolder)
            {
                InventoryFolder folder = (InventoryFolder)io;
                TreeNode node = treeLookup[folder.UUID];

                treInventory.BeginUpdate();
                node.Nodes.Clear();

                List<InventoryBase> folderContents = client.Inventory.Store.GetContents(folder);
                if (folderContents.Count > 0)
                {
                    ProcessInventoryItems(folderContents, node);
                    treInventory.Sort();

                    if (!node.IsVisible)
                    {
                        node.LastNode.EnsureVisible();
                        node.EnsureVisible();
                    }
                }

                treInventory.EndUpdate();
            }
            else if (io is InventoryItem)
            {
                InventoryItem item = (InventoryItem)io;
                TreeNode node = treeLookup[item.ParentUUID];

                treInventory.BeginUpdate();

                TreeNode itemNode = AddTreeItem(item, node);
                treInventory.Sort();
                
                if (!itemNode.IsVisible)
                {
                    if (node.IsExpanded)
                    {
                        node.LastNode.EnsureVisible();
                        itemNode.EnsureVisible();
                    }
                }

                treInventory.EndUpdate();
            }
        }

        private TreeNode AddTreeFolder(InventoryFolder folder, TreeNode node)
        {
            if (treeLookup.ContainsKey(folder.UUID))
                return treeLookup[folder.UUID];

            TreeNode folderNode = node.Nodes.Add(folder.UUID.ToString(), folder.Name);
            folderNode.Tag = folder;
            folderNode.ImageKey = "ClosedFolder";

            treeLookup.Add(folder.UUID, folderNode);
            return folderNode;
        }

        private TreeNode AddTreeItem(InventoryItem item, TreeNode node)
        {
            if (treeLookup.ContainsKey(item.UUID))
                return treeLookup[item.UUID];

            TreeNode itemNode = node.Nodes.Add(item.UUID.ToString(), item.Name);
            itemNode.Tag = item;

            switch (item.InventoryType)
            {
                case InventoryType.Wearable:
                    itemNode.ImageKey = "Gear"; //TODO: use "clothing" key instead
                    break;

                case InventoryType.Notecard:
                    itemNode.ImageKey = "Notecard";
                    break;

                case InventoryType.LSL:
                    itemNode.ImageKey = "Script";
                    break;

                case InventoryType.Texture:
                    itemNode.ImageKey = "Gear"; //TODO: use "image" key instead
                    break;

                default:
                    itemNode.ImageKey = "Gear";
                    break;
            }

            treeLookup.Add(item.UUID, itemNode);
            return itemNode;
        }

        //Recursive! :o
        private void ProcessInventoryItems(List<InventoryBase> list, TreeNode node)
        {
            if (list == null) return;

            foreach (InventoryBase item in list)
            {
                if (item is InventoryFolder)
                {
                    InventoryFolder folder = (InventoryFolder)item;
                    TreeNode folderNode = AddTreeFolder(folder, node);

                    List<InventoryBase> contents = client.Inventory.Store.GetContents(folder);
                    if (contents.Count > 0)
                        ProcessInventoryItems(contents, folderNode);
                    else
                        folderNode.Nodes.Add("Requesting folder contents...");
                }
                else if (item is InventoryItem)
                {
                    AddTreeItem((InventoryItem)item, node);
                }
            }
        }

        private void AddNewFolder(string folderName, TreeNode node)
        {
            if (node == null) return;

            InventoryFolder folder = null;
            TreeNode folderNode = null;

            if (node.Tag is InventoryFolder)
            {
                folder = (InventoryFolder)node.Tag;
                folderNode = node;
            }
            else if (node.Tag is InventoryItem)
            {
                folder = (InventoryFolder)node.Parent.Tag;
                folderNode = node.Parent;
            }

            treInventory.BeginUpdate();

            LLUUID newFolderID = client.Inventory.CreateFolder(folder.UUID, folderName, AssetType.Folder);
            InventoryFolder newFolder = (InventoryFolder)client.Inventory.Store[newFolderID];
            TreeNode newNode = AddTreeFolder(newFolder, folderNode);

            treInventory.Sort();
            treInventory.EndUpdate();
        }

        private void AddNewNotecard(string notecardName, string notecardDescription, string notecardContent, TreeNode node)
        {
            if (node == null) return;

            InventoryFolder folder = null;
            TreeNode folderNode = null;

            if (node.Tag is InventoryFolder)
            {
                folder = (InventoryFolder)node.Tag;
                folderNode = node;
            }
            else if (node.Tag is InventoryItem)
            {
                folder = (InventoryFolder)node.Parent.Tag;
                folderNode = node.Parent;
            }

            InventoryManager.ItemCreatedCallback itemCreated =
                new InventoryManager.ItemCreatedCallback(delegate(bool success, InventoryItem item)
                {
                    if (!success) return;

                    treInventory.BeginUpdate();
                    
                    AddTreeItem(item, folderNode);
                    
                    treInventory.Sort();
                    treInventory.EndUpdate();
                });

            client.Inventory.RequestCreateItem(
                folder.UUID, notecardName, notecardDescription,
                AssetType.Notecard, InventoryType.Notecard, PermissionMask.All,
                itemCreated);
        }

        private void AddNewScript(string name, string description, string content, TreeNode node)
        {
            if (node == null) return;

            InventoryFolder folder = null;
            TreeNode folderNode = null;

            if (node.Tag is InventoryFolder)
            {
                folder = (InventoryFolder)node.Tag;
                folderNode = node;
            }
            else if (node.Tag is InventoryItem)
            {
                folder = (InventoryFolder)node.Parent.Tag;
                folderNode = node.Parent;
            }

            InventoryManager.ItemCreatedCallback itemCreated =
                new InventoryManager.ItemCreatedCallback(delegate(bool success, InventoryItem item)
                {
                    if (!success) return;

                    treInventory.BeginUpdate();

                    AddTreeItem(item, folderNode);

                    treInventory.Sort();
                    treInventory.EndUpdate();
                });

            client.Inventory.RequestCreateItem(
                folder.UUID, name, description,
                AssetType.LSLText, InventoryType.LSL, PermissionMask.All,
                itemCreated);
        }

        private void DeleteItem(TreeNode node)
        {
            if (node == null) return;

            InventoryBase io = (InventoryBase)node.Tag;

            if (io is InventoryFolder)
            {
                InventoryFolder folder = (InventoryFolder)io;
                treeLookup.Remove(folder.UUID);
                client.Inventory.RemoveFolder(folder.UUID);
                folder = null;
            }
            else if (io is InventoryItem)
            {
                InventoryItem item = (InventoryItem)io;
                treeLookup.Remove(item.UUID);
                client.Inventory.RemoveItem(item.UUID);
                item = null;
            }

            io = null;

            node.Remove();
            node = null;
        }

        private void treInventory_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes[0].Tag == null)
            {
                InventoryFolder folder = (InventoryFolder)e.Node.Tag;
                client.Inventory.RequestFolderContents(folder.UUID, client.Self.AgentID, true, true, InventorySortOrder.ByName);                
            }

            e.Node.ImageKey = "OpenFolder";
        }

        private void treInventory_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageKey = "ClosedFolder";
        }

        private void tmnuNewFolder_Click(object sender, EventArgs e)
        {
            string newFolderName = "New Folder";

            if (treInventory.SelectedNode == null)
                AddNewFolder(newFolderName, treInventory.Nodes[0]);
            else
                AddNewFolder(newFolderName, treInventory.SelectedNode);
        }

        private void ClearCurrentProperties()
        {
            if (currentProperties == null) return;

            currentProperties.CleanUp();
            currentProperties.Dispose();
            currentProperties = null;
        }

        private void RefreshPropertiesPane()
        {
            if (treInventory.SelectedNode == null) return;

            InventoryBase io = (InventoryBase)treInventory.SelectedNode.Tag;
            if (io is InventoryItem)
            {
                InventoryItemConsole console = new InventoryItemConsole(instance, (InventoryItem)io);
                console.Dock = DockStyle.Fill;
                splitContainer1.Panel2.Controls.Add(console);

                ClearCurrentProperties();
                currentProperties = console;
            }
            else
            {
                ClearCurrentProperties();
            }
        }

        private void treInventory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tbtnNew.Enabled = tbtnOrganize.Enabled = (treInventory.SelectedNode != null);
            RefreshPropertiesPane();
        }

        private void tmnuDelete_Click(object sender, EventArgs e)
        {
            DeleteItem(treInventory.SelectedNode);
        }

        private void tmnuRename_Click(object sender, EventArgs e)
        {
            treInventory.SelectedNode.BeginEdit();
        }

        private void treInventory_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.CancelEdit) return;

            e.CancelEdit = true; //temporary until we can actually rename stuff

            /*
            if (e.Node.Tag is InventoryFolder)
                ((InventoryFolder)e.Node.Tag).Name = e.Label;
            else if (e.Node.Tag is InventoryItem)
                ((InventoryItem)e.Node.Tag).Name = e.Label;
            

            e.Node.Text = e.Label;
            */
        }

        private void tmnuNewNotecard_Click(object sender, EventArgs e)
        {
            string newNotecardName = "New Notecard";
            string newNotecardDescription = string.Empty;
            string newNotecardContent = string.Empty;

            if (treInventory.SelectedNode == null)
                AddNewNotecard(
                    newNotecardName,
                    newNotecardDescription,
                    newNotecardContent,
                    treInventory.Nodes[0]);
            else
                AddNewNotecard(
                    newNotecardName,
                    newNotecardDescription,
                    newNotecardContent,
                    treInventory.SelectedNode);
        }

        private void tmnuCut_Click(object sender, EventArgs e)
        {
            clip.SetClipboardNode(treInventory.SelectedNode, true);
            tmnuPaste.Enabled = true;
        }

        private void tmnuPaste_Click(object sender, EventArgs e)
        {
            clip.PasteTo(treInventory.SelectedNode);
            tmnuPaste.Enabled = false;
        }

        private void tmnuNewScript_Click(object sender, EventArgs e)
        {
            string newScriptName = "New Script";
            string newScriptDescription = string.Empty;
            string newScriptContent = string.Empty;

            if (treInventory.SelectedNode == null)
                AddNewScript(
                    newScriptName,
                    newScriptDescription,
                    newScriptContent,
                    treInventory.Nodes[0]);
            else
                AddNewScript(
                    newScriptName,
                    newScriptDescription,
                    newScriptContent,
                    treInventory.SelectedNode);
        }
    }
}
