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
    public partial class FindPeopleConsole : UserControl
    {
        private SleekInstance instance;
        private SLNetCom netcom;
        private SecondLife client;

        private LLUUID queryID;
        private Dictionary<string, LLUUID> findPeopleResults;

        public event EventHandler SelectedIndexChanged;

        public FindPeopleConsole(SleekInstance instance, LLUUID queryID)
        {
            InitializeComponent();

            findPeopleResults = new Dictionary<string, LLUUID>();
            this.queryID = queryID;

            this.instance = instance;
            netcom = this.instance.Netcom;
            client = this.instance.Client;
            AddClientEvents();
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
            if (queryID != this.queryID) return;

            lvwFindPeople.BeginUpdate();

            foreach (DirectoryManager.AgentSearchData person in matchedPeople)
            {
                string fullName = person.FirstName + " " + person.LastName;
                findPeopleResults.Add(fullName, person.AgentID);

                ListViewItem item = lvwFindPeople.Items.Add(fullName);
                item.SubItems.Add(person.Online ? "Yes" : "No");
            }

            lvwFindPeople.Sort();
            lvwFindPeople.EndUpdate();
        }

        public void ClearResults()
        {
            findPeopleResults.Clear();
            lvwFindPeople.Items.Clear();
        }

        private void lvwFindPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedIndexChanged(e);
        }

        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            if (SelectedIndexChanged != null) SelectedIndexChanged(this, e);
        }

        public Dictionary<string, LLUUID> LLUUIDs
        {
            get { return findPeopleResults; }
        }

        public LLUUID QueryID
        {
            get { return queryID; }
            set { queryID = value; }
        }

        public int SelectedIndex
        {
            get
            {
                if (lvwFindPeople.SelectedItems == null) return -1;
                if (lvwFindPeople.SelectedItems.Count == 0) return -1;

                return lvwFindPeople.SelectedIndices[0];
            }
        }

        public string SelectedName
        {
            get
            {
                if (lvwFindPeople.SelectedItems == null) return string.Empty;
                if (lvwFindPeople.SelectedItems.Count == 0) return string.Empty;

                return lvwFindPeople.SelectedItems[0].Text;
            }
        }

        public bool SelectedOnlineStatus
        {
            get
            {
                if (lvwFindPeople.SelectedItems == null) return false;
                if (lvwFindPeople.SelectedItems.Count == 0) return false;

                string yesNo = lvwFindPeople.SelectedItems[0].SubItems[0].Text;

                if (yesNo == "Yes")
                    return true;
                else if (yesNo == "No")
                    return false;
                else
                    return false;
            }
        }

        public LLUUID SelectedAgentUUID
        {
            get
            {
                if (lvwFindPeople.SelectedItems == null) return null;
                if (lvwFindPeople.SelectedItems.Count == 0) return null;

                string name = lvwFindPeople.SelectedItems[0].Text;
                return findPeopleResults[name];
            }
        }
    }
}
