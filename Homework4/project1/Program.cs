using System;
/*
*1、为示例中的泛型链表类添加
*类似于List<T>类的ForEach(Action<T> action)方法。
*通过调用这个方法打印链表元素，
*求最大值、最小值和求和
*（使用lambda表达式实现）。*/

namespace project1
{
    // 链表节点
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }

        public void Foreach(Action<T> action)//新增
        {
            for (Node<T> node = Head; node != null; node = node.Next)
            {
                action(node.Data);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0, max = int.MinValue, min = int.MaxValue;
            GenericList<int> intlist = new GenericList<int>();
            for (int i = 0; i < 10; i++)
            {
                intlist.Add(i);
            }

            intlist.Foreach(x => Console.WriteLine(x.ToString()));
            intlist.Foreach(x => sum += x);
            Console.WriteLine($"Sum={sum}");
            intlist.Foreach(delegate (int x) { max = (max > x) ? max : x; });
            Console.WriteLine($"Max={max}");
            intlist.Foreach(x => min = (min < x) ? min : x);
            Console.WriteLine($"Min={min}");
        }
    }
}
