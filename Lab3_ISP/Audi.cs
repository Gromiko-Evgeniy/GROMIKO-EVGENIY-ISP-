using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_ISP
{
    class Audi : Car
    {
        public Audi(string _fyelType, float _fyelQuantity, float _fyelConsumption, float _fuelTankVolume, float _maxSpeed, float _accelerationTimeToMaxSpeed,
        bool _automaticTransmissionType, bool _presenceOfAutopilot, bool _presenceOfConditioner, bool _presenceOfRemoteControl, bool _presenceOfSportCarMode)
       : base(_fyelType, _fyelQuantity, _fyelConsumption, _fuelTankVolume, _maxSpeed, _accelerationTimeToMaxSpeed)
        {
            automaticTransmissionType = _automaticTransmissionType;
            presenceOfAutopilot = _presenceOfAutopilot;
            presenceOfConditioner = _presenceOfConditioner;
            presenceOfRemoteControl = _presenceOfRemoteControl;
            presenceOfSportCarMode = _presenceOfSportCarMode;
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
            $"{Assist.outputAssistant2}n automatic transmissionType? it's {automaticTransmissionType} \n" +
            $"{Assist.outputAssistant2} Conditioner? it's {presenceOfConditioner} \n" +
            $"{Assist.outputAssistant2}n Autopilot? it's {presenceOfAutopilot} \n" +
            $"{Assist.outputAssistant2} sport car mode)? it's {presenceOfSportCarMode} \n" +
            $"{Assist.outputAssistant2} remote control? it's {presenceOfRemoteControl} \n");
        }
    }
}
