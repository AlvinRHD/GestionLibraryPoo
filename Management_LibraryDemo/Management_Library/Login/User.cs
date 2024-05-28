using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Library.Login
{
    public class User
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

        public List<User> LoadUsers()
        {
            var users = new List<User>()
            {
                new User {FullName = "Admin", Email = "admin@gmail.com", Password = "12345", Rol = "admin"},
                new User {FullName = "User", Email = "user@gmail.com", Password = "12345", Rol = "user"},
            };

            return users;
        }
    }
}
