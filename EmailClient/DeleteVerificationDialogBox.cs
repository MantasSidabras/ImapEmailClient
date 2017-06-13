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
    public partial class DeleteVerificationDialogBox : Form
    {
        private string catalog;
        private ImapControl imapControl;

        public DeleteVerificationDialogBox(string catalog, ImapControl imapControl)
        {
            InitializeComponent();
            this.imapControl = imapControl;
            this.catalog = catalog;
            textLabel.Text += @"""" + catalog + @"""" + "?";
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            imapControl.DeleteFolder(catalog);
            Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
