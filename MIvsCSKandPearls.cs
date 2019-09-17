using System;
using static System.Console;

namespace Greedy
{
    public class MIvsCSKandPearls
    {
        private long CalculateMaxProfit(int[] prices, int noOfPearls)
        {
            if (noOfPearls == 0) return 0;

            int[] dp = new int[prices.Length];

            int maxPriceDiff = int.MinValue;
            CalculateMaxPriceDiff(0);

            return (long)noOfPearls * maxPriceDiff;
            


            void CalculateMaxPriceDiff(int buyIndex)
            {
                int consecutiveMaxPriceDiff;

                if (buyIndex == prices.Length - 2)
                {
                    consecutiveMaxPriceDiff = prices[prices.Length - 1] - prices[prices.Length - 2];
                    if (consecutiveMaxPriceDiff > maxPriceDiff) maxPriceDiff = consecutiveMaxPriceDiff;

                    return;
                }

                if (dp[buyIndex + 1] == 0) FindMaxSalePrice(buyIndex + 1);
                int currentMaxProfit = dp[buyIndex + 1] - prices[buyIndex];
                if (dp[buyIndex + 2] == 0) FindMaxSalePrice(buyIndex + 2);
                int nextCurrentMaxProfit = dp[buyIndex + 2] - prices[buyIndex + 1];

                consecutiveMaxPriceDiff = Math.Max(currentMaxProfit, nextCurrentMaxProfit);
                if (consecutiveMaxPriceDiff > maxPriceDiff) maxPriceDiff = consecutiveMaxPriceDiff;

                CalculateMaxPriceDiff(buyIndex + 1);
            }


            int FindMaxSalePrice(int start)
            {
                dp[prices.Length - 1] = prices[prices.Length - 1];

                for (var i = prices.Length - 2; i >= start; i--)
                    dp[i] = prices[i] > dp[i + 1]
                        ? prices[i]
                        : dp[i + 1];

                return dp[start];
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