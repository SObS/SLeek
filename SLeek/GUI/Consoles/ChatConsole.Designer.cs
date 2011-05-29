namespace SLeek
{
    partial class ChatConsole
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbChat = new System.Windows.Forms.RichTextBox();
            this.cbxInput = new System.Windows.Forms.ComboBox();
            this.btnSay = new System.Windows.Forms.Button();
            this.btnShout = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvwObjects = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnStartIM = new System.Windows.Forms.ToolStripButton();
            this.tbtnProfile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnFollow = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbChat
            // 
            this.rtbChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbChat.BackColor = System.Drawing.Color.White;
            this.rtbChat.HideSelection = false;
            this.rtbChat.Location = new System.Drawing.Point(3, 0);
            this.rtbChat.Name = "rtbChat";
            this.rtbChat.ReadOnly = true;
            this.rtbChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtbChat.ShowSelectionMargin = true;
            this.rtbChat.Size = new System.Drawing.Size(400, 310);
            this.rtbChat.TabIndex = 5;
            this.rtbChat.Text = "";
            this.rtbChat.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbChat_LinkClicked);
            // 
            // cbxInput
            // 
            this.cbxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxInput.Enabled = false;
            this.cbxInput.FormattingEnabled = true;
            this.cbxInput.Location = new System.Drawing.Point(0, 0);
            this.cbxInput.Name = "cbxInput";
            this.cbxInput.Size = new System.Drawing.Size(352, 21);
            this.cbxInput.TabIndex = 3;
            this.cbxInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbxInput_KeyUp);
            this.cbxInput.TextChanged += new System.EventHandler(this.cbxInput_TextChanged);
            this.cbxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxInput_KeyDown);
            // 
            // btnSay
            // 
            this.btnSay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSay.Enabled = false;
            this.btnSay.Location = new System.Drawing.Point(358, 0);
            this.btnSay.Name = "btnSay";
            this.btnSay.Size = new System.Drawing.Size(76, 24);
            this.btnSay.TabIndex = 5;
            this.btnSay.Text = "Say";
            this.btnSay.UseVisualStyleBackColor = true;
            this.btnSay.Click += new System.EventHandler(this.btnSay_Click);
            // 
            // btnShout
            // 
            this.btnShout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShout.Enabled = false;
            this.btnShout.Location = new System.Drawing.Point(440, 0);
            this.btnShout.Name = "btnShout";
            this.btnShout.Size = new System.Drawing.Size(76, 24);
            this.btnShout.TabIndex = 4;
            this.btnShout.Text = "Shout";
            this.btnShout.UseVisualStyleBackColor = true;
            this.btnShout.Click += new System.EventHandler(this.btnShout_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtbChat);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvwObjects);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(516, 310);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 7;
            // 
            // lvwObjects
            // 
            this.lvwObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwObjects.FullRowSelect = true;
            this.lvwObjects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwObjects.LabelWrap = false;
            this.lvwObjects.Location = new System.Drawing.Point(0, 0);
            this.lvwObjects.MultiSelect = false;
            this.lvwObjects.Name = "lvwObjects";
            this.lvwObjects.Size = new System.Drawing.Size(88, 310);
            this.lvwObjects.TabIndex = 10;
            this.lvwObjects.UseCompatibleStateImageBehavior = false;
            this.lvwObjects.View = System.Windows.Forms.View.List;
            this.lvwObjects.SelectedIndexChanged += new System.EventHandler(this.lvwObjects_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnStartIM,
            this.tbtnProfile,
            this.toolStripSeparator1,
            this.tbtnFollow});
            this.toolStrip1.Location = new System.Drawing.Point(88, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(24, 310);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnStartIM
            // 
            this.tbtnStartIM.AutoToolTip = false;
            this.tbtnStartIM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnStartIM.Enabled = false;
            this.tbtnStartIM.Image = global::SLeek.Properties.Resources.computer_16;
            this.tbtnStartIM.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnStartIM.Name = "tbtnStartIM";
            this.tbtnStartIM.Size = new System.Drawing.Size(21, 20);
            this.tbtnStartIM.ToolTipText = "Start IM";
            this.tbtnStartIM.Click += new System.EventHandler(this.tbtnStartIM_Click);
            // 
            // tbtnProfile
            // 
            this.tbtnProfile.AutoToolTip = false;
            this.tbtnProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnProfile.Enabled = false;
            this.tbtnProfile.Image = global::SLeek.Properties.Resources.applications_16;
            this.tbtnProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnProfile.Name = "tbtnProfile";
            this.tbtnProfile.Size = new System.Drawing.Size(21, 20);
            this.tbtnProfile.ToolTipText = "View Profile";
            this.tbtnProfile.Click += new System.EventHandler(this.tbtnProfile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(21, 6);
            // 
            // tbtnFollow
            // 
            this.tbtnFollow.AutoToolTip = false;
            this.tbtnFollow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnFollow.Enabled = false;
            this.tbtnFollow.Image = global::SLeek.Properties.Resources.arrow_forward_16;
            this.tbtnFollow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnFollow.Name = "tbtnFollow";
            this.tbtnFollow.Size = new System.Drawing.Size(21, 20);
            this.tbtnFollow.ToolTipText = "Follow";
            this.tbtnFollow.Click += new System.EventHandler(this.tbtnFollow_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxInput);
            this.panel1.Controls.Add(this.btnSay);
            this.panel1.Controls.Add(this.btnShout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 310);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 24);
            this.panel1.TabIndex = 8;
            // 
            // ChatConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ChatConsole";
            this.Size = new System.Drawing.Size(516, 334);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbChat;
        private System.Windows.Forms.ComboBox cbxInput;
        private System.Windows.Forms.Button btnSay;
        private System.Windows.Forms.Button btnShout;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbtnStartIM;
        private System.Windows.Forms.ToolStripButton tbtnFollow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ListView lvwObjects;
        private System.Windows.Forms.ToolStripButton tbtnProfile;
    }
}
