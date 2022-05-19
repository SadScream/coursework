using Newtonsoft.Json.Linq;
using PlumMessenger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PlumMessenger.Connection.Errors;

namespace PlumMessenger.Connection.Requests
{
    class MessagesRequest : DefaultRequest
    {
        string ApiNewMessages { get; set; }
        string ApiMessages { get; set; }
        string ApiMessage { get; set; }

        public MessagesRequest(string host = null) : base(host)
        {
            ApiNewMessages = String.Format(ApiTemplate, "messages/");
            ApiMessages = String.Format(ApiTemplate, "messages/history/{0}");
            ApiMessage = String.Format(ApiTemplate, "message/{0}");
        }

        public async Task<bool> SendMessage(int userId, string text)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync(ApiNewMessages, new
            {
                recipient_id = userId,
                text = text,
                date = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds
            });

            if (!response.IsSuccessStatusCode)
            {
                JObject json = await GetJsonFromHttpContent(response.Content);

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new RecipientDoesntExist(json["message"].ToString());
                }

                return false;
            }

            return true;
        }

        public async Task<List<Message>> GetMessages(int userId)
        {
            List<Message> messages = new List<Message>();
            HttpResponseMessage response = await Client.GetAsync(String.Format(ApiMessages, userId));

            JObject json = await GetJsonFromHttpContent(response.Content);

            foreach (JObject message in json["messages"])
            {
                Message parsedMessage = Message.MessageFromJson(message);

                messages.Add(parsedMessage);
            }

            return messages;
        }

        public async Task<List<Message>> GetNewMessages()
        {
            List<Message> messages = new List<Message>();
            HttpResponseMessage response = await Client.GetAsync(ApiNewMessages);

            JObject json = await GetJsonFromHttpContent(response.Content);

            foreach (JObject message in json["messages"])
            {
                Message parsedMessage = Message.MessageFromJson(message);

                messages.Add(parsedMessage);
            }

            return messages;
        }

        public async Task GetMessage(int messageId)
        {

        }
    }
}
