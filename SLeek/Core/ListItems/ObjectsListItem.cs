using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using libsecondlife;

namespace SLeek
{
    public class ObjectsListItem
    {
        private Primitive prim;
        private SecondLife client;
        private ListBox listBox;
        private bool gotProperties = false;
        private bool gettingProperties = false;

        public ObjectsListItem(Primitive prim, SecondLife client, ListBox listBox)
        {
            this.prim = prim;
            this.client = client;
            this.listBox = listBox;
        }

        public void RequestProperties()
        {
            if (string.IsNullOrEmpty(prim.PropertiesFamily.Name))
            {
                gettingProperties = true;
                client.Objects.OnObjectPropertiesFamily += new ObjectManager.ObjectPropertiesFamilyCallback(Objects_OnObjectPropertiesFamily);
                client.Objects.RequestObjectPropertiesFamily(client.Network.CurrentSim, prim.ID);
            }
            else
            {
                gotProperties = true;
                OnPropertiesReceived(EventArgs.Empty);
            }
        }

        private void Objects_OnObjectPropertiesFamily(Simulator simulator, LLObject.ObjectPropertiesFamily properties)
        {
            if (properties.ObjectID != prim.ID) return;

            gettingProperties = false;
            gotProperties = true;
            prim.PropertiesFamily = properties;

            listBox.BeginInvoke(
                new OnPropReceivedRaise(OnPropertiesReceived),
                new object[] { EventArgs.Empty });
        }

        public override string ToString()
        {
            return (string.IsNullOrEmpty(prim.PropertiesFamily.Name) ? "..." : prim.PropertiesFamily.Name);
        }

        public event EventHandler PropertiesReceived;
        private delegate void OnPropReceivedRaise(EventArgs e);
        protected virtual void OnPropertiesReceived(EventArgs e)
        {
            if (PropertiesReceived != null) PropertiesReceived(this, e);
        }

        public Primitive Prim
        {
            get { return prim; }
        }

        public bool GotProperties
        {
            get { return gotProperties; }
        }

        public bool GettingProperties
        {
            get { return gettingProperties; }
        }
    }
}
