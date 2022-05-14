using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumMessenger.Models
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
                if (value == login) return;

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
                if (value == username) return;

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
                if (value == phoneNumber) return;

                Changed?.Invoke(this, EventArgs.Empty);
                phoneNumber = value;
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
                if (value == status) return;

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
                if (value == phonePublicy) return;

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

        public void SetContacts(List<User> newContacts)
        {
            contacts = new ObservableCollection<User>(newContacts);
        }

        public void SetMessages(List<Message> newMessages)
        {
            messages = new ObservableCollection<Message>(newMessages);
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

        public static User UserFromJson(JObject json)
        {
            User contact = new User();
            contact.Id = (int)json["user_id"];
            contact.Login = (string)json["login"];
            contact.Username = (string)json["username"];
            contact.PhonePublicy = (bool)json["phone_visibility"];

            if (contact.PhonePublicy)
            {
                contact.phoneNumber = (string)json["phone_number"];
            }

            contact.Status = (string)json["status"];

            DateTime dt = DateTime
                .ParseExact((string)json["last_visit"], "%dd.%MM.%yyyy, %HH:%mm", CultureInfo.CurrentCulture);
            contact.LastVisit = dt;

            return contact;
        }

        public static void UpdateFromUser(User to, User from)
        {
            to.Login = from.Login;
            to.Username = from.Username;
            to.PhonePublicy = from.PhonePublicy;
            to.phoneNumber = from.PhoneNumber;
            to.Status = from.Status;
            to.LastVisit = from.LastVisit;
        }
    }
}
