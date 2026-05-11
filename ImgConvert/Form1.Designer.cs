namespace ImgConvert
{
    partial class Form1
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
            this.ConvertButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioWebpButton = new System.Windows.Forms.RadioButton();
            this.radioPngButton = new System.Windows.Forms.RadioButton();
            this.radioJpgButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(109, 85);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(113, 37);
            this.ConvertButton.TabIndex = 0;
            this.ConvertButton.Text = "轉檔";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioWebpButton);
            this.groupBox1.Controls.Add(this.radioPngButton);
            this.groupBox1.Controls.Add(this.radioJpgButton);
            this.groupBox1.Location = new System.Drawing.Point(26, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(75, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "轉檔格式";
            // 
            // radioWebpButton
            // 
            this.radioWebpButton.AutoSize = true;
            this.radioWebpButton.Location = new System.Drawing.Point(6, 64);
            this.radioWebpButton.Name = "radioWebpButton";
            this.radioWebpButton.Size = new System.Drawing.Size(51, 16);
            this.radioWebpButton.TabIndex = 4;
            this.radioWebpButton.Text = "Webp";
            this.radioWebpButton.UseVisualStyleBackColor = true;
            // 
            // radioPngButton
            // 
            this.radioPngButton.AutoSize = true;
            this.radioPngButton.Checked = true;
            this.radioPngButton.Location = new System.Drawing.Point(6, 21);
            this.radioPngButton.Name = "radioPngButton";
            this.radioPngButton.Size = new System.Drawing.Size(41, 16);
            this.radioPngButton.TabIndex = 3;
            this.radioPngButton.TabStop = true;
            this.radioPngButton.Text = "Png";
            this.radioPngButton.UseVisualStyleBackColor = true;
            // 
            // radioJpgButton
            // 
            this.radioJpgButton.AutoSize = true;
            this.radioJpgButton.Location = new System.Drawing.Point(6, 42);
            this.radioJpgButton.Name = "radioJpgButton";
            this.radioJpgButton.Size = new System.Drawing.Size(39, 16);
            this.radioJpgButton.TabIndex = 2;
            this.radioJpgButton.Text = "Jpg";
            this.radioJpgButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "畫質%";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(151, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(30, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "100";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 136);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ConvertButton);
            this.Name = "Form1";
            this.Text = "圖片轉檔工具";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioPngButton;
        private System.Windows.Forms.RadioButton radioJpgButton;
        private System.Windows.Forms.RadioButton radioWebpButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

