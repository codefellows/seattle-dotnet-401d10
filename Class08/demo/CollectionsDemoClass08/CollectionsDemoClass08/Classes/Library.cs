using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionsDemoClass08.Classes
{
    // This is our generic Collection
    // Generic Collection IS JUST A CLASS!
    // When instantiating...we need the "new" keyword
    class Library<T>: IEnumerable
    {
        // an array instantiation is still required. 
        // under the hood a collection IS JUST AN ARRAY!!!
        // Seriously...no magic. 

        T[] inventory = new T[3];

        int counter = 0;

        public void Add(T book)
        {
            // check and make sure their is room in the array for my new value
            if (counter == inventory.Length)
            {
                Array.Resize(ref inventory, inventory.Length * 2);

                /* In Array Resize:
                 * it's creating a brand new array of the size that we specified
                  * it's traversing over the OLD array and transferring the old values to the new array
                  * Returning the new array, by setting the inventory variable frm the stack to the REFERENCE of the new array
                 */
            }

            inventory[counter++] = book;
        }

        public void ScanBook()
        {

        }

        // we must return to the user something that implements the IEnumerator interface

        // Enumerator enumerate through our array to each item
        // this getEnumerator is our foreach loop
        // under the hood..."syntactic sugar" of a foreach loop
        // IS A FOR LOOP that references an Array
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < counter; i++)
            {
                // yield return pauses
                yield return inventory[i];

                // yield break - cleanly breaks out of a loop.
            }

        }

        // this method exists for PURELY legacy code purposes. 
        // Magic...don't touch. 
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
