using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Library.Login
{
    public static class Auth
    {
        public static string Login(string email, string password)
        {
            var user = new User();
            var userLoggin = user.LoadUsers().FirstOrDefault(u => u.Email == email && u.Password == password);

            string response = "";

            if (userLoggin == null)
            {
                throw new NullReferenceException("Credenciales no encontradas");
            }

            switch (userLoggin.Rol)
            {
                case "admin":
                    response = "Menu admin";
                    break;
                case "user":
                    response = "Menu usuario";
                    break;
                default:
                    response = "Credenciales no encontradas";
                    break;
            }

            return response;
        }
    }
}
