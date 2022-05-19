using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumMessenger.Connection.Errors
{
    class RecipientDoesntExist : Exception
    {
        public RecipientDoesntExist(string message) : base(message) { }
    }
}
