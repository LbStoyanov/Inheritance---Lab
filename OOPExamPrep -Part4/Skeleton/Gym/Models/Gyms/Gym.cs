using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;

        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Athletes = new List<IAthlete>();
            this.Equipment = new List<IEquipment>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }
            

        public double EquipmentWeight
        {
            get { return this.Equipment.Select(e => e.Weight).Sum(); }
        }
           

        public ICollection<IEquipment> Equipment { get; }

        public ICollection<IAthlete> Athletes { get; }

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            Athletes.Add(athlete);
            Capacity--;
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var atlhete in Athletes)
            {
                atlhete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.Name} is a {this.GetType().Name}:");

            if (Athletes.Count == 0)
            {
                result.AppendLine("Athletes: No athletes");
            }
            else
            {
                var listOfAthletes = Athletes.Select(x => x.FullName).ToList();

                result.AppendLine($"Athletes: {string.Join(", ", listOfAthletes)}");
            }



            result.AppendLine($"Equipment total count: {Equipment.Count}");
            result.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return result.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }
    }
}
