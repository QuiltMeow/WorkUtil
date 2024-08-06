namespace PowerLEDOrderEditor
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
            this.btnSave = new System.Windows.Forms.Button();
            this.labelInput = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.labelPageName = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.txtPageName = new System.Windows.Forms.TextBox();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.labelDelay = new System.Windows.Forms.Label();
            this.txtDelay = new System.Windows.Forms.TextBox();
            this.labelContent = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.labelSecond = new System.Windows.Forms.Label();
            this.btnOpenContent = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.tvXML = new PowerLEDOrderEditor.CustomTreeView();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(497, 352);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(17, 48);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(53, 12);
            this.labelInput.TabIndex = 1;
            this.labelInput.Text = "輸入檔案";
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.SystemColors.Window;
            this.txtInput.Location = new System.Drawing.Point(80, 45);
            this.txtInput.Name = "txtInput";
            this.txtInput.ReadOnly = true;
            this.txtInput.Size = new System.Drawing.Size(300, 22);
            this.txtInput.TabIndex = 2;
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Location = new System.Drawing.Point(390, 43);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseInput.TabIndex = 3;
            this.btnBrowseInput.Text = "瀏覽";
            this.btnBrowseInput.UseVisualStyleBackColor = true;
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // labelPageName
            // 
            this.labelPageName.AutoSize = true;
            this.labelPageName.Location = new System.Drawing.Point(250, 88);
            this.labelPageName.Name = "labelPageName";
            this.labelPageName.Size = new System.Drawing.Size(29, 12);
            this.labelPageName.TabIndex = 5;
            this.labelPageName.Text = "名稱";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(250, 123);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(29, 12);
            this.labelSpeed.TabIndex = 7;
            this.labelSpeed.Text = "速度";
            // 
            // txtPageName
            // 
            this.txtPageName.BackColor = System.Drawing.SystemColors.Window;
            this.txtPageName.Location = new System.Drawing.Point(300, 85);
            this.txtPageName.Name = "txtPageName";
            this.txtPageName.ReadOnly = true;
            this.txtPageName.Size = new System.Drawing.Size(200, 22);
            this.txtPageName.TabIndex = 6;
            // 
            // txtSpeed
            // 
            this.txtSpeed.BackColor = System.Drawing.SystemColors.Window;
            this.txtSpeed.Location = new System.Drawing.Point(300, 120);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.ReadOnly = true;
            this.txtSpeed.Size = new System.Drawing.Size(200, 22);
            this.txtSpeed.TabIndex = 8;
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(250, 158);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(29, 12);
            this.labelDelay.TabIndex = 9;
            this.labelDelay.Text = "停留";
            // 
            // txtDelay
            // 
            this.txtDelay.BackColor = System.Drawing.SystemColors.Window;
            this.txtDelay.Location = new System.Drawing.Point(300, 155);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.ReadOnly = true;
            this.txtDelay.Size = new System.Drawing.Size(175, 22);
            this.txtDelay.TabIndex = 10;
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(250, 205);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(29, 12);
            this.labelContent.TabIndex = 12;
            this.labelContent.Text = "內容";
            // 
            // txtContent
            // 
            this.txtContent.BackColor = System.Drawing.SystemColors.Window;
            this.txtContent.Location = new System.Drawing.Point(252, 235);
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.Size = new System.Drawing.Size(320, 110);
            this.txtContent.TabIndex = 14;
            this.txtContent.Text = "";
            // 
            // labelSecond
            // 
            this.labelSecond.AutoSize = true;
            this.labelSecond.Location = new System.Drawing.Point(483, 158);
            this.labelSecond.Name = "labelSecond";
            this.labelSecond.Size = new System.Drawing.Size(17, 12);
            this.labelSecond.TabIndex = 11;
            this.labelSecond.Text = "秒";
            // 
            // btnOpenContent
            // 
            this.btnOpenContent.Enabled = false;
            this.btnOpenContent.Location = new System.Drawing.Point(497, 200);
            this.btnOpenContent.Name = "btnOpenContent";
            this.btnOpenContent.Size = new System.Drawing.Size(75, 23);
            this.btnOpenContent.TabIndex = 13;
            this.btnOpenContent.Text = "開啟";
            this.btnOpenContent.UseVisualStyleBackColor = true;
            this.btnOpenContent.Click += new System.EventHandler(this.btnOpenContent_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelTitle.Location = new System.Drawing.Point(15, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(221, 20);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Power LED 節目順序修改工具";
            // 
            // tvXML
            // 
            this.tvXML.AllowDrop = true;
            this.tvXML.Location = new System.Drawing.Point(19, 80);
            this.tvXML.Name = "tvXML";
            this.tvXML.Size = new System.Drawing.Size(195, 295);
            this.tvXML.TabIndex = 4;
            this.tvXML.SelectedNodeChanged += new System.Windows.Forms.TreeViewEventHandler(this.tvXML_SelectedNodeChanged);
            this.tvXML.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvXML_ItemDrag);
            this.tvXML.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvXML_DragDrop);
            this.tvXML.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvXML_DragEnter);
            this.tvXML.DragOver += new System.Windows.Forms.DragEventHandler(this.tvXML_DragOver);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 391);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnOpenContent);
            this.Controls.Add(this.labelSecond);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.labelContent);
            this.Controls.Add(this.txtDelay);
            this.Controls.Add(this.labelDelay);
            this.Controls.Add(this.txtSpeed);
            this.Controls.Add(this.txtPageName);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.labelPageName);
            this.Controls.Add(this.tvXML);
            this.Controls.Add(this.btnBrowseInput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Power LED 節目順序修改工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnBrowseInput;
        private CustomTreeView tvXML;
        private System.Windows.Forms.Label labelPageName;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.TextBox txtPageName;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.TextBox txtDelay;
        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.RichTextBox txtContent;
        private System.Windows.Forms.Label labelSecond;
        private System.Windows.Forms.Button btnOpenContent;
        private System.Windows.Forms.Label labelTitle;
    }
}

