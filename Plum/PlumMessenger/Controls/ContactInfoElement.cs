using PlumMessenger.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlumMessenger.Controls
{
    public partial class ContactInfoElement : UserControl
    {
        public event EventHandler CloseClickedEvent;

        private Contact contact;

        public ContactInfoElement(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
        }

        private void SetFields()
        {
            loginLabel.Text = contact.Login;
            userNameLabel.Text = contact.Username;
            phoneNumberLabel.Text = contact.PhoneNumber;

            if (contact.PhonePublicy)
            {
                phoneNumberPanel.Visible = true;
                phoneNumberLabel.Text = contact.PhoneNumber;
            } else
                phoneNumberPanel.Visible = false;

            statusLabel.Text = contact.Status;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            CloseClickedEvent.Invoke(this, EventArgs.Empty);
        }

        private void ContactInfoElement_Load(object sender, EventArgs e)
        {
            contact.EditEvent += CurrentUserEdited;
            SetFields();
        }

        private void CurrentUserEdited(object sender, EventArgs e)
        {
            SetFields();
        }
    }
}
