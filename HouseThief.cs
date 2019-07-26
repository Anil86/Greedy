using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Greedy
{
    public class HouseThief
    {
        private (Dictionary<int, int> values, int total) MaximizeValue(int[] houses)
        {
            int index = 0;
            Dictionary<int, int> stolenValues = new Dictionary<int, int>(houses.Length / 2 + 1);
            (int value, int i) previousHouse = default;
            (int value, int i)[] housesIndexes = Array.ConvertAll(houses, v => (v, index++));

            Array.Sort(housesIndexes, (h1, h2) => -1 * h1.value.CompareTo(h2.value));

            int stolenValue = MaximizeValue(0);
            return (stolenValues, stolenValue);


            int MaximizeValue(int current)
            {
                if (current == housesIndexes.Length) return 0;


                int currentHouseValue = 0;
                if (current == 0)
                {
                    stolenValues[housesIndexes[0].i] = housesIndexes[0].value;
                    //stolenValues.Add(housesIndexes[0]);
                    previousHouse = housesIndexes[0];
                    currentHouseValue = housesIndexes[0].value;
                    current++;
                }

                bool isAdjacent = Math.Abs(previousHouse.i - housesIndexes[current].i) == 1 ||
                                  stolenValues.ContainsKey(housesIndexes[current].i + 1) ||
                                  stolenValues.ContainsKey(housesIndexes[current].i - 1);
                //stolenValues.Any(h => Math.Abs(h.i - housesIndexes[current].i) == 1);
                if (!isAdjacent)
                {
                    stolenValues[housesIndexes[current].i] = housesIndexes[current].value;
                    //stolenValues.Add(housesIndexes[current]);
                    previousHouse = housesIndexes[current];
                    currentHouseValue += housesIndexes[current].value;
                }

                return currentHouseValue + MaximizeValue(current + 1);
            }
        }



        internal static void Work()
        {
            int[] houses = { 6, 7, 1, 30, 8, 2, 4 };
            //int[] houses = { 20, 5, 1, 13, 6, 11, 40 };

            var (stolenValues, total) = new HouseThief().MaximizeValue(houses);
            foreach ((int _, var value) in stolenValues) Write($"{value:C0}  ");
            WriteLine($"\nTotal: {total}");
        }
    }
}