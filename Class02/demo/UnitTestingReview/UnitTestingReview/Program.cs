using System;

namespace UnitTestingReview
{
   public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] myArray = new int[6];

        }

        static int[] MyArrayMethod(int[] arra)
        {
            int counter = 0;
            for (int i = 0; i < arra.Length; i++)
            {
                arra[i] = counter++;
            }

            return arra;
        }

        public static int[] Populate(int number)
        {
            int[] array = new int[number];
            return array;
        }

        public static int[] ChangeValue(int index, int value, int[] myArray)
        {
            myArray[index] = value;

            return myArray;
        }
    }
}
