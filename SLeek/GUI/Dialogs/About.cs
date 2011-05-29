using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SLeek
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();

            lblVersion.Text = Properties.Resources.SleekTitle;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://delta.slinked.net/second-life/sleek/");
        }

        private void lnkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:deltaphc@gmail.com");
        }
    }
}