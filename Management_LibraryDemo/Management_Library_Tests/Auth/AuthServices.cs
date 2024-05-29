using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management_Library.Auth;
using Management_Library.Exceptions;
using Management_Library.Services;

namespace Management_Library_Tests.Auth
{
    public class AuthServiceTests
    {
        private UserService userService;

        public AuthServiceTests()
        {
            userService = new UserService();
        }

        [Fact]
        public void Login_ShouldReturnUserRole()
        {
            var role = AuthService.Login("admin@gmail.com", "123", userService);

            Assert.Equal("admin", role);
        }

        [Fact]
        public void Login_ShouldThrowExceptionIfUserNotFound()
        {
            Assert.Throws<UserNotFoundException>(() => AuthService.Login("nonexistent@example.com", "wrongpassword", userService));
        }
    }
}
