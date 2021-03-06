using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using libsecondlife;

namespace SLeek
{
    public partial class frmPay : Form
    {
        private SleekInstance instance;
        private SecondLife client;
        private LLUUID target;
        private string name;

        public frmPay(SleekInstance instance, LLUUID target, string name)
        {
            InitializeComponent();

            this.instance = instance;
            client = this.instance.Client;

            this.target = target;
            this.name = txtPerson.Text = name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            client.Self.GiveAvatarMoney(target, (int)nudAmount.Value);
            this.Close();
        }
    }
}