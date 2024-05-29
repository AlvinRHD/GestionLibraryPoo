using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Library.Models
{
    using System.Collections.Generic;

    namespace Management_Library.Models
    {
        public class User
        {
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Rol { get; set; }

            public List<User> LoadUsers()
            {
                return new List<User>()
            {
                new User { FullName = "Librarian", Email = "librarian@gmail.com", Password = "123", Rol = "admin" }, 
                new User { FullName = "Client", Email = "client@gmail.com", Password = "123", Rol = "user" },
                new User { FullName = "Assistant", Email = "assistant@gmail.com", Password = "123", Rol = "assistant" }
            };
            }
        }
    }

}
