using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_ISP
{

    class BMW : Car, IComparable, IVehicleDocumentation
    {
        public BMW (string _ownerName, string _fyelType, float _fyelQuantity, float _fyelConsumption, float _fuelTankVolume, float _maxSpeed, float _accelerationTimeToMaxSpeed,
            bool _automaticTransmissionType, bool _presenceOfAutopilot, bool _presenceOfConditioner, bool _presenceOfRemoteControl, bool _presenceOfSportCarMode)
        : base(_ownerName, _fyelType, _fyelQuantity, _fyelConsumption, _fuelTankVolume, _maxSpeed, _accelerationTimeToMaxSpeed) 
        {
            automaticTransmissionType = _automaticTransmissionType;
            presenceOfAutopilot = _presenceOfAutopilot;
            presenceOfConditioner = _presenceOfConditioner;
            presenceOfRemoteControl = _presenceOfRemoteControl;
            presenceOfSportCarMode = _presenceOfSportCarMode;
            ownerName = _ownerName;
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
            Console.WriteLine($"your vehicle type is {vehicleType} \n" +
            $"{Assist.outputAssistant1} type is {fyelType} \n" +
            $"{Assist.outputAssistant1} quantity is {fyelQuantity} liters \n" +
            $"{Assist.outputAssistant1} consumption is {fyelConsumption} liters/100km \n" +
            $"{Assist.outputAssistant1} tank volume is {fuelTankVolume} liters \n" +
            $"your max. speed is {maxSpeed} km/h \n" +
            $"{Assist.outputAssistant2}n automatic transmissionType? it's {automaticTransmissionType} \n"+
            $"{Assist.outputAssistant2} Conditioner? it's {presenceOfConditioner} \n"+
            $"{Assist.outputAssistant2}n Autopilot? it's {presenceOfAutopilot} \n"+
            $"{Assist.outputAssistant2} sport car mode)? it's {presenceOfSportCarMode} \n"+
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

        //static void Documentation(IVehicleDocumentation ObjectDocumentation, string documentationActon, string iformation)
        //{
        //    if (documentationActon == "ChangeOwner")
        //    {
        //        ObjectDocumentation.ChangeOwner(iformation);
        //    }
        //    else
        //    {
        //        ObjectDocumentation.PassInspection(iformation);
        //    }
        //}

        //static void Documentation(IVehicleDocumentation ObjectDocumentation, string documentationActon)
        //{
        //    if (documentationActon == "GetOwner")
        //    {
        //        ObjectDocumentation.GetOwner();
        //    }
        //    else
        //    {
        //        ObjectDocumentation.GetInspectionDate();
        //    }
        //}
    }
}