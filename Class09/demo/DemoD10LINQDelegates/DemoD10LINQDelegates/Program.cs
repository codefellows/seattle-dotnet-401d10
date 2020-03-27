using DemoD10LINQDelegates.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoD10LINQDelegates
{
    // declared that MyDelegate exists. 
    // myDelegate has a return type of void
    delegate void MyDelegate();
    delegate bool NumbersDelegate(int n);

    /*
     * class MyDelegate{}
    */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //   MyMethod();
            // DelegatesExample();
            //    var numbersList = GetAllEvenNumbers(numbers);
            //   var numbersOddList = GetAllOddNumbers(numbers);

            LINQBasics();
            //foreach (var item in numbersList)
            //{
            //    Console.WriteLine(item);
            //}

            #region delgates

            List<int> numbers = new List<int>() { 4, 8, 15, 16, 23, 42 };


            // => is a lambda
            IEnumerable<int> values = GetNumbers(numbers, n => n % 2 == 0);
            IEnumerable<int> valuesOdd = GetNumbers(numbers, n => n % 2 == 1);

            // IEnumerables with lists are LAZY LOADING
            // lazy loading only loads values WHEN ITS CALLED
            // eager loading is the opposite...populates all the values right away

            foreach (var item in values)
            {
                Console.WriteLine(item);
            }

            #endregion
        }

        static IEnumerable<int> GetNumbers(IEnumerable<int> numbers, NumbersDelegate numbersDelegate)
        {
            foreach (int number in numbers)
            {
                if (numbersDelegate(number))
                {
                    yield return number;
                }
            }
        }

        static void DelegatesExample()
        {
            // create delegates
            // delegates are the ability to send methods as parameters. 

            // instantiate the delegate

            // ctor for the deleegate MUST be a method name with the same return type as the delegate
            //MyDelegate del = new MyDelegate(MyMethod);
            MyDelegate newDel = MyMethod;
            //// invoke the delegate
            //del();
            //del.Invoke();

            PassingADelegate(MyMethod);
        }

        static void PassingADelegate(MyDelegate delly)
        {
            delly();
        }

        static IEnumerable<int> GetAllEvenNumbers(IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    yield return number;
                }
            }

        }

        static IEnumerable<int> GetAllOddNumbers(IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                if (number % 2 == 1)
                {
                    yield return number;
                }
            }

        }


        static bool GetAllEven(int n) => n % 2 == 0;

        static bool GetAllOdd(int n) => n % 2 == 1;


        // return type is void
        // name is MyMethod
        static void MyMethod()
        {
            Console.WriteLine("Hello, Class!");
        }

        static void LINQBasics()
        {
            // LINQ = Language Integrated Query
            // Declarative - LINQ (i am going to give you directiosn and you are going to "just get the job done"
            // Imperative = Foreach loop
            // do step by step instructions

            // Query = expresssion that when enumerated over transforms the sequeces w/ query operators
            // standard queiry are implemented as extension methods, so can send data into it.

            // LINQ operations constist of 3 distinct actions
            /*
             * 1. Obtain a data source (database, list, array, external text file that you read in (???)
             * 2. Create a query (what are we trying to accomplish)
             * 3. Execture the query (actual act of running the query of step 2)
             */

            // step 1. Obtain a data source
            Person[] persons =
            {
                new Person ("Kate", "Austin", 33),
                new Person ("Jack", "Shepard", 39),
                new Person ("James", "Ford", 30),
                new Person ("Ben", "Linus", 23),
                new Person ("Hugo", "Reyes", 20),
            };

            /*Get the first and last name of all the people in the persons table older than 21
             * SQL
             * SELECT firstName, lastName --> projection 
             * FROM persons --> Data source
             * WHERE age > 21 -- filter
             * ORDER BY Age DESC; --> Sorting
             */

            // get a list of all the people in our persons table
            var query = from potato in persons
                        select new { potato.FirstName, potato.FirstName };

            // all linq queries return iEnumerables by default
            var query1 = from p in persons
                         where p.Age > 21
                         orderby p.Age descending
                         select p;

            foreach (var item in query1)
            {
                Console.WriteLine(item.FirstName);
            }


            // anonymous objects
            // only the first and the last name will be present
            var query2 = from person in persons
                         where person.Age > 21
                         orderby person.Age descending
                         select new { person.FirstName, person.LastName };

            foreach (var item in query2)
            {
                Console.WriteLine(item.FirstName);
            }


        }

        static void MethodCalls()
        {
            // projectsion are through the select
            // mapping is defined through delegates. use lambda exressions/functions

            Person[] persons =
            {
                new Person ("Kate", "Austin", 33),
                new Person ("Jack", "Shepard", 39),
                new Person ("James", "Ford", 30),
                new Person ("Ben", "Linus", 23),
                new Person ("Hugo", "Reyes", 20),
            };

            // method call with just the "SELECT" projection
            // anonymous object
            var query = persons.Select(candy => new { candy.FirstName, candy.LastName });

            var equiv = from p in persons
                        select new { p.FirstName, p.LastName };

            // possible chaining
            var chain = persons.Where(per => per.Age > 21)
                               .Select(p => new { p.FirstName, p.LastName });

            // orderby
            var orderby = persons
                            .Where(p => p.Age > 21)
                            .OrderByDescending(p => p.Age)
                            .Select(p => new { p.FirstName, p.LastName });


            // no select,. and returning a specific data type
            List<Person> noselect = persons.Where(p => p.Age > 21).ToList();

            // .Take and .Skip are some other linq queries

            var example = persons
                            .Where(p => p.Age > 21)
                            .OrderByDescending(p => p.Age)
                            .Skip(2)
                            .Take(1);
  
            // deferred execution (lazy loadin)
                // the items are not fully loaded up and only are loaded up when called. 
                // foreach loop

            // immediate execution (eager loading) all items are a loaded up right away. performance is frontloaded 

            // .WHERE does not execute until it's in a loop
            // .Skip() or .Sum() execute immediatly


        }
    }
}
