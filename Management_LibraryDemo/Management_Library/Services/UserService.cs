using Management_Library.Interfaces;
using Management_Library.Models.Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Library.Services
{
    public class UserService : IUserService
    {
        public List<User> LoadUsers()
        {
            return new User().LoadUsers();
        }
    }
}
