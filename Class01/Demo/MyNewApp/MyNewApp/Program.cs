using System;

namespace MyNewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MyMethod();

            Console.WriteLine("WE ARE DONE!");

            #region ExceptionOverview

            // Try
            // "try" everything in a code snippet to see if it works
            // there is a chance that that bit of code will throw an exception
            // activates the "catch"

            // Cannot have a single TRY
            // code will not work. 
            // A, catch or finally or both must accompany it. 


            // Catch
            // catch "catches" the exception
            // like an if...else statement
            // we can have as many as we want
            // Order matters. 
            // general exception should be at the end
            // "most specific" condition/exception needs to be first
            // Specific Excpetions (divideByZero)
            // console.Writeline in a catch
            // e.message to show the message...log files
            // throw??????

            // Finally
            // will ALWAYS run if the code is able to run it. 
            // disconnect/cleanup anything that is required

            // Throw
            // can be placed in a catch
            // if that catch "couldn't" take of it, it can throw it to the prior method. 
            // throw "forces" an exception
            // gives us the ability to manage our code 
            // NotImplementedException.

            #endregion

        }

        static void MyMethod()
        {
            try
            {
                ExceptionExample();
            }
            catch (FormatException e)
            {
                Console.WriteLine("You entered in a word and not a number");
            }
        }

        static void ExceptionExample()
        {
            string answer = "";
            try
            {
                Console.WriteLine("Enter your favorite number");
                answer = Console.ReadLine();
                int number = Convert.ToInt32(answer);

                Console.WriteLine("Did we make it this far?");

                // this will technically work...
               // int answer = Convert.ToInt32(Console.ReadLine());

            }

            catch (Exception e)
            {
                // we don't have to expose the exception to the user
                // sometimes the wording can just be hard to understand
                // clean up the messaging 
                // expose vulnerabilities 
                // Log the formatting exception to a log file//send an email

                // email service e.Message;
                Console.WriteLine($"You are wrong");
                throw;
                
            }
        }






    }
}
