using Newtonsoft.Json.Linq;
using PlumMessenger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlumMessenger.Connection.Requests
{
    public class Contacts : DefaultRequest
    {
        string ApiContacts { get; set; }

        public static ObservableCollection<User> AvailableContacts = new ObservableCollection<User>();
        public event EventHandler AddContact;
        public event EventHandler DeleteContact;

        public Contacts(string host = null) : base(host)
        {
            ApiContacts = String.Format(ApiTemplate, "contacts/");
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

        public async Task<ObservableCollection<User>> GetContacts()
        {
            IEnumerable<int> AvailableContactsIds = AvailableContacts.Select(x => x.Id);
            HttpResponseMessage response = await Client.GetAsync(ApiContacts);

            JObject json = await GetJsonFromHttpContent(response.Content);
            
            foreach (JObject contact in json["contacts"])
            {
                User parsedContact = User.UserFromJson(contact);

                if (AvailableContactsIds.Contains(parsedContact.Id))
                    User.UpdateFromUser(AvailableContacts.First(x => x.Id == parsedContact.Id), parsedContact);
                else
                    AvailableContacts.Add(parsedContact);
            }

            return AvailableContacts;
        }
    }
}
