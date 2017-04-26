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
    public partial class EmailBoxWindow : Form
    {

        private LoginInfo user;

        public EmailBoxWindow(LoginInfo user, ImapControl imapControl)
        {
            InitializeComponent();
            

            imapAddressLabel.Text = user.ImapAddress;
            usenameLabel.Text = user.Username;
            
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginlWindow().Show();
        }
    }
}
