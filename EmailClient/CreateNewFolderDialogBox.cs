using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailClient
{
    public partial class CreateNewFolderDialogBox : Form
    {
        string initialText;
        private ImapControl imapControl;

        public CreateNewFolderDialogBox(ImapControl imapControl)
        {
            InitializeComponent();

            this.imapControl = imapControl;
            initialText = this.folderNameBox.Text;
        }

        private void folderNameBox_Enter(object sender, EventArgs e)
        {
            if(this.folderNameBox.Text == initialText)
            {
                folderNameBox.Text = "";
            }
        }



        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if(folderNameBox.Text != initialText && folderNameBox.Text != "")
            {
                imapControl.CreateNewFloder(folderNameBox.Text);
                this.Close();
            }
        }
    }
}
