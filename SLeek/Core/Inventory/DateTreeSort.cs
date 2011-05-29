using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using libsecondlife;

namespace SLeek
{
    public class DateTreeSort : ITreeSortMethod
    {
        private string name = "By Date";
        private string description = "Sorts items in the inventory tree according to date, starting with the newest.";

        #region ITreeSortMethod Members

        public int CompareNodes(InventoryBase x, InventoryBase y, TreeNode nodeX, TreeNode nodeY)
        {
            int returnVal = 0;

            if (x is InventoryItem && y is InventoryItem)
            {
                InventoryItem itemX = (InventoryItem)x;
                InventoryItem itemY = (InventoryItem)y;
                
                returnVal = -itemX.CreationDate.CompareTo(itemY.CreationDate);
            }
            else if (x is InventoryFolder && y is InventoryFolder)
                returnVal = nodeX.Text.CompareTo(nodeY.Text);
            else if (x is InventoryFolder && y is InventoryItem)
                returnVal = -1;
            else if (x is InventoryItem && y is InventoryFolder)
                returnVal = 1;

            return returnVal;
        }

        public string Name
        {
            get { return name; }
        }

        public string Description
        {
            get { return description; }
        }

        #endregion
    }
}
