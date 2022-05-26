using Newtonsoft.Json.Linq;
using System;
using System.Globalization;

namespace PlumMessenger.Models
{
    public class User
    {
        public event EventHandler EditEvent;

        private string login;
        private string username;
        private string phoneNumber;
        private string status;
        private DateTime lastVisit;
        private bool phonePublicy;

        public string password;

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

                EditEvent?.Invoke(this, EventArgs.Empty);
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

                EditEvent?.Invoke(this, EventArgs.Empty);
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

                EditEvent?.Invoke(this, EventArgs.Empty);
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

                EditEvent?.Invoke(this, EventArgs.Empty);
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
                EditEvent?.Invoke(this, EventArgs.Empty);
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

                EditEvent?.Invoke(this, EventArgs.Empty);
                phonePublicy = value;
            }
        }

        public User()
        {
        }

        public static User FromJson(JObject json, bool ignorePhonePublicy = false)
        {
            User contact = new User();
            contact.Id = (int)json["user_id"];
            contact.Login = (string)json["login"];
            contact.Username = (string)json["username"];
            contact.PhonePublicy = (bool)json["phone_visibility"];

            if (contact.PhonePublicy || ignorePhonePublicy)
            {
                contact.PhoneNumber = (string)json["phone_number"];
            }

            contact.Status = (string)json["status"];

            DateTime dt = DateTime
                .ParseExact((string)json["last_visit"], "%dd.%MM.%yyyy, %HH:%mm", CultureInfo.CurrentCulture);
            contact.LastVisit = dt;

            return contact;
        }

        internal static JObject ToJson(User currentUser)
        {
            JObject json = new JObject();

            json["user_id"] = currentUser.Id;
            json["login"] = currentUser.Login;
            json["username"] = currentUser.Username;
            json["phone_visibility"] = currentUser.PhonePublicy;
            json["phone_number"] = currentUser.PhoneNumber;
            json["status"] = currentUser.Status;
            json["password"] = currentUser.password;

            return json;
        }

        /// <summary>
        /// Возвращает true, если пользователь проявлял активность за последние 5 минут
        /// Возвращает false иначе
        /// </summary>
        /// <returns></returns>
        public bool IsOnline()
        {
            if ((DateTime.UtcNow - LastVisit).TotalMinutes > 5)
                return false;

            return true;
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
