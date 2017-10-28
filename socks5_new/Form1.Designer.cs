namespace socks5_new
{
    partial class Socks
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.resetIpButton = new System.Windows.Forms.Button();
            ipTextBox = new System.Windows.Forms.TextBox();
            ipLabel = new System.Windows.Forms.Label();
            this.changePackageButton = new System.Windows.Forms.Button();
            this.notChangePackageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 90);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // resetIpButton
            // 
            this.resetIpButton.Location = new System.Drawing.Point(12, 61);
            this.resetIpButton.Name = "resetIpButton";
            this.resetIpButton.Size = new System.Drawing.Size(75, 23);
            this.resetIpButton.TabIndex = 2;
            this.resetIpButton.Text = "Reset IP";
            this.resetIpButton.UseVisualStyleBackColor = true;
            this.resetIpButton.Click += new System.EventHandler(this.resetIpButton_Click);
            // 
            // ipTextBox
            // 
            ipTextBox.Location = new System.Drawing.Point(12, 35);
            ipTextBox.Name = "ipTextBox";
            ipTextBox.Size = new System.Drawing.Size(217, 20);
            ipTextBox.TabIndex = 3;
            // 
            // ipLabel
            // 
            ipLabel.AutoSize = true;
            ipLabel.Location = new System.Drawing.Point(106, 61);
            ipLabel.Name = "ipLabel";
            ipLabel.Size = new System.Drawing.Size(0, 13);
            ipLabel.TabIndex = 4;
            // 
            // changePackageButton
            // 
            this.changePackageButton.Location = new System.Drawing.Point(12, 6);
            this.changePackageButton.Name = "changePackageButton";
            this.changePackageButton.Size = new System.Drawing.Size(75, 23);
            this.changePackageButton.TabIndex = 5;
            this.changePackageButton.Text = "Изменять";
            this.changePackageButton.UseVisualStyleBackColor = true;
            this.changePackageButton.Click += new System.EventHandler(this.changePackageButton_Click);
            // 
            // notChangePackageButton
            // 
            this.notChangePackageButton.Location = new System.Drawing.Point(12, 6);
            this.notChangePackageButton.Name = "notChangePackageButton";
            this.notChangePackageButton.Size = new System.Drawing.Size(75, 23);
            this.notChangePackageButton.TabIndex = 6;
            this.notChangePackageButton.Text = "Не изменять";
            this.notChangePackageButton.UseVisualStyleBackColor = true;
            this.notChangePackageButton.Visible = false;
            this.notChangePackageButton.Click += new System.EventHandler(this.notChangePackageButton_Click);
            // 
            // Socks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 124);
            this.Controls.Add(this.notChangePackageButton);
            this.Controls.Add(this.changePackageButton);
            this.Controls.Add(ipLabel);
            this.Controls.Add(ipTextBox);
            this.Controls.Add(this.resetIpButton);
            this.Controls.Add(this.startButton);
            this.Name = "Socks";
            this.Text = "SOCKS5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button resetIpButton;
        private System.Windows.Forms.Button changePackageButton;
        private System.Windows.Forms.Button notChangePackageButton;
        private static System.Windows.Forms.TextBox ipTextBox;
        public static System.Windows.Forms.Label ipLabel;
    }
}

