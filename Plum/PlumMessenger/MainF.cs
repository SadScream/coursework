using PlumMessenger.Models;
using PlumMessenger.Connection.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Threading;

namespace PlumMessenger
{
    public partial class MainF : Form
    {
        Thread loopThread;
        public static bool looping = false;
        public static Contacts contacts;

        public MainF()
        {
            InitializeComponent();
        }

        private void MainF_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();

            contacts = new Contacts();
            contacts.AddContact += AddContact;
            contacts.DeleteContact += DeleteContact;

            looping = true;
            loopThread = new Thread(Listener);
            loopThread.IsBackground = true;
            loopThread.Start();
        }

        private void DeleteContact(object sender, EventArgs e)
        {
            NotifyCollectionChangedEventArgs args = (NotifyCollectionChangedEventArgs)e;

            contactsPanel.Controls
                .Remove(contactsPanel.Controls
                            .Cast<ContactElement>()
                            .First(x => x.contact.Id == ((User)sender).Id));
        }

        private void AddContact(object sender, EventArgs e)
        {
            NotifyCollectionChangedEventArgs args = (NotifyCollectionChangedEventArgs)e;

            this.Invoke(new MethodInvoker(() => {
                if (args.Action == NotifyCollectionChangedAction.Add)
                {
                    ContactElement element = new ContactElement((User)sender);
                    element.Dock = DockStyle.Top;

                    contactsPanel.RowCount = contactsPanel.RowCount + 1;
                    contactsPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    contactsPanel.Controls.Add(element);
                }
            }));
        }

        public static async void Listener()
        {
            while (looping)
            {
                await contacts.GetContacts();

                Thread.Sleep(500);
            }
        }

        private void MainF_FormClosing(object sender, FormClosingEventArgs e)
        {
            looping = false;
        }
    }
}
