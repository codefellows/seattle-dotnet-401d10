using Class07Solution.Classes;
using System;
using System.Collections.Generic;

namespace Class07Solution
{
    class Program
    {
        public static Library<Book> Library { get; set; }
        public static List<Book> BookBag { get; set; }

        static void Main(string[] args)
        {
            Library = new Library<Book>();
            BookBag = new List<Book>();

            LoadBooks();
            UserInterface();
        }

        static void UserInterface()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();

                Console.WriteLine("WELCOME to Phil's lending library!");
                Console.WriteLine("pick an option...");
                Console.WriteLine("1. View All Books");
                Console.WriteLine("2. Add New Book");
                Console.WriteLine("3. Borrow a Book");
                Console.WriteLine("4. Return a Book");
                Console.WriteLine("5. View Book Bag");
                Console.WriteLine("6. Exit");
                Console.WriteLine();

                string answer = System.Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        Console.Clear();

                        OutputBooks();

                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Please enter the following details:");
                        Console.Write("Book Title: ");
                        string title = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Author First Name: ");
                        string firstName = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Author Last Name: ");
                        string lastName = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Number Of Pages: ");
                        string numberOfPages = Console.ReadLine();
                        int.TryParse(numberOfPages, out int result);

                        AddABook(title, firstName, lastName, result);
                        break;
                    case "3":
                        Console.Clear();

                        Dictionary<int, string> books = new Dictionary<int, string>();
                        Console.WriteLine("Which book would you like to borrow? Please only select the number.");
                        int counter = 1;
                        foreach (Book book in Library)
                        {
                            books.Add(counter, book.Title);
                            Console.WriteLine($"{counter++}. {book.Title} - {book.Author.FirstName} {book.Author.LastName}");
                        }
                        string response = Console.ReadLine();
                        int.TryParse(response, out int selection);
                        books.TryGetValue(selection, out string borrowedtitle);
                        Borrow(borrowedtitle);
                        break;
                    case "4":
                        ReturnBook();
                    break;
                    case "5":
                        Console.Clear();

                        foreach (Book book in BookBag)
                        {
                            System.Console.WriteLine($"{book.Title} - {book.Author.FirstName} {book.Author.LastName}");
                        }
                        break;
                    case "6":
                        exit = true;
                        Environment.Exit(1);
                        break;
                    default:
                        System.Console.WriteLine("Invalid option...");
                        break;
                }
            }



        }

        static void AddABook(string title, string firstName, string lastName, int numberOfPages)
        {
            Book book = new Book() { Title = title, Author = new Author() { FirstName = firstName, LastName = lastName }, NumberOfPages = numberOfPages, Genre = Genre.Romance };
            Library.Add(book);
        }

        static void OutputBooks()
        {
            int counter = 1;
            foreach (Book book in Library)
            {
                System.Console.WriteLine($"{counter++}.{book.Title} - {book.Author.FirstName} {book.Author.LastName}");
            }
        }
        static void LoadBooks()
        {


            // Create Books
            Book a = new Book { Title = "Alice in Wonderland", Author = new Author() { FirstName = "Lewis", LastName = "Carol" }, Genre = Genre.Mystery };
            Book b = new Book
            {
                Title = "The Great Gatsby",
                Author = new Author() { FirstName = "F. Scott", LastName = "Fitzgerald" },
                Genre = Genre.Drama
            };
            Book c = new Book { Title = "To Kill a Mockingbird", Author = new Author() { FirstName = "Harper", LastName = "Lee" }, Genre = Genre.SciFi };
            Book d = new Book { Title = "Lord of the Flies", Author = new Author() { FirstName = "William", LastName = "Golding" }, Genre = Genre.Drama };
            Book e = new Book { Title = "Harry Potter and the Prison of Azkaban", Author = new Author() { FirstName = "JK", LastName = "Rowling" }, Genre = Genre.Mystery };

            // Add all the books to the library
            Library.Add(a);
            Library.Add(b);
            Library.Add(c);
            Library.Add(d);
            Library.Add(e);


        }

        static void ReturnBook()
        {
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            Console.WriteLine("Which book would you like to return");
            int counter = 1;
            foreach (var item in BookBag)
            {
                books.Add(counter, item);
                Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");

            }

            string response = Console.ReadLine();
            int.TryParse(response, out int selection);
            books.TryGetValue(selection, out Book returnedBook);
            BookBag.Remove(returnedBook);
             Library.Add(returnedBook);
        }

        public static Book Borrow(string title)
        {
            Book borrowedBook = null;
            foreach (Book book in Library)
            {
                if (book.Title == title)
                {
                    borrowedBook = book;
                    BookBag.Add(Library.Remove(borrowedBook));
                    break;

                }
            }
            return borrowedBook;
        }

    }
}
