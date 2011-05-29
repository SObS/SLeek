using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using libsecondlife;

namespace SLeek
{
    public class InventoryClipboard
    {
        private SecondLife client;
        private TreeNode clipNode;
        private InventoryBase clipItem;
        private bool cut = false;

        public InventoryClipboard(SecondLife client)
        {
            this.client = client;
        }

        public void SetClipboardNode(TreeNode itemNode, bool cut)
        {
            clipNode = itemNode;
            clipItem = (InventoryBase)itemNode.Tag;
            
            this.cut = cut;
            if (cut)
            {
                if (clipNode.Parent.Nodes.Count == 1)
                    clipNode.Parent.Collapse();

                clipNode.Remove();
            }
        }

        public void PasteTo(TreeNode pasteNode)
        {
            if (clipNode == null) return;

            InventoryBase pasteio = (InventoryBase)pasteNode.Tag;

            if (clipItem is InventoryFolder)
            {
                InventoryFolder folder = (InventoryFolder)clipItem;

                if (cut)
                {
                    if (pasteio is InventoryFolder)
                    {
                        client.Inventory.MoveFolder(folder.UUID, pasteio.UUID);
                        pasteNode.Nodes.Add(clipNode);
                    }
                    else if (pasteio is InventoryItem)
                    {
                        client.Inventory.MoveFolder(folder.UUID, pasteio.ParentUUID);
                        pasteNode.Parent.Nodes.Add(clipNode);
                    }

                    clipNode.EnsureVisible();
                    clipNode = null;
                    clipItem = null;
                }
                else
                {
                    //TODO: handle copying
                }
            }
            else if (clipItem is InventoryItem)
            {
                InventoryItem item = (InventoryItem)clipItem;

                if (cut)
                {
                    if (pasteio is InventoryFolder)
                    {
                        client.Inventory.MoveItem(item.UUID, pasteio.UUID);
                        pasteNode.Nodes.Add(clipNode);
                    }
                    else if (pasteio is InventoryItem)
                    {
                        client.Inventory.MoveItem(item.UUID, pasteio.ParentUUID);
                        pasteNode.Parent.Nodes.Add(clipNode);
                    }

                    clipNode.EnsureVisible();
                    clipNode = null;
                    clipItem = null;
                }
                else
                {
                    //TODO: handle copying
                }
            }
        }

        public InventoryBase CurrentClipItem
        {
            get { return clipItem; }
        }

        public TreeNode CurrentClipNode
        {
            get { return clipNode; }
        }
    }
}
