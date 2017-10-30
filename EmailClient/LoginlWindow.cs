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
    public partial class LoginlWindow : Form
    {

        private LoginInfo user;

        public LoginlWindow()
        {
            InitializeComponent();
            connectErrorLabel.Visible = false;

            //imapAddressBox.Text = "imap.gmail.com";
            //usernameBox.Text = "sid.mantas@gmail.com";
            //passwordBox.Text = "txvyrhbp";

            imapAddressBox.Text = "mail.stud.vu.lt";
            usernameBox.Text = "s1510701";
            passwordBox.Text = "Txvyrhbl_3";

        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            ImapControl imapControl = new ImapControl(993);
            user = new LoginInfo();
            user.ImapAddress = imapAddressBox.Text;
            user.Username = usernameBox.Text;
            user.Password = passwordBox.Text;

            if (imapControl.Connect(user))
            {
                this.Hide();
                new DeleteButton(user, imapControl).Show();
            }
            else
            {
        }
    }

    private void resetButton_Click(object sender, EventArgs e)
    {
        imapAddressBox.Text = string.Empty;
        usernameBox.Text = string.Empty;
        passwordBox.Text = string.Empty;

    }
}
}
