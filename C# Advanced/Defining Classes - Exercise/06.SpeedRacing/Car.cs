using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance=0;


        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }
        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }

        }
        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }
        public bool CalculateDistance(double amountOfKm)
        {
            if(FuelAmount - (amountOfKm * FuelConsumptionPerKilometer)>=0)
            {
                FuelAmount-=(amountOfKm*FuelConsumptionPerKilometer);
                TravelledDistance += amountOfKm;
                return true;
            }
            return false;
        }
    }
}
