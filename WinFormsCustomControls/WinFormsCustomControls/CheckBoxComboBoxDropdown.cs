using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsCustomControls
{
    internal partial class CheckBoxComboBoxDropdown : UserControl
    {
        internal event EventHandler<EventArgs> CheckedChanged;
        internal CheckBox[] GetItems => vflpMain.Controls.OfType<CheckBox>().ToArray();
        internal CheckBoxComboBoxDropdown()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }
        internal void AddItem(string item, bool isChecked)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            CheckBox checkBox = new CheckBox
            {
                Name = CreateCheckBoxName(vflpMain.Controls.Count),
                Text = item,
                AutoSize = true,
                Checked = isChecked

            };
            checkBox.CheckedChanged += CheckBox_CheckedChanged;
            vflpMain.Controls.Add(checkBox);
        }
        internal void AddItemRange(string[] items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                    throw new ArgumentException("Items cannot contain null values.", nameof(items));
            }

            CheckBox[] arrCheckBox = new CheckBox[items.Length];
            int startIndex = vflpMain.Controls.Count;
            for (int i = 0; i < items.Length; i++)
            {
                string sText = items[i];
                CheckBox checkBox = new CheckBox
                {
                    Name = CreateCheckBoxName(startIndex + i),
                    Text = sText,
                    AutoSize = true,
                    Checked = false
                };
                checkBox.CheckedChanged += CheckBox_CheckedChanged;
                arrCheckBox[i] = checkBox;
            }
            vflpMain.Controls.AddRange(arrCheckBox);
        }
        internal CheckBox FirstCheckBoxStringContain(string sText)
        {
            if (sText == null)
                throw new ArgumentNullException(nameof(sText));

            CheckBox[] arrCheckBox = GetItems;
            foreach (CheckBox checkBox in arrCheckBox)
            {
                if (checkBox.Text.Contains(sText))
                    return checkBox;
            }
            return null;
        }
        internal void ItemClear()
        {
            foreach (Control control in vflpMain.Controls.Cast<Control>().ToArray())
            {
                if (control is CheckBox checkBox)
                    checkBox.CheckedChanged -= CheckBox_CheckedChanged;

                vflpMain.Controls.Remove(control);
                control.Dispose();
            }
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckedChanged?.Invoke(this, e);
        }
        private static string CreateCheckBoxName(int index)
        {
            return $"cbx{index}";
        }
    }
}
