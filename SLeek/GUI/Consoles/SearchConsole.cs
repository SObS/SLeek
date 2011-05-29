using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using libsecondlife;
using SLNetworkComm;

namespace SLeek
{
    public partial class SearchConsole : UserControl
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;

        private TabsConsole tabConsole;
        private FindPeopleConsole console;

        private string lastQuery = string.Empty;
        private int startResult = 0;

        private int totalResults = 0;

        public SearchConsole(SleekInstance instance)
        {
            InitializeComponent();

            this.instance = instance;
            netcom = this.instance.Netcom;
            client = this.instance.Client;
            AddClientEvents();

            tabConsole = this.instance.TabConsole;

            console = new FindPeopleConsole(instance, LLUUID.Random());
            console.Dock = DockStyle.Fill;
            console.SelectedIndexChanged += new EventHandler(console_SelectedIndexChanged);
            pnlFindPeople.Controls.Add(console);
        }

        private void console_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnNewIM.Enabled = btnProfile.Enabled = (console.SelectedName != null);
        }

        private void AddClientEvents()
        {
            client.Directory.OnDirPeopleReply += new DirectoryManager.DirPeopleReplyCallback(Directory_OnDirPeopleReply);
        }

        //Separate thread
        private void Directory_OnDirPeopleReply(LLUUID queryID, List<DirectoryManager.AgentSearchData> matchedPeople)
        {
            BeginInvoke(new DirectoryManager.DirPeopleReplyCallback(PeopleReply), new object[] { queryID, matchedPeople });
        }

        //UI thread
        private void PeopleReply(LLUUID queryID, List<DirectoryManager.AgentSearchData> matchedPeople)
        {
            if (console.QueryID != queryID) return;

            totalResults += matchedPeople.Count;
            lblResultCount.Text = totalResults.ToString() + " people found";

            txtPersonName.Enabled = true;
            btnFind.Enabled = true;

            btnNext.Enabled = (totalResults > 100);
            btnPrevious.Enabled = (startResult > 0);
        }

        private void txtPersonName_TextChanged(object sender, EventArgs e)
        {
            btnFind.Enabled = (txtPersonName.Text.Trim().Length > 2);
        }

        private void btnNewIM_Click(object sender, EventArgs e)
        {
            if (tabConsole.TabExists(console.SelectedName))
            {
                tabConsole.SelectTab(console.SelectedName);
                return;
            }

            tabConsole.AddIMTab(console.SelectedAgentUUID, client.Self.SessionID ^ console.SelectedAgentUUID, console.SelectedName);
            tabConsole.SelectTab(console.SelectedName);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            lastQuery = txtPersonName.Text;
            startResult = 0;
            StartFinding();
        }

        private void txtPersonName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            e.SuppressKeyPress = true;
            if (txtPersonName.Text.Trim().Length < 3) return;

            lastQuery = txtPersonName.Text;
            startResult = 0;
            StartFinding();
        }

        private void StartFinding()
        {
            totalResults = 0;
            lblResultCount.Text = "Searching for " + lastQuery;

            txtPersonName.Enabled = false;
            btnFind.Enabled = false;
            btnNewIM.Enabled = false;
            btnProfile.Enabled = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;

            console.ClearResults();
            console.QueryID = client.Directory.StartPeopleSearch(
                DirectoryManager.DirFindFlags.NameSort |
                DirectoryManager.DirFindFlags.SortAsc |
                DirectoryManager.DirFindFlags.People,
                lastQuery, startResult);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            startResult += 100;
            StartFinding();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            startResult -= 100;
            StartFinding();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            (new frmProfile(instance, console.SelectedName, console.SelectedAgentUUID)).Show();
        }

        private void txtPersonName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) e.SuppressKeyPress = true;
        }
    }
}
