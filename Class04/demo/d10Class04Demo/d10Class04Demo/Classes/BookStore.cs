using System;
using System.Collections.Generic;
using System.Text;

namespace d10Class04Demo.Classes
{
    class BookStore
    {
        // an array is not being instantiated
        public Book[] Books { get; set; }
        public string Name { get; set; } = "Unknown Name";

        // Best practice is to have an _ in front of a private variable for visibility sake
        private int _intialBookSize = 10;
        // empty constructor
        public BookStore()
        {
            Books = new Book[_intialBookSize];

        }

        public BookStore(string name)
        {
            Name = name;
            Books = new Book[_intialBookSize];

        }

        public Book PurchaseBook(string bookName)
        {
            Book book = null;
            for (int i = 0; i < Books.Length; i++)
            {
                if(Books[i].Title == bookName)
                {
                    Books[i].CheckedOut = true;
                    book = Books[i];
                }
            }

            return book;

        }
       


    }
}
