using PlumMessenger.Models;
using PlumMessenger.Connection.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlumMessenger.Connection
{
    class Puller
    {
        public static ObservableCollection<Contact> AvailableContacts = new ObservableCollection<Contact>();
        public event EventHandler AddContact;
        public event EventHandler DeleteContact;

        Thread loopThread;

        private static bool looping = false;
        public bool Looping {
            get {
                return looping;
            } set {
                looping = value;
            } 
        }

        public static int ObservingUserId = -1;

        public static readonly UserRequest userRequest = new UserRequest();
        public static readonly ContactsRequest contactRequest = new ContactsRequest();
        public static readonly MessagesRequest messagesRequest = new MessagesRequest();

        private static double contactsRequestTiming = 3000.0;
        private static double unreadMessagesRequestTiming = 650.0;
        private static double messagesRequestTiming = 150.0;

        public Puller()
        {
            AvailableContacts.CollectionChanged += ContactsChanged;
        }

        private void ContactsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                AddContact.Invoke(e.NewItems[0], e);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                DeleteContact.Invoke(e.OldItems[0], e);
            }
        }

        public void StartPulling()
        {
            Looping = true;
            loopThread = new Thread(Listener);
            loopThread.IsBackground = true;
            loopThread.Start();
        }

        public static async void Listener()
        {
            DateTime startContacts = DateTime.UtcNow, 
                startNewMessages = DateTime.UtcNow,
                startCurrentMessages = DateTime.UtcNow;

            double spanContacts = contactsRequestTiming,
                spanNewMessages = unreadMessagesRequestTiming,
                spanCurrentMessages = messagesRequestTiming;

            while (looping)
            {
                if (spanContacts >= contactsRequestTiming)
                {
                    await GetContacts();
                    startContacts = DateTime.UtcNow;
                }

                if (spanNewMessages >= unreadMessagesRequestTiming)
                {
                    await GetNewMessages();
                    startNewMessages = DateTime.UtcNow;
                }

                if (spanCurrentMessages >= messagesRequestTiming && ObservingUserId != -1)
                {
                    await GetCurrentMessages(ObservingUserId);
                    startCurrentMessages = DateTime.UtcNow;
                }

                spanContacts = (DateTime.UtcNow - startContacts).TotalMilliseconds;
                spanNewMessages = (DateTime.UtcNow - startNewMessages).TotalMilliseconds;
                spanCurrentMessages = (DateTime.UtcNow - startCurrentMessages).TotalMilliseconds;
            }
        }

        // получаем список контактов
        private static async Task GetContacts()
        {
            IEnumerable<int> AvailableContactsIds = AvailableContacts.Select(x => x.Id);
            List<Contact> contacts = await contactRequest.GetContacts();

            foreach (Contact contact in contacts)
            {
                // если контакт уже есть в списке, то обновляем информацию о нем
                if (AvailableContactsIds.Contains(contact.Id))
                    User.UpdateFromUser((User)AvailableContacts.First(x => x.Id == contact.Id), (User)contact);
                else
                    AvailableContacts.Add(contact);
            }

            var exceptedContactsIds = AvailableContacts.Select(x => x.Id).Except(contacts.Select(x => x.Id));

            if (exceptedContactsIds.Count() > 0)
            {
                var exceptedContacts = AvailableContacts.Where(x => exceptedContactsIds.Contains(x.Id)).ToList();

                foreach (Contact contact in exceptedContacts)
                {
                    AvailableContacts.Remove(contact);
                }
            }
        }

        // получаем список новых(не прочитанных) сообщений
        private static async Task GetNewMessages()
        {
            List<Message> messages = await messagesRequest.GetNewMessages();
            
            foreach (Message message in messages)
            {
                Contact messageOwner = AvailableContacts.FirstOrDefault(x => x.Id == message.OwnerId);

                if (messageOwner == null)
                    continue;

                if (messageOwner.GetUnreadMessages().Select(x => x.Id).Contains(message.Id) ||
                    message.OwnerId == UserRequest.CurrentUserId)
                    continue;
                
                message.Owner = messageOwner;
                messageOwner.GetUnreadMessages().Add(message);
            }
        }

        /// <summary>
        /// получаем список всех сообщений от пользователя
        /// при этом все запрошенные сообщения пометятся как прочитанные
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private static async Task GetCurrentMessages(int userId)
        {
            List<Message> messages = await messagesRequest.GetMessages(userId);

            foreach (Message message in messages)
            {
                Contact contact;

                Contact messageOwner = AvailableContacts.FirstOrDefault(x => x.Id == message.OwnerId);
                Contact messageRecipient = AvailableContacts.FirstOrDefault(x => x.Id == message.RecipientId);

                if (messageOwner != null)
                {
                    contact = messageOwner;
                    if (messageOwner.GetMessages().Select(x => x.Id).Contains(message.Id))
                    {
                        continue;
                    }
                }
                else if (messageRecipient != null)
                {
                    contact = messageRecipient;
                    if (messageRecipient.GetMessages().Select(x => x.Id).Contains(message.Id))
                    {
                        continue;
                    }
                }
                else
                    continue;

                if (messageRecipient == null && message.RecipientId == UserRequest.CurrentUserId)
                {
                    message.Owner = messageOwner;
                    message.RecipientId = UserRequest.CurrentUserId;
                    messageOwner.GetMessages().Add(message);
                }
                else if (messageRecipient != null && messageRecipient.Id == userId)
                {
                    message.Recipient = messageRecipient;
                    message.OwnerId = UserRequest.CurrentUserId;
                    messageRecipient.GetMessages().Add(message);
                }
            }
        }
    }
}
