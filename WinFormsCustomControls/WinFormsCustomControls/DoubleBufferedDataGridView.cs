using System.ComponentModel;
using System.Windows.Forms;

namespace WinFormsCustomControls
{
    public partial class DoubleBufferedDataGridView : DataGridView
    {
        // Constructor
        public DoubleBufferedDataGridView()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, false);
            this.UpdateStyles();
        }
    }
}
