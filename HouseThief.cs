using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Greedy
{
    public class HouseThief
    {
        private (IEnumerable<House> stolenHouses, int value) StealHouses(int[] values)
        {
            House[] houses = new House[values.Length];
            for (int i = 0; i < values.Length; i++) houses[i] = new House($"H{i}", values[i]);
            for (int i = 0; i < houses.Length - 1; i++) houses[i].NextHouse = houses[i + 1];   // Add neighbors


            List<House> stolenHouses = new List<House>(houses.Length / 2 + 1);
            Array.Sort(houses, (h1, h2) => -1 * h1.Value.CompareTo(h2.Value));


            int totalValue = StealHouses(0);


            return (stolenHouses.OrderBy(h => h.Name), totalValue);



            int StealHouses(int current)
            {
                if (current == houses.Length) return 0;


                if (current == 0 ||   // Take 1st house
                    // Check for neighbors
                    stolenHouses.All(h => h.NextHouse != houses[current] &&   // Current house is not neighbor for stolen houses
                                          houses[current].NextHouse != h))   // Current house's neighbor isn't stolen house
                {
                    stolenHouses.Add(houses[current]);
                    return houses[current].Value + StealHouses(current + 1);
                }


                return StealHouses(current + 1);
            }
        }



        internal static void Work()
        {
            int[] houses = { 6, 7, 1, 30, 8, 2, 4 };
            //int[] houses = { 20, 5, 1, 13, 6, 11, 40 };

            (IEnumerable<House> stolenHouses, int totalValue) = new HouseThief().StealHouses(houses);
            foreach (House house in stolenHouses) WriteLine(house);
            WriteLine($"Total Value: {totalValue:C0}");
        }
    }



    internal class House : IEquatable<House>
    {
        public House(string name, int value)
        {
            Name = name;
            Value = value;
        }


        public string Name { get; }
        public int Value { get; }
        public House NextHouse { get; set; }


        #region Equality

        /// <inheritdoc />
        public bool Equals(House other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && Value == other.Value;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((House)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (Name.GetHashCode() * 397) ^ Value;
            }
        }

        public static bool operator ==(House left, House right) => Equals(left, right);

        public static bool operator !=(House left, House right) => !Equals(left, right);

        #endregion


        /// <inheritdoc />
        public override string ToString() => $"{Name}: {Value:C0}";
    }
}