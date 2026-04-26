using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCustomControls
{
    public partial class CheckableGroupBox : ContainerControl
    {
        private readonly CheckBox checkBox;
        public CheckableGroupBox()
        {
            checkBox = new CheckBox
            {
                Location = new Point(10, 0),
                Text = "CheckableGroupBox", // 기본텍스트
                AutoSize = true,
                Checked = false
            };
            checkBox.CheckedChanged += (s, e) => UpdateChildEnabledState();

            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            this.Controls.Add(checkBox);
            this.Padding = new Padding(10, 20, 10, 10);
        }
        private void UpdateChildEnabledState()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != checkBox)
                    ctrl.Enabled = checkBox.Checked;
            }
            this.Invalidate();
        }
        [Browsable(true)]
        [Category("Appearance")]
        public override string Text
        {
            get => checkBox.Text;
            set => checkBox.Text = value;
        }
        [Browsable(true)]
        [Category("Behavior")]
        public bool Checked
        {
            get => checkBox.Checked;
            set
            {
                if (checkBox.Checked != value)
                {
                    checkBox.Checked = value;
                    UpdateChildEnabledState();
                }
            } 
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            UpdateChildEnabledState();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            Rectangle bounds = this.ClientRectangle;
            using (Pen pen = new Pen(SystemColors.ControlDark))
            {
                // 테두리 그리기
                Rectangle borderRect = new Rectangle(bounds.X, bounds.Y + 6, bounds.Width - 1, bounds.Height - 7);
                g.DrawRectangle(pen, borderRect);
            }
        }
        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
            checkBox.Location = new Point(10, 0);
        }
    }
}

