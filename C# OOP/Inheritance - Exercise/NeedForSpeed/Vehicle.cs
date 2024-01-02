using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        private int horsePower;
        private double fuel;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower { get { return horsePower; } set { horsePower = value; } }
        public double Fuel { get { return fuel; } set { fuel = value; } }

        public virtual double FuelConsumption => DefaultFuelConsumption;
        public virtual void Drive(double kilometers) => Fuel -= kilometers * FuelConsumption; 
        

    }
    /*
     
        Create a base class Vehicle. It should contain the following members:
     A constructor that accepts the following parameters: int horsePower, double fuel
     DefaultFuelConsumption – double
     FuelConsumption – virtual double
     Fuel – double
     HorsePower – int
     virtual void Drive(double kilometers)
    o The Drive method should have a functionality to reduce the Fuel based on the traveled
    kilometers.

    */
}
