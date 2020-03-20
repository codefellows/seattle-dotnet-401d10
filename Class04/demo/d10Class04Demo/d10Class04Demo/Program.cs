using d10Class04Demo.Classes;
using System;
using System.Text;

namespace d10Class04Demo
{
    // not great practice because it's telling thisfile to do "too much"
    // better to seperate it out
    //class MyNewClass
    //{

    //}
    class Program
    {
        // private no one outsideofthis class can access this class
        //class MyNEstedClass
        //{

        //}

        // Program.Main(string [] args)
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // MyNewClass mnc = new MyNewClass();
            //LibraryExample();

           // Example2();
            ValueTypes();
        }

        public static void ValueTypes()
        {
            int x = 10;
            x++;
            int y = x;

            Console.WriteLine($"X is: {x}");
            Console.WriteLine($"Y is: {y}");

            Cat josie = new Cat();
            josie.Name = "Josie";
            josie.Age = 9;

            Console.WriteLine($"'josie' name is: {josie.Name}");

            Cat belle = new Cat()
            {
                Name = "Belle",
                Age = 10
            };

            Console.WriteLine($"'belle' name is: {belle.Name}");

            Cat frodo = josie;
            Console.WriteLine($"'frodo' name is: {frodo.Name}");

            josie.Name = "Fred";
            Console.WriteLine($"'josie' name is: {josie.Name}");
            Console.WriteLine($"'Frodo' name is: {frodo.Name}");

            frodo.Age = 22;
            Console.WriteLine($"'josie' name is: {josie.Age}");
            Console.WriteLine($"'Frodo' name is: {frodo.Age}");

            frodo = belle;

            Console.WriteLine($"'josie' name is: {josie.Name}");
            Console.WriteLine($"'Frodo' name is: {frodo.Name}");


            // strings are reference types
            // treat them like value types
            // live on the heap

            string name = "a";
            name += "mand";
            name += "a";

            StringBuilder sb = new StringBuilder();
            sb.Append("a");
            sb.Append("mand");
            sb.Append("a");

            sb.ToString();

        }

        static void Example2()
        {
            Book book = new Book("Harry Potter and the Sorcerer's Stone", "", 343);
            book.Author = new Author("JK", "Rowling");
            book.Author.SignBook(book);

            Author drSuess = new Author("Dr.", "Seuss");
            Book newBook = new Book("The Cat in the Hat", "SomePublisher", 25);
            drSuess.SignBook(newBook);
            newBook.Author = drSuess;

            
        }
       static void LibraryExample()
        {
            // instanitate an object
            // is by using the "new"
            // {Data Type} {Variable Name} = {Value}
            string name = "Josie";

            // Instantiated a new object named potato from the Library class
            Library potato = new Library("Josie");

            // the open and close parenths are the calling of an empty constructor. 
            Library amandasLibrary = new Library("Belle");

            // potato is an instance of the Library class
            // An object is an instance of a class. 

            // force a "getter"
            potato.MyLibrary($"My name is {potato.Name}");

            potato.Name = "JosieCat is Super Duper!"; // activate the setter

            potato.MyLibrary($"My name is {potato.Name}");


            amandasLibrary.MyLibrary("Kats are Cool!");

            // static means that the "thing" (method or property), can be accessed without instantiating the class into an object AND it lives WITH THE CLASS
            Library.Open();

        }
    }
}
