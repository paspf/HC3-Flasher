namespace HC3_Flasher
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxCom = new System.Windows.Forms.TextBox();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FlashButton = new System.Windows.Forms.Button();
            this.comboBoxProfileSelect = new System.Windows.Forms.ComboBox();
            this.textBoxBaudRate = new System.Windows.Forms.TextBox();
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.labelParity = new System.Windows.Forms.Label();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.labelDataBits = new System.Windows.Forms.Label();
            this.textBoxDataBits = new System.Windows.Forms.TextBox();
            this.labelStopBits = new System.Windows.Forms.Label();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.storeProfileButton = new System.Windows.Forms.Button();
            this.dropProfileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxCom
            // 
            this.textBoxCom.Location = new System.Drawing.Point(72, 10);
            this.textBoxCom.Name = "textBoxCom";
            this.textBoxCom.Size = new System.Drawing.Size(384, 20);
            this.textBoxCom.TabIndex = 0;
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(72, 36);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(384, 20);
            this.textBoxFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "COM Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Flash File";
            // 
            // FlashButton
            // 
            this.FlashButton.Location = new System.Drawing.Point(462, 10);
            this.FlashButton.Name = "FlashButton";
            this.FlashButton.Size = new System.Drawing.Size(82, 46);
            this.FlashButton.TabIndex = 4;
            this.FlashButton.Text = "Flash!";
            this.FlashButton.UseVisualStyleBackColor = true;
            this.FlashButton.Click += new System.EventHandler(this.FlashButton_Click);
            // 
            // comboBoxProfileSelect
            // 
            this.comboBoxProfileSelect.FormattingEnabled = true;
            this.comboBoxProfileSelect.Location = new System.Drawing.Point(16, 62);
            this.comboBoxProfileSelect.Name = "comboBoxProfileSelect";
            this.comboBoxProfileSelect.Size = new System.Drawing.Size(96, 21);
            this.comboBoxProfileSelect.TabIndex = 5;
            this.comboBoxProfileSelect.SelectedIndexChanged += new System.EventHandler(this.comboBoxProfileSelect_SelectedIndexChanged);
            // 
            // textBoxBaudRate
            // 
            this.textBoxBaudRate.Location = new System.Drawing.Point(182, 62);
            this.textBoxBaudRate.Name = "textBoxBaudRate";
            this.textBoxBaudRate.Size = new System.Drawing.Size(64, 20);
            this.textBoxBaudRate.TabIndex = 6;
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Location = new System.Drawing.Point(118, 65);
            this.labelBaudRate.Name = "labelBaudRate";
            this.labelBaudRate.Size = new System.Drawing.Size(58, 13);
            this.labelBaudRate.TabIndex = 7;
            this.labelBaudRate.Text = "Baud Rate";
            // 
            // labelParity
            // 
            this.labelParity.AutoSize = true;
            this.labelParity.Location = new System.Drawing.Point(252, 65);
            this.labelParity.Name = "labelParity";
            this.labelParity.Size = new System.Drawing.Size(33, 13);
            this.labelParity.TabIndex = 8;
            this.labelParity.Text = "Parity";
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Location = new System.Drawing.Point(291, 62);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(64, 21);
            this.comboBoxParity.TabIndex = 9;
            // 
            // labelDataBits
            // 
            this.labelDataBits.AutoSize = true;
            this.labelDataBits.Location = new System.Drawing.Point(361, 65);
            this.labelDataBits.Name = "labelDataBits";
            this.labelDataBits.Size = new System.Drawing.Size(47, 13);
            this.labelDataBits.TabIndex = 10;
            this.labelDataBits.Text = "DataBits";
            // 
            // textBoxDataBits
            // 
            this.textBoxDataBits.Location = new System.Drawing.Point(414, 62);
            this.textBoxDataBits.Name = "textBoxDataBits";
            this.textBoxDataBits.Size = new System.Drawing.Size(32, 20);
            this.textBoxDataBits.TabIndex = 11;
            // 
            // labelStopBits
            // 
            this.labelStopBits.AutoSize = true;
            this.labelStopBits.Location = new System.Drawing.Point(450, 65);
            this.labelStopBits.Name = "labelStopBits";
            this.labelStopBits.Size = new System.Drawing.Size(46, 13);
            this.labelStopBits.TabIndex = 12;
            this.labelStopBits.Text = "StopBits";
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Location = new System.Drawing.Point(502, 62);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(42, 21);
            this.comboBoxStopBits.TabIndex = 13;
            // 
            // storeProfileButton
            // 
            this.storeProfileButton.Location = new System.Drawing.Point(16, 89);
            this.storeProfileButton.Name = "storeProfileButton";
            this.storeProfileButton.Size = new System.Drawing.Size(75, 23);
            this.storeProfileButton.TabIndex = 14;
            this.storeProfileButton.Text = "Store Profile";
            this.storeProfileButton.UseVisualStyleBackColor = true;
            this.storeProfileButton.Click += new System.EventHandler(this.storeProfileButton_Click);
            // 
            // dropProfileButton
            // 
            this.dropProfileButton.Location = new System.Drawing.Point(98, 88);
            this.dropProfileButton.Name = "dropProfileButton";
            this.dropProfileButton.Size = new System.Drawing.Size(75, 23);
            this.dropProfileButton.TabIndex = 15;
            this.dropProfileButton.Text = "Drop Profile";
            this.dropProfileButton.UseVisualStyleBackColor = true;
            this.dropProfileButton.Click += new System.EventHandler(this.dropProfileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 118);
            this.Controls.Add(this.dropProfileButton);
            this.Controls.Add(this.storeProfileButton);
            this.Controls.Add(this.comboBoxStopBits);
            this.Controls.Add(this.labelStopBits);
            this.Controls.Add(this.textBoxDataBits);
            this.Controls.Add(this.labelDataBits);
            this.Controls.Add(this.comboBoxParity);
            this.Controls.Add(this.labelParity);
            this.Controls.Add(this.labelBaudRate);
            this.Controls.Add(this.textBoxBaudRate);
            this.Controls.Add(this.comboBoxProfileSelect);
            this.Controls.Add(this.FlashButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.textBoxCom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "HC3 Flasher (2019 10 01)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCom;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button FlashButton;
        private System.Windows.Forms.ComboBox comboBoxProfileSelect;
        private System.Windows.Forms.TextBox textBoxBaudRate;
        private System.Windows.Forms.Label labelBaudRate;
        private System.Windows.Forms.Label labelParity;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.Label labelDataBits;
        private System.Windows.Forms.TextBox textBoxDataBits;
        private System.Windows.Forms.Label labelStopBits;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.Button storeProfileButton;
        private System.Windows.Forms.Button dropProfileButton;
    }
}

