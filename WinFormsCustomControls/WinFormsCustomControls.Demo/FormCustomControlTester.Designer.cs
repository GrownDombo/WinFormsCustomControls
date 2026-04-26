namespace WinFormsCustomControls.Demo
{
    partial class FormCustomControlTester
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbColorComboBox = new System.Windows.Forms.Label();
            this.lbCheckBoxComboBox = new System.Windows.Forms.Label();
            this.checkableGroupBox1 = new WinFormsCustomControls.CheckableGroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.doubleBufferedDataGridView1 = new WinFormsCustomControls.DoubleBufferedDataGridView();
            this.colorComboBox1 = new WinFormsCustomControls.ColorComboBox();
            this.verticalFlowLayoutPanel1 = new WinFormsCustomControls.VerticalFlowLayoutPanel();
            this.checkBoxComboBox1 = new WinFormsCustomControls.CheckBoxComboBox();
            this.checkableGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleBufferedDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbColorComboBox
            // 
            this.lbColorComboBox.Location = new System.Drawing.Point(12, 8);
            this.lbColorComboBox.Name = "lbColorComboBox";
            this.lbColorComboBox.Size = new System.Drawing.Size(138, 23);
            this.lbColorComboBox.TabIndex = 4;
            this.lbColorComboBox.Text = "ColorComboBox : ";
            this.lbColorComboBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCheckBoxComboBox
            // 
            this.lbCheckBoxComboBox.Location = new System.Drawing.Point(12, 36);
            this.lbCheckBoxComboBox.Name = "lbCheckBoxComboBox";
            this.lbCheckBoxComboBox.Size = new System.Drawing.Size(138, 17);
            this.lbCheckBoxComboBox.TabIndex = 5;
            this.lbCheckBoxComboBox.Text = "CheckBoxComboBox : ";
            this.lbCheckBoxComboBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkableGroupBox1
            // 
            this.checkableGroupBox1.Checked = false;
            this.checkableGroupBox1.Controls.Add(this.checkBox1);
            this.checkableGroupBox1.Location = new System.Drawing.Point(12, 59);
            this.checkableGroupBox1.Name = "checkableGroupBox1";
            this.checkableGroupBox1.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.checkableGroupBox1.Size = new System.Drawing.Size(238, 106);
            this.checkableGroupBox1.TabIndex = 6;
            this.checkableGroupBox1.Text = "checkableGroupBox1";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // doubleBufferedDataGridView1
            // 
            this.doubleBufferedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.doubleBufferedDataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.doubleBufferedDataGridView1.Location = new System.Drawing.Point(288, 0);
            this.doubleBufferedDataGridView1.Name = "doubleBufferedDataGridView1";
            this.doubleBufferedDataGridView1.RowTemplate.Height = 23;
            this.doubleBufferedDataGridView1.Size = new System.Drawing.Size(350, 654);
            this.doubleBufferedDataGridView1.TabIndex = 2;
            // 
            // colorComboBox1
            // 
            this.colorComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorComboBox1.DropDownHeight = 1;
            this.colorComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox1.FormattingEnabled = true;
            this.colorComboBox1.IntegralHeight = false;
            this.colorComboBox1.Location = new System.Drawing.Point(156, 5);
            this.colorComboBox1.Name = "colorComboBox1";
            this.colorComboBox1.SelectedColor = System.Drawing.Color.Red;
            this.colorComboBox1.Size = new System.Drawing.Size(94, 22);
            this.colorComboBox1.TabIndex = 1;
            // 
            // verticalFlowLayoutPanel1
            // 
            this.verticalFlowLayoutPanel1.AutoScroll = true;
            this.verticalFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.verticalFlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.verticalFlowLayoutPanel1.Location = new System.Drawing.Point(638, 0);
            this.verticalFlowLayoutPanel1.Name = "verticalFlowLayoutPanel1";
            this.verticalFlowLayoutPanel1.Size = new System.Drawing.Size(350, 654);
            this.verticalFlowLayoutPanel1.TabIndex = 3;
            this.verticalFlowLayoutPanel1.WrapContents = false;
            // 
            // checkBoxComboBox1
            // 
            this.checkBoxComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.checkBoxComboBox1.DropDownHeight = 1;
            this.checkBoxComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.checkBoxComboBox1.FormattingEnabled = true;
            this.checkBoxComboBox1.IntegralHeight = false;
            this.checkBoxComboBox1.Location = new System.Drawing.Point(156, 34);
            this.checkBoxComboBox1.Name = "checkBoxComboBox1";
            this.checkBoxComboBox1.Size = new System.Drawing.Size(94, 22);
            this.checkBoxComboBox1.TabIndex = 0;
            // 
            // FormCustomControlTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 654);
            this.Controls.Add(this.checkableGroupBox1);
            this.Controls.Add(this.lbCheckBoxComboBox);
            this.Controls.Add(this.lbColorComboBox);
            this.Controls.Add(this.doubleBufferedDataGridView1);
            this.Controls.Add(this.colorComboBox1);
            this.Controls.Add(this.verticalFlowLayoutPanel1);
            this.Controls.Add(this.checkBoxComboBox1);
            this.Name = "FormCustomControlTester";
            this.Text = "FormCustomControlTester";
            this.checkableGroupBox1.ResumeLayout(false);
            this.checkableGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleBufferedDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WinFormsCustomControls.CheckBoxComboBox checkBoxComboBox1;
        private WinFormsCustomControls.ColorComboBox colorComboBox1;
        private WinFormsCustomControls.DoubleBufferedDataGridView doubleBufferedDataGridView1;
        private WinFormsCustomControls.VerticalFlowLayoutPanel verticalFlowLayoutPanel1;
        private System.Windows.Forms.Label lbColorComboBox;
        private System.Windows.Forms.Label lbCheckBoxComboBox;
        private WinFormsCustomControls.CheckableGroupBox checkableGroupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

