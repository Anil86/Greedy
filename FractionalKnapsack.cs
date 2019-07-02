using static System.Console;
using System;
using System.Linq;

namespace Greedy
{
    public class FractionalKnapsack
    {
        private int CalculateMaxValue(Item[] items, int knapCapacity)
        {
            items = items.OrderByDescending(i => i.ValuePerKg).ToArray();


            return CalculateMaxValue_(0, knapCapacity);   // Start w/ 1st (most costly) item



            int CalculateMaxValue_(int i, int knapCap)
            {
                if (knapCap == 0 || i == items.Length) return 0;

                return items[i].Weight <= knapCap   // Check can current item be added fully?
                    ? items[i].Value + CalculateMaxValue_(i + 1, knapCap - items[i].Weight)   // Take full item
                    : (int)Math.Round(knapCap * items[i].ValuePerKg);   // Take partial item
            }
        }



        internal static void Work()
        {
            Item[] items =
            {
                new Item("Item 1", 6, 6),
                new Item("Item 2", 10, 2),
                new Item("Item 3", 3, 1),
                new Item("Item 4", 5,8 ),
                new Item("Item 5", 1,3 ),
                new Item("Item 6", 3,5 )

                //new Item("Item 1", 20, 100),
                //new Item("Item 1", 30, 120),
                //new Item("Item 1", 10, 60)
            };
            //int knapCapacity = 50;
            int knapCapacity = 10;

            int totalValue = new FractionalKnapsack().CalculateMaxValue(items, knapCapacity);
            WriteLine($"Total value = {totalValue}");
        }
    }



    internal struct Item
    {
        internal Item(string name, int weight, int value)
        {
            Name = name;
            Weight = weight;
            Value = value;
            ValuePerKg = (float)Value / (float)Weight;
        }

        public string Name { get; }
        public int Weight { get; }
        public int Value { get; }
        public float ValuePerKg { get; }
    }
}