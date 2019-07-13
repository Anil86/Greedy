using System;
using static System.Console;
using System.Linq;

namespace Greedy
{
    public class CoinChange
    {
        /// <summary>Calculates the minimum coins.</summary>
        /// <param name="change">The change.</param>
        /// <param name="denominations">The denominations.</param>
        private void CalculateMinCoins(int change, Denomination[] denominations)
        {
            // Sort denominations in descending order
            Array.Sort(denominations, (d1, d2) => -1 * d1.Money.CompareTo(d2.Money));


            CalculateChange(change);



            void CalculateChange(int change_)
            {
                if (change_ == 0)   // Stop condition
                {
                    // When full change is given, print coins
                    var selectedDenominations = denominations
                        .Where(d => d.Count > 0);

                    foreach (var selectedDenomination in selectedDenominations) WriteLine(selectedDenomination);


                    return;   // When full change is given, return
                }


                foreach (var denomination in denominations)   // Find proper denomination
                {
                    if (denomination.Money > change_) continue;

                    change_ -= denomination.Money;   // Balance change
                    denomination.Count++;   // Increase denomination count
                    break;
                }


                CalculateChange(change_);   // Find next denomination to give
            }
        }


        internal static void Work()
        {
            Denomination[] denominations =
            {
                new Denomination(1),
                new Denomination(2),
                new Denomination(5),
                new Denomination(10),
                new Denomination(20),
                new Denomination(50),
                new Denomination(100),
                new Denomination(200),
                new Denomination(500),
                new Denomination(1000),
                new Denomination(2000)
            };

            new CoinChange().CalculateMinCoins(2758, denominations);
        }
    }



    /// <summary>Class Denomination.</summary>
    internal class Denomination
    {
        public Denomination(int money) => Money = money;

        public int Money { get; }
        public int Count { get; set; }


        /// <inheritdoc />
        public override string ToString() => $"{Money} X {Count}";
    }
}