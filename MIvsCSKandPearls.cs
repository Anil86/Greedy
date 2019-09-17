using System;
using static System.Console;

namespace Greedy
{
    public class MIvsCSKandPearls
    {
        private long CalculateMaxProfit(int[] prices, int noOfPearls)
        {
            // If no pearls, nothing to buy or sell.
            // So return 0.
            if (noOfPearls == 0) return 0;

            int[] dp = new int[prices.Length];

            int maxPriceDiff = int.MinValue;
            CalculateMaxPriceDiff(0, int.MinValue);   // Calculate max profit from day 1

            return (long)noOfPearls * maxPriceDiff;   // Profit for k pearls



            void CalculateMaxPriceDiff(int buyIndex, int currentMaxProfit)
            {
                int consecutiveMaxPriceDiff;

                // Stop condition
                // If 2nd-last day, buy on 2nd-last day & sell on last day
                if (buyIndex == prices.Length - 2)
                {
                    consecutiveMaxPriceDiff = prices[prices.Length - 1] - prices[prices.Length - 2];
                    if (consecutiveMaxPriceDiff > maxPriceDiff) maxPriceDiff = consecutiveMaxPriceDiff;

                    return;
                }


                // Optimization:
                // Current max profit = previous cycle's next buy day
                // So need to calculate max profit for current day.
                // Only calculate current profit, it's the 1st day
                if (buyIndex == 0)
                {
                    // Find max profit if pearl bought on current day
                    if (dp[buyIndex + 1] == 0) FindMaxSalePrice(buyIndex + 1);
                    currentMaxProfit = dp[buyIndex + 1] - prices[buyIndex];
                }

                // Find max profit if pearl bought on next day
                if (dp[buyIndex + 2] == 0) FindMaxSalePrice(buyIndex + 2);
                int nextCurrentMaxProfit = dp[buyIndex + 2] - prices[buyIndex + 1];


                // Greedy choice:
                // Pick max profit between current & next day
                consecutiveMaxPriceDiff = Math.Max(currentMaxProfit, nextCurrentMaxProfit);
                // Update global max profit
                if (consecutiveMaxPriceDiff > maxPriceDiff) maxPriceDiff = consecutiveMaxPriceDiff;


                // Find max profit for next buying day
                // Next cycle's current = current cycle's next
                // So pass next
                CalculateMaxPriceDiff(buyIndex + 1, nextCurrentMaxProfit);
            }


            int FindMaxSalePrice(int start)
            {
                // Base condition
                // Find max when only 1 item (last)
                dp[prices.Length - 1] = prices[prices.Length - 1];

                // Compare from 2nd-last to start item & find max
                for (var i = prices.Length - 2; i >= start; i--)
                    dp[i] = prices[i] > dp[i + 1]   // If current > succeeding
                        ? prices[i]   // current is max
                        : dp[i + 1];   // else succeeding is max

                return dp[start];   // Return max item from start
            }
        }



        internal static void Work()
        {
            int noOfPearls = 2;
            int[] prices = { 8, 97, 7, 66 };   // Ans: 178

            long maxProfit = new MIvsCSKandPearls().CalculateMaxProfit(prices, noOfPearls);
            // If pearls price don't rise, -ve profit.
            // So return 0.
            if (maxProfit < 0) maxProfit = 0;
            WriteLine(maxProfit);
        }
    }
}