using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumMessenger.Classes
{
    public class Message
    {
        public int Id { get; set; }
        public User Owner { get; set; }
        public User Recipient { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool Viewed { get; set; } = false; // просмотрено ли сообщение
    }
}
