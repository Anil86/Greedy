using System;
using static System.Console;

namespace Greedy
{
    public class MIvsCSKandPearls
    {
        private long CalculateMaxProfit(int[] prices, int noOfPearls)
        {
            if (noOfPearls == 0) return 0;

            int maxPriceDiff = int.MinValue;
            CalculateMaxPriceDiff(0);

            return noOfPearls * maxPriceDiff;



            void CalculateMaxPriceDiff(int buyIndex)
            {
                int consecutiveMaxPriceDiff;

                if (buyIndex == prices.Length - 2)
                {
                    consecutiveMaxPriceDiff = prices[prices.Length - 1] - prices[prices.Length - 2];
                    if (consecutiveMaxPriceDiff > maxPriceDiff) maxPriceDiff = consecutiveMaxPriceDiff;

                    return;
                }

                int currentMaxProfit = FindMaxSalePrice(buyIndex + 1) - prices[buyIndex];
                int nextCurrentMaxProfit = FindMaxSalePrice(buyIndex + 2) - prices[buyIndex + 1];

                consecutiveMaxPriceDiff = Math.Max(currentMaxProfit, nextCurrentMaxProfit);
                if (consecutiveMaxPriceDiff > maxPriceDiff) maxPriceDiff = consecutiveMaxPriceDiff;

                CalculateMaxPriceDiff(buyIndex + 1);
            }


            int FindMaxSalePrice(int start)
            {
                int maxSalePrice = prices[start];
                for (var i = start + 1; i < prices.Length; i++)
                    if (prices[i] > maxSalePrice)
                        maxSalePrice = prices[i];

                return maxSalePrice;
            }
        }



        internal static void Work()
        {
            int noOfPearls = 2;
            int[] prices = { 8, 97, 7, 66 };

            long maxProfit = new MIvsCSKandPearls().CalculateMaxProfit(prices, noOfPearls);
            WriteLine(maxProfit);
        }
    }
}