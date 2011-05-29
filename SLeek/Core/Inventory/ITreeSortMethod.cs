using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using libsecondlife;

namespace SLeek
{
    public interface ITreeSortMethod
    {
        int CompareNodes(InventoryBase x, InventoryBase y, TreeNode nodeX, TreeNode nodeY);

        string Name { get; }
        string Description { get; }
    }
}
