using Newtonsoft.Json.Linq;
using PlumMessenger.Connection.Errors;
using PlumMessenger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlumMessenger.Connection.Requests
{
    public class ContactsRequest : DefaultRequest
    {
        string ApiContacts { get; set; }
        string ApiContactsWithParam { get; set; }

        public ContactsRequest(string host = null) : base(host)
        {
            ApiContacts = String.Format(ApiTemplate, "contacts/");
            ApiContactsWithParam = String.Format(ApiTemplate, "contacts/{0}");
        }

        public async Task<List<Contact>> GetContacts()
        {
            List<Contact> contacts = new List<Contact>();
            HttpResponseMessage response = await Client.GetAsync(ApiContacts);

            JObject json = await GetJsonFromHttpContent(response.Content);

            foreach (JObject contact in json["contacts"])
            {
                Contact parsedContact = Contact.FromJson(contact);

                contacts.Add(parsedContact);
            }

            return contacts;
        }

        public async Task AddContact(int userId)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync(ApiContacts, new { user_id = userId });

            JObject json = await GetJsonFromHttpContent(response.Content);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new UserNotFound(json["message"].ToString());
                }
                else if (response.StatusCode == HttpStatusCode.MethodNotAllowed)
                {
                    throw new UserNotFound(json["message"].ToString());
                }
            }
        }

        public async Task DeleteContact(int userId)
        {
            HttpResponseMessage response = await Client.DeleteAsync(String.Format(ApiContactsWithParam, userId));

            JObject json = await GetJsonFromHttpContent(response.Content);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new UserNotFound(json["message"].ToString());
                }
            }
        }
    }
}
