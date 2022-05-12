using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumMessenger.Classes
{
    public class User
    {
        public event EventHandler Changed;
        public event EventHandler AddMessage;
        public event EventHandler AddContact;
        public event EventHandler RemoveContact;

        private string login;
        private string username;
        private string phoneNumber;
        private string passwordHash;
        private string status;
        private DateTime lastVisit;
        private bool phonePublicy;

        public int Id { get; set; }
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                Changed?.Invoke(this, EventArgs.Empty);
                login = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                Changed?.Invoke(this, EventArgs.Empty);
                username = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                Changed?.Invoke(this, EventArgs.Empty);
                phoneNumber = value;
            }
        }

        public string PasswordHash
        {
            get
            {
                return passwordHash;
            }
            set
            {
                Changed?.Invoke(this, EventArgs.Empty);
                passwordHash = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                Changed?.Invoke(this, EventArgs.Empty);
                status = value;
            }
        }

        public DateTime LastVisit
        {
            get
            {
                return lastVisit;
            }
            set
            {
                Changed?.Invoke(this, EventArgs.Empty);
                lastVisit = value;
            }
        }

        public bool PhonePublicy
        {
            get
            {
                return phonePublicy;
            }
            set
            {
                Changed?.Invoke(this, EventArgs.Empty);
                phonePublicy = value;
            }
        }

        private ObservableCollection<User> contacts = new ObservableCollection<User>();
        private ObservableCollection<Message> messages = new ObservableCollection<Message>();

        public User()
        {
            messages.CollectionChanged += MessagesModifiedEvent;
            GetContacts().CollectionChanged += ContactsModifiedEvent;
        }

        public ObservableCollection<User> GetContacts()
        {
            return contacts;
        }

        public ObservableCollection<Message> GetMessages()
        {
            return messages;
        }

        private void MessagesModifiedEvent(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                AddMessage?.Invoke(this, e);
            }
        }

        private void ContactsModifiedEvent(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                AddContact?.Invoke(this, e as NotifyCollectionChangedEventArgs);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                RemoveContact?.Invoke(this, e as NotifyCollectionChangedEventArgs);
            }
        }
    }
}
