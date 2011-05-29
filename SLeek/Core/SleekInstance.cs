using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SLNetworkComm;
using libsecondlife;

namespace SLeek
{
    public class SleekInstance
    {
        private SecondLife client;
        private SLNetCom netcom;

        private ImageCache imageCache;
        private StateManager state;
        private ConfigManager config;

        private frmMain mainForm;
        private TabsConsole tabsConsole;

        private bool firstInstance;
        private bool otherInstancesOpen = false;

        public SleekInstance(bool firstInstance)
        {
            this.firstInstance = firstInstance;

            client = new SecondLife();
            client.Settings.ALWAYS_REQUEST_OBJECTS = true;
            client.Settings.ALWAYS_DECODE_OBJECTS = true;
            client.Settings.OBJECT_TRACKING = true;
            client.Settings.ENABLE_SIMSTATS = true;
            client.Settings.FETCH_MISSING_INVENTORY = true;
            client.Settings.MULTIPLE_SIMS = true;
            client.Settings.SEND_AGENT_THROTTLE = true;
            client.Settings.SEND_AGENT_UPDATES = true;
            
            netcom = new SLNetCom(client);

            imageCache = new ImageCache();
            state = new StateManager(this);
            InitializeConfig();

            mainForm = new frmMain(this);
            mainForm.InitializeControls();
            tabsConsole = mainForm.TabConsole;

            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            config.SaveCurrentConfig();
        }

        private void InitializeConfig()
        {
            config = new ConfigManager();
            config.ApplyDefault();

            netcom.LoginOptions.FirstName = config.CurrentConfig.FirstName;
            netcom.LoginOptions.LastName = config.CurrentConfig.LastName;
            netcom.LoginOptions.Password = config.CurrentConfig.PasswordMD5;
            netcom.LoginOptions.IsPasswordMD5 = true;
        }

        public SecondLife Client
        {
            get { return client; }
        }

        public SLNetCom Netcom
        {
            get { return netcom; }
        }

        public ImageCache ImageCache
        {
            get { return imageCache; }
        }

        public StateManager State
        {
            get { return state; }
        }

        public ConfigManager Config
        {
            get { return config; }
        }

        public frmMain MainForm
        {
            get { return mainForm; }
        }

        public TabsConsole TabConsole
        {
            get { return tabsConsole; }
        }

        public bool IsFirstInstance
        {
            get { return firstInstance; }
        }

        public bool OtherInstancesOpen
        {
            get { return otherInstancesOpen; }
            set { otherInstancesOpen = value; }
        }
    }
}
