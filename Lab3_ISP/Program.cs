using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_ISP
{
    class Program
    {
        static void Main()
        {
            Car X5 = new BMW("Petrol",40 ,9 ,94 ,240, 9, true, false, true, true, true);
            Console.WriteLine($"My subjective assessment of the car is {X5.CarRate()}");
            Console.WriteLine($"You have an {X5.MotorAgeCheck()}");
            X5.ShowAllInfo();
        }
    }
}