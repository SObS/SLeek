namespace SLeek
{
    partial class MainConsole
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
            this.pnlLoginPrompt = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustomLoginUri = new System.Windows.Forms.TextBox();
            this.cbxGrid = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbxLocation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlLoggingIn = new System.Windows.Forms.Panel();
            this.lblLoginStatus = new System.Windows.Forms.Label();
            this.proLogin = new System.Windows.Forms.ProgressBar();
            this.btnInfo = new System.Windows.Forms.Button();
            this.pnlLoginPage = new System.Windows.Forms.Panel();
            this.lblInitWebBrowser = new System.Windows.Forms.Label();
            this.pnlLoginPrompt.SuspendLayout();
            this.pnlLoggingIn.SuspendLayout();
            this.pnlLoginPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLoginPrompt
            // 
            this.pnlLoginPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLoginPrompt.Controls.Add(this.label6);
            this.pnlLoginPrompt.Controls.Add(this.txtCustomLoginUri);
            this.pnlLoginPrompt.Controls.Add(this.cbxGrid);
            this.pnlLoginPrompt.Controls.Add(this.label5);
            this.pnlLoginPrompt.Controls.Add(this.label1);
            this.pnlLoginPrompt.Controls.Add(this.txtFirstName);
            this.pnlLoginPrompt.Controls.Add(this.label4);
            this.pnlLoginPrompt.Controls.Add(this.txtLastName);
            this.pnlLoginPrompt.Controls.Add(this.label2);
            this.pnlLoginPrompt.Controls.Add(this.txtPassword);
            this.pnlLoginPrompt.Controls.Add(this.cbxLocation);
            this.pnlLoginPrompt.Controls.Add(this.label3);
            this.pnlLoginPrompt.Location = new System.Drawing.Point(125, 3);
            this.pnlLoginPrompt.Name = "pnlLoginPrompt";
            this.pnlLoginPrompt.Size = new System.Drawing.Size(554, 94);
            this.pnlLoginPrompt.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Login Uri";
            // 
            // txtCustomLoginUri
            // 
            this.txtCustomLoginUri.Enabled = false;
            this.txtCustomLoginUri.Location = new System.Drawing.Point(326, 70);
            this.txtCustomLoginUri.Name = "txtCustomLoginUri";
            this.txtCustomLoginUri.Size = new System.Drawing.Size(224, 21);
            this.txtCustomLoginUri.TabIndex = 13;
            // 
            // cbxGrid
            // 
            this.cbxGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxGrid.FormattingEnabled = true;
            this.cbxGrid.Items.AddRange(new object[] {
            "Main Grid or Teen Grid (Agni)",
            "Beta Grid (Aditi)",
            "Custom"});
            this.cbxGrid.Location = new System.Drawing.Point(56, 70);
            this.cbxGrid.Name = "cbxGrid";
            this.cbxGrid.Size = new System.Drawing.Size(210, 21);
            this.cbxGrid.TabIndex = 12;
            this.cbxGrid.SelectedIndexChanged += new System.EventHandler(this.cbxGrid_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Grid";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(3, 16);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(164, 21);
            this.txtFirstName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(173, 16);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(164, 21);
            this.txtLastName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(343, 16);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(207, 21);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // cbxLocation
            // 
            this.cbxLocation.FormattingEnabled = true;
            this.cbxLocation.Items.AddRange(new object[] {
            "My Home",
            "My Last Location"});
            this.cbxLocation.Location = new System.Drawing.Point(56, 43);
            this.cbxLocation.Name = "cbxLocation";
            this.cbxLocation.Size = new System.Drawing.Size(494, 21);
            this.cbxLocation.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Location";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(3, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(116, 23);
            this.btnLogin.TabIndex = 15;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pnlLoggingIn
            // 
            this.pnlLoggingIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLoggingIn.Controls.Add(this.lblLoginStatus);
            this.pnlLoggingIn.Controls.Add(this.proLogin);
            this.pnlLoggingIn.Location = new System.Drawing.Point(125, 3);
            this.pnlLoggingIn.Name = "pnlLoggingIn";
            this.pnlLoggingIn.Size = new System.Drawing.Size(554, 94);
            this.pnlLoggingIn.TabIndex = 17;
            this.pnlLoggingIn.Visible = false;
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoginStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginStatus.Location = new System.Drawing.Point(3, 0);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(548, 42);
            this.lblLoginStatus.TabIndex = 12;
            this.lblLoginStatus.Text = "Login status goes here.";
            this.lblLoginStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // proLogin
            // 
            this.proLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.proLogin.Location = new System.Drawing.Point(3, 45);
            this.proLogin.MarqueeAnimationSpeed = 50;
            this.proLogin.Name = "proLogin";
            this.proLogin.Size = new System.Drawing.Size(548, 23);
            this.proLogin.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.proLogin.TabIndex = 11;
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(3, 74);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(116, 23);
            this.btnInfo.TabIndex = 18;
            this.btnInfo.Text = "Show Grid Status";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // pnlLoginPage
            // 
            this.pnlLoginPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLoginPage.Controls.Add(this.lblInitWebBrowser);
            this.pnlLoginPage.Location = new System.Drawing.Point(3, 103);
            this.pnlLoginPage.Name = "pnlLoginPage";
            this.pnlLoginPage.Size = new System.Drawing.Size(676, 360);
            this.pnlLoginPage.TabIndex = 19;
            // 
            // lblInitWebBrowser
            // 
            this.lblInitWebBrowser.AutoSize = true;
            this.lblInitWebBrowser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitWebBrowser.Location = new System.Drawing.Point(3, 0);
            this.lblInitWebBrowser.Name = "lblInitWebBrowser";
            this.lblInitWebBrowser.Size = new System.Drawing.Size(150, 13);
            this.lblInitWebBrowser.TabIndex = 0;
            this.lblInitWebBrowser.Text = "Initializing web browser...";
            this.lblInitWebBrowser.Visible = false;
            // 
            // MainConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLoginPage);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.pnlLoginPrompt);
            this.Controls.Add(this.pnlLoggingIn);
            this.Controls.Add(this.btnLogin);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainConsole";
            this.Size = new System.Drawing.Size(682, 466);
            this.pnlLoginPrompt.ResumeLayout(false);
            this.pnlLoginPrompt.PerformLayout();
            this.pnlLoggingIn.ResumeLayout(false);
            this.pnlLoginPage.ResumeLayout(false);
            this.pnlLoginPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLoginPrompt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cbxLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel pnlLoggingIn;
        private System.Windows.Forms.Label lblLoginStatus;
        private System.Windows.Forms.ProgressBar proLogin;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.ComboBox cbxGrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlLoginPage;
        private System.Windows.Forms.Label lblInitWebBrowser;
        private System.Windows.Forms.TextBox txtCustomLoginUri;
        private System.Windows.Forms.Label label6;
    }
}
