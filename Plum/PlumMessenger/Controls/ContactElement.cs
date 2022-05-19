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
        bool selected = false;
        public Contact contact;
        string loginTemplate = "@{0}";
        public event EventHandler Clicked;
        public event MouseEventHandler RightClicked;
        public event EventHandler MouseIn;
        public event EventHandler MouseOut;

        public Func<int, Task> ContextMenuAction { get; set; }

        Color selectedColor = Color.FromArgb(43, 82, 120);
        Color hoveredColor = Color.FromArgb(32, 43, 54);
        Color defaultColor = Color.FromArgb(18, 25, 33); // Transparent;

        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                if (value)
                    SetColorSelected();
                else
                    SetColorDefault();

                selected = value;
            }
        }

        public ContactElement()
        {
            InitializeComponent();
        }

        public ContactElement(Contact contact)
        {
            InitializeComponent();

            this.contact = contact;

            contact.EditEvent += ContactInfoChangedEvent;
            contact.UnreadMessageAddedEvent += NewMessageEvent;
            contact.UnreadMessageRemovedEvent += NewMessageEvent;

            UpdateFields();
        }

        public void OpenContextMenuFromSearch(object sender, MouseEventArgs e)
        {
            ContextMenu = new ContextMenu();

            MenuItem itemAdd = new MenuItem("Добавить в контакты");

            if (ContextMenuAction != null)
                itemAdd.Click += async (o, _) => await ContextMenuAction(contact.Id);

            ContextMenu.MenuItems.Add(itemAdd);

            ContextMenu.Show(this, e.Location);
        }

        public void OpenContextMenuDefault(object sender, MouseEventArgs e)
        {
            ContextMenu = new ContextMenu();

            MenuItem itemRemove = new MenuItem("Удалить из контактов");

            if (ContextMenuAction != null)
                itemRemove.Click += async (o, _) => await ContextMenuAction(contact.Id);

            ContextMenu.MenuItems.Add(itemRemove);

            ContextMenu.Show(this, e.Location);
        }

        public void SetColorSelected()
        {
            BackColor = selectedColor;
        }

        public void SetColorDefault()
        {
            BackColor = defaultColor;
        }

        private void DispatchMouseEvents()
        {
            this.MouseClick += ((o, e) => {
                if (e.Button == MouseButtons.Right)
                {
                    RightClicked?.Invoke(this, e);
                    return;
                }

                Clicked?.Invoke(this, EventArgs.Empty);
            });
            this.MouseEnter += (o, e) => MouseIn?.Invoke(this, EventArgs.Empty);
            this.MouseLeave += (o, e) => MouseOut?.Invoke(this, EventArgs.Empty);

            foreach (Control c in GetNestedControls<Control>(this))
            {
                c.MouseClick += ((o, e) => {
                    if (e.Button == MouseButtons.Right)
                    {
                        RightClicked?.Invoke(this, e);
                        return;
                    }

                    Clicked?.Invoke(this, EventArgs.Empty);
                });
                c.MouseEnter += (o, e) => this.MouseIn?.Invoke(this, EventArgs.Empty);
                c.MouseLeave += (o, e) => this.MouseOut?.Invoke(this, EventArgs.Empty);
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
            int currentCount = ((Contact)sender)
                .GetUnreadMessages()
                .Count();
            
            this.Invoke(new MethodInvoker(() => {
                if (currentCount > 0)
                    newMessagesCountLabel.Text = currentCount.ToString();
                else
                    newMessagesCountLabel.Text = "";
            }));
        }

        private void ContactElement_Load(object sender, EventArgs e)
        {
            DispatchMouseEvents();

            MouseIn += ContactElement_MouseEnter;
            MouseOut += ContactElement_MouseLeave;
        }

        private void ContactElement_MouseEnter(object sender, EventArgs e)
        {
            if (selected)
                return;

            BackColor = hoveredColor;
        }

        private void ContactElement_MouseLeave(object sender, EventArgs e)
        {
            if (selected)
                return;

            BackColor = defaultColor;
        }
    }
}
