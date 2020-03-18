using System;

namespace d10Demo02
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AddAllNumbers("Josie", 10);
        }

        /// <summary>
        /// Adding all the numbers together dependent on what the user inputs. Useful for this really important reason
        /// </summary>
        /// <param name="name">Name of user's Cat</param>
        /// <param name="number">final number that we are adding together.</param>
        /// <returns>Sum of all the numbers from 0 to the variable number</returns>
        static int AddAllNumbers(string name, int number)
        {
            // outputs to the console the name of the cat.
            Console.WriteLine($"My Cat is named {name}");
            int sum = 0;

            // adding sequence of user given number for This really really important reason
            // Reference to something
            // bug fix for something
            // links to the otherthing that is super important.
            // Amanda - 3.17.2020 - Added thsi for loop per Josie'e request for bug # 123456
            for (int i = 0; i < number; i++)
            {
                sum += i;
            }

            // returns sum
            return sum;
        }

        public static string FizzBuzz(int number)
        {
            // alternative condition is
            // if(number % 15 == 0)
            if(number % 3 == 0 && number % 5 == 0)
            {
                return "FizzBuzz";
            }
            // Modulo operator give us the remainder from whatever you send it
            if(number % 3 == 0)
            {
                return "Fizz";
            } 
            if(number % 5 == 0)
            {
                return "Buzz";
            }
            return number.ToString();
        }

        // .NET has 3 different types of testing frameworks
        // NUNIT
        // MSTEST
        // XUNIT - Brad Wilson

        // Unit Tests - XUNIT!
        // Code Coverage = percentage of code that has been tested
        // TEST - Tests are important so that we can find issues in our code
        // Edge Case - expecting int vs strings
        // TDD stands for Test - Driven - Development
        // Writing tests first and code 2nd. 

        // Red - Red is not passing, The code is satisfactory
        // modify the code == 
        // Hardcode

        // Green - Test has passed...Moving on to the next pass (potentially)
        // Refactor the tests or write new tests. 
        // break out into other methods
        // turn hardcoded values into variables

    }
}
