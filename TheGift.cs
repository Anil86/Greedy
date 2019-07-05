using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Greedy
{
    public class TheGift
    {
        private IEnumerable<Person> DistributeContribution(Person[] persons, int giftPrice)
        {
            Array.Sort(persons, (p1, p2) => p1.Budget.CompareTo(p2.Budget));


            return DistributeContribution_(0, giftPrice)
                .OrderBy(p => p.Contribution);


            IEnumerable<Person> DistributeContribution_(int i, int price)
            {
                if (price == 0) yield break;

                int average = (int)Math.Round((float)price / (float)(persons.Length - i));

                if (persons[i].Budget < average) persons[i].Contribution = persons[i].Budget;
                else persons[i].Contribution = average;

                price -= persons[i].Contribution;
                yield return persons[i];


                foreach (var nextPerson in DistributeContribution_(i + 1, price))
                    yield return nextPerson;
            }
        }



        internal static void Work()
        {
            Person[] persons =
            {
                new Person("P 1", 1),
                new Person("P 2", 60),
                new Person("P 3", 100)
            };


            var contributions = new TheGift().DistributeContribution(persons, 100);

            foreach (var person in contributions) WriteLine(person);
        }
    }



    internal struct Person
    {
        public Person(string name, int budget)
        {
            Name = name;
            Budget = budget;
            Contribution = 0;
        }

        public string Name { get; }
        public int Budget { get; }
        public int Contribution { get; set; }


        /// <inheritdoc />
        public override string ToString() => $"{Name}: Budget: {Contribution:C0} ({Budget:C0})";
    }
}