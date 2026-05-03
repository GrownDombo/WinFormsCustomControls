using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsCustomControls
{
    public partial class CheckBoxComboBox : ComboBox
    {
        private readonly CheckBoxComboBoxDropdown dropdownPanel;
        private readonly ToolStripDropDown dropDown;
        private bool isDropDownPending;
        public CheckBox[] GetItems => dropdownPanel.GetItems;
        private string sText;
        public CheckBoxComboBox()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            this.sText = string.Empty;

            // 기본 설정
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownHeight = 1; // 기본 드롭다운 숨기기
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            dropdownPanel = new CheckBoxComboBoxDropdown();
            dropdownPanel.CheckedChanged += DropdownPanel_CheckedChanged; // 이벤트 핸들러 추가
            ToolStripControlHost host = new ToolStripControlHost(dropdownPanel)
            {
                Padding = Padding.Empty,
                Margin = Padding.Empty,
                AutoSize = true
            };
            dropDown = new ToolStripDropDown
            {
                AutoClose = true,
                Padding = Padding.Empty
            };
            dropDown.Closing += dropdown_Closing;
            dropDown.Items.Add(host);
            components?.Add(dropDown);
        }
        private void DropdownPanel_CheckedChanged(object sender, EventArgs e)
        {
            UpdateText();
        }
        private void dropdown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                e.Cancel = true;
            UpdateText();
        }
        private void UpdateText()
        {
            CheckBox[] checkBoxes = dropdownPanel.GetItems;
            List<string> selectedItems = new List<string>();
            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (checkBoxes[i].Checked)
                    selectedItems.Add(checkBoxes[i].Text);
            }
            this.sText = string.Join(", ", selectedItems);
            Invalidate();
        }
        public void AddItem(string item, bool isChecked = false)
        {
            dropdownPanel.AddItem(item, isChecked);
            UpdateText();
        }
        public void AddItemRange(string[] items)
        {
            dropdownPanel.AddItemRange(items);
            UpdateText();
        }
        public void ItemClear()
        {
            dropdownPanel.ItemClear();
            UpdateText();
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
            TextRenderer.DrawText(
                e.Graphics,
                sText,
                e.Font ?? Font,
                e.Bounds,
                e.ForeColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

        }
    }
}
