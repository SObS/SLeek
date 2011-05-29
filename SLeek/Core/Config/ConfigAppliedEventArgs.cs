using System;
using System.Collections.Generic;
using System.Text;

namespace SLeek
{
    public class ConfigAppliedEventArgs : EventArgs
    {
        private Config appliedConfig;

        public ConfigAppliedEventArgs(Config appliedConfig)
        {
            this.appliedConfig = appliedConfig;
        }

        public Config AppliedConfig
        {
            get { return appliedConfig; }
        }
    }
}
