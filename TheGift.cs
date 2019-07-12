using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Greedy
{
    public class TheGift
    {
        /// <summary>Calculates contributions of people.</summary>
        /// <param name="persons">Persons.</param>
        /// <param name="giftPrice">Gift price.</param>
        /// <returns>Persons w/ their contributions.</returns>
        private IEnumerable<Person> CalculateContributions(Person[] persons, int giftPrice)
        {
            Array.Sort(persons, (p1, p2) => p1.Budget.CompareTo(p2.Budget));   // Sort by budget


            return CalculateContributions(0, giftPrice)
                .OrderBy(p => p.Contribution);



            IEnumerable<Person> CalculateContributions(int i, int gPrice)
            {
                if (gPrice == 0) yield break;   // When all gift price collected, return

                int average = (int) Math.Round((float) gPrice / (persons.Length - i));   // Find average contribution
                persons[i].Contribution = persons[i].Budget < average ? persons[i].Budget : average;   // Calculate contribution

                yield return persons[i];



                gPrice -= persons[i].Contribution;   // Balance gift price
                foreach (var nextPerson in CalculateContributions(i + 1, gPrice))   // Find next person contribution
                    yield return nextPerson;
            }
        }



        internal static void Work()
        {
            Person[] persons =
            {
                new Person {Name = "P 1", Budget = 1},
                new Person {Name = "P 2", Budget = 60},
                new Person {Name = "P 3", Budget = 100}
            };

            var contributions = new TheGift().CalculateContributions(persons, 100);

            foreach (var person in contributions) WriteLine(person);
        }
    }



    internal class Person
    {
        public string Name { get; set; }
        public int Budget { get; set; }
        public int Contribution { get; set; }


        /// <inheritdoc />
        public override string ToString() => $"{Name}: {Contribution:C0} ({Budget:C0})";
    }
}