namespace VideoCompress
{
    partial class DefaultConfigurationForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultConfigurationForm));
            labelResolution = new Label();
            cbResolution = new ComboBox();
            btnConfirm = new Button();
            labelBitRate = new Label();
            cbBitRate = new ComboBox();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // labelResolution
            // 
            labelResolution.AutoSize = true;
            labelResolution.Location = new Point(15, 15);
            labelResolution.Name = "labelResolution";
            labelResolution.Size = new Size(67, 15);
            labelResolution.TabIndex = 0;
            labelResolution.Text = "選擇解析度";
            // 
            // cbResolution
            // 
            cbResolution.DropDownStyle = ComboBoxStyle.DropDownList;
            cbResolution.FormattingEnabled = true;
            cbResolution.Location = new Point(50, 50);
            cbResolution.Name = "cbResolution";
            cbResolution.Size = new Size(500, 23);
            cbResolution.TabIndex = 1;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(100, 180);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 4;
            btnConfirm.Text = "確認";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // labelBitRate
            // 
            labelBitRate.AutoSize = true;
            labelBitRate.Location = new Point(15, 100);
            labelBitRate.Name = "labelBitRate";
            labelBitRate.Size = new Size(79, 15);
            labelBitRate.TabIndex = 2;
            labelBitRate.Text = "選擇位元速率";
            // 
            // cbBitRate
            // 
            cbBitRate.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBitRate.FormattingEnabled = true;
            cbBitRate.Location = new Point(50, 135);
            cbBitRate.Name = "cbBitRate";
            cbBitRate.Size = new Size(500, 23);
            cbBitRate.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(350, 180);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // DefaultConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(574, 221);
            Controls.Add(btnCancel);
            Controls.Add(cbBitRate);
            Controls.Add(labelBitRate);
            Controls.Add(btnConfirm);
            Controls.Add(cbResolution);
            Controls.Add(labelResolution);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            ImeMode = ImeMode.Off;
            MaximizeBox = false;
            Name = "DefaultConfigurationForm";
            Text = "選擇預設參數";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelResolution;
        private ComboBox cbResolution;
        private Button btnConfirm;
        private Label labelBitRate;
        private ComboBox cbBitRate;
        private Button btnCancel;
    }
}