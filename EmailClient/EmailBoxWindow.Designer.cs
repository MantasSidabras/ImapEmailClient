namespace EmailClient
{
    partial class DeleteButton
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
            this.createFolderButton = new System.Windows.Forms.Button();
            this.deleteFolderButton = new System.Windows.Forms.Button();
            this.numOfMailsLabel = new System.Windows.Forms.Label();
            this.mailCount = new System.Windows.Forms.Label();
            this.deleteEmailButton = new System.Windows.Forms.Button();
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
            this.catalogList.SelectedIndexChanged += new System.EventHandler(this.catalogList_SelectedIndexChanged);
            // 
            // emailList
            // 
            this.emailList.FormattingEnabled = true;
            this.emailList.Location = new System.Drawing.Point(353, 117);
            this.emailList.Name = "emailList";
            this.emailList.Size = new System.Drawing.Size(403, 394);
            this.emailList.TabIndex = 4;
            this.emailList.DoubleClick += new System.EventHandler(this.emailList_DoubleClick);
            // 
            // createFolderButton
            // 
            this.createFolderButton.Location = new System.Drawing.Point(50, 74);
            this.createFolderButton.Name = "createFolderButton";
            this.createFolderButton.Size = new System.Drawing.Size(104, 23);
            this.createFolderButton.TabIndex = 5;
            this.createFolderButton.Text = "Create new folder";
            this.createFolderButton.UseVisualStyleBackColor = true;
            this.createFolderButton.Click += new System.EventHandler(this.createFolderButton_Click);
            // 
            // deleteFolderButton
            // 
            this.deleteFolderButton.Location = new System.Drawing.Point(175, 74);
            this.deleteFolderButton.Name = "deleteFolderButton";
            this.deleteFolderButton.Size = new System.Drawing.Size(104, 23);
            this.deleteFolderButton.TabIndex = 7;
            this.deleteFolderButton.Text = "Delete folder";
            this.deleteFolderButton.UseVisualStyleBackColor = true;
            this.deleteFolderButton.Click += new System.EventHandler(this.deleteFolderButton_Click);
            // 
            // numOfMailsLabel
            // 
            this.numOfMailsLabel.AutoSize = true;
            this.numOfMailsLabel.Location = new System.Drawing.Point(350, 79);
            this.numOfMailsLabel.Name = "numOfMailsLabel";
            this.numOfMailsLabel.Size = new System.Drawing.Size(88, 13);
            this.numOfMailsLabel.TabIndex = 8;
            this.numOfMailsLabel.Text = "Number of mails: ";
            // 
            // mailCount
            // 
            this.mailCount.AutoSize = true;
            this.mailCount.Location = new System.Drawing.Point(444, 79);
            this.mailCount.Name = "mailCount";
            this.mailCount.Size = new System.Drawing.Size(13, 13);
            this.mailCount.TabIndex = 9;
            this.mailCount.Text = "0";
            // 
            // deleteEmailButton
            // 
            this.deleteEmailButton.Location = new System.Drawing.Point(554, 74);
            this.deleteEmailButton.Name = "deleteEmailButton";
            this.deleteEmailButton.Size = new System.Drawing.Size(75, 23);
            this.deleteEmailButton.TabIndex = 10;
            this.deleteEmailButton.Text = "Delete";
            this.deleteEmailButton.UseVisualStyleBackColor = true;
            this.deleteEmailButton.Click += new System.EventHandler(this.deleteEmailButton_Click);
            // 
            // DeleteButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.deleteEmailButton);
            this.Controls.Add(this.mailCount);
            this.Controls.Add(this.numOfMailsLabel);
            this.Controls.Add(this.deleteFolderButton);
            this.Controls.Add(this.createFolderButton);
            this.Controls.Add(this.emailList);
            this.Controls.Add(this.catalogList);
            this.Controls.Add(this.usenameLabel);
            this.Controls.Add(this.imapAddressLabel);
            this.Controls.Add(this.logoutButton);
            this.Name = "DeleteButton";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmailBoxWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label imapAddressLabel;
        private System.Windows.Forms.Label usenameLabel;
        private System.Windows.Forms.ListBox catalogList;
        private System.Windows.Forms.ListBox emailList;
        private System.Windows.Forms.Button createFolderButton;
        private System.Windows.Forms.Button deleteFolderButton;
        private System.Windows.Forms.Label numOfMailsLabel;
        private System.Windows.Forms.Label mailCount;
        private System.Windows.Forms.Button deleteEmailButton;
    }
}