using System;
using Management_Library.Login;

namespace Management_Library
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Ingrese su email:");
            string email = Console.ReadLine();

            Console.WriteLine("Ingrese su contraseña:");
            string password = Console.ReadLine();

            try
            {
                string result = Auth.Login(email, password);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
        }
    }
}
