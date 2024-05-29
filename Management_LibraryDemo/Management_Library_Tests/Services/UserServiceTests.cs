using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management_Library.Services;

namespace Management_Library_Tests.Services
{
    public class UserServiceTests
    {
        private UserService userService;

        public UserServiceTests()
        {
            userService = new UserService();
        }

        [Fact]
        public void LoadUsers_ShouldReturnUsers()
        {
            var users = userService.LoadUsers();

            Assert.Equal(3, users.Count);
        }

        [Fact]
        public void LoadUsers_ShouldReturnAdmin()
        {
            var users = userService.LoadUsers();
            var admin = users.Find(u => u.Email == "admin@gmail.com");

            Assert.NotNull(admin);
            Assert.Equal("admin", admin.Rol);
        }

        [Fact]
        public void LoadUsers_ShouldReturnUser()
        {
            var users = userService.LoadUsers();
            var user = users.Find(u => u.Email == "user@gmail.com");

            Assert.NotNull(user);
            Assert.Equal("user", user.Rol);
        }

        [Fact]
        public void LoadUsers_ShouldReturnAssistant()
        {
            var users = userService.LoadUsers();
            var assistant = users.Find(u => u.Email == "assistant@gmail.com");

            Assert.NotNull(assistant);
            Assert.Equal("assistant", assistant.Rol);
        }
    }
}
