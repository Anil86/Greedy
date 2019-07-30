using System;
using System.Linq;
using static System.Console;

namespace Greedy
{
    class Player
    {
        static void SendUnit(string[] args)
        {
            int L = int.Parse(Console.ReadLine()); // Size of forest map
            int water = int.Parse(Console.ReadLine()); // Total amount of water available

            // game loop
            while (true)
            {
                int N = int.Parse(Console.ReadLine()); // Amount of fires
                FireCoordinate[] fireCoordinates = new FireCoordinate[N];
                for (int i = 0; i < N; i++)
                {
                    string[] inputs = Console.ReadLine().Split(' ');
                    int fireX = int.Parse(inputs[0]); // X coordinate of fire
                    int fireY = int.Parse(inputs[1]); // Y coordinate of fire
                    fireCoordinates[i] = new FireCoordinate(fireX, fireY);
                }

                if (N > 4)
                {
                    char unit = 'C';
                    FireCoordinate topCoord = FindTopLeftCoordinate(fireCoordinates);
                    WriteLine($"{unit} {topCoord.X} {topCoord.Y}");
                }
                else if (N > 1)
                {
                    char unit = 'H';
                    FireCoordinate topCoord = FindTopLeftCoordinate(fireCoordinates);
                    WriteLine($"{unit} {topCoord.X} {topCoord.Y}");
                }
                else
                {
                    char unit = 'J';
                    FireCoordinate topCoord = fireCoordinates[0];
                    WriteLine($"{unit} {topCoord.X} {topCoord.Y}");
                }
            }
        }


        private static FireCoordinate FindTopLeftCoordinate(FireCoordinate[] fireCoordinates)
        {
            int topX = fireCoordinates.Aggregate(21, (xPrev, coord) => Math.Min(xPrev, coord.X));
            int topY = fireCoordinates.Aggregate(21, (yPrev, coord) => Math.Min(yPrev, coord.Y));
            return new FireCoordinate(topX, topY);
        }
    }



    internal struct FireCoordinate
    {
        public FireCoordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
    }
}