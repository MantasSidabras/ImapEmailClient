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
    public partial class LoginlWindow : Form
    {

        private LoginInfo user;

        public LoginlWindow()
        {
            InitializeComponent();

            imapAddressBox.Text = "imap.gmail.com";
            usernameBox.Text = "sid.mantas@gmail.com";
            passwordBox.Text = "txvyrhbp";

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
                new EmailBoxWindow(user, imapControl).Show();
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
