using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Library.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string UserEmail { get; } 
        public UserNotFoundException(string message, string userEmail) : base(message)
        {
            UserEmail = userEmail;
        }


        public UserNotFoundException(string message) : base(message)
        {
        }

        public string GetDetailedMessage()
        {
            string errorMessage = Message;
            if (!string.IsNullOrEmpty(UserEmail))
            {
                errorMessage += $" Email del usuario: {UserEmail}";
            }
            return errorMessage;
        }
    }
}
