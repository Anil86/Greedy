using static System.Console;
using System;

namespace Greedy
{
    // Problem: https://www.codingame.com/ide/puzzle/addem-up 

    public class AddemUp
    {
        private (int CardValue, int Charge) CalculateCharge(int[] cards)
        {
            Array.Sort(cards);   // Initial sort


            int cardValue = 0, charge = 0;
            CalculateCharge(0, ref cardValue, ref charge);


            return (cardValue, charge);



            void CalculateCharge(int i, ref int card, ref int chrg)
            {
                if (i == cards.Length - 1) return;   // Return the last card


                card = cards[i + 1] = cards[i] + cards[i + 1];   // Add 2 minimum cards
                chrg += card;   // Update charge
                Array.Sort(cards, i + 1, cards.Length - (i + 1));   // Sort after new (high) card created


                CalculateCharge(i + 1, ref card, ref chrg);
            }
        }



        internal static void Work()
        {
            int[] cards = { 1, 4, 3, 4 };
            //int[] cards = { 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            //int[] cards = { 15282, 6674, 93033, 48628, 75335, 61596, 66495, 33570, 15004, 60598, 91072, 79972, 78971, 72325, 15986, 95574, 41770, 39882, 96387, 9413 };

            var (cardValue, charge) = new AddemUp().CalculateCharge(cards);
            WriteLine($"Card: {cardValue}\t\tCharge: {charge:C0}");
        }
    }
}