using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailClient
{
    public partial class DeleteButton : Form
    {
        private ImapControl imapControl;
        private LoginInfo user;

        public DeleteButton(LoginInfo user, ImapControl imapControl)
        {
            InitializeComponent();
            this.imapControl = imapControl;
            this.user = user;
            imapAddressLabel.Text = user.ImapAddress;
            usenameLabel.Text = user.Username;

            UpdateCatalogList();
            emailList.Items.Clear();


        }



        public void UpdateCatalogList()
        {
            catalogList.Items.Clear();
            catalogList.Items.AddRange(imapControl.GetFolderList().ToArray());
            catalogList.Sorted = true;
        }



        private void createFolderButton_Click(object sender, EventArgs e)
        {
            var newFolderBox = new CreateNewFolderDialogBox(imapControl);
            newFolderBox.ShowDialog();
            UpdateCatalogList();
        }

        private void catalogList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (catalogList.SelectedItem != null)
            {
                string currentItem = catalogList.SelectedItem.ToString();
                Console.WriteLine(currentItem);
                mailCount.Text = imapControl.GetMailCount(currentItem);
                List<EmailTemplate> emails = imapControl.SelectFolder(currentItem);
                emailList.Items.Clear();
                emailList.Items.AddRange(emails.ToArray());
                //                emailList.DisplayMember = "Subject";
                emailList.DisplayMember = "From";

            }

        }

        private void deleteFolderButton_Click(object sender, EventArgs e)
        {
            if (catalogList.SelectedItem != null)
            {
                new DeleteVerificationDialogBox(catalogList.SelectedItem.ToString(), imapControl).ShowDialog();
                UpdateCatalogList();
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            imapControl.Logout();
            this.Hide();
            new LoginlWindow().Show();
        }

        private void EmailBoxWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            imapControl.Logout();
        }

        private void emailList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                EmailTemplate currentItem = (EmailTemplate)emailList.SelectedItem;
                currentItem.Body = imapControl.GetEmailBody(currentItem.Uid);

                new EmailWindow(currentItem).ShowDialog();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void deleteEmailButton_Click(object sender, EventArgs e)
        {
            try
            {
                EmailTemplate currentItem = (EmailTemplate)emailList.SelectedItem;
                imapControl.DeleteMessage(currentItem);
                emailList.Items.Remove(currentItem);

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
