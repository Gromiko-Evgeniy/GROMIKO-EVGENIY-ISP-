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
            BMW X5 = new BMW("Vasia", "Petrol", 60, 9, 94 ,230, 14, true, false, true, true, true);
            BMW X6 = new BMW("Petia", "Petrol", 80, 9, 94 ,250, 10, true, false, true, true, true);
            Console.WriteLine($"My subjective assessment of the car is {X6.CarRate()}");
            Console.WriteLine($"You have an {X6.MotorAgeCheck()}");
            X5.ShowAllInfo();

            int compareIndex = X6.CompareTo(X5);
            if (compareIndex == 0)
            {
                Console.WriteLine("the maximum speed is the same \n" + $"compareIndex = {compareIndex}");
            }
            else if (compareIndex == 1)
            {
                Console.WriteLine("bmw X6 is faster \n" + $"compareIndex = { compareIndex}");
            }
            else
            {
                Console.WriteLine("bmw X5 is faster \n" + $"compareIndex = { compareIndex}");
            }

            BMW.SeeAllInNewColor += color => BMW.RandomColor("red");

            X6.ChangeOwner("Kolia");
            Console.WriteLine(X6.GetOwner());
            X6.PassInspection("today");
            Console.WriteLine(X6.GetInspectionDate());
        }
    }
}