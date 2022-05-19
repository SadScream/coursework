using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
