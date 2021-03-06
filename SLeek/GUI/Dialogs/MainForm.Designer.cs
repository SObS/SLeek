namespace SLeek
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnSLeek = new System.Windows.Forms.ToolStripDropDownButton();
            this.tmnuNewWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tmnuPrefs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnHelp = new System.Windows.Forms.ToolStripDropDownButton();
            this.tmnuHelpReadme = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmnuDonate = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtnDebug = new System.Windows.Forms.ToolStripDropDownButton();
            this.tmnuDebugLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtnStatus = new System.Windows.Forms.ToolStripDropDownButton();
            this.tmnuStatusAway = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnuStatusBusy = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtnControl = new System.Windows.Forms.ToolStripDropDownButton();
            this.tmnuControlFly = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnuControlAlwaysRun = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnTeleport = new System.Windows.Forms.ToolStripButton();
            this.tbtnObjects = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlblLoginName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblMoneyBalance = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblHealth = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblRegionInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlblParcel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnSLeek,
            this.toolStripSeparator1,
            this.tbtnHelp,
            this.tbtnDebug,
            this.tbtnStatus,
            this.tbtnControl,
            this.toolStripSeparator2,
            this.tbtnTeleport,
            this.tbtnObjects});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(720, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnSLeek
            // 
            this.tbtnSLeek.AutoToolTip = false;
            this.tbtnSLeek.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmnuNewWindow,
            this.toolStripMenuItem3,
            this.tmnuPrefs,
            this.toolStripMenuItem2,
            this.tmnuExit});
            this.tbtnSLeek.Image = global::SLeek.Properties.Resources.computer_16;
            this.tbtnSLeek.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnSLeek.Name = "tbtnSLeek";
            this.tbtnSLeek.Size = new System.Drawing.Size(64, 22);
            this.tbtnSLeek.Text = "SLeek";
            // 
            // tmnuNewWindow
            // 
            this.tmnuNewWindow.Name = "tmnuNewWindow";
            this.tmnuNewWindow.Size = new System.Drawing.Size(155, 22);
            this.tmnuNewWindow.Text = "New Window";
            this.tmnuNewWindow.Click += new System.EventHandler(this.tmnuNewWindow_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 6);
            // 
            // tmnuPrefs
            // 
            this.tmnuPrefs.Image = global::SLeek.Properties.Resources.applications_16;
            this.tmnuPrefs.Name = "tmnuPrefs";
            this.tmnuPrefs.Size = new System.Drawing.Size(155, 22);
            this.tmnuPrefs.Text = "Preferences...";
            this.tmnuPrefs.Click += new System.EventHandler(this.tmnuPrefs_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 6);
            // 
            // tmnuExit
            // 
            this.tmnuExit.Name = "tmnuExit";
            this.tmnuExit.Size = new System.Drawing.Size(155, 22);
            this.tmnuExit.Text = "Exit";
            this.tmnuExit.Click += new System.EventHandler(this.tmnuExit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnHelp
            // 
            this.tbtnHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbtnHelp.AutoToolTip = false;
            this.tbtnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmnuHelpReadme,
            this.toolStripMenuItem1,
            this.tmnuDonate,
            this.tmnuAbout});
            this.tbtnHelp.Image = ((System.Drawing.Image)(resources.GetObject("tbtnHelp.Image")));
            this.tbtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnHelp.Name = "tbtnHelp";
            this.tbtnHelp.Size = new System.Drawing.Size(41, 22);
            this.tbtnHelp.Text = "Help";
            // 
            // tmnuHelpReadme
            // 
            this.tmnuHelpReadme.Name = "tmnuHelpReadme";
            this.tmnuHelpReadme.Size = new System.Drawing.Size(136, 22);
            this.tmnuHelpReadme.Text = "Readme...";
            this.tmnuHelpReadme.Click += new System.EventHandler(this.tmnuHelpReadme_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // tmnuDonate
            // 
            this.tmnuDonate.Name = "tmnuDonate";
            this.tmnuDonate.Size = new System.Drawing.Size(136, 22);
            this.tmnuDonate.Text = "Donate...";
            this.tmnuDonate.Click += new System.EventHandler(this.tmnuDonate_Click);
            // 
            // tmnuAbout
            // 
            this.tmnuAbout.Name = "tmnuAbout";
            this.tmnuAbout.Size = new System.Drawing.Size(136, 22);
            this.tmnuAbout.Text = "About...";
            this.tmnuAbout.Click += new System.EventHandler(this.tmnuAbout_Click);
            // 
            // tbtnDebug
            // 
            this.tbtnDebug.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbtnDebug.AutoToolTip = false;
            this.tbtnDebug.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtnDebug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmnuDebugLog});
            this.tbtnDebug.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDebug.Image")));
            this.tbtnDebug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDebug.Name = "tbtnDebug";
            this.tbtnDebug.Size = new System.Drawing.Size(51, 22);
            this.tbtnDebug.Text = "Debug";
            this.tbtnDebug.Visible = false;
            // 
            // tmnuDebugLog
            // 
            this.tmnuDebugLog.Name = "tmnuDebugLog";
            this.tmnuDebugLog.Size = new System.Drawing.Size(124, 22);
            this.tmnuDebugLog.Text = "Log...";
            this.tmnuDebugLog.Click += new System.EventHandler(this.tmnuDebugLog_Click);
            // 
            // tbtnStatus
            // 
            this.tbtnStatus.AutoToolTip = false;
            this.tbtnStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtnStatus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmnuStatusAway,
            this.tmnuStatusBusy});
            this.tbtnStatus.Enabled = false;
            this.tbtnStatus.Image = ((System.Drawing.Image)(resources.GetObject("tbtnStatus.Image")));
            this.tbtnStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnStatus.Name = "tbtnStatus";
            this.tbtnStatus.Size = new System.Drawing.Size(51, 22);
            this.tbtnStatus.Text = "Status";
            // 
            // tmnuStatusAway
            // 
            this.tmnuStatusAway.CheckOnClick = true;
            this.tmnuStatusAway.Name = "tmnuStatusAway";
            this.tmnuStatusAway.Size = new System.Drawing.Size(112, 22);
            this.tmnuStatusAway.Text = "Away";
            this.tmnuStatusAway.Click += new System.EventHandler(this.tmnuStatusAway_Click);
            // 
            // tmnuStatusBusy
            // 
            this.tmnuStatusBusy.CheckOnClick = true;
            this.tmnuStatusBusy.Name = "tmnuStatusBusy";
            this.tmnuStatusBusy.Size = new System.Drawing.Size(112, 22);
            this.tmnuStatusBusy.Text = "Busy";
            this.tmnuStatusBusy.Click += new System.EventHandler(this.tmnuStatusBusy_Click);
            // 
            // tbtnControl
            // 
            this.tbtnControl.AutoToolTip = false;
            this.tbtnControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtnControl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmnuControlFly,
            this.tmnuControlAlwaysRun});
            this.tbtnControl.Enabled = false;
            this.tbtnControl.Image = ((System.Drawing.Image)(resources.GetObject("tbtnControl.Image")));
            this.tbtnControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnControl.Name = "tbtnControl";
            this.tbtnControl.Size = new System.Drawing.Size(55, 22);
            this.tbtnControl.Text = "Control";
            // 
            // tmnuControlFly
            // 
            this.tmnuControlFly.CheckOnClick = true;
            this.tmnuControlFly.Name = "tmnuControlFly";
            this.tmnuControlFly.Size = new System.Drawing.Size(141, 22);
            this.tmnuControlFly.Text = "Fly";
            this.tmnuControlFly.Click += new System.EventHandler(this.tmnuControlFly_Click);
            // 
            // tmnuControlAlwaysRun
            // 
            this.tmnuControlAlwaysRun.CheckOnClick = true;
            this.tmnuControlAlwaysRun.Name = "tmnuControlAlwaysRun";
            this.tmnuControlAlwaysRun.Size = new System.Drawing.Size(141, 22);
            this.tmnuControlAlwaysRun.Text = "Always Run";
            this.tmnuControlAlwaysRun.Click += new System.EventHandler(this.tmnuControlAlwaysRun_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnTeleport
            // 
            this.tbtnTeleport.AutoToolTip = false;
            this.tbtnTeleport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtnTeleport.Enabled = false;
            this.tbtnTeleport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnTeleport.Name = "tbtnTeleport";
            this.tbtnTeleport.Size = new System.Drawing.Size(51, 22);
            this.tbtnTeleport.Text = "Teleport";
            this.tbtnTeleport.Click += new System.EventHandler(this.tbtnTeleport_Click);
            // 
            // tbtnObjects
            // 
            this.tbtnObjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtnObjects.Enabled = false;
            this.tbtnObjects.Image = ((System.Drawing.Image)(resources.GetObject("tbtnObjects.Image")));
            this.tbtnObjects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnObjects.Name = "tbtnObjects";
            this.tbtnObjects.Size = new System.Drawing.Size(48, 22);
            this.tbtnObjects.Text = "Objects";
            this.tbtnObjects.Click += new System.EventHandler(this.tbtnObjects_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblLoginName,
            this.tlblMoneyBalance,
            this.tlblHealth,
            this.tlblRegionInfo,
            this.tlblParcel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 534);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(720, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlblLoginName
            // 
            this.tlblLoginName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tlblLoginName.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tlblLoginName.Name = "tlblLoginName";
            this.tlblLoginName.Size = new System.Drawing.Size(43, 17);
            this.tlblLoginName.Text = "Offline";
            // 
            // tlblMoneyBalance
            // 
            this.tlblMoneyBalance.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tlblMoneyBalance.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tlblMoneyBalance.Name = "tlblMoneyBalance";
            this.tlblMoneyBalance.Size = new System.Drawing.Size(28, 17);
            this.tlblMoneyBalance.Text = "L$0";
            // 
            // tlblHealth
            // 
            this.tlblHealth.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tlblHealth.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tlblHealth.Name = "tlblHealth";
            this.tlblHealth.Size = new System.Drawing.Size(55, 17);
            this.tlblHealth.Text = "Health: 0";
            // 
            // tlblRegionInfo
            // 
            this.tlblRegionInfo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tlblRegionInfo.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tlblRegionInfo.Name = "tlblRegionInfo";
            this.tlblRegionInfo.Size = new System.Drawing.Size(60, 17);
            this.tlblRegionInfo.Text = "No Region";
            // 
            // tlblParcel
            // 
            this.tlblParcel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tlblParcel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.tlblParcel.Name = "tlblParcel";
            this.tlblParcel.Size = new System.Drawing.Size(56, 17);
            this.tlblParcel.Text = "No Parcel";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(720, 509);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            this.toolStripContainer1.LeftToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            this.toolStripContainer1.RightToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripContainer1.Size = new System.Drawing.Size(720, 534);
            this.toolStripContainer1.TabIndex = 10;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Detailed Info";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 556);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.Text = "SLeek";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyUp);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton tbtnSLeek;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton tbtnHelp;
        private System.Windows.Forms.ToolStripMenuItem tmnuAbout;
        private System.Windows.Forms.ToolStripMenuItem tmnuExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblLoginName;
        private System.Windows.Forms.ToolStripStatusLabel tlblRegionInfo;
        private System.Windows.Forms.ToolStripStatusLabel tlblHealth;
        private System.Windows.Forms.ToolStripStatusLabel tlblMoneyBalance;
        private System.Windows.Forms.ToolStripDropDownButton tbtnDebug;
        private System.Windows.Forms.ToolStripMenuItem tmnuPrefs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripButton tbtnTeleport;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripMenuItem tmnuDebugLog;
        private System.Windows.Forms.ToolStripDropDownButton tbtnStatus;
        private System.Windows.Forms.ToolStripMenuItem tmnuStatusAway;
        private System.Windows.Forms.ToolStripMenuItem tmnuStatusBusy;
        private System.Windows.Forms.ToolStripMenuItem tmnuHelpReadme;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton tbtnControl;
        private System.Windows.Forms.ToolStripMenuItem tmnuControlFly;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tmnuControlAlwaysRun;
        private System.Windows.Forms.ToolStripMenuItem tmnuNewWindow;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tmnuDonate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblParcel;
        private System.Windows.Forms.ToolStripButton tbtnObjects;
    }
}

