namespace SLeek
{
    partial class frmProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfile));
            this.tabProfile = new System.Windows.Forms.TabControl();
            this.tpgProfile = new System.Windows.Forms.TabPage();
            this.btnOfferTeleport = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.rtbAccountInfo = new System.Windows.Forms.RichTextBox();
            this.rtbAbout = new System.Windows.Forms.RichTextBox();
            this.proSLImage = new System.Windows.Forms.ProgressBar();
            this.txtPartner = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBornOn = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picSLImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpgWeb = new System.Windows.Forms.TabPage();
            this.pnlWeb = new System.Windows.Forms.Panel();
            this.btnWebOpen = new System.Windows.Forms.Button();
            this.btnWebView = new System.Windows.Forms.Button();
            this.txtWebURL = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tpgFirstLife = new System.Windows.Forms.TabPage();
            this.rtbAboutFL = new System.Windows.Forms.RichTextBox();
            this.proFLImage = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.picFLImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabProfile.SuspendLayout();
            this.tpgProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSLImage)).BeginInit();
            this.tpgWeb.SuspendLayout();
            this.tpgFirstLife.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFLImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tabProfile
            // 
            this.tabProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabProfile.Controls.Add(this.tpgProfile);
            this.tabProfile.Controls.Add(this.tpgWeb);
            this.tabProfile.Controls.Add(this.tpgFirstLife);
            this.tabProfile.Location = new System.Drawing.Point(12, 12);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.SelectedIndex = 0;
            this.tabProfile.Size = new System.Drawing.Size(468, 483);
            this.tabProfile.TabIndex = 0;
            // 
            // tpgProfile
            // 
            this.tpgProfile.Controls.Add(this.btnOfferTeleport);
            this.tpgProfile.Controls.Add(this.btnPay);
            this.tpgProfile.Controls.Add(this.rtbAccountInfo);
            this.tpgProfile.Controls.Add(this.rtbAbout);
            this.tpgProfile.Controls.Add(this.proSLImage);
            this.tpgProfile.Controls.Add(this.txtPartner);
            this.tpgProfile.Controls.Add(this.label5);
            this.tpgProfile.Controls.Add(this.label4);
            this.tpgProfile.Controls.Add(this.label3);
            this.tpgProfile.Controls.Add(this.txtBornOn);
            this.tpgProfile.Controls.Add(this.txtFullName);
            this.tpgProfile.Controls.Add(this.label2);
            this.tpgProfile.Controls.Add(this.picSLImage);
            this.tpgProfile.Controls.Add(this.label1);
            this.tpgProfile.Location = new System.Drawing.Point(4, 22);
            this.tpgProfile.Name = "tpgProfile";
            this.tpgProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tpgProfile.Size = new System.Drawing.Size(460, 457);
            this.tpgProfile.TabIndex = 0;
            this.tpgProfile.Text = "Profile";
            this.tpgProfile.UseVisualStyleBackColor = true;
            // 
            // btnOfferTeleport
            // 
            this.btnOfferTeleport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOfferTeleport.Location = new System.Drawing.Point(6, 368);
            this.btnOfferTeleport.Name = "btnOfferTeleport";
            this.btnOfferTeleport.Size = new System.Drawing.Size(108, 23);
            this.btnOfferTeleport.TabIndex = 16;
            this.btnOfferTeleport.Text = "Offer Teleport";
            this.btnOfferTeleport.UseVisualStyleBackColor = true;
            this.btnOfferTeleport.Click += new System.EventHandler(this.btnOfferTeleport_Click);
            // 
            // btnPay
            // 
            this.btnPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPay.Location = new System.Drawing.Point(120, 368);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 23);
            this.btnPay.TabIndex = 15;
            this.btnPay.Text = "Pay...";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // rtbAccountInfo
            // 
            this.rtbAccountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbAccountInfo.Location = new System.Drawing.Point(306, 60);
            this.rtbAccountInfo.Name = "rtbAccountInfo";
            this.rtbAccountInfo.ReadOnly = true;
            this.rtbAccountInfo.Size = new System.Drawing.Size(148, 133);
            this.rtbAccountInfo.TabIndex = 14;
            this.rtbAccountInfo.Text = "";
            // 
            // rtbAbout
            // 
            this.rtbAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbAbout.Location = new System.Drawing.Point(6, 212);
            this.rtbAbout.Name = "rtbAbout";
            this.rtbAbout.ReadOnly = true;
            this.rtbAbout.Size = new System.Drawing.Size(448, 150);
            this.rtbAbout.TabIndex = 13;
            this.rtbAbout.Text = "";
            this.rtbAbout.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbAbout_LinkClicked);
            // 
            // proSLImage
            // 
            this.proSLImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.proSLImage.Location = new System.Drawing.Point(6, 33);
            this.proSLImage.MarqueeAnimationSpeed = 50;
            this.proSLImage.Name = "proSLImage";
            this.proSLImage.Size = new System.Drawing.Size(240, 16);
            this.proSLImage.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.proSLImage.TabIndex = 12;
            // 
            // txtPartner
            // 
            this.txtPartner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartner.Location = new System.Drawing.Point(306, 33);
            this.txtPartner.Name = "txtPartner";
            this.txtPartner.ReadOnly = true;
            this.txtPartner.Size = new System.Drawing.Size(148, 21);
            this.txtPartner.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Partner:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "About:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Info:";
            // 
            // txtBornOn
            // 
            this.txtBornOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBornOn.Location = new System.Drawing.Point(306, 6);
            this.txtBornOn.Name = "txtBornOn";
            this.txtBornOn.ReadOnly = true;
            this.txtBornOn.Size = new System.Drawing.Size(148, 21);
            this.txtBornOn.TabIndex = 5;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(50, 6);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(196, 21);
            this.txtFullName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Born on:";
            // 
            // picSLImage
            // 
            this.picSLImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picSLImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picSLImage.Location = new System.Drawing.Point(6, 33);
            this.picSLImage.Name = "picSLImage";
            this.picSLImage.Size = new System.Drawing.Size(240, 160);
            this.picSLImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSLImage.TabIndex = 2;
            this.picSLImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // tpgWeb
            // 
            this.tpgWeb.Controls.Add(this.pnlWeb);
            this.tpgWeb.Controls.Add(this.btnWebOpen);
            this.tpgWeb.Controls.Add(this.btnWebView);
            this.tpgWeb.Controls.Add(this.txtWebURL);
            this.tpgWeb.Controls.Add(this.label6);
            this.tpgWeb.Location = new System.Drawing.Point(4, 22);
            this.tpgWeb.Name = "tpgWeb";
            this.tpgWeb.Padding = new System.Windows.Forms.Padding(3);
            this.tpgWeb.Size = new System.Drawing.Size(460, 457);
            this.tpgWeb.TabIndex = 1;
            this.tpgWeb.Text = "Web";
            this.tpgWeb.UseVisualStyleBackColor = true;
            // 
            // pnlWeb
            // 
            this.pnlWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWeb.Location = new System.Drawing.Point(6, 33);
            this.pnlWeb.Name = "pnlWeb";
            this.pnlWeb.Size = new System.Drawing.Size(448, 418);
            this.pnlWeb.TabIndex = 4;
            // 
            // btnWebOpen
            // 
            this.btnWebOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWebOpen.Enabled = false;
            this.btnWebOpen.Location = new System.Drawing.Point(379, 4);
            this.btnWebOpen.Name = "btnWebOpen";
            this.btnWebOpen.Size = new System.Drawing.Size(75, 23);
            this.btnWebOpen.TabIndex = 3;
            this.btnWebOpen.Text = "Open";
            this.btnWebOpen.UseVisualStyleBackColor = true;
            this.btnWebOpen.Click += new System.EventHandler(this.btnWebOpen_Click);
            // 
            // btnWebView
            // 
            this.btnWebView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWebView.Enabled = false;
            this.btnWebView.Location = new System.Drawing.Point(298, 4);
            this.btnWebView.Name = "btnWebView";
            this.btnWebView.Size = new System.Drawing.Size(75, 23);
            this.btnWebView.TabIndex = 2;
            this.btnWebView.Text = "View";
            this.btnWebView.UseVisualStyleBackColor = true;
            this.btnWebView.Click += new System.EventHandler(this.btnWebView_Click);
            // 
            // txtWebURL
            // 
            this.txtWebURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebURL.Location = new System.Drawing.Point(42, 6);
            this.txtWebURL.Name = "txtWebURL";
            this.txtWebURL.ReadOnly = true;
            this.txtWebURL.Size = new System.Drawing.Size(250, 21);
            this.txtWebURL.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "URL:";
            // 
            // tpgFirstLife
            // 
            this.tpgFirstLife.Controls.Add(this.rtbAboutFL);
            this.tpgFirstLife.Controls.Add(this.proFLImage);
            this.tpgFirstLife.Controls.Add(this.label8);
            this.tpgFirstLife.Controls.Add(this.label7);
            this.tpgFirstLife.Controls.Add(this.picFLImage);
            this.tpgFirstLife.Location = new System.Drawing.Point(4, 22);
            this.tpgFirstLife.Name = "tpgFirstLife";
            this.tpgFirstLife.Padding = new System.Windows.Forms.Padding(3);
            this.tpgFirstLife.Size = new System.Drawing.Size(460, 457);
            this.tpgFirstLife.TabIndex = 2;
            this.tpgFirstLife.Text = "First Life";
            this.tpgFirstLife.UseVisualStyleBackColor = true;
            // 
            // rtbAboutFL
            // 
            this.rtbAboutFL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbAboutFL.Location = new System.Drawing.Point(6, 201);
            this.rtbAboutFL.Name = "rtbAboutFL";
            this.rtbAboutFL.ReadOnly = true;
            this.rtbAboutFL.Size = new System.Drawing.Size(448, 150);
            this.rtbAboutFL.TabIndex = 14;
            this.rtbAboutFL.Text = "";
            this.rtbAboutFL.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtbAboutFL_LinkClicked);
            // 
            // proFLImage
            // 
            this.proFLImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.proFLImage.Location = new System.Drawing.Point(6, 22);
            this.proFLImage.MarqueeAnimationSpeed = 50;
            this.proFLImage.Name = "proFLImage";
            this.proFLImage.Size = new System.Drawing.Size(240, 16);
            this.proFLImage.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.proFLImage.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "My first life pic:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "About my first life:";
            // 
            // picFLImage
            // 
            this.picFLImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picFLImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picFLImage.Location = new System.Drawing.Point(6, 22);
            this.picFLImage.Name = "picFLImage";
            this.picFLImage.Size = new System.Drawing.Size(240, 160);
            this.picFLImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFLImage.TabIndex = 3;
            this.picFLImage.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(405, 501);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 536);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabProfile);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProfile";
            this.Text = "Profile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProfile_FormClosing);
            this.tabProfile.ResumeLayout(false);
            this.tpgProfile.ResumeLayout(false);
            this.tpgProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSLImage)).EndInit();
            this.tpgWeb.ResumeLayout(false);
            this.tpgWeb.PerformLayout();
            this.tpgFirstLife.ResumeLayout(false);
            this.tpgFirstLife.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFLImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabProfile;
        private System.Windows.Forms.TabPage tpgProfile;
        private System.Windows.Forms.TabPage tpgWeb;
        private System.Windows.Forms.TabPage tpgFirstLife;
        private System.Windows.Forms.PictureBox picSLImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBornOn;
        private System.Windows.Forms.TextBox txtPartner;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlWeb;
        private System.Windows.Forms.Button btnWebOpen;
        private System.Windows.Forms.Button btnWebView;
        private System.Windows.Forms.TextBox txtWebURL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picFLImage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar proSLImage;
        private System.Windows.Forms.ProgressBar proFLImage;
        private System.Windows.Forms.RichTextBox rtbAbout;
        private System.Windows.Forms.RichTextBox rtbAboutFL;
        private System.Windows.Forms.RichTextBox rtbAccountInfo;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnOfferTeleport;
    }
}