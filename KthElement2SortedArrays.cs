using static System.Console;

namespace Greedy
{
    public class KthElement2SortedArrays
    {
        /// <summary>Gets item at specified index in the combined array.</summary>
        /// <param name="array1">The array1.</param>
        /// <param name="array2">The array2.</param>
        /// <param name="k">  Item's index (not 0 based).</param>
        /// <returns>Item at index k in the combined array.</returns>
        private int Get(int[] array1, int[] array2, int k)
        {
            k--;   // Convert item's index to 0-based


            // Optimization: If arrays are in order
            if (array2[0] >= array1[array1.Length - 1])   // If array1 before array2
                return k <= array1.Length - 1
                    ? array1[k]   // If k in array1
                    : array2[k - array1.Length];   // If k in array2

            if (array1[0] >= array2[array2.Length - 1])   // If array1 after array2
                return k <= array2.Length - 1
                    ? array2[k]   // If k in array2
                    : array1[k - array2.Length];   // If k in array1


            int current = -1;   // Current picked item's index
            int last = array1.Length + array2.Length - 1;   // Last item's index in combined array
            int mid = last / 2;

            if (k <= mid)   // If k lies on left of mid
                return GetLeft(0, 0);

            // If k lies on right of mid
            k = last - k;   // k's position from end
            return GetRight(array1.Length - 1, array2.Length - 1);



            int GetLeft(int i, int j)
            {
                // Stop conditions
                if (i == array1.Length) return array2[k - i];   // If array1 finish, get kth item from array2
                if (j == array2.Length) return array1[k - j];   // If array2 finish, get kth item from array1


                // Greedy choices
                if (array1[i] < array2[j]) // array1 < array2
                {
                    if (current == k - 1) return array1[i]; // If k will be reached, return

                    i++;   // array1 item picked, so increase index
                    current++;   // Increase current picked counter
                }
                else if (array1[i] > array2[j]) // array1 > array2
                {
                    if (current == k - 1) return array2[j]; // If k will be reached, return

                    j++;   // array2 item picked, so increase index
                    current++;   // Increase current picked counter
                }
                else   // if (array1[i] == array2[j])             array1 = array2
                {
                    // As 2 items will be picked, check if current is last or 2nd-last item w.r.t k
                    if (current == k - 1 || current == k - 2) return array1[i]; // If k will be reached, return

                    // array1 & array2 items picked, so decrease both
                    i++;
                    j++;
                    current += 2;   // As 2 items picked, increase current picked counter by 2
                }


                return GetLeft(i, j);   // Find next item
            }


            int GetRight(int i, int j)
            {
                // Stop conditions
                if (i == -1) return array2[last - k];   // If array1 below start, get kth item from array2
                if (j == -1) return array1[last - k];   // If array2 below start, get kth item from array1


                // Greedy choices
                if (array1[i] > array2[j])   // array1 > array2   
                {
                    if (current == k - 1) return array1[i];   // If k will be reached, return

                    i--;   // array1 item picked, so decrease index
                    current++;   // Increase current picked counter
                }
                else if (array1[i] < array2[j])   // array1 < array2
                {
                    if (current == k - 1) return array2[j];   // If k will be reached, return

                    j--;   // array2 item picked, so decrease index
                    current++;   // Increase current picked counter
                }
                else   // if (array1[i] == array2[j])              array1 = array2
                {
                    // As 2 items will be picked, check if current is last or 2nd-last item w.r.t k                    
                    if (current == k - 1 || current == k - 2) return array1[i];   // If k will be reached, return

                    // array1 & array2 items picked, so decrease both
                    i--;
                    j--;
                    current += 2;   // As 2 items picked, increase current picked counter by 2
                }


                return GetRight(i, j);   // Find next item
            }
        }



