using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new List<Car>();
        }
        public int Count { get { return cars.Count; } }
        public List<Car> Cars { get { return cars; } set { cars = value; } }
       
     

        public string AddCar(Car car)
        {
           
            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
              
            }
            if (Count ==capacity)
            {
               return "Parking is full!";
              
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            
        }
        public string RemoveCar(string RegistrationNumber)
        {
            if (!cars.Any(x => x.RegistrationNumber == RegistrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.Remove(cars.Where(x=>x.RegistrationNumber==RegistrationNumber).FirstOrDefault());
               return $"Successfully removed {RegistrationNumber}";
            }
        }
        public Car GetCar(string RegistrationNumber)
        {
            return cars.Where(x=>x.RegistrationNumber==RegistrationNumber).First();
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach(var  registrationNumber in RegistrationNumbers)
            {
                if (cars.Any(x => x.RegistrationNumber == registrationNumber))
                {
                    cars.Remove(GetCar(registrationNumber));
                }
            }
        }       

    }
}
