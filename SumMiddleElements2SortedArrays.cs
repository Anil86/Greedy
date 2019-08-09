using System;
using static System.Console;

namespace Greedy
{
    public class SumMiddleElements2SortedArrays
    {
        private int SumOfMids(int[] array1, int[] array2)
        {
            int totalLength = 2 * array1.Length,
                mid1Index = totalLength / 2 - 1,
                mid2Index = mid1Index + 1,
                mid1 = 0;

            FindMid(0, 0, 0, ref mid1, out int mid2);

            return mid1 + mid2;



            void FindMid(int current, int i1, int i2, ref int midA, out int midB)
            {
                int min = Math.Min(array1[i1], array2[i2]);

                // Stop condition
                if (current == mid2Index)
                {
                    midB = min;
                    return;
                }


                if (current == mid1Index) midA = min;

                if (min == array1[i1])
                {
                    FindMid(current + 1, i1 + 1, i2, ref midA, out midB);
                    return;
                }

                FindMid(current + 1, i1, i2 + 1, ref midA, out midB);
            }
        }



        internal static void Work()
        {
            int[] array1 = { 1, 2, 4, 6, 10 },
                array2 = { 4, 5, 6, 9, 12 };
            // Ans: 11

            //int[] array1 =
            //    {
            //        1397, 2784, 3922, 9370, 9592, 9660, 9691, 13618, 16539, 16791, 17496, 18000, 19191, 19282, 21357,
            //        22927, 23522, 25972, 26311, 26813, 26901, 28359, 29025, 32056
            //    },
            //    array2 =
            //    {
            //        182, 1157, 1209, 1580, 4143, 4390, 4623, 4767, 5793, 7156, 8009, 8135, 11891, 15901, 21045, 22789,
            //        22837, 23687, 24570, 26571, 26955, 29064, 31267, 31613
            //    };
            // Ans: 34287

            int sum = new SumMiddleElements2SortedArrays().SumOfMids(array1, array2);
            WriteLine(sum);
        }
    }
}