using static System.Console;
using System;

namespace Greedy
{
    public class BrickInWall
    {
        private double CalculateWorkDone(int[] w, int columns)
        {
            Array.Sort(w, (w1, w2) => -1 * w1.CompareTo(w2));

            int r = w.Length / columns;
            int rows = w.Length % columns == 0 ? r : r + 1;   // Find no.of rows of wall
            int[,] wall = new int[rows, columns];   // Matrix representing wall
            int brickIndex = 0,
                g = 10;   // Acceleration due to gravity
            double work = 0.0;

            for (int i = 0; i < wall.GetLength(0); i++)
                for (int j = 0; j < wall.GetLength(1); j++)
                {
                    wall[i, j] = w[brickIndex++];

                    if (i > 0) work += i * 0.065 * wall[i, j] * g;   // Calculate work from 2nd row

                    if (brickIndex == w.Length) return work;   // Return when all bricks complete
                }

            return work;
        }



        internal static void Work()
        {
            int[] weights = { 100, 10, 150 };
            //int[] weights = { 11, 13, 15, 17, 19, 1, 3, 5, 7, 9 };
            //int[] weights = { 1, 2, 2, 3, 4, 6, 9, 14, 22, 35, 56, 90, 145, 234, 378, 611, 988 };
            //int[] weights =
            //{
            //    21, 15, 5, 9, 5, 7, 9, 11, 11, 11, 20, 3, 8, 21, 8, 10, 19, 15, 6, 5, 18, 6, 8, 17, 18, 12, 1, 10, 19,
            //    5, 14, 16, 9, 15, 3, 5, 4, 5, 3, 6, 19, 1
            //};
            int columns = 2;
            double work = new BrickInWall().CalculateWorkDone(weights, columns);
            WriteLine($"{work:f3}");
        }
    }
}