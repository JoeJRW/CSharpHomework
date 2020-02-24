using System;

namespace project1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            while (!endApp)
            {
                Console.WriteLine("输入一个数字：");
                try
                {
                    long testNum = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("这个数字的所有素数因子为" + getFactor(testNum));
                }
                catch (Exception e)
                {
                    Console.WriteLine("解析错误：" + e.Message);
                }
                Console.WriteLine("输入字母n退出程序，按任意键再次计算。");
                if (Console.ReadLine() == "n")
                    endApp = true;

                Console.WriteLine("\n");
            }

            string getFactor(long num)
            {
                string answer = "";
                for (int i = 2; i * i <= num; i++)
                {
                    while (true)
                    {
                        if (num % i == 0)
                        {
                            answer = answer + i.ToString() + " ";
                            num /= i;
                        }
                        else
                            break;
                    }
                }
                if (num != 1)
                    answer = answer + num.ToString() + " ";
                return answer;
            }

        }
    }
}

