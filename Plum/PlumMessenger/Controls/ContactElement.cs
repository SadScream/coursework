using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlumMessenger.Models;

namespace PlumMessenger
{
    public partial class ContactElement : UserControl
    {
        public User contact;
        string loginTemplate = "@{0}";
        public event EventHandler Clicked;

        public ContactElement(User contact)
        {
            InitializeComponent();

            this.contact = contact;

            contact.Changed += ContactInfoChangedEvent;
            contact.AddMessage += NewMessageEvent;

            ClickedDispatch();

            Clicked += ClickedEvent;

            UpdateFields();
        }

        private void ClickedDispatch()
        {
            this.MouseClick += (o, e) => Clicked.Invoke(this, e);
            foreach (Control c in GetNestedControls<Control>(this))
            {
                c.MouseClick += (o, e) => Clicked.Invoke(this, e);
            }
        }

        private IEnumerable<ControlType> GetNestedControls<ControlType>(Control control)
        {
            if (control.Controls == null || control.Controls.Count == 0)
                return Enumerable.Empty<ControlType>();

            return control.Controls
                .OfType<ControlType>()
                .Concat(control.Controls
                    .Cast<Control>()
                    .SelectMany(x => GetNestedControls<ControlType>(x)));
        }

        private void ClickedEvent(object sender, EventArgs e)
        {
            contact.GetMessages().Select(x => x.Viewed = true);
            newMessagesCountLabel.Text = "0";
        }

        private void UpdateFields()
        {
            usernameLabel.Text = contact.Username;
            loginLabel.Text = String.Format(loginTemplate, contact.Login);
        }

        private void ContactInfoChangedEvent(object sender, EventArgs e)
        {
            UpdateFields();
        }

        private void NewMessageEvent(object sender, EventArgs e)
        {
            int currentCount = Int32.Parse(newMessagesCountLabel.Text);
            currentCount += ((NotifyCollectionChangedEventArgs)e).NewItems.Count;
            newMessagesCountLabel.Text = currentCount.ToString();
        }
    }
}
