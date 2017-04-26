namespace EmailClient
{
    partial class EmailBoxWindow
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
            this.logoutButton = new System.Windows.Forms.Button();
            this.imapAddressLabel = new System.Windows.Forms.Label();
            this.usenameLabel = new System.Windows.Forms.Label();
            this.catalogList = new System.Windows.Forms.ListBox();
            this.emailList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(681, 29);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 0;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // imapAddressLabel
            // 
            this.imapAddressLabel.AutoSize = true;
            this.imapAddressLabel.Location = new System.Drawing.Point(47, 34);
            this.imapAddressLabel.Name = "imapAddressLabel";
            this.imapAddressLabel.Size = new System.Drawing.Size(69, 13);
            this.imapAddressLabel.TabIndex = 1;
            this.imapAddressLabel.Text = "imap address";
            // 
            // usenameLabel
            // 
            this.usenameLabel.AutoSize = true;
            this.usenameLabel.Location = new System.Drawing.Point(248, 34);
            this.usenameLabel.Name = "usenameLabel";
            this.usenameLabel.Size = new System.Drawing.Size(53, 13);
            this.usenameLabel.TabIndex = 2;
            this.usenameLabel.Text = "username";
            // 
            // catalogList
            // 
            this.catalogList.FormattingEnabled = true;
            this.catalogList.Items.AddRange(new object[] {
            "box1",
            "box2",
            "box3"});
            this.catalogList.Location = new System.Drawing.Point(50, 117);
            this.catalogList.Name = "catalogList";
            this.catalogList.Size = new System.Drawing.Size(229, 394);
            this.catalogList.TabIndex = 3;
            // 
            // emailList
            // 
            this.emailList.FormattingEnabled = true;
            this.emailList.Location = new System.Drawing.Point(353, 117);
            this.emailList.Name = "emailList";
            this.emailList.Size = new System.Drawing.Size(403, 394);
            this.emailList.TabIndex = 4;
            // 
            // EmailBoxWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.emailList);
            this.Controls.Add(this.catalogList);
            this.Controls.Add(this.usenameLabel);
            this.Controls.Add(this.imapAddressLabel);
            this.Controls.Add(this.logoutButton);
            this.Name = "EmailBoxWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label imapAddressLabel;
        private System.Windows.Forms.Label usenameLabel;
        private System.Windows.Forms.ListBox catalogList;
        private System.Windows.Forms.ListBox emailList;
    }
}