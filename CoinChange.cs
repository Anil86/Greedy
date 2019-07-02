using static System.Console;
using System.Collections.Generic;
using System.Linq;

namespace Greedy
{
    public class CoinChange
    {
        private void CalculateMinCoins(int value)
        {
            if (value == 0)
            {
                var changes = _sortedDenominations
                    .Where(d => d.Count > 0);

                foreach (var change in changes) WriteLine(change);


                return;
            }


            if (!_isSorted)
            {
                _sortedDenominations = _denominations.OrderByDescending(d => d.Money);
                _isSorted = true;
            }

            foreach (var denomination in _sortedDenominations)
            {
                if (denomination.Money > value) continue;   // Find proper denomination

                value -= denomination.Money;   // Subtract proper denomination
                denomination.Count++;   // Increase denomination count
                break;
            }


            CalculateMinCoins(value);
        }


        internal static void Work() => new CoinChange().CalculateMinCoins(2758);


        private readonly List<Denomination> _denominations = new List<Denomination>(11)
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
        private IEnumerable<Denomination> _sortedDenominations;
        private bool _isSorted;
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