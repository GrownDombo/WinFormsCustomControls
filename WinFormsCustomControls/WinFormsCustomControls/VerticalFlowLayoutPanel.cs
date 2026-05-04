using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsCustomControls
{
    public partial class VerticalFlowLayoutPanel : FlowLayoutPanel
    {
        private readonly int MARGIN;
        public VerticalFlowLayoutPanel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            MARGIN = SystemInformation.VerticalScrollBarWidth + 10;
            this.FlowDirection = FlowDirection.TopDown;
            this.WrapContents = false;
            this.AutoScroll = true;
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            this.SuspendLayout();
            try
            {
                SetChildWidth(e.Control);
                base.OnControlAdded(e);
            }
            finally
            {
                this.ResumeLayout(false);
                this.PerformLayout();
                UpdateScrollMinSize();
            }
        }
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            this.SuspendLayout();
            try
            {
                base.OnControlRemoved(e);
            }
            finally
            {
                this.ResumeLayout(false);
                this.PerformLayout();
                UpdateScrollMinSize();
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            this.SuspendLayout();
            try
            {
                foreach (Control control in this.Controls)
                    SetChildWidth(control);
                base.OnSizeChanged(e);
            }
            finally
            {
                this.ResumeLayout(false);
                this.PerformLayout();
                UpdateScrollMinSize();
            }
        }
        private void SetChildWidth(Control control)
        {
            if (control != null)
                control.Width = Math.Max(0, this.ClientSize.Width - MARGIN);
        }
        private void UpdateScrollMinSize()
        {
            int height = this.Controls
                .Cast<Control>()
                .Where(control => control.Visible)
                .Sum(control => control.Height + control.Margin.Vertical);

            this.AutoScrollMinSize = new Size(0, height);
        }
    }
}
