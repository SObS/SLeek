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
    public partial class frmDisconnected : Form
    {
        private SleekInstance instance;
        private SLNetCom netcom;

        public frmDisconnected(SleekInstance instance, ClientDisconnectEventArgs e)
        {
            InitializeComponent();

            this.instance = instance;
            netcom = this.instance.Netcom;
            AddNetcomEvents();

            lblMessage.Text = e.Message;
        }

        private void AddNetcomEvents()
        {
            netcom.ClientLoggingIn += new EventHandler<OverrideEventArgs>(netcom_ClientLoggingIn);
            netcom.ClientLoginStatus += new EventHandler<ClientLoginEventArgs>(netcom_ClientLoginStatus);
        }

        private void netcom_ClientLoginStatus(object sender, ClientLoginEventArgs e)
        {
            if (e.Status == LoginStatus.Success)
                Close();
        }

        private void netcom_ClientLoggingIn(object sender, OverrideEventArgs e)
        {
            proReconnect.Visible = true;
            btnExit.Enabled = false;
            btnReconnect.Enabled = false;
        }

        private void btnReconnect_Click(object sender, EventArgs e)
        {
            netcom.Login();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            instance.MainForm.Close();
        }

        private void frmDisconnected_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (netcom.IsLoggingIn) e.Cancel = true;
        }
    }
}