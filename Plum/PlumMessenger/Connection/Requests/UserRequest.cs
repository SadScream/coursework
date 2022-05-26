using Newtonsoft.Json.Linq;
using PlumMessenger.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlumMessenger.Connection.Requests
{
    class UserRequest : DefaultRequest
    {
        public static int CurrentUserId;
        public static User CurrentUser;

        string ApiUser { get; set; }
        string ApiUsers { get; set; }

        public UserRequest(string host = null) : base(host)
        {
            ApiUser = String.Format(ApiTemplate, "user/");
            ApiUsers = String.Format(ApiTemplate, "users/search/{0}");
        }

        public async Task<User> GetUser()
        {
            HttpResponseMessage response = await Client.GetAsync(String.Format(ApiUser));

            JObject json = await GetJsonFromHttpContent(response.Content);

            if (CurrentUser == null)
                CurrentUser = User.FromJson(json, true);
            else
            {
                User u = User.FromJson(json, true);
                User.UpdateFromUser(CurrentUser, u);
            }

            return CurrentUser;
        }

        public async Task<bool> EditUser(User modified)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync(ApiUser, User.ToJson(modified));
            JObject json = await GetJsonFromHttpContent(response.Content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(json["message"].ToString());
            }
            else if (json["message"] != null)
            {
                return false;
            }

            return true;
        }

        public async Task<List<Contact>> SearchUsers(string query)
        {
            List<Contact> users = new List<Contact>();
            HttpResponseMessage response = await Client.GetAsync(String.Format(ApiUsers, query));

            JObject json = await GetJsonFromHttpContent(response.Content);

            foreach (JObject contact in json["users"])
            {
                Contact parsedContact = Contact.FromJson(contact);

                users.Add(parsedContact);
            }

            return users;
        }
    }
}
