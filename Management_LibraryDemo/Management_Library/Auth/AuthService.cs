using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management_Library.Exceptions;
using Management_Library.Interfaces;

namespace Management_Library.Auth
{
    public static class AuthService
    {
        public static string Login(string email, string password, IUserService userService)
        {
            var users = userService.LoadUsers();
            var userLoggin = users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (userLoggin == null)
            {
                throw new UserNotFoundException("Sus credenciales no han sido encontradas...");
            }

            return userLoggin.Rol;
        }
    }
}
