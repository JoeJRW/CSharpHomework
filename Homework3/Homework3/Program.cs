using System;

/*1. 编写面向对象程序实现长方形、正方形、三角形等形状的类。
 *   每个形状类都能计算面积、判断形状是否合法。 
 *   请尝试合理使用接口、属性来实现。
 *2. 随机创建10个形状对象，计算这些对象的面积之和。 
 *   尝试使用简单工厂设计模式来创建对象。*/

namespace Homework3
{
    interface IShape
    {
        double CalArea();
        bool IsLegal { get; }
    }

    class Rectangle : IShape
    {
        double Height { get; }
        double Width { get; }
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public double CalArea()
        {
            if (!IsLegal)
                return -1;
            double area = Height * Width;
            return area;           
        }
        public bool IsLegal
        {
            get
            {
                return Height > 0 && Width > 0;                   
            }
        }
    }

    class Square : IShape
    {
        double Side { get; }
        public Square(double side)
        {
            Side = side;
        }
        public double CalArea()
        {
            if (!IsLegal)
                return -1;
            double area = Side * Side;
            return area;
        }
        public bool IsLegal
        {
            get
            {
                return Side > 0;

            }
        }
    }

    class Triangle : IShape
    {
        double Side1 { get; }
        double Side2 { get; }
        double Side3 { get; }
        public Triangle(double side1, double side2, double side3)
        {
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }
        public double CalArea()
        {
            if (!IsLegal)
                return -1;
            double p = (Side1 + Side2 + Side3) / 2;
            double area = Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
            return area;
        }
        public bool IsLegal
        {
            get
            {
                return Side1 > 0 && Side2 > 0 && Side3 > 0
                    && Side1 + Side2 > Side3 && Side2 + Side3 > Side1 && Side1 + Side3 > Side2;
            }
        }
    }

    class ShapeFactory
    {
        //默认各个形状最长边为20
        public static IShape CreateShape(String type)
        {
            IShape myShape = null;
            bool isShape = false;
            while (!isShape)
            {
                switch (type)
                {
                    case "Rectangle":
                        myShape = new Rectangle(CreateRandom.GetRandomDouble(20),
                            CreateRandom.GetRandomDouble(20));
                        break;
                    case "Triangle":
                        myShape = new Triangle(CreateRandom.GetRandomDouble(20),
                            CreateRandom.GetRandomDouble(20), CreateRandom.GetRandomDouble(20));
                        break;
                    case "Square":
                        myShape = new Square(CreateRandom.GetRandomDouble(20));
                        break;
                }
                isShape = myShape.IsLegal;
            }            
            return myShape;
        }
    }

    class CreateRandom
    {
        static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng =
                new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        public static int GetRandomInt(int range)
        {
            Random rdNum = new Random(GetRandomSeed());
            return rdNum.Next(range);
        }

        public static double GetRandomDouble(int range)
        {
            Random rdNum = new Random(GetRandomSeed());
            return rdNum.NextDouble()*range;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int shapeNum = 0;
            double sumArea = 0;//存放形状的和
            Console.WriteLine("请输入想生成的形状数：");
            try
            {
                shapeNum = int.Parse(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine("存在错误：" + e.Message);
            }
            for(int i = 0; i < shapeNum; i++)
            {
                int j = CreateRandom.GetRandomInt(3);
                switch(j)
                {
                    case 0:                      
                        sumArea += ShapeFactory.CreateShape("Rectangle").CalArea();
                        break;
                    case 1:
                        sumArea += ShapeFactory.CreateShape("Triangle").CalArea();
                        break;
                    case 2:
                        sumArea += ShapeFactory.CreateShape("Square").CalArea();
                        break;
                    default:
                        Console.WriteLine("Having trouble when creating shapes");
                        break;
                }
            }
            Console.WriteLine($"已随机生成{shapeNum}个形状，其面积和为{sumArea}。");
        }
    }
}
