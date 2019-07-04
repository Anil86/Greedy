using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace Greedy
{
    public class CoinChange
    {
        private void CalculateMinCoins(int change, List<Denomination> denominations)
        {
            denominations.Sort((d1, d2) => -1 * d1.Money.CompareTo(d2.Money));   // Sort


            CalculateChange(change);



            void CalculateChange(int change_)
            {
                if (change_ == 0)   // Stop condition
                {
                    var selectedDenominations = denominations
                        .Where(d => d.Count > 0);

                    foreach (var selectedDenomination in selectedDenominations) WriteLine(selectedDenomination);


                    return;
                }


                foreach (var denomination in denominations)
                {
                    if (denomination.Money > change_) continue;   // Find proper denomination

                    change_ -= denomination.Money;   // Balance change
                    denomination.Count++;   // Increase denomination count
                    break;
                }


                CalculateChange(change_);
            }
        }


        internal static void Work()
        {
            var denominations = new List<Denomination>(11)
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



    internal class Denomination
    {
        public Denomination(int money) => Money = money;

        public int Money { get; }
        public int Count { get; set; }


        /// <inheritdoc />
        public override string ToString() => $"{Money} X {Count}";
    }
}