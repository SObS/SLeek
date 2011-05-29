using System;
using System.Collections.Generic;
using System.Text;
using libsecondlife;

namespace SLNetworkComm
{
    public class TeleportStatusEventArgs : EventArgs
    {
        private string message;
        private AgentManager.TeleportStatus status;
        private AgentManager.TeleportFlags flags;

        public TeleportStatusEventArgs(string message, AgentManager.TeleportStatus status, AgentManager.TeleportFlags flags)
        {
            this.message = message;
            this.status = status;
            this.flags = flags;
        }

        public string Message
        {
            get { return message; }
        }

        public AgentManager.TeleportStatus Status
        {
            get { return status; }
        }

        public AgentManager.TeleportFlags Flags
        {
            get { return flags; }
        }
    }
}
