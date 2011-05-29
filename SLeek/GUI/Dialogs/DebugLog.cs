using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using libsecondlife;
using SLNetworkComm;

namespace SLeek
{
    public partial class frmDebugLog : Form
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;

        //Workaround for window handle exception on login
        private List<DebugLogMessage> initQueue = new List<DebugLogMessage>();

        public frmDebugLog(SleekInstance instance)
        {
            InitializeComponent();

            this.instance = instance;
            netcom = this.instance.Netcom;
            client = this.instance.Client;
            AddClientEvents();

            this.Disposed += new EventHandler(frmDebugLog_Disposed);
        }

        private void frmDebugLog_Disposed(object sender, EventArgs e)
        {
            client.OnLogMessage -= new SecondLife.LogCallback(client_OnLogMessage);
        }

        private void AddClientEvents()
        {
            client.OnLogMessage += new SecondLife.LogCallback(client_OnLogMessage);
        }

        //comes in on separate thread
        private void client_OnLogMessage(string message, Helpers.LogLevel level)
        {
            if (this.IsHandleCreated)
                BeginInvoke(new SecondLife.LogCallback(ReceivedLogMessage), new object[] { message, level });
            else
                initQueue.Add(new DebugLogMessage(message, level));
        }

        //called on GUI thread
        private void ReceivedLogMessage(string message, Helpers.LogLevel level)
        {
            RichTextBox rtb = null;

            switch (level)
            {
                case Helpers.LogLevel.Info:
                    rtb = rtbInfo;
                    break;

                case Helpers.LogLevel.Warning:
                    rtb = rtbWarning;
                    break;

                case Helpers.LogLevel.Error:
                    rtb = rtbError;
                    break;

                case Helpers.LogLevel.Debug:
                    rtb = rtbDebug;
                    break;
            }

            rtb.AppendText("[" + DateTime.Now.ToString() + "] " + message + "\n");
        }

        private void ProcessLogMessage(DebugLogMessage logMessage)
        {
            ReceivedLogMessage(logMessage.Message, logMessage.Level);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void frmDebugLog_Shown(object sender, EventArgs e)
        {
            if (initQueue.Count > 0)
                foreach (DebugLogMessage msg in initQueue) ProcessLogMessage(msg);
        }
    }
}