using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Lab3_ISP
{
    class Vehicle
    {
        protected string vehicleType;  //  car/plane/ship
        protected string fyelType;
        protected float fyelConsumption;
        protected float fyelQuantity;
        protected float fuelTankVolume; // max. fyelQuantity
        protected int numberOfPassengers;
        protected int maxNumberOfPassengers;
        protected float maxSpeed;
        protected float accelerationTimeToMaxSpeed;  // seconds        
       
        public Vehicle(string _vehicleType, string _fyelType, float _fyelQuantity, float _fyelConsumption, float _fuelTankVolume, int _numberOfPassengers, int _maxNumberOfPassengers, float _maxSpeed, float _accelerationTimeToMaxSpeed)
        {
            vehicleType = _vehicleType;
            fyelType = _fyelType;
            fyelQuantity = _fyelQuantity;
            fyelConsumption = _fyelConsumption;
            fuelTankVolume = _fuelTankVolume;
            numberOfPassengers = _numberOfPassengers;
            maxNumberOfPassengers = _maxNumberOfPassengers;
            maxSpeed = _maxSpeed;
            accelerationTimeToMaxSpeed = _accelerationTimeToMaxSpeed;
        }

        public float FyelQuantity
        {
            set
            {
                if (value > fuelTankVolume)
                {
                    Console.WriteLine("fyel quantity should be less than fuel tank volume");
                }
                else
                {
                    fyelQuantity = value;
                }
            }
            get
            {
                return fyelQuantity;
            }
        }

        public string VehicleType
        {
           
            get
            {
                return vehicleType;
            }
        } public string FyelType
        {
           
            get
            {
                return fyelType;
            }
        } 
        public float FyelConsumption
        {
           
            get
            {
                return fyelConsumption;
            }
        } 
        public float FuelTankVolume
        {
           
            get
            {
                return fuelTankVolume;
            }
        } public float AccelerationTimeToMaxSpeed
        {
           
            get
            {
                return accelerationTimeToMaxSpeed ;
            }
        }
        public int NumberOfPassengers
        {
            set
            {
                if (value > maxNumberOfPassengers)
                {
                    Console.WriteLine("The number of passengers has been exceeded. " + maxNumberOfPassengers + "is maximum" );
                }
                else
                {
                    numberOfPassengers = value;
                }
            }
            get
            {
                return numberOfPassengers;
            }
        }
        public float MaxSpeed
        {
           
            get
            {
                return maxSpeed;
            }
        }

        public void ShowAllInfo()
        {
            Console.WriteLine($"your vehicle type is {vehicleType}\n" +
                $"your fyel type is {fyelType}\n" +
                $"your fyel quantity is {fyelQuantity} liters \n" +
                $"your fyel consumption is {fyelConsumption} liters/100km \n" +
                $"your fyel tank volume is {fuelTankVolume} liters \n" +
                $"your number of passengers is {numberOfPassengers}\n" +
                $"your max. speed is {maxSpeed} km/h\n" +
                $"your acceleration time to max speed is {accelerationTimeToMaxSpeed} seconds \n");
        }

        public void ChangeMotor (string newFyelType, float newFyelConsumption, float newMaxSpeed, float newAccelerationTimeToMaxSpeed)
        {
            fyelType = newFyelType;
            fyelConsumption = newFyelConsumption;
            maxSpeed = newMaxSpeed;
            accelerationTimeToMaxSpeed = newAccelerationTimeToMaxSpeed;
        }

        public float MaxDistanse (float fyelQuantity, float fyelConsumption)
        {
           return(fyelQuantity / fyelConsumption*100);
        }


        public void RefuelCheck(float distance)
        {
            if (fyelQuantity - fyelConsumption * 100 / distance > 0)
            {
                fyelQuantity = fyelQuantity - fyelConsumption * 100 / distance;
                Console.WriteLine("you don't need to refuel");
            }
            else if (fyelQuantity - fyelConsumption * 100 / distance == 0)
            {
                fyelQuantity = 0;
                Console.WriteLine("you don't need to refuel now, but you will have no fuel in the end of the trip.");
            }
            else if (fyelQuantity - fyelConsumption * 100 / distance < 0)
            {
                Console.WriteLine("you don't have enough fuel for the entire trip, refuel tank at least for " + Math.Abs(fyelQuantity - fyelConsumption * 100 / distance) +  " litre(s).");
            }
        }

        public void Refuelation()
        {
            fyelQuantity = fuelTankVolume;
        }

        public void Refuelation(float addFuel)
        {
            fyelQuantity += addFuel;
        }

        public void Race(Vehicle vehicle, float distance)
        {
            if (maxSpeed > vehicle.maxSpeed && accelerationTimeToMaxSpeed > vehicle.accelerationTimeToMaxSpeed)
            {
                Console.WriteLine("the first vehicle heve won the race");
            }
            else if (maxSpeed < vehicle.maxSpeed && accelerationTimeToMaxSpeed < vehicle.accelerationTimeToMaxSpeed)
            {
                Console.WriteLine($" {vehicle.vehicleType} heve won the race");
            }
            else if (distance / maxSpeed * 360 + accelerationTimeToMaxSpeed < distance / vehicle.maxSpeed * 360 + vehicle.accelerationTimeToMaxSpeed)
            {
                Console.WriteLine("the first vehicle heve won the race");
            }
            else if (distance / maxSpeed * 360 + accelerationTimeToMaxSpeed > distance / vehicle.maxSpeed * 360 + vehicle.accelerationTimeToMaxSpeed)
            {
                Console.WriteLine("the second vehicle heve won the race");
            }
        } 


        public  string this [string index]
        {
            get
            {
                switch (index)
                {
                    case "vehicle type":
                        return vehicleType;
                       
                    case "fyel type":
                        return fyelType;
                    default:
                        return "wrong index";
                }
            }
        }
    } 

    class Program
    {
        static void Main()
        {
            Vehicle Car = new Vehicle("car", "petrol", 5, 6, 55, 4, 4, 100, 7);
            Vehicle Plane = new Vehicle("plane", "petrol", 1000, 30, 1500, 100, 120, 1500, 30);
            //Car.ShowAllInfo();
            //Car.Race(Plane, 1);
            Car.FyelQuantity = 56;
            Console.WriteLine(Car.FyelQuantity);
         }
    }
}
