using System;
using System.IO;

namespace Euler13
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var result = new byte[] { 0 };

            Print(result);
            foreach (var number in input)
            {
                var stringNumber = number.TrimStart(' ', '0');                
                var num = new byte[stringNumber.Length];
                for (int i = stringNumber.Length - 1; i >= 0; i--)
                {
                    num[stringNumber.Length - i - 1] = (byte)(stringNumber[i] - 48);
                }

                Console.WriteLine("+");
                Print(num);
                Console.WriteLine("=");

                result = Add(result, num);
                Print(result);
            }

            var answer = new byte[10];
            Array.Copy(result, result.Length - 10, answer, 0, 10);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(new string('=', 52));
            Console.WriteLine(new string('=', 52));
            Console.WriteLine();
            Print(answer);
            Console.WriteLine();
            Console.WriteLine(new string('=', 52));
            Console.WriteLine(new string('=', 52));
            Console.ReadLine();
        }

        private static void Print(byte[] a)
        {
            for (int i = 0; i < 52 - a.Length; i++)
            {
                Console.Write(" ");
            }

            for (int i = a.Length - 1; i >= 0; i--)
            {
                Console.Write(a[i]);
            }
            Console.WriteLine();
        }

        private static byte[] Add(byte[] a, byte[] b)
        {
            if (a.Length < b.Length)
            {
                var tmp = b;
                b = a;
                a = tmp;
            }

            var result = new byte[a.Length + 1];

            byte over = 0;
            for (int i = 0; i < b.Length; i++)
            {
                byte tmp = (byte)(a[i] + b[i] + over);
                var digit = (byte)(tmp % 10);
                over = (byte)(tmp / 10);
                result[i] = digit;
            }

            for (int i = b.Length; i < a.Length; i++)
            {
                byte tmp = (byte)(a[i] + over);
                var digit = (byte)(tmp % 10);
                over = (byte)(tmp / 10);
                result[i] = digit;
            }

            if (over == 0)
            {
                var tmp = new byte[a.Length];
                Array.Copy(result, tmp, a.Length);
                result = tmp;
            }
            else
            {
                result[a.Length] = over;
            }

            return result;
        }
    }
}
