using System;

namespace project1
{
    class Calculator
    {
        public static double MyCalculator(double num1, double num2, string op)
        {
            double answer = 0;
            switch (op)
            {
                case "+":
                    answer = num1 + num2;
                    break;
                case "-":
                    answer = num1 - num2;
                    break;
                case "*":
                    answer = num1 * num2;
                    break;
                case "/":
                    answer = num1 / num2;
                    break;
                default:
                    break;
            }
            return answer;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            double firstnum = 0, secondnum = 0, answer = 0;
            string myoperator = "", firstInput, secondInput;
            bool flag1 = false, flag2 = false, flag3 = false;//判断输入是否正常
            while (!flag1)
            {
                Console.WriteLine("请输入第一个操作数:");
                firstInput = Console.ReadLine();
                if (!double.TryParse(firstInput, out firstnum))
                {
                    Console.WriteLine("请输入一个数字！");
                    continue;
                }
                flag1 = true;
            }
            while (!flag2)
            {
                Console.WriteLine("请输入第二个操作数:");
                secondInput = Console.ReadLine();
                if (!double.TryParse(secondInput, out secondnum))
                {
                    Console.WriteLine("请输入一个数字！");
                    continue;
                }
                flag2 = true;
            }
            while (!flag3)
            {
                Console.WriteLine("请输入需要进行的操作(+,-,*,/):");
                myoperator = Console.ReadLine();
                if (myoperator == "+" || myoperator == "-" ||
                    myoperator == "*" || myoperator == "/")
                    flag3 = true;
                else
                    Console.WriteLine("请输入(+,-,*,/)中的一个操作符！");
            }

            try
            {
                answer = Calculator.MyCalculator(firstnum, secondnum, myoperator);
                if (double.IsNaN(answer) || double.IsInfinity(answer))
                {
                    Console.WriteLine("计算遇到问题，检查是否存在例如除数为零的问题。");
                }
                else
                {
                    Console.WriteLine("结果为:{0}", answer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("存在问题:" + e.Message);
            }
        }
    }
}
