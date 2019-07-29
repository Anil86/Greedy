using System;
using static System.Console;

namespace Greedy
{
    public class AddemUp
    {
        private (int value, int cost) RecycleEfficiently(int[] cards)
        {
            Array.Sort(cards);

            int cost = 0;
            RecycleEfficiently(0, 1);
            int value = cards[cards.Length - 1];   // Last card's value

            return (value, cost);



            void RecycleEfficiently(int previous, int current)
            {
                if (current == cards.Length) return;


                // Replace previous 2 cards w/ new recycled card
                cards[current] = cards[previous] + cards[current];
                cost += cards[current];   // Add new cost to previous cost

                // Sort to place new higher value card in proper position
                Array.Sort(cards, current, cards.Length - current);


                RecycleEfficiently(current, current + 1);   // Recycle remaining cards
            }

        }



        internal static void Work()
        {
            int[] cards = { 1, 4, 3, 4 };
            //int[] cards = { 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            //int[] cards =
            //{
            //    15282, 6674, 93033, 48628, 75335, 61596, 66495, 33570, 15004, 60598, 91072, 79972, 78971, 72325, 15986,
            //    95574, 41770, 39882, 96387, 9413
            //};

            (int value, int cost) = new AddemUp().RecycleEfficiently(cards);
            WriteLine($"Card: {value}\tCost: {cost:C0}");
        }
    }
}