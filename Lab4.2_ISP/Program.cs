using System;
using System.Runtime.InteropServices;


namespace Lab4._2_ISP
{
    class Program
    {
        [DllImport("RectangleCheck.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Perimeter(double a, double b);  
        
        [DllImport("RectangleCheck.dll", CallingConvention = CallingConvention.StdCall)]
        static extern double  Area(double a, double b);

        [DllImport("RectangleCheck.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Diagonal(double a, double b);

        [DllImport("RectangleCheck.dll", CallingConvention = CallingConvention.StdCall)]
        static extern bool SquareCheck(double a, double b);

        [DllImport("RectangleCheck.dll", CallingConvention = CallingConvention.StdCall)]
        static extern double DiagonalAngle(double a, double b);

        [DllImport("RectangleCheck.dll", CallingConvention = CallingConvention.StdCall)]
        static extern bool Rectangle1IsBiggerByPerimeter(double a1, double b1, double a2, double b2);

        [DllImport("RectangleCheck.dll", CallingConvention = CallingConvention.StdCall)]
        static extern bool Rectangle1IsBiggerByArea(double a1, double b1, double a2, double b2);


        static void Main(string[] args)
        {
            double Width1 = 20;
            double hight1 = 25;
            double Width2 = 10;
            double hight2 = 15;


            double P1 = Perimeter(Width1, hight1);
            double A1 = Area(Width1, hight1);
            double P2 = Perimeter(Width2, hight2);
            double A2 = Area(Width2, hight2);
            double D1 = Diagonal(Width1, hight1);
            double D2 = Diagonal(Width2, hight2);
            bool Square_OrNot = SquareCheck(Width1, hight1);
            double diagonalAngle = DiagonalAngle (Width1, hight1);
            bool rectangle1IsBiggerByPerimeter = Rectangle1IsBiggerByPerimeter (Width1, hight1, Width2, hight2);
            bool rectangle1IsBiggerByArea = Rectangle1IsBiggerByArea (Width1, hight1, Width2, hight2);


            Console.WriteLine($"Perimeter of the 1 rectangle - {P1}");
            Console.WriteLine($"Area of the 1 rectangle -  {A1}");
            Console.WriteLine($"Perimeter of the 1 rectangle - {P2}");
            Console.WriteLine($"Area of the 1 rectangle -  {A2}");
            Console.WriteLine($"Diagonal of the 1 rectangle -  {D1}");
            Console.WriteLine($"Diagonal of the 2 rectangle -  {D2}");
            Console.WriteLine($"Rectangle is a square? It's  {Square_OrNot}");
            Console.WriteLine($"diagonalAngle (1) of the rectangle -  {diagonalAngle}");
            Console.WriteLine($"Rectangle 1 is bigger by perimeter? It's {rectangle1IsBiggerByPerimeter}");      
                
            Console.WriteLine($"Rectangle 1 is bigger by area? It's {rectangle1IsBiggerByArea}");      
        }
    }
}
