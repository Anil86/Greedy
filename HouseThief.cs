using static System.Console;
using System;
using System.Collections.Generic;

namespace Greedy
{
    public class HouseThief
    {
        private (Dictionary<int, int> values, int total) MaximizeValue(int[] houses)
        {
            // ToDo: Store adjacency data using 2-D array
            // Store original index prior to sorting
            int index = 0;
            (int value, int i)[] housesIndexes = Array.ConvertAll(houses, v => (v, index++));
            // Dictionary<original index, value> of stolen houses
            Dictionary<int, int> stolenValues = new Dictionary<int, int>(houses.Length / 2 + 1);

            // Sort by descending
            Array.Sort(housesIndexes, (h1, h2) => -1 * h1.value.CompareTo(h2.value));

            int stolenValue = MaximizeValue(0);
            return (stolenValues, stolenValue);


            int MaximizeValue(int current)
            {
                if (current == housesIndexes.Length) return 0;


                if (current == 0 ||   // 1st house
                    !stolenValues.ContainsKey(housesIndexes[current].i - 1) &&   // Check previous index is neighbor
                    !stolenValues.ContainsKey(housesIndexes[current].i + 1))   // Check next index is neighbor
                {
                    stolenValues[housesIndexes[current].i] = housesIndexes[current].value;
                    // Take current house value
                    return housesIndexes[current].value + MaximizeValue(current + 1);
                }

                return MaximizeValue(current + 1);   // Neighbor: Ignore value
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