        internal static void Work()
        {
            int[] array1 = { 2, 3, 6, 7, 9 },
                array2 = { 1, 4, 8, 10 };
            int k = 5;
            // Ans: 6

            // Arrays in order
            //int[] array1 = { 1, 3, 4, 6, 7 },
            //    array2 = { 8, 10, 11, 12 };
            //int k = 9;
            // Ans: 11

            //int[] array1 = { 8, 10, 11, 12 },
            //    array2 = { 1, 3, 4, 6, 7 };
            //int k = 9;
            // Ans: 11

            //int[] array1 =
            //    {
            //        3, 4, 11, 14, 15, 15, 16, 18, 22, 23, 24, 24, 26, 27, 28, 28, 35, 36, 39, 41, 41, 41, 42, 43, 43,
            //        44,
            //        45, 45, 47, 48, 48, 53, 54, 55, 55, 56, 56, 60, 61, 61, 61, 63, 65, 66, 68, 69, 70, 72, 72, 73, 73,
            //        74,
            //        74, 76, 76, 79, 81, 81, 81, 83, 86, 90, 91, 92, 92, 95, 99, 100
            //    },
            //    array2 = { 26 };
            //int k = 26;
            // Ans: 43

            //int[] array1 =
            //    {
            //        3, 4, 6, 6, 9, 12, 12, 14, 14, 15, 16, 16, 20, 22, 22, 23, 24, 25, 25, 26, 27, 27, 27, 28, 28, 30,
            //        30,
            //        30, 30, 31, 35, 36, 36, 37, 37, 38, 41, 43, 44, 46, 47, 50, 51, 57, 57, 58, 59, 60, 63, 63, 63, 64,
            //        65,
            //        68, 68, 68, 68, 69, 70, 71, 71, 73, 74, 74, 77, 79, 81, 82, 83, 83, 85, 85, 85, 87, 88, 89, 91, 92,
            //        93,
            //        94, 94, 96, 97, 99
            //    },
            //    array2 =
            //    {
            //        1, 2, 2, 3, 4, 7, 9, 10, 13, 15, 16, 18, 18, 19, 20, 20, 20, 22, 24, 25, 25, 27, 28, 29, 29, 30, 30,
            //        32,
            //        33, 33, 35, 35, 40, 40, 41, 41, 42, 42, 45, 46, 47, 50, 51, 52, 52, 53, 54, 55, 56, 57, 57, 57, 61,
            //        65,
            //        65, 66, 66, 68, 68, 69, 69, 71, 71, 72, 72, 76, 77, 79, 80, 81, 82, 84, 87, 87, 87, 88, 89, 90, 93,
            //        94,
            //        95, 96, 97, 98, 98, 98, 100
            //    };
            //int k = 96;
            // Ans: 57

            //int[] array1 =
            //    {
            //        5, 5, 7, 8, 12, 14, 18, 18, 19, 19, 22, 25, 29, 29, 29, 29, 30, 30, 33, 36, 37, 38, 38, 39, 41, 44,
            //        44,
            //        44, 52, 59, 60, 64, 66, 70, 71, 75, 76, 77, 84, 89, 91, 94, 96, 97
            //    },
            //    array2 =
            //    {
            //        1, 2, 5, 6, 6, 6, 8, 8, 9, 11, 12, 12, 13, 14, 17, 19, 21, 23, 23, 23, 25, 25, 26, 27, 27, 29, 31,
            //        31,
            //        32, 34, 37, 37, 37, 38, 40, 41, 41, 43, 43, 44, 45, 45, 46, 47, 49, 49, 51, 53, 55, 56, 57, 59, 60,
            //        61,
            //        62, 63, 64, 65, 66, 67, 69, 69, 69, 70, 72, 73, 74, 74, 77, 79, 80, 80, 82, 82, 83, 83, 85, 85, 87,
            //        88,
            //        91, 91, 91, 95, 96, 97, 98, 100, 100, 100, 100, 100
            //    };
            //int k = 127;
            //Ans: 96

            //int[] array1 = { 4, 5, 14, 16, 21, 23, 26, 32, 34, 51, 51, 55, 58, 80, 82, 82, 82, 83, 88, 91, 93, 95, 97 },
            //    array2 =
            //    {
            //        7, 9, 9, 10, 11, 11, 11, 12, 15, 16, 16, 17, 19, 21, 22, 22, 23, 26, 26, 26, 27, 28, 29, 29, 29, 31,
            //        33, 33, 35, 37, 38, 38, 40, 40, 44, 50, 51, 52, 52, 54, 55, 56, 58, 58, 61, 61, 63, 64, 67, 70, 71,
            //        72, 77, 77, 77, 78, 78, 82, 83, 83, 83, 84, 84, 84, 86, 86, 87, 88, 89, 89, 91, 91, 91, 93, 94, 96,
            //        98, 98, 98, 99, 100, 100
            //    };
            //int k = 102;
            // Ans: 98

            int element = new KthElement2SortedArrays().Get(array1, array2, k);
            WriteLine(element);
        }
    }
}