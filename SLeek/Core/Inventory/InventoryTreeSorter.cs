using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using libsecondlife;

namespace SLeek
{
    public class InventoryTreeSorter : IComparer
    {
        private Dictionary<string, ITreeSortMethod> sortMethods = new Dictionary<string, ITreeSortMethod>();
        private string currentMethodName;
        private ITreeSortMethod currentMethod;

        public InventoryTreeSorter()
        {
            RegisterSortMethods();
            
            //because the Values property is gay and doesn't have an indexer
            foreach (ITreeSortMethod method in sortMethods.Values)
            {
                currentMethodName = method.Name;
                break;
            }
        }

        private void RegisterSortMethods()
        {
            AddSortMethod(new DateTreeSort());
            AddSortMethod(new NameTreeSort());
        }

        private void AddSortMethod(ITreeSortMethod sort)
        {
            sortMethods.Add(sort.Name, sort);
        }

        public List<ITreeSortMethod> GetSortMethods()
        {
            if (sortMethods.Values.Count == 0) return null;

            List<ITreeSortMethod> methods = new List<ITreeSortMethod>();

            foreach (ITreeSortMethod method in sortMethods.Values)
                methods.Add(method);

            return methods;
        }

        public string CurrentSortName
        {
            get { return currentMethodName; }
            set
            {
                if (!sortMethods.ContainsKey(value))
                    throw new Exception("The specified sort method does not exist.");

                currentMethodName = value;
                currentMethod = sortMethods[currentMethodName];
            }
        }

        #region IComparer Members

        public int Compare(object x, object y)
        {
            TreeNode nodeX = (TreeNode)x;
            TreeNode nodeY = (TreeNode)y;

            InventoryBase ibX = (InventoryBase)nodeX.Tag;
            InventoryBase ibY = (InventoryBase)nodeY.Tag;

            return currentMethod.CompareNodes(ibX, ibY, nodeX, nodeY);
        }

        #endregion
    }
}
