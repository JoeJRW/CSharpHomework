using System;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            int aLength;
            int[] arr;
            int maxNum, minNum, sum;
            double avg;
            try
            {
                Console.WriteLine("请输入需要使用的数组的长度：");
                aLength = Convert.ToInt32(Console.ReadLine());
                arr = new int[aLength];
                for (int i = 0; i < aLength; i++)
                {
                    Console.WriteLine("请输入数组的第" + (i + 1) + "个元素：");
                    arr[i] = Convert.ToInt32(Console.ReadLine());
                }
                GetArrInfo(arr, out maxNum, out minNum, out avg, out sum);
                Console.WriteLine("数组最大元素为：" + maxNum.ToString());
                Console.WriteLine("数组最小元素为：" + minNum.ToString());
                Console.WriteLine("数组元素的平均值为：" + avg.ToString());
                Console.WriteLine("数组元素的和为：" + sum.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("解析错误：" + e.Message);
            }
        }
        static void GetArrInfo(int[] arr, out int maxNum, out int minNum, out double avg, out int sum)
        {
            maxNum = minNum = sum = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > maxNum)
                    maxNum = arr[i];
                if (arr[i] < minNum)
                    minNum = arr[i];
                sum += arr[i];
            }
            avg = (double)sum / arr.Length;
        }
    }
}

