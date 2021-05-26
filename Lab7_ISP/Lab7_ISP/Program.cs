using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction Fract1 = new Fraction(-3,5);
            Fraction Fract2 = new Fraction(4,-5);
            Fraction Fract3 = new Fraction(0, 0);

            Fract3 = Fract1 + Fract2;
            Console.WriteLine("result of addition ="); Fract3.ShowFraction();
            Fract3 = Fract1 - Fract2;
            Console.WriteLine("result of subtraction ="); Fract3.ShowFraction();
            Fract3 = Fract1 * Fract2;
            Console.WriteLine("result of multiplication ="); Fract3.ShowFraction();
            Fract3 = Fract1 / Fract2;
            Console.WriteLine("result of devision ="); Fract3.ShowFraction();

            Console.WriteLine(Fract1.ReturnFractionASString() + " > " + Fract2.ReturnFractionASString() + " is " + (Fract1 > Fract2));
            Console.WriteLine(Fract1.ReturnFractionASString() + " < " + Fract2.ReturnFractionASString() + " is " + (Fract1 < Fract2));
            Console.WriteLine(Fract1.ReturnFractionASString() + " = " + Fract2.ReturnFractionASString() + " is " + (Fract1 == Fract2));
            Console.WriteLine(Fract1.ReturnFractionASString() + " != " + Fract2.ReturnFractionASString() + " is " + (Fract1 != Fract2));

            int num1 = 5;
            Console.WriteLine($"num1 = {num1}");
            Fract1 = num1;
            Console.WriteLine("Fract1 ="); Fract3.ShowFraction();

            int num2 = (int)Fract2;
            Console.WriteLine($"num2 = {num2}");

            string str = "-12/-3";
            int x = Fraction.StringCheck(str);
            Console.WriteLine(x);

            Fraction Fract4 = new Fraction(str);
            Fract4.ShowFraction();
        }
    }
}
