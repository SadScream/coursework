using System;

namespace PlumMessenger.Connection.Errors
{
    class RecipientDoesntExist : Exception
    {
        public RecipientDoesntExist(string message) : base(message) { }
    }
}
