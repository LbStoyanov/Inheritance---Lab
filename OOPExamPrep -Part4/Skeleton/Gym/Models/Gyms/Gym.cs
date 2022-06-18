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
            throw new NotImplementedException();
        }

        public void AddEquipment(IEquipment equipment)
        {
            throw new NotImplementedException();
        }

        public void Exercise()
        {
            throw new NotImplementedException();
        }

        public string GymInfo()
        {
            throw new NotImplementedException();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            throw new NotImplementedException();
        }
    }
}
