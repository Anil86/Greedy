using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Greedy
{
    public class TheGift
    {
        private IEnumerable<Person> CalculateContributions(Person[] persons, int giftPrice)
        {
            Array.Sort(persons, (p1, p2) => p1.Budget.CompareTo(p2.Budget));   // Sort


            return CalculateContributions(0, giftPrice)
                .OrderBy(p => p.Contribution);



            IEnumerable<Person> CalculateContributions(int personIndex, int gPrice)
            {
                if (gPrice == 0) yield break;

                int average = (int) Math.Round((float) gPrice / (persons.Length - personIndex));
                // Calculate contribution
                persons[personIndex].Contribution =
                    persons[personIndex].Budget < average ? persons[personIndex].Budget : average;

                yield return persons[personIndex];



                gPrice -= persons[personIndex].Contribution;
                foreach (var nextPerson in CalculateContributions(personIndex + 1, gPrice))
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