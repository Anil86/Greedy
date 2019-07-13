using static System.Console;
using System;

namespace Greedy
{
    public class FractionalKnapsack
    {
        /// <summary>Calculates maximum value that can be filled in knapsack.</summary>
        /// <param name="items">The items.</param>
        /// <param name="knapCapacity">Knapsack capacity.</param>
        /// <returns>Maximum value that can be filled in knapsack.</returns>
        private int CalculateMaxValue(Item[] items, int knapCapacity)
        {
            // Sort based on cost/kg in descending order
            Array.Sort(items, (i1, i2) => -1 * i1.ValuePerKg.CompareTo(i2.ValuePerKg));


            return FindMaxItem(0, knapCapacity);   // Start w/ 1st (most costly) item



            int FindMaxItem(int i, int knapCap)
            {
                if (knapCap == 0 || i == items.Length) return 0;


                if (items[i].Weight <= knapCap)   // Check can current item be added fully?
                {
                    WriteLine(items[i]);   // Print full item

                    knapCap -= items[i].Weight;   // Remaining capacity
                    return items[i].Value + FindMaxItem(i + 1, knapCap);   // Add next item
                }

                // Find partial item quantity & value
                int weight = knapCap,   // Remaining capacity = item's partial weight
                    value = (int)Math.Round(items[i].ValuePerKg * weight);   // Partial weight value
                WriteLine($"{items[i].Name}: {weight} Kg, {value:C0}");   // Print partial item
                return value;
            }
        }



        internal static void Work()
        {
            Item[] items =
            {
                new Item("Item 1", 6, 6),
                new Item("Item 2", 10, 2),
                new Item("Item 3", 3, 1),
                new Item("Item 4", 5, 8),
                new Item("Item 5", 1, 3),
                new Item("Item 6", 3, 5)

                //new Item("Item 1", 20, 100),
                //new Item("Item 2", 30, 120),
                //new Item("Item 3", 10, 60)
            };
            //int knapCapacity = 50;
            int knapCapacity = 10;

            int totalValue = new FractionalKnapsack().CalculateMaxValue(items, knapCapacity);
            WriteLine($"Total value = {totalValue}");
        }
    }



    /// <summary>Struct Item</summary>
    internal struct Item
    {
        /// <summary>Initializes a new instance of the <see cref="T:Greedy.Item"/> struct.</summary>
        /// <param name="name">The name.</param>
        /// <param name="weight">The weight.</param>
        /// <param name="value">The value.</param>
        internal Item(string name, int weight, int value)
        {
            Name = name;
            Weight = weight;
            Value = value;
            ValuePerKg = (float)Value / Weight;   // cost/kg
        }

        public string Name { get; }
        public int Weight { get; }
        public int Value { get; }
        public float ValuePerKg { get; }


        /// <inheritdoc />
        public override string ToString() => $"{Name}: {Weight} Kg, {Value:C0}";
    }
}