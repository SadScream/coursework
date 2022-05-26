using System;

namespace PlumMessenger.Connection.Errors
{
    class LoginAlreadyTaken : Exception
    {
        public LoginAlreadyTaken(string message) : base(message) { }
    }

    class Unauthorized : Exception
    {
        public Unauthorized(string message) : base(message) { }
    }

    class Authorized : Exception
    {
        public Authorized(string message) : base(message) { }
    }

    class IncorrectLoginOrPasswordFormat : Exception
    {
        public IncorrectLoginOrPasswordFormat(string message) : base(message) { }
    }

    class InvalidLoginOrPassword : Exception
    {
        public InvalidLoginOrPassword(string message) : base(message) { }
    }
}
