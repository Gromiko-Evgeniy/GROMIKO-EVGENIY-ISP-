using System;
namespace Lab3_ISP
{
    abstract class Car : Vehicle
    {
        protected struct OutputAssistant
        {
            public string outputAssistant1;
            public string outputAssistant2;
            public string outputAssistant3;
        }

        protected OutputAssistant Assist = new OutputAssistant();

        public Car(string _ownerName, string _fyelType, float _fyelQuantity, float _fyelConsumption, float _fuelTankVolume, float _maxSpeed, float _accelerationTimeToMaxSpeed)
            : base("Car", _fyelType, _fyelQuantity, _fyelConsumption, _fuelTankVolume, _maxSpeed, _accelerationTimeToMaxSpeed)
        {
            Assist.outputAssistant1 = "your fyel ";
            Assist.outputAssistant2 = "Is there a";
            Assist.outputAssistant3 = "Something's wrong";
        }

        protected bool automaticTransmissionType; // car part
        protected bool presenceOfAutopilot;
        protected bool presenceOfConditioner;
        protected bool presenceOfRemoteControl;
        protected bool presenceOfSportCarMode;
        protected string ownerName;
        protected string inspectionDate = "long time ago";



        public enum MotorAge
        {
            newMotor = 1,
            oldMotor
        }

        public MotorAge motorAge = MotorAge.oldMotor;

        public void ChangeMotor(string newFyelType, float newFyelConsumption, float newMaxSpeed, float newAccelerationTimeToMaxSpeed)
        {
            fyelType = newFyelType;
            fyelConsumption = newFyelConsumption;
            maxSpeed = newMaxSpeed;
            accelerationTimeToMaxSpeed = newAccelerationTimeToMaxSpeed;
            motorAge = MotorAge.newMotor;
        }

        public MotorAge MotorAgeCheck()
        {
            return motorAge;
        }

        public uint Exhaust()
        {
            if (fyelType == "Electricity")
            {
                return 3;
            }
            else if (fyelType == "Gas")
            {
                return (uint)(3 - fyelConsumption / 10);
            }
            else if (fyelType == "Diesel")
            {
                return (uint)(2 - fyelConsumption / 10);
            }
            else if (fyelType == "Petrol")
            {
                return (uint)(2 - fyelConsumption / 10);
            }
            else
            {
                return 0;
            }
        }
        public abstract uint CarRate();

        public virtual void ShowAllInfo()
        {
            Console.WriteLine($"your vehicle type is {vehicleType}\n" +
            $"your fyel type is {fyelType}\n" +
            $"your fyel quantity is {fyelQuantity} liters \n" +
            $"your fyel consumption is {fyelConsumption} liters/100km \n" +
            $"your fyel tank volume is {fuelTankVolume} liters \n" +
            $"your max. speed is {maxSpeed} km/h\n" +
            $"your acceleration time to max speed is {accelerationTimeToMaxSpeed} seconds \n");
        }
    }
}