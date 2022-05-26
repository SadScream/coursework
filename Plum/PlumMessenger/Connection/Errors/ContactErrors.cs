using System;

namespace PlumMessenger.Connection.Errors
{
    class SelfAdd : Exception
    {
        public SelfAdd(string message) : base(message) { }
    }

    class UserNotFound : Exception
    {
        public UserNotFound(string message) : base(message) { }
    }
}
