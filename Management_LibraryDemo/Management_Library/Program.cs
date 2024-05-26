using Management_Library.Login;

namespace Management_Library
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Auth.Login("user@gmail.com", "12345"));
        }
    }
}
