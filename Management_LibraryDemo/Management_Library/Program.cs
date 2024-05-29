using System;
using Management_Library.Auth;
using Management_Library.Interfaces;
using Management_Library.Models;
using Management_Library.Services;

namespace Management_Library
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool isLoggedIn = false;
            IBookService bookService = new BookService();
            IUserService userService = new UserService();
            ILoanService loanService = new LoanService(bookService.GetBooks());

            InitializeData(bookService, userService);

            string email, password;

            while (true) 
            {
                isLoggedIn = false; 

                Console.WriteLine("\n*****************************--- Inicio de sesión ---*****************************");

                Console.WriteLine("\nIngrese su email:");
                email = Console.ReadLine();

                Console.WriteLine("Ingrese su contraseña:");
                password = Console.ReadLine();

                try
                {
                    string role = AuthService.Login(email, password, userService);
                    isLoggedIn = true;

                    switch (role)
                    {
                        case "admin":
                            AdminMenu(bookService, loanService);
                            break;
                        case "assistant":
                            AssistantMenu(bookService);
                            break;
                        case "user":
                            UserMenu(loanService, email);
                            break;
                        default:
                            Console.WriteLine("Rol no reconocido.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocurrió un error: {ex.Message}");
                }
            }
        }

        private static void InitializeData(IBookService bookService, IUserService userService)
        {
            bookService.AddBook(new Book { Title = "Cien Años de Soledad", Author = "Gabriel García Márquez" });
            bookService.AddBook(new Book { Title = "Don Quijote de la Mancha", Author = "Miguel de Cervantes" });
            bookService.AddBook(new Book { Title = "El Principito", Author = "Antoine de Saint-Exupéry" });
            bookService.AddBook(new Book { Title = "El retrato de Dorian Gray", Author = "Oscar Wilde" });
            bookService.AddBook(new Book { Title = "Asylum", Author = "Madeleine Roux" });

            var users = userService.LoadUsers();
        }

        private static void AdminMenu(IBookService bookService, ILoanService loanService)
        {
            while (true)
            {
                Console.WriteLine("\nMenu Admin:");
                Console.WriteLine("1. Ver listado de libros.");
                Console.WriteLine("2. Registrar préstamo.");
                Console.WriteLine("3. Cerrar sesión.");
                Console.WriteLine("4. Salir del programa.");
                Console.Write("Seleccione una opción: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        var books = bookService.GetBooks();
                        foreach (var book in books)
                        {
                            Console.WriteLine($"{book.Id}: {book.Title} por {book.Author} (Disponible: {book.IsAvailable})");
                        }
                        break;
                    case "2":
                        Console.Write("Ingrese el email del cliente: ");
                        var clientEmail = Console.ReadLine();
                        Console.Write("Ingrese el ID del libro: ");
                        var bookId = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese la duración del préstamo en días: ");
                        var loanDays = int.Parse(Console.ReadLine());

                        try
                        {
                            loanService.RegisterLoan(clientEmail, bookId, loanDays);
                            Console.WriteLine("¡Préstamo registrado correctamente!.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "3":
                        return;
                    case "4":
                        Environment.Exit(0); // Cerrar programa completamente
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        private static void AssistantMenu(IBookService bookService)
        {
            while (true)
            {
                Console.WriteLine("\nMenu Asistente:");
                Console.WriteLine("1. Agregar nuevo libro.");
                Console.WriteLine("2. Editar datos de un libro.");
                Console.WriteLine("3. Cerrar sesión.");
                Console.WriteLine("4. Salir del programa.");
                Console.Write("Seleccione una opción: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Ingrese el título del libro: ");
                        var title = Console.ReadLine();
                        Console.Write("Ingrese el autor del libro: ");
                        var author = Console.ReadLine();

                        var newBook = new Book { Title = title, Author = author };
                        bookService.AddBook(newBook);
                        Console.WriteLine("Libro agregado correctamente.");
                        break;
                    case "2":
                        Console.Write("Ingrese el ID del libro: ");
                        var bookId = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el nuevo título del libro: ");
                        title = Console.ReadLine();
                        Console.Write("Ingrese el nuevo autor del libro: ");
                        author = Console.ReadLine();

                        try
                        {
                            bookService.EditBook(bookId, title, author);
                            Console.WriteLine("¡Libro editado correctamente!.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "3":
                        return;
                    case "4":
                        Environment.Exit(0); 
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        private static void UserMenu(ILoanService loanService, string email)
        {
            while (true)
            {
                Console.WriteLine("\nMenu Usuario:");
                Console.WriteLine("1. Devolver libro.");
                Console.WriteLine("2. Cerrar sesión.");
                Console.WriteLine("3. Salir del programa.");
                Console.Write("Seleccione una opción: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Ingrese el ID del préstamo: ");
                        var loanId = int.Parse(Console.ReadLine());

                        try
                        {
                            loanService.ReturnBook(loanId);
                            Console.WriteLine("¡Libro devuelto correctamente!.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;
                    case "2":
                        return;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}