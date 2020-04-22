using System;

namespace MergeSort
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] myArray = { 8, 3, 2, 9, 7, 1, 5, 4,6};
			Mergesort(myArray);
		}


		//Sorting in non decreasing order
		private static void Mergesort(int[] arr)
		{
			// an array of 1 is already sorted...
			if (arr.Length > 1)
			{
				// put first half in one array (array left)
				int bSize = arr.Length / 2;
				int cSize = arr.Length - bSize;

				int[] B = new int[bSize];
				Array.Copy(arr, 0, B, 0, bSize);

				// put the second half in the other array
				int[] C = new int[cSize];
				Array.Copy(arr, arr.Length / 2, C, 0, cSize);

                // Recursively keep breaking down the array
                
				Mergesort(B);
				Mergesort(C);
                // Console.WriteLine(string.Join(',', B));
                // Console.WriteLine(string.Join(',', C));

                // once they are broken down, merge the arrays together
                Merge(B, C, arr);
			}

			Console.WriteLine(string.Join(",", arr));
		}

		private static int[] Merge(int[] b, int[] c, int[] a)
		{
			// i is the reference for array b, set it to the beginning
			int i = 0;
            // j is the reference for array c, set it to the beginning
            int j = 0;
            // k is the reference for the main array to populate
            int k = 0;


			while (i < b.Length && j < c.Length)
			{

                // if reference b is less than reference c value put that value of reference b into the main array (a)
                if (b[i] <= c[j])
				{
					// 
					a[k] = b[i];
					// immediate increment the counter then to move to the next one
					i = i + 1;
				}
				else
				{
                    // if the value of reference c is less, then put that in the main array
                    a[k] = c[j];
					// immediately increment the counter
					j = j + 1;
				}
				k = k + 1;
			}
			// do this until one array is to the end and then copy over the rest. 
			if (i == b.Length)
			{
				//copy c to a
				Array.Copy(c, j, a, k, c.Length - j);
			}
			else
			{
				// copy b to a
				Array.Copy(b, i, a, k, b.Length - i);
			}
			return a;
		}
	}


}
