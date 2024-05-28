using Management_Library.Models.Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Library.Interfaces
{
    public interface IUserService
    {
        List<User> LoadUsers();
    }
}
