using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsCustomControls
{
    public partial class ColorComboBox : ComboBox
    {
        private readonly ColorComboBoxDropdown dropdownPanel;
        private readonly ToolStripDropDown dropDown;
        private bool isDropDownPending;
        private Color _selectedColor = Color.Red;
        public Color SelectedColor
        {
            get => _selectedColor;
            set
            {
                _selectedColor = value;
                this.Invalidate(); // 그려줄 수 있도록 다시 그리기
            }
        }
        public ColorComboBox()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownHeight = 1; // 기본 드롭다운 숨김
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            dropdownPanel = new ColorComboBoxDropdown();
            dropdownPanel.ColorSelected += ColorComboBoxPanel_ColorSelected;
            ToolStripControlHost host = new ToolStripControlHost(dropdownPanel)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = false,
                Size = dropdownPanel.Size
            };

            dropDown = new ToolStripDropDown
            {
                AutoClose = true,
                Padding = Padding.Empty,
            };
            dropDown.Closing += dropdown_Closing;
            dropDown.Items.Add(host);
            components?.Add(dropDown);
        }
        private void ColorComboBoxPanel_ColorSelected(object sender, ColorSelectedEventArgs e)
        {
            SelectedColor = e.color;
            dropDown.Close();
        }
        private void dropdown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                e.Cancel = true;
        }
        protected override void OnClick(EventArgs e)
        {
            if (isDropDownPending || dropDown.Visible || IsDisposed || Disposing || !IsHandleCreated)
                return;

            isDropDownPending = true;
            BeginInvoke(new MethodInvoker(ShowCustomDropDown));
        }
        private void ShowCustomDropDown()
        {
            isDropDownPending = false;

            if (dropDown.Visible || IsDisposed || Disposing || !IsHandleCreated)
                return;

            if (DroppedDown)
                DroppedDown = false;

            dropDown.Show(this, new Point(0, this.Height));
            if (dropdownPanel.CanFocus)
                dropdownPanel.Focus(); // 포커스를 패널로 줘서 외부 클릭 감지 유도
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground(); // 배경 그리기 추가
            Rectangle colorRect = new Rectangle(
                e.Bounds.X + 2,
                e.Bounds.Y + 2,
                Math.Max(0, e.Bounds.Width - 5),
                Math.Max(0, e.Bounds.Height - 5));

            if (colorRect.Width > 0 && colorRect.Height > 0)
            {
                using (Brush brush = new SolidBrush(SelectedColor))
                    e.Graphics.FillRectangle(brush, colorRect);

                e.Graphics.DrawRectangle(Pens.Black, colorRect);
            }

        }
    }
}
