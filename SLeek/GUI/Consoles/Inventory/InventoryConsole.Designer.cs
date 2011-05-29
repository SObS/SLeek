namespace SLeek
{
    partial class InventoryConsole
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
            this.components = new System.ComponentModel.Container();
            this.ilsInventory = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treInventory = new System.Windows.Forms.TreeView();
            this.tstInventory = new System.Windows.Forms.ToolStrip();
            this.tbtnNew = new System.Windows.Forms.ToolStripDropDownButton();
            this.tmnuNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmnuNewLandmark = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnuNewNotecard = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnuNewScript = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnOrganize = new System.Windows.Forms.ToolStripDropDownButton();
            this.tmnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tmnuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tmnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tbtnSort = new System.Windows.Forms.ToolStripDropDownButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tstInventory.SuspendLayout();
            this.SuspendLayout();
            // 
            // ilsInventory
            // 
            this.ilsInventory.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilsInventory.ImageSize = new System.Drawing.Size(16, 16);
            this.ilsInventory.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treInventory);
            this.splitContainer1.Panel1.Controls.Add(this.tstInventory);
            this.splitContainer1.Size = new System.Drawing.Size(632, 432);
            this.splitContainer1.SplitterDistance = 316;
            this.splitContainer1.TabIndex = 2;
            // 
            // treInventory
            // 
            this.treInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treInventory.ImageIndex = 0;
            this.treInventory.ImageList = this.ilsInventory;
            this.treInventory.Location = new System.Drawing.Point(0, 25);
            this.treInventory.Name = "treInventory";
            this.treInventory.SelectedImageIndex = 0;
            this.treInventory.Size = new System.Drawing.Size(312, 403);
            this.treInventory.TabIndex = 3;
            this.treInventory.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treInventory_AfterCollapse);
            this.treInventory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treInventory_AfterSelect);
            this.treInventory.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treInventory_AfterExpand);
            // 
            // tstInventory
            // 
            this.tstInventory.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tstInventory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnNew,
            this.toolStripSeparator1,
            this.tbtnOrganize,
            this.tbtnSort});
            this.tstInventory.Location = new System.Drawing.Point(0, 0);
            this.tstInventory.Name = "tstInventory";
            this.tstInventory.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tstInventory.Size = new System.Drawing.Size(312, 25);
            this.tstInventory.TabIndex = 2;
            this.tstInventory.Text = "toolStrip1";
            // 
            // tbtnNew
            // 
            this.tbtnNew.AutoToolTip = false;
            this.tbtnNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmnuNewFolder,
            this.toolStripMenuItem1,
            this.tmnuNewLandmark,
            this.tmnuNewNotecard,
            this.tmnuNewScript});
            this.tbtnNew.Enabled = false;
            this.tbtnNew.Image = global::SLeek.Properties.Resources.add_16;
            this.tbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnNew.Name = "tbtnNew";
            this.tbtnNew.Size = new System.Drawing.Size(57, 22);
            this.tbtnNew.Text = "New";
            // 
            // tmnuNewFolder
            // 
            this.tmnuNewFolder.Image = global::SLeek.Properties.Resources.folder_closed_16;
            this.tmnuNewFolder.Name = "tmnuNewFolder";
            this.tmnuNewFolder.Size = new System.Drawing.Size(152, 22);
            this.tmnuNewFolder.Text = "Folder";
            this.tmnuNewFolder.Click += new System.EventHandler(this.tmnuNewFolder_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // tmnuNewLandmark
            // 
            this.tmnuNewLandmark.Enabled = false;
            this.tmnuNewLandmark.Name = "tmnuNewLandmark";
            this.tmnuNewLandmark.Size = new System.Drawing.Size(152, 22);
            this.tmnuNewLandmark.Text = "Landmark";
            // 
            // tmnuNewNotecard
            // 
            this.tmnuNewNotecard.Image = global::SLeek.Properties.Resources.documents_16;
            this.tmnuNewNotecard.Name = "tmnuNewNotecard";
            this.tmnuNewNotecard.Size = new System.Drawing.Size(152, 22);
            this.tmnuNewNotecard.Text = "Notecard";
            this.tmnuNewNotecard.Click += new System.EventHandler(this.tmnuNewNotecard_Click);
            // 
            // tmnuNewScript
            // 
            this.tmnuNewScript.Image = global::SLeek.Properties.Resources.lsl_scripts_16;
            this.tmnuNewScript.Name = "tmnuNewScript";
            this.tmnuNewScript.Size = new System.Drawing.Size(152, 22);
            this.tmnuNewScript.Text = "Script";
            this.tmnuNewScript.Click += new System.EventHandler(this.tmnuNewScript_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbtnOrganize
            // 
            this.tbtnOrganize.AutoToolTip = false;
            this.tbtnOrganize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmnuCut,
            this.tmnuCopy,
            this.tmnuPaste,
            this.toolStripMenuItem2,
            this.tmnuRename,
            this.toolStripMenuItem3,
            this.tmnuDelete});
            this.tbtnOrganize.Enabled = false;
            this.tbtnOrganize.Image = global::SLeek.Properties.Resources.applications_16;
            this.tbtnOrganize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnOrganize.Name = "tbtnOrganize";
            this.tbtnOrganize.Size = new System.Drawing.Size(79, 22);
            this.tbtnOrganize.Text = "Organize";
            // 
            // tmnuCut
            // 
            this.tmnuCut.Image = global::SLeek.Properties.Resources.cut_16;
            this.tmnuCut.Name = "tmnuCut";
            this.tmnuCut.Size = new System.Drawing.Size(152, 22);
            this.tmnuCut.Text = "Cut";
            this.tmnuCut.Click += new System.EventHandler(this.tmnuCut_Click);
            // 
            // tmnuCopy
            // 
            this.tmnuCopy.Enabled = false;
            this.tmnuCopy.Image = global::SLeek.Properties.Resources.copy_16;
            this.tmnuCopy.Name = "tmnuCopy";
            this.tmnuCopy.Size = new System.Drawing.Size(152, 22);
            this.tmnuCopy.Text = "Copy";
            // 
            // tmnuPaste
            // 
            this.tmnuPaste.Image = global::SLeek.Properties.Resources.paste_16;
            this.tmnuPaste.Name = "tmnuPaste";
            this.tmnuPaste.Size = new System.Drawing.Size(152, 22);
            this.tmnuPaste.Text = "Paste";
            this.tmnuPaste.Click += new System.EventHandler(this.tmnuPaste_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // tmnuRename
            // 
            this.tmnuRename.Enabled = false;
            this.tmnuRename.Name = "tmnuRename";
            this.tmnuRename.Size = new System.Drawing.Size(152, 22);
            this.tmnuRename.Text = "Rename";
            this.tmnuRename.Click += new System.EventHandler(this.tmnuRename_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // tmnuDelete
            // 
            this.tmnuDelete.Image = global::SLeek.Properties.Resources.delete_16;
            this.tmnuDelete.Name = "tmnuDelete";
            this.tmnuDelete.Size = new System.Drawing.Size(152, 22);
            this.tmnuDelete.Text = "Delete";
            this.tmnuDelete.Click += new System.EventHandler(this.tmnuDelete_Click);
            // 
            // tbtnSort
            // 
            this.tbtnSort.AutoToolTip = false;
            this.tbtnSort.Image = global::SLeek.Properties.Resources.copy_16;
            this.tbtnSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnSort.Name = "tbtnSort";
            this.tbtnSort.Size = new System.Drawing.Size(56, 22);
            this.tbtnSort.Text = "Sort";
            // 
            // InventoryConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "InventoryConsole";
            this.Size = new System.Drawing.Size(632, 432);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tstInventory.ResumeLayout(false);
            this.tstInventory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList ilsInventory;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treInventory;
        private System.Windows.Forms.ToolStrip tstInventory;
        private System.Windows.Forms.ToolStripDropDownButton tbtnNew;
        private System.Windows.Forms.ToolStripMenuItem tmnuNewFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tmnuNewLandmark;
        private System.Windows.Forms.ToolStripMenuItem tmnuNewNotecard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton tbtnOrganize;
        private System.Windows.Forms.ToolStripMenuItem tmnuCut;
        private System.Windows.Forms.ToolStripMenuItem tmnuCopy;
        private System.Windows.Forms.ToolStripMenuItem tmnuPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tmnuRename;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tmnuDelete;
        private System.Windows.Forms.ToolStripDropDownButton tbtnSort;
        private System.Windows.Forms.ToolStripMenuItem tmnuNewScript;
    }
}
