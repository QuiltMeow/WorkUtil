namespace GroupListHandler
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpFileHandler = new System.Windows.Forms.TabPage();
            this.btnHandleFile = new System.Windows.Forms.Button();
            this.btnBrowseFileHandlerOutput = new System.Windows.Forms.Button();
            this.labelFileHandlerOutput = new System.Windows.Forms.Label();
            this.txtFileHandlerOutput = new System.Windows.Forms.TextBox();
            this.btnBrowseFileHandlerInput = new System.Windows.Forms.Button();
            this.txtFileHandlerInput = new System.Windows.Forms.TextBox();
            this.labelFileHandlerInput = new System.Windows.Forms.Label();
            this.tpDifference = new System.Windows.Forms.TabPage();
            this.btnBrowseDifferenceRightInput = new System.Windows.Forms.Button();
            this.txtDifferenceRightInput = new System.Windows.Forms.TextBox();
            this.labelDifferenceRightInput = new System.Windows.Forms.Label();
            this.btnHandleDifference = new System.Windows.Forms.Button();
            this.btnBrowseDifferenceOutput = new System.Windows.Forms.Button();
            this.labelDifferenceOutput = new System.Windows.Forms.Label();
            this.txtDifferenceOutput = new System.Windows.Forms.TextBox();
            this.btnBrowseDifferenceLeftInput = new System.Windows.Forms.Button();
            this.txtDifferenceLeftInput = new System.Windows.Forms.TextBox();
            this.labelDifferenceLeftInput = new System.Windows.Forms.Label();
            this.tcMain.SuspendLayout();
            this.tpFileHandler.SuspendLayout();
            this.tpDifference.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTitle.Location = new System.Drawing.Point(15, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(169, 20);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "人民團體名冊比對工具";
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpFileHandler);
            this.tcMain.Controls.Add(this.tpDifference);
            this.tcMain.Location = new System.Drawing.Point(19, 50);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(530, 240);
            this.tcMain.TabIndex = 1;
            // 
            // tpFileHandler
            // 
            this.tpFileHandler.Controls.Add(this.btnHandleFile);
            this.tpFileHandler.Controls.Add(this.btnBrowseFileHandlerOutput);
            this.tpFileHandler.Controls.Add(this.labelFileHandlerOutput);
            this.tpFileHandler.Controls.Add(this.txtFileHandlerOutput);
            this.tpFileHandler.Controls.Add(this.btnBrowseFileHandlerInput);
            this.tpFileHandler.Controls.Add(this.txtFileHandlerInput);
            this.tpFileHandler.Controls.Add(this.labelFileHandlerInput);
            this.tpFileHandler.Location = new System.Drawing.Point(4, 22);
            this.tpFileHandler.Name = "tpFileHandler";
            this.tpFileHandler.Padding = new System.Windows.Forms.Padding(3);
            this.tpFileHandler.Size = new System.Drawing.Size(522, 214);
            this.tpFileHandler.TabIndex = 0;
            this.tpFileHandler.Text = "檔案整理";
            this.tpFileHandler.UseVisualStyleBackColor = true;
            // 
            // btnHandleFile
            // 
            this.btnHandleFile.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnHandleFile.Location = new System.Drawing.Point(190, 135);
            this.btnHandleFile.Name = "btnHandleFile";
            this.btnHandleFile.Size = new System.Drawing.Size(100, 50);
            this.btnHandleFile.TabIndex = 6;
            this.btnHandleFile.Text = "開始處理";
            this.btnHandleFile.UseVisualStyleBackColor = true;
            this.btnHandleFile.Click += new System.EventHandler(this.btnHandleFile_Click);
            // 
            // btnBrowseFileHandlerOutput
            // 
            this.btnBrowseFileHandlerOutput.Location = new System.Drawing.Point(410, 80);
            this.btnBrowseFileHandlerOutput.Name = "btnBrowseFileHandlerOutput";
            this.btnBrowseFileHandlerOutput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFileHandlerOutput.TabIndex = 5;
            this.btnBrowseFileHandlerOutput.Text = "瀏覽";
            this.btnBrowseFileHandlerOutput.UseVisualStyleBackColor = true;
            this.btnBrowseFileHandlerOutput.Click += new System.EventHandler(this.btnBrowseFileHandlerOutput_Click);
            // 
            // labelFileHandlerOutput
            // 
            this.labelFileHandlerOutput.AutoSize = true;
            this.labelFileHandlerOutput.Location = new System.Drawing.Point(25, 85);
            this.labelFileHandlerOutput.Name = "labelFileHandlerOutput";
            this.labelFileHandlerOutput.Size = new System.Drawing.Size(53, 12);
            this.labelFileHandlerOutput.TabIndex = 3;
            this.labelFileHandlerOutput.Text = "輸出檔案";
            // 
            // txtFileHandlerOutput
            // 
            this.txtFileHandlerOutput.BackColor = System.Drawing.Color.White;
            this.txtFileHandlerOutput.Location = new System.Drawing.Point(95, 82);
            this.txtFileHandlerOutput.Name = "txtFileHandlerOutput";
            this.txtFileHandlerOutput.ReadOnly = true;
            this.txtFileHandlerOutput.Size = new System.Drawing.Size(300, 22);
            this.txtFileHandlerOutput.TabIndex = 4;
            // 
            // btnBrowseFileHandlerInput
            // 
            this.btnBrowseFileHandlerInput.Location = new System.Drawing.Point(410, 25);
            this.btnBrowseFileHandlerInput.Name = "btnBrowseFileHandlerInput";
            this.btnBrowseFileHandlerInput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFileHandlerInput.TabIndex = 2;
            this.btnBrowseFileHandlerInput.Text = "瀏覽";
            this.btnBrowseFileHandlerInput.UseVisualStyleBackColor = true;
            this.btnBrowseFileHandlerInput.Click += new System.EventHandler(this.btnBrowseFileHandlerInput_Click);
            // 
            // txtFileHandlerInput
            // 
            this.txtFileHandlerInput.BackColor = System.Drawing.Color.White;
            this.txtFileHandlerInput.Location = new System.Drawing.Point(95, 27);
            this.txtFileHandlerInput.Name = "txtFileHandlerInput";
            this.txtFileHandlerInput.ReadOnly = true;
            this.txtFileHandlerInput.Size = new System.Drawing.Size(300, 22);
            this.txtFileHandlerInput.TabIndex = 1;
            // 
            // labelFileHandlerInput
            // 
            this.labelFileHandlerInput.AutoSize = true;
            this.labelFileHandlerInput.Location = new System.Drawing.Point(25, 30);
            this.labelFileHandlerInput.Name = "labelFileHandlerInput";
            this.labelFileHandlerInput.Size = new System.Drawing.Size(53, 12);
            this.labelFileHandlerInput.TabIndex = 0;
            this.labelFileHandlerInput.Text = "輸入檔案";
            // 
            // tpDifference
            // 
            this.tpDifference.Controls.Add(this.btnBrowseDifferenceRightInput);
            this.tpDifference.Controls.Add(this.txtDifferenceRightInput);
            this.tpDifference.Controls.Add(this.labelDifferenceRightInput);
            this.tpDifference.Controls.Add(this.btnHandleDifference);
            this.tpDifference.Controls.Add(this.btnBrowseDifferenceOutput);
            this.tpDifference.Controls.Add(this.labelDifferenceOutput);
            this.tpDifference.Controls.Add(this.txtDifferenceOutput);
            this.tpDifference.Controls.Add(this.btnBrowseDifferenceLeftInput);
            this.tpDifference.Controls.Add(this.txtDifferenceLeftInput);
            this.tpDifference.Controls.Add(this.labelDifferenceLeftInput);
            this.tpDifference.Location = new System.Drawing.Point(4, 22);
            this.tpDifference.Name = "tpDifference";
            this.tpDifference.Padding = new System.Windows.Forms.Padding(3);
            this.tpDifference.Size = new System.Drawing.Size(522, 214);
            this.tpDifference.TabIndex = 1;
            this.tpDifference.Text = "差異比對";
            this.tpDifference.UseVisualStyleBackColor = true;
            // 
            // btnBrowseDifferenceRightInput
            // 
            this.btnBrowseDifferenceRightInput.Location = new System.Drawing.Point(425, 60);
            this.btnBrowseDifferenceRightInput.Name = "btnBrowseDifferenceRightInput";
            this.btnBrowseDifferenceRightInput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDifferenceRightInput.TabIndex = 5;
            this.btnBrowseDifferenceRightInput.Text = "瀏覽";
            this.btnBrowseDifferenceRightInput.UseVisualStyleBackColor = true;
            this.btnBrowseDifferenceRightInput.Click += new System.EventHandler(this.btnBrowseDifferenceRightInput_Click);
            // 
            // txtDifferenceRightInput
            // 
            this.txtDifferenceRightInput.BackColor = System.Drawing.Color.White;
            this.txtDifferenceRightInput.Location = new System.Drawing.Point(115, 62);
            this.txtDifferenceRightInput.Name = "txtDifferenceRightInput";
            this.txtDifferenceRightInput.ReadOnly = true;
            this.txtDifferenceRightInput.Size = new System.Drawing.Size(300, 22);
            this.txtDifferenceRightInput.TabIndex = 4;
            // 
            // labelDifferenceRightInput
            // 
            this.labelDifferenceRightInput.AutoSize = true;
            this.labelDifferenceRightInput.Location = new System.Drawing.Point(20, 65);
            this.labelDifferenceRightInput.Name = "labelDifferenceRightInput";
            this.labelDifferenceRightInput.Size = new System.Drawing.Size(86, 12);
            this.labelDifferenceRightInput.TabIndex = 3;
            this.labelDifferenceRightInput.Text = "比對輸入檔案 2";
            // 
            // btnHandleDifference
            // 
            this.btnHandleDifference.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnHandleDifference.Location = new System.Drawing.Point(200, 140);
            this.btnHandleDifference.Name = "btnHandleDifference";
            this.btnHandleDifference.Size = new System.Drawing.Size(100, 50);
            this.btnHandleDifference.TabIndex = 9;
            this.btnHandleDifference.Text = "開始處理";
            this.btnHandleDifference.UseVisualStyleBackColor = true;
            this.btnHandleDifference.Click += new System.EventHandler(this.btnHandleDifference_Click);
            // 
            // btnBrowseDifferenceOutput
            // 
            this.btnBrowseDifferenceOutput.Location = new System.Drawing.Point(425, 95);
            this.btnBrowseDifferenceOutput.Name = "btnBrowseDifferenceOutput";
            this.btnBrowseDifferenceOutput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDifferenceOutput.TabIndex = 8;
            this.btnBrowseDifferenceOutput.Text = "瀏覽";
            this.btnBrowseDifferenceOutput.UseVisualStyleBackColor = true;
            this.btnBrowseDifferenceOutput.Click += new System.EventHandler(this.btnBrowseDifferenceOutput_Click);
            // 
            // labelDifferenceOutput
            // 
            this.labelDifferenceOutput.AutoSize = true;
            this.labelDifferenceOutput.Location = new System.Drawing.Point(20, 100);
            this.labelDifferenceOutput.Name = "labelDifferenceOutput";
            this.labelDifferenceOutput.Size = new System.Drawing.Size(53, 12);
            this.labelDifferenceOutput.TabIndex = 6;
            this.labelDifferenceOutput.Text = "輸出檔案";
            // 
            // txtDifferenceOutput
            // 
            this.txtDifferenceOutput.BackColor = System.Drawing.Color.White;
            this.txtDifferenceOutput.Location = new System.Drawing.Point(115, 97);
            this.txtDifferenceOutput.Name = "txtDifferenceOutput";
            this.txtDifferenceOutput.ReadOnly = true;
            this.txtDifferenceOutput.Size = new System.Drawing.Size(300, 22);
            this.txtDifferenceOutput.TabIndex = 7;
            // 
            // btnBrowseDifferenceLeftInput
            // 
            this.btnBrowseDifferenceLeftInput.Location = new System.Drawing.Point(425, 25);
            this.btnBrowseDifferenceLeftInput.Name = "btnBrowseDifferenceLeftInput";
            this.btnBrowseDifferenceLeftInput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDifferenceLeftInput.TabIndex = 2;
            this.btnBrowseDifferenceLeftInput.Text = "瀏覽";
            this.btnBrowseDifferenceLeftInput.UseVisualStyleBackColor = true;
            this.btnBrowseDifferenceLeftInput.Click += new System.EventHandler(this.btnBrowseDifferenceLeftInput_Click);
            // 
            // txtDifferenceLeftInput
            // 
            this.txtDifferenceLeftInput.BackColor = System.Drawing.Color.White;
            this.txtDifferenceLeftInput.Location = new System.Drawing.Point(115, 27);
            this.txtDifferenceLeftInput.Name = "txtDifferenceLeftInput";
            this.txtDifferenceLeftInput.ReadOnly = true;
            this.txtDifferenceLeftInput.Size = new System.Drawing.Size(300, 22);
            this.txtDifferenceLeftInput.TabIndex = 1;
            // 
            // labelDifferenceLeftInput
            // 
            this.labelDifferenceLeftInput.AutoSize = true;
            this.labelDifferenceLeftInput.Location = new System.Drawing.Point(20, 30);
            this.labelDifferenceLeftInput.Name = "labelDifferenceLeftInput";
            this.labelDifferenceLeftInput.Size = new System.Drawing.Size(86, 12);
            this.labelDifferenceLeftInput.TabIndex = 0;
            this.labelDifferenceLeftInput.Text = "比對輸入檔案 1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 306);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "人民團體名冊比對工具";
            this.tcMain.ResumeLayout(false);
            this.tpFileHandler.ResumeLayout(false);
            this.tpFileHandler.PerformLayout();
            this.tpDifference.ResumeLayout(false);
            this.tpDifference.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpFileHandler;
        private System.Windows.Forms.Button btnHandleFile;
        private System.Windows.Forms.Button btnBrowseFileHandlerOutput;
        private System.Windows.Forms.Label labelFileHandlerOutput;
        private System.Windows.Forms.TextBox txtFileHandlerOutput;
        private System.Windows.Forms.Button btnBrowseFileHandlerInput;
        private System.Windows.Forms.TextBox txtFileHandlerInput;
        private System.Windows.Forms.Label labelFileHandlerInput;
        private System.Windows.Forms.TabPage tpDifference;
        private System.Windows.Forms.Button btnBrowseDifferenceRightInput;
        private System.Windows.Forms.TextBox txtDifferenceRightInput;
        private System.Windows.Forms.Label labelDifferenceRightInput;
        private System.Windows.Forms.Button btnHandleDifference;
        private System.Windows.Forms.Button btnBrowseDifferenceOutput;
        private System.Windows.Forms.Label labelDifferenceOutput;
        private System.Windows.Forms.TextBox txtDifferenceOutput;
        private System.Windows.Forms.Button btnBrowseDifferenceLeftInput;
        private System.Windows.Forms.TextBox txtDifferenceLeftInput;
        private System.Windows.Forms.Label labelDifferenceLeftInput;
    }
}

