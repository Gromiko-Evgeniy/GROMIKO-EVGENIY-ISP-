using System;

namespace Lab3_ISP
{
    class Vehicle
    {
        protected string vehicleType;  //  car/plane/ship
        protected string fyelType;
        protected float fyelConsumption;
        protected float fyelQuantity;
        protected float fuelTankVolume; // max. fyelQuantity
        protected int maxNumberOfPassengers = 1;
        protected float maxSpeed;
        protected float accelerationTimeToMaxSpeed;  // seconds        
        public Vehicle(string _vehicleType, string _fyelType, float _fyelQuantity, float _fyelConsumption, float _fuelTankVolume, float _maxSpeed, float _accelerationTimeToMaxSpeed)
        {
            vehicleType = _vehicleType;
            fyelType = _fyelType;
            fyelQuantity = _fyelQuantity;
            fyelConsumption = _fyelConsumption;
            fuelTankVolume = _fuelTankVolume;
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
        }
        public string FyelType
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
        }
        public float AccelerationTimeToMaxSpeed
        {

            get
            {
                return accelerationTimeToMaxSpeed;
            }
        }

        public float MaxSpeed
        {

            get
            {
                return maxSpeed;
            }
        }

        public float MaxDistanse(float fyelQuantity, float fyelConsumption)
        {
            return (fyelQuantity / fyelConsumption * 100);
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
                Console.WriteLine("you don't have enough fuel for the entire trip, refuel tank at least for " + Math.Abs(fyelQuantity - fyelConsumption * 100 / distance) + " litre(s).");
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


        public string this[string index]
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

}
