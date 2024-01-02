using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        
        private List<IMilitaryUnit> army;
        private List<IWeapon> weapons;
        public Planet(string name, double budget)
        {
            army = new List<IMilitaryUnit>();
            weapons = new List<IWeapon>();
            Name = name;
            Budget = budget;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower => Math.Round(Check(),3);
        
        private double Check()
        {
            double totalAmount = army.Sum(x => x.EnduranceLevel) + weapons.Sum(x => x.DestructionLevel) ;
            if (army.Any(x=>x.GetType() == typeof(AnonymousImpactUnit)))
            {
                totalAmount *=1.3;
            }
           if(weapons.Any(x=>x.GetType() == typeof(NuclearWeapon)))
            {
                totalAmount*=1.45 ;
            }
            return totalAmount;
        }
        public IReadOnlyCollection<IMilitaryUnit> Army => army;

        public IReadOnlyCollection<IWeapon> Weapons => weapons;

        public void AddUnit(IMilitaryUnit unit)
        {
            army.Add(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }
        public void TrainArmy()
        {
            army.ForEach(x => x.IncreaseEndurance());
        }
        public void Spend(double amount)
        {
            if(Budget-amount >= 0)
            {
                Budget -= amount;
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
        }
        public void Profit(double amount)
        {
            Budget += amount;
        }
        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.Append("--Forces: ");
            sb.AppendLine(Army.Count >0 ? string.Join(", ", Army.Select(x=>x.GetType().Name)) : "No units");
            sb.Append("--Combat equipment: ");
            sb.AppendLine(Weapons.Count > 0 ? string.Join(", ", Weapons.Select(x=>x.GetType().Name)) : "No weapons");
            sb.AppendLine($"--Military Power: {MilitaryPower}");
            return sb.ToString().TrimEnd();
        }

        

     

      
    }
}
