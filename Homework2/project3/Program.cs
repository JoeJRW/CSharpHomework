using System;

namespace Project3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] isPrime = new bool[101];
            Console.Write("100以内质数为：");
            for (int i = 2; i <= 100; i++)
            {
                if (!isPrime[i])
                {
                    Console.WriteLine(i.ToString());
                    for (int j = i * 2; j <= 100; j = j + i)
                    {
                        isPrime[j] = true;
                    }
                }
            }

        }
    }
}
