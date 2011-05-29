using System;
using System.Collections.Generic;
using System.Text;
using libsecondlife;

namespace SLNetworkComm
{
    public class InstantMessageSentEventArgs : EventArgs
    {
        private string message;
        private LLUUID targetID;
        private LLUUID sessionID;
        private DateTime timestamp;

        public InstantMessageSentEventArgs(string message, LLUUID targetID, LLUUID sessionID, DateTime timestamp)
        {
            this.message = message;
            this.targetID = targetID;
            this.sessionID = sessionID;
            this.timestamp = timestamp;
        }

        public string Message
        {
            get { return message; }
        }

        public LLUUID TargetID
        {
            get { return targetID; }
        }

        public LLUUID SessionID
        {
            get { return sessionID; }
        }

        public DateTime Timestamp
        {
            get { return timestamp; }
        }
    }
}