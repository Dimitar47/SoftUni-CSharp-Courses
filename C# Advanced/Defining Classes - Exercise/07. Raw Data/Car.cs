using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        
        private Cargo cargo;
        private List<Tires> tires;

        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType,
            double tire1Pressure, int tire1Age,
            double tire2Pressure, int tire2Age,
            double tire3Pressure, int tire3Age,
            double tire4Pressure, int tire4Age
            )
        {
            Model = model;
            Engine = new Engine { Speed = engineSpeed, Power = enginePower };
            Cargo = new Cargo { Weight = cargoWeight, Type = cargoType };
            tires = new List<Tires>()
            {
                new Tires {Age= tire1Age,Pressure = tire1Pressure},
                new Tires {Age= tire2Age,Pressure = tire2Pressure},
                new Tires {Age= tire3Age,Pressure = tire3Pressure},
                new Tires {Age= tire4Age,Pressure = tire4Pressure},
            };
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public Engine Engine { get { return engine; } set { engine = value; } }
        public Cargo Cargo { get { return cargo; } set {  cargo = value; } }
        public List<Tires> Tires { get {return tires; } set { tires = value; } }
    }
}
