using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    public class Bus : Vehicle
    {
        private double busFuelConsumptionWithAirCondition = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption,double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            
        }
        public override void Drive(double distance)
        {
            base.FuelConsumption += busFuelConsumptionWithAirCondition;
            base.Drive(distance);
            base.FuelConsumption-= busFuelConsumptionWithAirCondition;

        }
        public void DriveEmpty(double distance)
        {
            base.Drive(distance);
        }
    }
}
