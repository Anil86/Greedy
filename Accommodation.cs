using System;
using static System.Console;

namespace Greedy
{
    public class Accommodation
    {
        private long CountAccommodationWaysMemo(int[] floorCapacities, int noOfPeople)
        {
            Array.Sort(floorCapacities);

            return CountAccommodationWays(noOfPeople, 0);



            long CountAccommodationWays(int noOfPeopleLocal, int floor)
            {
                _count++;
                // Solve small sub-problems
                if (noOfPeopleLocal == 0) return 1;
                if (noOfPeopleLocal < 0) return 0;


                // Divide & Combine
                long noOfWays = 0;
                for (var level = floor; level < floorCapacities.Length; level++)
                    noOfWays += CountAccommodationWays(noOfPeopleLocal - floorCapacities[level], level);

                return noOfWays;
            }
        }



        private long CountAccommodationWaysTab(int[] floorCapacities, int noOfPeople)
        {
            Array.Sort(floorCapacities, (n1, n2) => -1 * n1.CompareTo(n2));

            long[,] dp = new long[floorCapacities.Length, noOfPeople + 1];

            int row = floorCapacities.Length;

            for (int currentNoOfPeople = floorCapacities[^1]; currentNoOfPeople <= noOfPeople; currentNoOfPeople++)
            {
                row -= 1;
                if (row < 0) row = 0;

                for (var floor = row; floor < floorCapacities.Length; floor++)
                {
                    int remaining = currentNoOfPeople - floorCapacities[floor];

                    // Solve small sub-problems
                    if (remaining == 0)
                    {
                        dp[floor, currentNoOfPeople] = 1;
                        continue;
                    }


                    // Divide & Combine
                    long levelCount = 0;
                    for (var level = floor; level < floorCapacities.Length; level++)
                    {
                        if (remaining < floorCapacities[level]) continue;

                        levelCount += dp[level, remaining];
                    }

                    dp[floor, currentNoOfPeople] = levelCount;
                }
            }

            long finalCount = 0;
            for (var floor = 0; floor < floorCapacities.Length; floor++) finalCount += dp[floor, noOfPeople];

            return finalCount;
        }


        private static int _count;
        internal static void Work()
        {
            //int noOfPeople = 4;
            //int[] floorCapacities = { 1, 2 };   // Ans: 3   C: 11

            //int noOfPeople = 5;
            //int[] floorCapacities = { 1, 2, 3 };   // Ans: 5   C: 26

            //int noOfPeople = 6;
            //int[] floorCapacities = { 1, 3, 5 };   // Ans: 4   C: 26

            int noOfPeople = 10;
            int[] floorCapacities = { 2, 4, 5, 7, 8 };   // Ans: 5   C: 59

            long accommodationWays = new Accommodation().CountAccommodationWaysMemo(floorCapacities, noOfPeople);
            WriteLine(accommodationWays); WriteLine($"C: {_count}");
        }
    }
}