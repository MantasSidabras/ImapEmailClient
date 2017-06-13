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
    public partial class EmailWindow : Form
    {
        private EmailTemplate currentItem;

        public EmailWindow(EmailTemplate currentItem)
        {
            InitializeComponent();
            this.currentItem = currentItem;

            FromTextBox.Text = currentItem.From;
            ToTextBox.Text = currentItem.To;
            SubjectTextBox.Text = currentItem.Subject;
            BodyTextBox.Text = currentItem.Body;

        }
    }
}
