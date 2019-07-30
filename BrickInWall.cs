using System;
using static System.Console;

namespace Greedy
{
    public class BrickInWall
    {
        private double MinimizeWork(int[] weights, int columns)
        {
            Array.Sort(weights, (w1, w2) => -1 * w1.CompareTo(w2));

            int rows = weights.Length / columns;
            rows = weights.Length % columns != 0 ? rows + 1 : rows;   // Find no.of rows of wall
            int current = columns,   // For 1st row 1st column, current = columns
                g = 10;
            double work = 0.0;

            for (int i = 1; i < rows; i++)   // Start considering weights from 2nd row
                // Continue till current = last brick
                for (int j = 0; j < columns && current < weights.Length; j++, current++)
                    work += i * 0.065 * g * weights[current];

            return work;
        }



        internal static void Work()
        {
            //int[] weights = { 100, 10, 150 };   // Ans: 6.500
            //int[] weights = { 11, 13, 15, 17, 19, 1, 3, 5, 7, 9 };   // Ans: 0.000
            //int[] weights = { 1, 2, 2, 3, 4, 6, 9, 14, 22, 35, 56, 90, 145, 234, 378, 611, 988 };   // Ans: 541.450
            int[] weights =   // Ans: 436.150
            {
                21, 15, 5, 9, 5, 7, 9, 11, 11, 11, 20, 3, 8, 21, 8, 10, 19, 15, 6, 5, 18, 6, 8, 17, 18, 12, 1, 10, 19,
                5, 14, 16, 9, 15, 3, 5, 4, 5, 3, 6, 19, 1
            };
            int columns = 7;

            double work = new BrickInWall().MinimizeWork(weights, columns);
            WriteLine($"{work:f3}");
        }
    }
}