using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PlumMessenger.Models
{
    public class Message
    {
        public event EventHandler ReadEvent;

        private bool read = false;

        public int Id { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public int RecipientId { get; set; }
        public User Recipient { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        // прочитано ли сообщение
        public bool Read {
            get
            { 
                return read;
            }
            set
            {
                if (value)
                    ReadEvent?.Invoke(this, EventArgs.Empty);
                read = value;
            }
        }

        internal static Message MessageFromJson(JObject json)
        {
            Message message = new Message();
            message.Id = (int)json["message_id"];
            message.OwnerId = (int)json["owner_id"];
            message.RecipientId = (int)json["recipient_id"];
            message.Text = (string)json["text"];

            DateTime dt = DateTime.ParseExact((string)json["date"], "dd.MM.yyyy, HH:mm:ss.ffffff", null);
            message.Date = dt;
            message.Read = (bool)json["read"];

            return message;
        }
    }
}
