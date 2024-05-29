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
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return "El email y la contraseña no pueden estar vacíos.";
            }

            var user = new User();
            var userLoggin = user.LoadUsers().FirstOrDefault(u => u.Email == email && u.Password == password);

            if (userLoggin == null)
            {
                return "Credenciales no encontradas...";
            }

            switch (userLoggin.Rol)
            {
                case "admin":
                    return "Menu administrados";
                case "user":
                    return "Menu usuario";
                default:
                    return "Credenciales no encontradas...";
            }
        }
    }
}
