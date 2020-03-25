using CollectionsDemoClass08.Classes;
using CollectionsDemoClass08.Classes.Enums;
using System;
using System.Collections.Generic;

namespace CollectionsDemoClass08
{
    class Program
    {
        // ENUMS
        // - Used a lot in web developmet
        // user input
        // predefined set of values that we can choose from
        // eliminate spelling errors
        // choosing anythign that's not valid
        // Example: Days of the week, Months of the year, 
        // E-commerce Store: xs - xl, colors of products
        // types of accounts: Basic // premium// platinum 
        // used in Databases, 
        // Generic Collections
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //EnumPractice();
            // CollectionExample();
            // Phil's Lending Library
            PhilsLendingLibrary();

        }

        static void EnumPractice()
        {
            // dayOfWeek will be equal to 1
            // casting. 
            // boxing

            // enums are Value types
            // ints are value types
            int dayOfWeek = (int)Day.Monday;

            Day monday = Day.Monday;

            Console.WriteLine($"Today is {dayOfWeek}");

            Console.WriteLine($"Monday is {monday}");

        }


        static void CollectionExample()
        {
            /*
             There are 2 different ways that we can group together pieces of data

            1. Arrays
                - Their good on memory
                - explicitly what the size is. 
                - Cons: Sometimes we just don't know the size.  
            1. Collections
                - More flexible way to work with groups of objects
                - Grow and shrink dynamically as needed
                - key/value pairs (dictionary, hashtable)
                - can contain mish mash of data types (non-generic) (slower)   
                        -- Collections came out in C# 1
                        -- Generics came out in C# 2
                            -- Generics means all the same data type
                - can contain all the same data type (generics) (faster)
             */

            List<string> catNames = new List<string>();

            catNames.Add("Josie");
            catNames.Add("Belle");
            catNames.Add("munchkin");
            catNames.Add("Pinot");
            catNames.Add("Pandora");
            catNames.Add("Revy");
            catNames.Add("Garfield");

            // foreach name that exists in my CatNames list...please 
            // write it to the console.
            foreach (string name in catNames)
            {
                Console.WriteLine(name);
            }
            //collection initializer
            List<int> numbers = new List<int> { 4, 8, 15, 16, 23, 42 };

            numbers.Sort();

            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

            numbers.Remove(15);

            bool contains23 = numbers.Contains(23);

            Console.WriteLine($"Index of 8: {numbers.IndexOf(8)}");

            Console.WriteLine($"Do you Contain 23? {contains23}");

            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }


        }

        static void PhilsLendingLibrary()
        {
            // instantiated our custom collection
            Library<Book> phil = new Library<Book>();

            Book a = new Book { Title = "Alice in Wonderland", Author = new Author() { FirstName = "Lewis", LastName = "Carol" }, Genre = Genre.Mystery };

            Book b = new Book
            {
                Title = "The Great Gatsby",
                Author = new Author() { FirstName = "F. Scott", LastName = "Fitzgerald" },
                Genre = Genre.Drama
            };

            Book c = new Book { Title = "To Kill a Mockingbird", Author = new Author() { FirstName = "Harper", LastName = "Lee" }, Genre = Genre.SciFi };

            Book d = new Book { Title = "Lord of the Flies", Author = new Author() { FirstName = "William", LastName = "Golding" }, Genre = Genre.Drama };

            phil.Add(a);
            phil.Add(b);
            phil.Add(c);
            phil.Add(d);


            // Foreach loop needs to ENUMERATE through the list
            // and then do something...{code block} for each item
            foreach (Book book in phil)
            {
                Console.WriteLine(book.Title);
            }

            // instiating a list of books using the collection initalizer

            // To use a collection initializer...we MUST make sure that the collection is Enumerable.
            // the only way to GUARANTEE that the collection is enumerable is to 
            // implement the IENUMERABLE interface. 
            Library<Book> newCollection = new Library<Book>()
            {
                new Book{
                    Title = "MyBook",
                    Author = new Author
                    {
                        FirstName = "Belle",
                        LastName = "Kitty"
                    }
                },

                  new Book{
                    Title = "Book 2",
                    Author = new Author
                    {
                        FirstName = "Josie",
                        LastName = "Cat"
                    }
                }
            };

            foreach (var item in newCollection)
            {
                Console.WriteLine($"{item.Title}");
            }

        }
    }
}
