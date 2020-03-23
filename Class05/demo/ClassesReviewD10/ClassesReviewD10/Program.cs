using ClassesReviewD10.Classes;
using System;

namespace ClassesReviewD10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ClassesExample();
        }

        static void ClassesExample()
        {
            /* Define:
            Method Signature:
                // combo of the name, type, and it's paramters and it's type. 
                // add it's access modifier. 
            Return Type:
                // what is value is returned from a method
            Properties:
                // It's what the class "has"// Attribute
            Classes:
                // "widget maker" , template for making objects
            Objects:
                // what gets instantiated from the class
            Auto Implemented Properties:
                 // "getter and setters" - {get; set;} part of the property
                 // under the hood -- private backing fields. 
             */

            // {DataType} {variable name} = {new} {DataType}{(Constructor)}
            Person myPerson = new Person("Fred");
            Person person2 = new Person("Hermione");

            myPerson.DrinkCoffee();
            person2.DrinkCoffee();

            myPerson.PlayOutside();

            Course course = new Course();
            course.Name = "Math";
            course.Professor = person2;
            course.MaxStudents = 10;

            Assignment assignment = new Assignment()
            {
                Name = "Addition Problems",
                Directions = "Add two numbers together....blah blah blah",
                Points = 100
            };

            course.StartCourse();
            course.LabTime(3, assignment);


        }
    }
}
