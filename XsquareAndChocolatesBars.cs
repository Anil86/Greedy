using static System.Console;

namespace Greedy
{
    public class XsquareAndChocolatesBars
    {
        private int CountRemainingCandies(string bar)
        {
            int[] dp = new int[bar.Length + 1];
            int maxGroupsCount = 0;

            CountConsecutiveSets(bar.Length - 3);
            int consecutiveSetsCount = maxGroupsCount;
            return bar.Length - 3 * consecutiveSetsCount;



            void CountConsecutiveSets(int current)
            {
                // Stop condition
                if (current < 0) return;


                // Greedy choice
                // Group w/ unequal pieces: Count 1
                if (bar[current] != bar[current + 1] || bar[current] != bar[current + 2])
                {
                    dp[current] = 1 + dp[current + 3];

                    // Store max no.of groups till current
                    if (dp[current] > maxGroupsCount) maxGroupsCount = dp[current];
                }
                else
                    // Group w/ same pieces: Count 0
                    dp[current] = 0;


                // Find remaining
                CountConsecutiveSets(current - 1);
            }
        }



        internal static void Work()
        {
            //string bar = "CCCCCCCCC";  // Ans: 9
            //string bar = "SSSSCSCCC";  // Ans: 3
            //string bar = "SSCCSSSCS";  // Ans: 0
            //string bar = "CCSSSSC";  // Ans: 1
            string bar = "CCCSCCSSSCSCCSCSSCSCCCSSCCSCCCSCCSSSCCSCCCSCSCCCSSSCCSSSSCSCCCSCSSCSSSCSSSCSCCCSCSCSCSSSCS";  // Ans: 39

            int remainingCandies = new XsquareAndChocolatesBars().CountRemainingCandies(bar);
            WriteLine(remainingCandies);
        }
    }
}