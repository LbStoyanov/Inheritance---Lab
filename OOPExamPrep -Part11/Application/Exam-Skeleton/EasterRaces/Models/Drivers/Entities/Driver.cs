using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Drivers.Entities
{
    public  class Driver :IDriver
    {
        private string name;
        private bool carParticipate = false;
        public Driver()
        {
            
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) && value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value,value.Length));
                }

                this.name = value;
            }
        }
        public ICar Car { get; private set; }
        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get { return this.carParticipate; }
        }
       
        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }

            this.Car = car;
            this.carParticipate = true;
        }
    }
}
