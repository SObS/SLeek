using System;
using System.Collections.Generic;
using System.Text;
using libsecondlife;

namespace SLNetworkComm
{
    public class OverrideEventArgs : EventArgs
    {
        private bool _cancel = false;

        public OverrideEventArgs()
        {

        }

        public OverrideEventArgs(bool cancel)
        {
            _cancel = cancel;
        }

        public bool Cancel
        {
            get { return _cancel; }
            set { _cancel = value; }
        }
    }
}