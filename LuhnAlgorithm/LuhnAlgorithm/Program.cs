using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuhnAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string cardNumber = string.Empty;

            while (cardNumber.ToUpper() != "QUIT")
            {
                try
                {
                    Console.Write("Enter credit card number (or quit, to exit) > ");

                    cardNumber = Console.ReadLine().Trim();

                    Console.WriteLine($"Is valid? {IsValidCardNumber(cardNumber)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\r\n" + ex.Message);
                }

            }
        }

        static bool IsValidCardNumber(string number)
        {
            bool even = true;
            int check = 0;
            char[] digits = number.ToCharArray();

            for (int idx = digits.Length - 2; idx >= 0; idx--)
            {
                if (even)
                {
                    int value = 2 * int.Parse(digits[idx].ToString());

                    value = (value > 9) ? (value - 9) : value;
                    check += value;
                }
                else
                {
                    check += int.Parse(digits[idx].ToString());
                }
                even = !even;
            }

            check = (check * 9) % 10;

            return (check == int.Parse(digits[digits.Length - 1].ToString()));
        }
    }
}
