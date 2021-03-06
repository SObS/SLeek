using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SLeek
{
    public partial class SleekTab
    {
        private ToolStripButton button;
        private Control control;
        private Button defaultControlButton;
        private string name;
        private string label;
        private SleekTab mergedTab;
        private Form owner;
        private string originalLabel;

        private bool allowMerge = true;
        private bool allowDetach = true;
        private bool allowClose = true;

        private bool partialHighlighted = false;
        private bool highlighted = false;
        private bool selected = false;
        private bool detached = false;
        private bool merged = false;

        public SleekTab(ToolStripButton button, Control control, string name, string label)
        {
            this.button = button;
            this.control = control;
            this.name = name;
            this.label = label;
        }

        public void Close()
        {
            if (!allowClose) return;

            if (button != null)
            {
                button.Dispose();
                button = null;
            }

            if (control != null)
            {
                control.Dispose();
                control = null;
            }

            OnTabClosed(EventArgs.Empty);
        }

        public void Select()
        {
            if (detached) return;

            control.Visible = true;
            control.BringToFront();

            if (!partialHighlighted) Unhighlight();
            button.Checked = true;
            selected = true;

            OnTabSelected(EventArgs.Empty);
        }

        public void Deselect()
        {
            if (detached) return;

            if (control != null) control.Visible = false;
            if (button != null) button.Checked = false;
            selected = false;

            OnTabDeselected(EventArgs.Empty);
        }

        public void PartialHighlight()
        {
            if (detached)
            {
                //do nothing?!
            }
            else
            {
                button.Image = null;
                button.ForeColor = Color.Blue;
            }

            partialHighlighted = true;
            OnTabPartiallyHighlighted(EventArgs.Empty);
        }

        public void Highlight()
        {
            if (selected) return;

            if (detached)
            {
                if (!owner.Focused)
                    FormFlash.Flash(owner);
            }
            else
            {
                button.Image = Properties.Resources.arrow_forward_16;
                button.ForeColor = Color.Red;
            }

            highlighted = true;
            OnTabHighlighted(EventArgs.Empty);
        }

        public void Unhighlight()
        {
            if (detached)
            {
                FormFlash.Unflash(owner);
            }
            else
            {
                button.Image = null;
                button.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            }

            highlighted = partialHighlighted = false;
            OnTabUnhighlighted(EventArgs.Empty);
        }

        public void AttachTo(ToolStrip strip, Panel container)
        {
            if (!allowDetach) return;
            if (!detached) return;

            strip.Items.Add(button);
            container.Controls.Add(control);

            owner = null;
            detached = false;
            OnTabAttached(EventArgs.Empty);
        }

        public void Detach(SleekInstance instance)
        {
            if (!allowDetach) return;
            if (detached) return;

            owner = new frmDetachedTab(instance, this);
            detached = true;
            OnTabDetached(EventArgs.Empty);            
        }

        public void MergeWith(SleekTab tab)
        {
            if (!allowMerge) return;
            if (merged) return;

            SplitContainer container = new SplitContainer();
            container.Dock = DockStyle.Fill;
            container.BorderStyle = BorderStyle.Fixed3D;
            container.SplitterDistance = container.Width / 2;
            container.Panel1.Controls.Add(control);
            container.Panel2.Controls.Add(tab.Control);

            control.Visible = true;
            tab.Control.Visible = true;

            control = container;
            tab.Control = container;
            
            mergedTab = tab;
            tab.mergedTab = this;

            originalLabel = label;
            tab.originalLabel = tab.label;
            this.Label = label + "+" + tab.Label;
            
            merged = tab.merged = true;

            OnTabMerged(EventArgs.Empty);
        }

        public SleekTab Split()
        {
            if (!allowMerge) return null;
            if (!merged) return null;

            SleekTab returnTab = mergedTab;
            mergedTab = null;
            returnTab.mergedTab = null;

            SplitContainer container = (SplitContainer)control;
            control = container.Panel1.Controls[0];
            returnTab.Control = container.Panel2.Controls[0];
            merged = returnTab.merged = false;

            this.Label = originalLabel;
            OnTabSplit(EventArgs.Empty);

            return returnTab;
        }

        public ToolStripButton Button
        {
            get { return button; }
            set { button = value; }
        }

        public Control Control
        {
            get { return control; }
            set { control = value; }
        }

        public Button DefaultControlButton
        {
            get { return defaultControlButton; }
            set { defaultControlButton = value; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Label
        {
            get { return label; }
            set { label = button.Text = value; }
        }

        public SleekTab MergedTab
        {
            get { return mergedTab; }
        }

        public Form Owner
        {
            get { return owner; }
        }

        public bool AllowMerge
        {
            get { return allowMerge; }
            set { allowMerge = value; }
        }

        public bool AllowDetach
        {
            get { return allowDetach; }
            set { allowDetach = value; }
        }

        public bool AllowClose
        {
            get { return allowClose; }
            set { allowClose = value; }
        }

        public bool PartiallyHighlighted
        {
            get { return partialHighlighted; }
        }

        public bool Highlighted
        {
            get { return highlighted; }
        }

        public bool Selected
        {
            get { return selected; }
        }

        public bool Detached
        {
            get { return detached; }
        }

        public bool Merged
        {
            get { return merged; }
        }
    }
}
