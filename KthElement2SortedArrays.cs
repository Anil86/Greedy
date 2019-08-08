using System;
using static System.Console;

namespace Greedy
{
    public class KthElement2SortedArrays
    {
        private int FindElement(int[] array1, int[] array2, int k)
        {
            k -= 1;
            int totalLength = array1.Length + array2.Length;
            int mid = totalLength / 2;
            int end;

            if (k <= mid)   // Element present in 1st-half
            {
                end = k + 1;   // No.of items to skip to reach `k`.
                return FindElementLeft(1, 0, 0);
            }

            // Element present in 2nd-half
            end = totalLength - k;   // No.of items to skip to reach `k`.
            return FindElementRight(1, array1.Length - 1, array2.Length - 1);




            int FindElementLeft(int current, int i1, int i2)
            {
                // Stop condition
                // If one of the arrays has finished, directly return kth item
                if (i1 == array1.Length) return array2[i2 + end - current];
                if (i2 == array2.Length) return array1[i1 + end - current];

                // When processing kth index, pick min of 2 current items 
                if (current == end) return Math.Min(array1[i1], array2[i2]);


                // Recursive condition
                if (array1[i1] == array2[i2])   // When 2 items are same:
                    return current + 1 == end
                        ? array1[i1]   // If k is reached, return
                        : FindElementLeft(current + 2, i1 + 1, i2 + 1);   // Take both items

                int min = Math.Min(array1[i1], array2[i2]);   // Find the min item
                return min == array1[i1]
                    ? FindElementLeft(current + 1, i1 + 1, i2)    // If array1 is min, increase its index 
                    : FindElementLeft(current + 1, i1, i2 + 1);   // If array2 is min, increase its index 
            }


            int FindElementRight(int current, int i1, int i2)
            {
                if (i1 == -1) return array2[i2 - end + current];
                if (i2 == -1) return array1[i1 - end + current];

                if (current == end) return Math.Max(array1[i1], array2[i2]);

                if (array1[i1] == array2[i2])
                    return current + 1 == end
                        ? array1[i1]
                        : FindElementRight(current + 2, i1 - 1, i2 - 1);

                int max = Math.Max(array1[i1], array2[i2]);
                return max == array1[i1]
                    ? FindElementRight(current + 1, i1 - 1, i2)
                    : FindElementRight(current + 1, i1, i2 - 1);
            }
        }



        internal static void Work()
        {
            int[] array1 = { 2, 3, 6, 7, 9 };
            int[] array2 = { 1, 4, 8, 10 };
            int k = 5;
            // Ans: 6

            //int[] array1 =
            //{
            //    3, 4, 11, 14, 15, 15, 16, 18, 22, 23, 24, 24, 26, 27, 28, 28, 35, 36, 39, 41, 41, 41, 42, 43, 43, 44,
            //    45, 45, 47, 48, 48, 53, 54, 55, 55, 56, 56, 60, 61, 61, 61, 63, 65, 66, 68, 69, 70, 72, 72, 73, 73, 74,
            //    74, 76, 76, 79, 81, 81, 81, 83, 86, 90, 91, 92, 92, 95, 99, 100
            //};
            //int[] array2 = { 26 };
            //int k = 26;
            // Ans: 43

            //int[] array1 =
            //{
            //    3, 4, 6, 6, 9, 12, 12, 14, 14, 15, 16, 16, 20, 22, 22, 23, 24, 25, 25, 26, 27, 27, 27, 28, 28, 30, 30,
            //    30, 30, 31, 35, 36, 36, 37, 37, 38, 41, 43, 44, 46, 47, 50, 51, 57, 57, 58, 59, 60, 63, 63, 63, 64, 65,
            //    68, 68, 68, 68, 69, 70, 71, 71, 73, 74, 74, 77, 79, 81, 82, 83, 83, 85, 85, 85, 87, 88, 89, 91, 92, 93,
            //    94, 94, 96, 97, 99
            //};
            //int[] array2 =
            //{
            //    1, 2, 2, 3, 4, 7, 9, 10, 13, 15, 16, 18, 18, 19, 20, 20, 20, 22, 24, 25, 25, 27, 28, 29, 29, 30, 30, 32,
            //    33, 33, 35, 35, 40, 40, 41, 41, 42, 42, 45, 46, 47, 50, 51, 52, 52, 53, 54, 55, 56, 57, 57, 57, 61, 65,
            //    65, 66, 66, 68, 68, 69, 69, 71, 71, 72, 72, 76, 77, 79, 80, 81, 82, 84, 87, 87, 87, 88, 89, 90, 93, 94,
            //    95, 96, 97, 98, 98, 98, 100
            //};
            //int k = 96;
            // Ans: 57

            //int[] array1 =
            //{
            //    5, 5, 7, 8, 12, 14, 18, 18, 19, 19, 22, 25, 29, 29, 29, 29, 30, 30, 33, 36, 37, 38, 38, 39, 41, 44, 44,
            //    44, 52, 59, 60, 64, 66, 70, 71, 75, 76, 77, 84, 89, 91, 94, 96, 97
            //};
            //int[] array2 =
            //{
            //    1, 2, 5, 6, 6, 6, 8, 8, 9, 11, 12, 12, 13, 14, 17, 19, 21, 23, 23, 23, 25, 25, 26, 27, 27, 29, 31, 31,
            //    32, 34, 37, 37, 37, 38, 40, 41, 41, 43, 43, 44, 45, 45, 46, 47, 49, 49, 51, 53, 55, 56, 57, 59, 60, 61,
            //    62, 63, 64, 65, 66, 67, 69, 69, 69, 70, 72, 73, 74, 74, 77, 79, 80, 80, 82, 82, 83, 83, 85, 85, 87, 88,
            //    91, 91, 91, 95, 96, 97, 98, 100, 100, 100, 100, 100
            //};
            //int k = 127;
            //Ans: 96

            int element = new KthElement2SortedArrays().FindElement(array1, array2, k);
            WriteLine(element);
        }
    }
}