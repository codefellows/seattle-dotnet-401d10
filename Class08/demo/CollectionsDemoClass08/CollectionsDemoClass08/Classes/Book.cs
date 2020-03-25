using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionsDemoClass08.Classes
{
    class Book
    {
        public string Title { get; set; }
        public int NumberOfPages { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }

    }

    enum Genre
    {
        Mystery,
        SciFi,
        Drama,
        Romance
    }
}
