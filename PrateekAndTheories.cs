using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Greedy
{
    public class PrateekAndTheories
    {
        private int CalculateMaxPopularity(Theory[] theories, out int popularTime)
        {
            Dictionary<int, int> theoryLogs = new Dictionary<int, int>(2 * theories.Length);

            // Fill
            // Count no.of theories
            // When theory starts, count 1 (increase count)
            // When theory ends, count 0 (decrease count)
            foreach (Theory theory in theories)
            {
                theoryLogs[theory.StartTime] = theoryLogs.GetValueOrDefault(theory.StartTime) + 1;
                theoryLogs[theory.EndTime] = theoryLogs.GetValueOrDefault(theory.EndTime) - 1;
            }


            // Sort
            var orderedTheoryLogs = theoryLogs.OrderBy(kv => kv.Key);
            theoryLogs = new Dictionary<int, int>(orderedTheoryLogs);


            // Find popularity & popular time
            int popularity = 0, maxPopularity = int.MinValue;
            popularTime = default;
            foreach (var kv in theoryLogs)
            {
                popularity += kv.Value;

                if (popularity > maxPopularity)
                {
                    maxPopularity = popularity;
                    popularTime = kv.Key;
                }
            }

            return maxPopularity;
        }



        internal static void Work()
        {
            Theory[] theories =
            {
                new Theory(1, 10),
                new Theory(2, 4),
                new Theory(3, 5),
                new Theory(11, 12),
                new Theory(12, 13)
            };

            int popularity = new PrateekAndTheories().CalculateMaxPopularity(theories, out int popularTime);
            WriteLine($"Popularity: {popularity}\tPopular time: {popularTime}");
        }
    }



    internal struct Theory
    {
        public Theory(int startTime, int endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }


        public int StartTime { get; }
        public int EndTime { get; }
    }
}