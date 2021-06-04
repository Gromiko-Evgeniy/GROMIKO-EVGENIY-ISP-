using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_ISP
{

    class BMW : Car, IComparable, IVehicleDocumentation
    {
        public BMW(string _ownerName, string _fyelType, float _fyelQuantity, float _fyelConsumption, float _fuelTankVolume, float _maxSpeed, float _accelerationTimeToMaxSpeed,
            bool _automaticTransmissionType, bool _presenceOfAutopilot, bool _presenceOfConditioner, bool _presenceOfRemoteControl, bool _presenceOfSportCarMode)
        : base(_ownerName, _fyelType, _fyelQuantity, _fyelConsumption, _fuelTankVolume, _maxSpeed, _accelerationTimeToMaxSpeed)
        {
            automaticTransmissionType = _automaticTransmissionType;
            presenceOfAutopilot = _presenceOfAutopilot;
            presenceOfConditioner = _presenceOfConditioner;
            presenceOfRemoteControl = _presenceOfRemoteControl;
            presenceOfSportCarMode = _presenceOfSportCarMode;
            ownerName = _ownerName;


            SeeAllInNewColor += delegate (string newColor)
            {
                switch (newColor)
                {
                    case "red":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "green":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "yellow":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case "blue":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case "white":
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "magenta":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                }
            };
        }

        public delegate void MakeBeautiful(String color);
        public static event MakeBeautiful SeeAllInNewColor;

        public static void RandomColor (string besidesColor)
        {
            Random rand = new Random();
            int temp = rand.Next(1, 7);
            int besidesTemp;

            switch (besidesColor)
            {
                case "red":
                    besidesTemp = 1;
                    break;
                case "green":
                    besidesTemp = 2;
                    break;
                case "yellow":
                    besidesTemp = 3;
                    break;
                case "blue":
                    besidesTemp = 4;
                    break;
                case "white":
                    besidesTemp = 5;
                    break;
                case "magenta":
                    besidesTemp = 6;
                    break;
                default:
                    besidesTemp = temp;
                    break;
            }

            switch (temp)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
            }

            if (besidesTemp == temp)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
        }

        public override uint CarRate()
        {
            uint carRate = 0;
            carRate += Exhaust();
            if (presenceOfConditioner)
            {
                carRate++;
            }
            if (automaticTransmissionType)
            {
                carRate++;
            }
            if (presenceOfAutopilot)
            {
                carRate += 2;
            }
            if (presenceOfRemoteControl)
            {
                carRate += 2;
            }
            if (presenceOfSportCarMode)
            {
                carRate += 2;
            }
            return carRate;
        }

        public override void ShowAllInfo()
        {
            BMW.SeeAllInNewColor("red");
            Console.WriteLine($"your vehicle type is {vehicleType} \n" +
            $"{Assist.outputAssistant1} type is {fyelType} \n" +
            $"{Assist.outputAssistant1} quantity is {fyelQuantity} liters \n");
            BMW.SeeAllInNewColor("green");
            Console.WriteLine($"{Assist.outputAssistant1} consumption is {fyelConsumption} liters/100km \n" +
            $"{Assist.outputAssistant1} tank volume is {fuelTankVolume} liters \n" +
            $"your max. speed is {maxSpeed} km/h \n");
            BMW.SeeAllInNewColor("yellow");
            Console.WriteLine($"{Assist.outputAssistant2}n automatic transmissionType? it's {automaticTransmissionType} \n");
            SeeAllInNewColor += RandomColor;
            SeeAllInNewColor("white");
            Console.WriteLine($"{Assist.outputAssistant2} Conditioner? it's {presenceOfConditioner} \n" +
            $"{Assist.outputAssistant2}n Autopilot? it's {presenceOfAutopilot} \n"+
            $"{Assist.outputAssistant2} sport car mode)? it's {presenceOfSportCarMode} \n" +
            $"{Assist.outputAssistant2} remote control? it's {presenceOfRemoteControl} \n");
        }

        public int CompareTo(object obj)
        {
            if (obj is BMW BMWobj)
            {
                double mySpeed = MaxSpeed;
                double itsSpeed = BMWobj.MaxSpeed;
                if (mySpeed == itsSpeed)
                {
                    return 0;
                }
                else if (mySpeed < itsSpeed)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            throw new NotSupportedException();
        }

        public void ChangeOwner(string newName)
        {
            ownerName = newName;
        }
        public string GetOwner()
        {
            return ownerName;
        } 
        public void PassInspection(string newInspectionDate)
        {
            inspectionDate = newInspectionDate;
        }
        public string GetInspectionDate()
        {
            return inspectionDate;
        }
    }
}