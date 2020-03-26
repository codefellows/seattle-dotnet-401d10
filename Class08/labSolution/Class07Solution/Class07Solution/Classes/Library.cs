using System;
using System.Collections;
using System.Collections.Generic;

namespace Class07Solution.Classes
{
    class Library<T> : IEnumerable
    {
        T[] inventory = new T[10];
        int count = 0;

        /// <summary>
        /// Add anew item to the Library List
        /// </summary>
        /// <param name="book">The new object that needs to be added</param>
        public void Add(T book)
        {
            // Check if you need to resize your array
            if (count == inventory.Length)
            {
                // resize the array to 1/4 the size
                Array.Resize(ref inventory, inventory.Length * 2);
            }
            // add the book to the array, and increment the counter
            inventory[count++] = book;
        }

        /// <summary>
        /// Remove an item from the library
        /// </summary>
        /// <param name="item"> The book needs to be removed from the list</param>
        public T Remove(T item)
        {
            int quarter = count - 1;
            int tempcount = 0;
            T[] temp;
            T removedBook = default(T);
             

            // First make sure the item exists in the array and then resize if necessary. 
            if (IsAvailable(item))
            {
                if (count < inventory.Length / 2)
                {
                    // resize it to an array that is 1/4 size larger of count. 
                    temp = new T[quarter];
                }
                else
                {
                    // keep the length the same if it is at least half the length.
                    temp = new T[inventory.Length];
                }

                // power through the array and only add the items that are not null'd
                for (int i = 0; i < count; i++)
                {
                    if (inventory[i] != null)
                    {
                        if (!inventory[i].Equals(item))
                        {
                            temp[tempcount] = inventory[i];

                            tempcount++;
                        }
                        else
                        {
                            removedBook = inventory[i];

                        }
                    }
                }
                inventory = temp;
                count--;
            }
            return removedBook;
        }

        public int Count()
        {
            return count;
        }

        /// <summary>
        /// Check if the item exists in the Library
        /// </summary>
        /// <param name="book">The book we are looking for</param>
        /// <returns>indicator if it exists in the library</returns>
        public bool IsAvailable(T book)
        {
            for (int i = 0; i < count; i++)
            {
                if (inventory[i].Equals(book))
                {
                    return true;
                }
            }
            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                // Yield return pauses at each item in the array before moving to the next
                yield return inventory[i];
            }
        }



        // Magic Don't Touch
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
