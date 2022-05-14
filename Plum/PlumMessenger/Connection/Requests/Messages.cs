using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumMessenger.Connection.Requests
{
    class Messages : DefaultRequest
    {
        string ApiMessages { get; set; }
        string ApiMessage { get; set; }

        public Messages(string host = null) : base(host)
        {
            ApiMessages = String.Format(ApiTemplate, "sign-up/");
            ApiMessage = String.Format(ApiTemplate, "sign-in/");
        }

        public async Task SendMessage(int userId, string text)
        {

        }

        public async Task GetMessages()
        {

        }

        public async Task GetMessage(int messageId)
        {

        }
    }
}
