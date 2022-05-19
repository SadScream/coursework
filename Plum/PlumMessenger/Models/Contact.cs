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
    public class Contact : User
    {
        public event EventHandler MessageAddedEvent;
        public event EventHandler UnreadMessageAddedEvent;
        public event EventHandler UnreadMessageRemovedEvent;

        // список непрочитанных сообщений
        private ObservableCollection<Message> unreadMessages = new ObservableCollection<Message>();
        private ObservableCollection<Message> messages = new ObservableCollection<Message>();

        public Contact() : base()
        {
            messages.CollectionChanged += MessagesModifiedEvent;
            unreadMessages.CollectionChanged += UnreadMessagesModifiedEvent;

            MessageAddedEvent += MessageAdded;
        }

        public ObservableCollection<Message> GetUnreadMessages()
        {
            return unreadMessages;
        }

        public ObservableCollection<Message> GetMessages()
        {
            return messages;
        }

        public void SetUnreadMessages(List<Message> newMessages)
        {
            this.unreadMessages = new ObservableCollection<Message>(newMessages);
        }

        public void SetMessages(List<Message> messages)
        {
            this.messages = new ObservableCollection<Message>(messages);
        }

        private void MessageAdded(object sender, EventArgs e)
        {
            NotifyCollectionChangedEventArgs addEvent = (NotifyCollectionChangedEventArgs)e;

            foreach (Message message in addEvent.NewItems)
            {
                if (unreadMessages.Select(x => x.Id).Contains(message.Id))
                {
                    unreadMessages.Remove(unreadMessages.First(x => x.Id == message.Id));
                }
            }
        }

        private void MessagesModifiedEvent(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                MessageAddedEvent?.Invoke(this, e);
            }
        }

        private void UnreadMessagesModifiedEvent(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                UnreadMessageAddedEvent?.Invoke(this, e);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                UnreadMessageRemovedEvent?.Invoke(this, e);
            }
        }

        public static new Contact FromJson(JObject json)
        {
            Contact contact = new Contact();
            contact.Id = (int)json["user_id"];
            contact.Login = (string)json["login"];
            contact.Username = (string)json["username"];
            contact.PhonePublicy = (bool)json["phone_visibility"];

            if (contact.PhonePublicy)
            {
                contact.PhoneNumber = (string)json["phone_number"];
            }

            contact.Status = (string)json["status"];

            DateTime dt = DateTime
                .ParseExact((string)json["last_visit"], "%dd.%MM.%yyyy, %HH:%mm", CultureInfo.CurrentCulture);
            contact.LastVisit = dt;

            return contact;
        }
    }
}
