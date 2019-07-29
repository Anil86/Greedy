using System;
using System.Collections.Generic;
using static System.Console;

namespace Greedy
{
    // Bug: Doesn't work w/ "0" digits
    // ToDo: Using some algorithm pattern (greedy, DC, Dynamic, Backtracking), insert 0 in number
    public class RearrangeStringTo2Nums
    {
        private (long A, long B) SplitDigits(string digitsString)
        {
            int[] digits = Array.ConvertAll(digitsString.ToCharArray(), c => int.Parse(c.ToString()));
            Array.Sort(digits);
            List<int> a = new List<int>(), b = new List<int>();
            long max = (long)Math.Pow(10, 18);


            SplitDigits(0);

            (long aNum, long bNum) = (CreateNumFromDigits(a), CreateNumFromDigits(b));
            return aNum <= max ? (aNum, bNum) : (-1, -1);



            void SplitDigits(int current)
            {
                if (current == digits.Length ||
                    CreateNumFromDigits(a) >= max) return;


                if (a.Count == 0)
                    a.Add(digits[current]);
                else
                {
                    b.Add(digits[current]);

                    while (CreateNumFromDigits(b) > max)
                    {
                        int digitToTransfer = b[0];
                        b.RemoveAt(0);
                        a.Add(digitToTransfer);
                    }
                }


                SplitDigits(current + 1);
            }


            long CreateNumFromDigits(List<int> digitsList)
            {
                if (digitsList.Count == 0) return 0;

                long num = 0, digitsPlace = 1;
                for (int i = digitsList.Count - 1; i >= 0; i--)
                {
                    num += digitsList[i] * digitsPlace;
                    digitsPlace *= 10;
                }

                return num;
            }
        }



        internal static void Work()
        {
            //string digitsString = "92";
            string digitsString = "99";
            //string digitsString = "9967380512";
            //string digitsString = "111122223333444455556666777788889999";
            //string digitsString = "11112222333344445555666677778888999999";

            (long a, long b) = new RearrangeStringTo2Nums().SplitDigits(digitsString);
            WriteLine($"{a} {b}");
        }
    }
}