using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_ISP
{
    class Tesla : Car, IComparable, IVehicleDocumentation
    {
        public Tesla (string _ownerName, float _fyelQuantity, float _fyelConsumption, float _fuelTankVolume, float _maxSpeed, float _accelerationTimeToMaxSpeed,
         bool _presenceOfConditioner, bool _presenceOfRemoteControl, bool _presenceOfSportCarMode)
       : base(_ownerName, "electricity", _fyelQuantity, _fyelConsumption, _fuelTankVolume, _maxSpeed, _accelerationTimeToMaxSpeed)
        {
            presenceOfConditioner = _presenceOfConditioner;
            presenceOfRemoteControl = _presenceOfRemoteControl;
            presenceOfSportCarMode = _presenceOfSportCarMode;
            ownerName = _ownerName;
        }

        public override uint CarRate()
        {
            uint carRate = 6;
            if (presenceOfConditioner)
            {
                carRate++;
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
            Console.WriteLine($"your vehicle type is {vehicleType} \n" +
           $"{Assist.outputAssistant1} type is electricity \n" +
           $"{Assist.outputAssistant1} quantity is {fyelQuantity} liters \n" +
           $"{Assist.outputAssistant1} consumption is {fyelConsumption} liters/100km \n" +
           $"{Assist.outputAssistant1} tank volume is {fuelTankVolume} liters \n" +
           $"your max. speed is {maxSpeed} km/h \n" +
           $"{Assist.outputAssistant2}n automatic transmissionType? it's {automaticTransmissionType} \n" +
           $"{Assist.outputAssistant2} Conditioner? it's {presenceOfConditioner} \n" +
           $"{Assist.outputAssistant2}n Autopilot? it's true \n" +
           $"{Assist.outputAssistant2} sport car mode)? it's {presenceOfSportCarMode} \n" +
           $"{Assist.outputAssistant2} remote control? it's {presenceOfRemoteControl} \n");
        }
        public int CompareTo(object obj)
        {
            if (obj is Tesla TeslaObj)
            {
                double mySpeed = MaxSpeed;
                double itsSpeed = TeslaObj.MaxSpeed;
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
        void IVehicleDocumentation.ChangeOwner(string newName)
        {
            ownerName = newName;
        }
        string IVehicleDocumentation.GetOwner()
        {
            return ownerName;
        }
        void IVehicleDocumentation.PassInspection(string newInspectionDate)
        {
            ownerName = newInspectionDate;
        }
        string IVehicleDocumentation.GetInspectionDate()
        {
            return inspectionDate;
        }
    }
}
