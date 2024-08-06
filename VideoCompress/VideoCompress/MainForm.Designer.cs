namespace VideoCompress
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            chkRemoveAudio = new CheckBox();
            chkResizeResolution = new CheckBox();
            labelInput = new Label();
            txtInput = new TextBox();
            btnBrowseInput = new Button();
            btnSelectDefault = new Button();
            numWidth = new NumericUpDown();
            numHeight = new NumericUpDown();
            chkChangeBitRate = new CheckBox();
            chkReEncode = new CheckBox();
            labelKbps = new Label();
            btnProcess = new Button();
            labelOutput = new Label();
            txtOutput = new TextBox();
            btnBrowseOutput = new Button();
            numBitRate = new NumericUpDown();
            labelProduct = new Label();
            labelResult = new Label();
            txtResult = new TextBox();
            btnClearLog = new Button();
            ((System.ComponentModel.ISupportInitialize)numWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBitRate).BeginInit();
            SuspendLayout();
            // 
            // chkRemoveAudio
            // 
            chkRemoveAudio.AutoSize = true;
            chkRemoveAudio.Location = new Point(25, 110);
            chkRemoveAudio.Name = "chkRemoveAudio";
            chkRemoveAudio.Size = new Size(74, 19);
            chkRemoveAudio.TabIndex = 6;
            chkRemoveAudio.Text = "移除音訊";
            chkRemoveAudio.UseVisualStyleBackColor = true;
            // 
            // chkResizeResolution
            // 
            chkResizeResolution.AutoSize = true;
            chkResizeResolution.Location = new Point(25, 145);
            chkResizeResolution.Name = "chkResizeResolution";
            chkResizeResolution.Size = new Size(86, 19);
            chkResizeResolution.TabIndex = 7;
            chkResizeResolution.Text = "調整解析度";
            chkResizeResolution.UseVisualStyleBackColor = true;
            chkResizeResolution.CheckedChanged += chkResizeResolution_CheckedChanged;
            // 
            // labelInput
            // 
            labelInput.AutoSize = true;
            labelInput.Location = new Point(25, 25);
            labelInput.Name = "labelInput";
            labelInput.Size = new Size(55, 15);
            labelInput.TabIndex = 0;
            labelInput.Text = "輸入檔案";
            // 
            // txtInput
            // 
            txtInput.BackColor = SystemColors.Window;
            txtInput.Location = new Point(90, 22);
            txtInput.Name = "txtInput";
            txtInput.ReadOnly = true;
            txtInput.Size = new Size(250, 23);
            txtInput.TabIndex = 1;
            // 
            // btnBrowseInput
            // 
            btnBrowseInput.Location = new Point(350, 21);
            btnBrowseInput.Name = "btnBrowseInput";
            btnBrowseInput.Size = new Size(75, 23);
            btnBrowseInput.TabIndex = 2;
            btnBrowseInput.Text = "瀏覽";
            btnBrowseInput.UseVisualStyleBackColor = true;
            btnBrowseInput.Click += btnBrowseInput_Click;
            // 
            // btnSelectDefault
            // 
            btnSelectDefault.Location = new Point(120, 142);
            btnSelectDefault.Name = "btnSelectDefault";
            btnSelectDefault.Size = new Size(75, 23);
            btnSelectDefault.TabIndex = 8;
            btnSelectDefault.Text = "選擇預設";
            btnSelectDefault.UseVisualStyleBackColor = true;
            btnSelectDefault.Click += btnSelectDefault_Click;
            // 
            // numWidth
            // 
            numWidth.Enabled = false;
            numWidth.Location = new Point(40, 180);
            numWidth.Maximum = new decimal(new int[] { 8192, 0, 0, 0 });
            numWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numWidth.Name = "numWidth";
            numWidth.Size = new Size(120, 23);
            numWidth.TabIndex = 9;
            numWidth.Value = new decimal(new int[] { 1080, 0, 0, 0 });
            // 
            // numHeight
            // 
            numHeight.Enabled = false;
            numHeight.Location = new Point(215, 180);
            numHeight.Maximum = new decimal(new int[] { 8192, 0, 0, 0 });
            numHeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numHeight.Name = "numHeight";
            numHeight.Size = new Size(120, 23);
            numHeight.TabIndex = 11;
            numHeight.Value = new decimal(new int[] { 608, 0, 0, 0 });
            // 
            // chkChangeBitRate
            // 
            chkChangeBitRate.AutoSize = true;
            chkChangeBitRate.Location = new Point(25, 225);
            chkChangeBitRate.Name = "chkChangeBitRate";
            chkChangeBitRate.Size = new Size(98, 19);
            chkChangeBitRate.TabIndex = 12;
            chkChangeBitRate.Text = "調整位元速率";
            chkChangeBitRate.UseVisualStyleBackColor = true;
            chkChangeBitRate.CheckedChanged += chkChangeBitRate_CheckedChanged;
            // 
            // chkReEncode
            // 
            chkReEncode.AutoSize = true;
            chkReEncode.Location = new Point(25, 305);
            chkReEncode.Name = "chkReEncode";
            chkReEncode.Size = new Size(173, 19);
            chkReEncode.TabIndex = 15;
            chkReEncode.Text = "重新執行 H.264／AAC 編碼";
            chkReEncode.UseVisualStyleBackColor = true;
            // 
            // labelKbps
            // 
            labelKbps.AutoSize = true;
            labelKbps.Location = new Point(180, 262);
            labelKbps.Name = "labelKbps";
            labelKbps.Size = new Size(35, 15);
            labelKbps.TabIndex = 14;
            labelKbps.Text = "Kbps";
            // 
            // btnProcess
            // 
            btnProcess.Location = new Point(115, 382);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(175, 23);
            btnProcess.TabIndex = 16;
            btnProcess.Text = "處理影片";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // labelOutput
            // 
            labelOutput.AutoSize = true;
            labelOutput.Location = new Point(25, 65);
            labelOutput.Name = "labelOutput";
            labelOutput.Size = new Size(55, 15);
            labelOutput.TabIndex = 3;
            labelOutput.Text = "輸出檔案";
            // 
            // txtOutput
            // 
            txtOutput.BackColor = SystemColors.Window;
            txtOutput.Location = new Point(90, 62);
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.Size = new Size(250, 23);
            txtOutput.TabIndex = 4;
            // 
            // btnBrowseOutput
            // 
            btnBrowseOutput.Location = new Point(350, 61);
            btnBrowseOutput.Name = "btnBrowseOutput";
            btnBrowseOutput.Size = new Size(75, 23);
            btnBrowseOutput.TabIndex = 5;
            btnBrowseOutput.Text = "瀏覽";
            btnBrowseOutput.UseVisualStyleBackColor = true;
            btnBrowseOutput.Click += btnBrowseOutput_Click;
            // 
            // numBitRate
            // 
            numBitRate.Enabled = false;
            numBitRate.Location = new Point(40, 260);
            numBitRate.Maximum = new decimal(new int[] { 300000, 0, 0, 0 });
            numBitRate.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numBitRate.Name = "numBitRate";
            numBitRate.Size = new Size(120, 23);
            numBitRate.TabIndex = 13;
            numBitRate.Value = new decimal(new int[] { 320, 0, 0, 0 });
            // 
            // labelProduct
            // 
            labelProduct.AutoSize = true;
            labelProduct.Location = new Point(180, 182);
            labelProduct.Name = "labelProduct";
            labelProduct.Size = new Size(16, 15);
            labelProduct.TabIndex = 10;
            labelProduct.Text = "×";
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(470, 25);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(55, 15);
            labelResult.TabIndex = 17;
            labelResult.Text = "處理狀態";
            // 
            // txtResult
            // 
            txtResult.BackColor = SystemColors.Window;
            txtResult.Location = new Point(470, 55);
            txtResult.Multiline = true;
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.ScrollBars = ScrollBars.Both;
            txtResult.Size = new Size(300, 350);
            txtResult.TabIndex = 19;
            // 
            // btnClearLog
            // 
            btnClearLog.Location = new Point(695, 21);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(75, 23);
            btnClearLog.TabIndex = 18;
            btnClearLog.Text = "清除紀錄";
            btnClearLog.UseVisualStyleBackColor = true;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 421);
            Controls.Add(btnClearLog);
            Controls.Add(txtResult);
            Controls.Add(labelResult);
            Controls.Add(labelProduct);
            Controls.Add(numBitRate);
            Controls.Add(btnBrowseOutput);
            Controls.Add(txtOutput);
            Controls.Add(labelOutput);
            Controls.Add(btnProcess);
            Controls.Add(labelKbps);
            Controls.Add(chkReEncode);
            Controls.Add(chkChangeBitRate);
            Controls.Add(numHeight);
            Controls.Add(numWidth);
            Controls.Add(btnSelectDefault);
            Controls.Add(btnBrowseInput);
            Controls.Add(txtInput);
            Controls.Add(labelInput);
            Controls.Add(chkResizeResolution);
            Controls.Add(chkRemoveAudio);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            ImeMode = ImeMode.Off;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "影片壓縮工具";
            ((System.ComponentModel.ISupportInitialize)numWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBitRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkRemoveAudio;
        private CheckBox chkResizeResolution;
        private Label labelInput;
        private TextBox txtInput;
        private Button btnBrowseInput;
        private Button btnSelectDefault;
        private NumericUpDown numWidth;
        private NumericUpDown numHeight;
        private CheckBox chkChangeBitRate;
        private CheckBox chkReEncode;
        private Label labelKbps;
        private Button btnProcess;
        private Label labelOutput;
        private TextBox txtOutput;
        private Button btnBrowseOutput;
        private NumericUpDown numBitRate;
        private Label labelProduct;
        private Label labelResult;
        private TextBox txtResult;
        private Button btnClearLog;
    }
}
