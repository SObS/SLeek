using System;
using System.Collections.Generic;
using System.Text;
using libsecondlife;

namespace SLNetworkComm
{
    public class TeleportingEventArgs : OverrideEventArgs
    {
        private string _sim;
        private LLVector3 _coordinates;

        public TeleportingEventArgs(string sim, LLVector3 coordinates) : base()
        {
            _sim = sim;
            _coordinates = coordinates;
        }

        public string SimName
        {
            get { return _sim; }
        }

        public LLVector3 Coordinates
        {
            get { return _coordinates; }
        }
    }
}