using System;
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
            }
        }
        private void SetChildWidth(Control control)
        {
            if (control != null)
                control.Width = Math.Max(0, this.ClientSize.Width - MARGIN);
        }
    }
}
