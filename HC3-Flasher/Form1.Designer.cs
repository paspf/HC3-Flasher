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
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxComPort = new System.Windows.Forms.ComboBox();
            this.buttonSetAsDefault = new System.Windows.Forms.Button();
            this.buttonRefreshCom = new System.Windows.Forms.Button();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(103, 49);
            this.textBoxFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(420, 22);
            this.textBoxFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "COM Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Binary File";
            // 
            // FlashButton
            // 
            this.FlashButton.Location = new System.Drawing.Point(621, 11);
            this.FlashButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FlashButton.Name = "FlashButton";
            this.FlashButton.Size = new System.Drawing.Size(83, 63);
            this.FlashButton.TabIndex = 4;
            this.FlashButton.Text = "Flash!";
            this.FlashButton.UseVisualStyleBackColor = true;
            this.FlashButton.Click += new System.EventHandler(this.FlashButton_Click);
            // 
            // comboBoxProfileSelect
            // 
            this.comboBoxProfileSelect.FormattingEnabled = true;
            this.comboBoxProfileSelect.Location = new System.Drawing.Point(20, 84);
            this.comboBoxProfileSelect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxProfileSelect.Name = "comboBoxProfileSelect";
            this.comboBoxProfileSelect.Size = new System.Drawing.Size(116, 24);
            this.comboBoxProfileSelect.TabIndex = 5;
            this.comboBoxProfileSelect.SelectedIndexChanged += new System.EventHandler(this.comboBoxProfileSelect_SelectedIndexChanged);
            // 
            // textBoxBaudRate
            // 
            this.textBoxBaudRate.Location = new System.Drawing.Point(235, 84);
            this.textBoxBaudRate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxBaudRate.Name = "textBoxBaudRate";
            this.textBoxBaudRate.Size = new System.Drawing.Size(55, 22);
            this.textBoxBaudRate.TabIndex = 6;
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Location = new System.Drawing.Point(154, 87);
            this.labelBaudRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBaudRate.Name = "labelBaudRate";
            this.labelBaudRate.Size = new System.Drawing.Size(71, 16);
            this.labelBaudRate.TabIndex = 7;
            this.labelBaudRate.Text = "Baud Rate";
            // 
            // labelParity
            // 
            this.labelParity.AutoSize = true;
            this.labelParity.Location = new System.Drawing.Point(327, 87);
            this.labelParity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelParity.Name = "labelParity";
            this.labelParity.Size = new System.Drawing.Size(41, 16);
            this.labelParity.TabIndex = 8;
            this.labelParity.Text = "Parity";
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Location = new System.Drawing.Point(374, 84);
            this.comboBoxParity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(78, 24);
            this.comboBoxParity.TabIndex = 9;
            // 
            // labelDataBits
            // 
            this.labelDataBits.AutoSize = true;
            this.labelDataBits.Location = new System.Drawing.Point(465, 87);
            this.labelDataBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDataBits.Name = "labelDataBits";
            this.labelDataBits.Size = new System.Drawing.Size(58, 16);
            this.labelDataBits.TabIndex = 10;
            this.labelDataBits.Text = "DataBits";
            // 
            // textBoxDataBits
            // 
            this.textBoxDataBits.Location = new System.Drawing.Point(532, 84);
            this.textBoxDataBits.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxDataBits.Name = "textBoxDataBits";
            this.textBoxDataBits.Size = new System.Drawing.Size(43, 22);
            this.textBoxDataBits.TabIndex = 11;
            // 
            // labelStopBits
            // 
            this.labelStopBits.AutoSize = true;
            this.labelStopBits.Location = new System.Drawing.Point(582, 87);
            this.labelStopBits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStopBits.Name = "labelStopBits";
            this.labelStopBits.Size = new System.Drawing.Size(57, 16);
            this.labelStopBits.TabIndex = 12;
            this.labelStopBits.Text = "StopBits";
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Location = new System.Drawing.Point(650, 84);
            this.comboBoxStopBits.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(53, 24);
            this.comboBoxStopBits.TabIndex = 13;
            // 
            // storeProfileButton
            // 
            this.storeProfileButton.Location = new System.Drawing.Point(20, 119);
            this.storeProfileButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.storeProfileButton.Name = "storeProfileButton";
            this.storeProfileButton.Size = new System.Drawing.Size(122, 35);
            this.storeProfileButton.TabIndex = 14;
            this.storeProfileButton.Text = "Store Profile";
            this.storeProfileButton.UseVisualStyleBackColor = true;
            this.storeProfileButton.Click += new System.EventHandler(this.storeProfileButton_Click);
            // 
            // dropProfileButton
            // 
            this.dropProfileButton.Location = new System.Drawing.Point(169, 119);
            this.dropProfileButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dropProfileButton.Name = "dropProfileButton";
            this.dropProfileButton.Size = new System.Drawing.Size(122, 35);
            this.dropProfileButton.TabIndex = 15;
            this.dropProfileButton.Text = "Drop Profile";
            this.dropProfileButton.UseVisualStyleBackColor = true;
            this.dropProfileButton.Click += new System.EventHandler(this.dropProfileButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(598, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "v1.1 (2022-04-16)";
            // 
            // comboBoxComPort
            // 
            this.comboBoxComPort.FormattingEnabled = true;
            this.comboBoxComPort.Location = new System.Drawing.Point(103, 11);
            this.comboBoxComPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxComPort.Name = "comboBoxComPort";
            this.comboBoxComPort.Size = new System.Drawing.Size(420, 24);
            this.comboBoxComPort.TabIndex = 17;
            // 
            // buttonSetAsDefault
            // 
            this.buttonSetAsDefault.Location = new System.Drawing.Point(315, 119);
            this.buttonSetAsDefault.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSetAsDefault.Name = "buttonSetAsDefault";
            this.buttonSetAsDefault.Size = new System.Drawing.Size(122, 35);
            this.buttonSetAsDefault.TabIndex = 19;
            this.buttonSetAsDefault.Text = "Set as Default";
            this.buttonSetAsDefault.UseVisualStyleBackColor = true;
            this.buttonSetAsDefault.Click += new System.EventHandler(this.buttonSetAsDefault_Click);
            // 
            // buttonRefreshCom
            // 
            this.buttonRefreshCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRefreshCom.Location = new System.Drawing.Point(532, 12);
            this.buttonRefreshCom.Name = "buttonRefreshCom";
            this.buttonRefreshCom.Size = new System.Drawing.Size(37, 62);
            this.buttonRefreshCom.TabIndex = 20;
            this.buttonRefreshCom.Text = "↻";
            this.buttonRefreshCom.UseVisualStyleBackColor = true;
            this.buttonRefreshCom.Click += new System.EventHandler(this.buttonRefreshCom_Click);
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSelectFile.Location = new System.Drawing.Point(575, 12);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(39, 62);
            this.buttonSelectFile.TabIndex = 21;
            this.buttonSelectFile.Text = "📁";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(712, 162);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.buttonRefreshCom);
            this.Controls.Add(this.buttonSetAsDefault);
            this.Controls.Add(this.comboBoxComPort);
            this.Controls.Add(this.label3);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(716, 201);
            this.Name = "Form1";
            this.Text = "HC3 Flasher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxComPort;
        private System.Windows.Forms.Button buttonSetAsDefault;
        private System.Windows.Forms.Button buttonRefreshCom;
        private System.Windows.Forms.Button buttonSelectFile;
    }
}

