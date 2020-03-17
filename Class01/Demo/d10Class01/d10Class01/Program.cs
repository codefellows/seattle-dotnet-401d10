using System;

namespace d10Class01
{   // Bad:
    // string kitty = "Belle";
    class Program
    {
        static string cat = "Josie";

        // Methods live in classes
        // functions live outside of classes
        static void Main(string[] args)
        {
            //Main runs the program. 
            // Main is our "main" point of entry into a console app
            //Console.WriteLine("My Cat Rocks!");
            //Console.WriteLine(cat);
            //Console.WriteLine("Please enter your name");
            //string name = Console.ReadLine();
            //NewNameMethod(name);
            CatchSingleException();

            //try
            //{
            //    Console.WriteLine("Main Method");
            //    MethodA();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);

            //}

            //Console.WriteLine("I AM DONE!");
        }

        // Default values must be set at the end
        static void NewNameMethod(string potato, int number = 5)
        {
            Console.WriteLine(potato);
            //Console.WriteLine(number);
            for (int i = 0; i < number; i++)
            {
                // String interpolation
                Console.WriteLine($"The number is {i}");   
            }
        }

        public static void CatchSingleException()
        {
            // can declare more than one variable on teh same line as long as they are the same type
            // ints default to zero
            int milesDrive, gallonsOfGas, mpg = 0;

            try
            {
                // Try statements is code that you want to "try" to run and could potentially output an exception.
                Console.WriteLine("Enter The Miles Driven:");
                milesDrive = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the gallons of gas purchased");
                gallonsOfGas = Convert.ToInt32(Console.ReadLine());

                mpg = milesDrive / gallonsOfGas;


            }
            // Catch statements are run from top to bottom. 
            // like if/else statement
            catch (FormatException e)
            {
                // output the message of the exception
                Console.WriteLine($"FORMAT EXCEPTION is: {e.Message}");
                //throw;
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine("YOU DID SOMETHING WRONG!");
                Console.WriteLine(exception.Message);
                
            }
            catch (Exception e)
            {
                Console.WriteLine($"This was not a format exception, the message was: {e.Message}");
            }
            finally
            {
                //Finally blocks are like housekeepers. 
                // they clean up anything that is needed before the method is left
                Console.WriteLine("Good-bye");
            }

            Console.WriteLine($"You received {mpg} miles per gallon");




         

        }

        public static void MethodA()
        {
            try
            {
                Console.WriteLine("I am in Method A");
                MethodB();
            }
            catch (Exception)
            {
                Console.WriteLine("Caught in Method A");
                // throw
            }

            Console.WriteLine("Method A is done");
        }

        public static void MethodB()
        {
            try
            {
                Console.WriteLine("I am in Method B");
                MethodC();
            }
            catch (Exception)
            {
                Console.WriteLine("Caught in Method B");
                throw;
            }

            Console.WriteLine("Method B is done");
        }

        public static void MethodC()
        {
            Console.WriteLine("I am in Method C");
            throw (new Exception("this came from Method C"));
        }

    }
}
