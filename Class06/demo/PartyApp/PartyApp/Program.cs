using PartyApp.Classes;
using System;

namespace PartyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Over21 party = new Over21();

            Console.WriteLine(party.Budget);
        }
    }
}
