using System;
using System.Linq;
using static System.Console;

namespace Greedy
{
    public class ForestFire
    {
        private (char unit, int topX, int topY) SendUnit((int x, int y)[] fireCoordinates)
        {
            int noOfFires = fireCoordinates.Length;
            switch (noOfFires)
            {
                case int n when n > 4:
                    {
                        char unit = 'C';
                        (int topX, int topY) = FindTopLeftCoordinate();
                        return (unit, topX, topY);
                    }
                case int n when n > 1:
                    {
                        char unit = 'H';
                        (int topX, int topY) = FindTopLeftCoordinate();
                        return (unit, topX, topY);
                    }
                default:
                    {
                        char unit = 'J';
                        (int topX, int topY) = (fireCoordinates[0].x, fireCoordinates[0].y);
                        return (unit, topX, topY);
                    }
            }



            (int topX, int topY) FindTopLeftCoordinate()
            {
                int topX = fireCoordinates.Aggregate(21, (xPrev, coord) => Math.Min(xPrev, coord.x));
                int topY = fireCoordinates.Aggregate(21, (yPrev, coord) => Math.Min(yPrev, coord.y));
                return (topX, topY);
            }
        }



        internal static void Work()
        {
            //(int x, int y)[] fireCoordinates = { (1, 3), (1, 4), (2, 2), (2, 3), (3, 2), (3, 3) };
            //(int x, int y)[] fireCoordinates = { (4, 4), (4, 5), (5, 5) };
            (int x, int y)[] fireCoordinates = { (5, 0) };

            (char unit, int topX, int topY) = new ForestFire().SendUnit(fireCoordinates);
            WriteLine($"{unit} {topX} {topY}");
        }
    }
}