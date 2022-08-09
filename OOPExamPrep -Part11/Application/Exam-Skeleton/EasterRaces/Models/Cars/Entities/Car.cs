using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;

        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) && value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, this.model, value.Length));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsePower;
            private set
            {
                if (value < this.minHorsePower && value > this.maxHorsePower)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHorsePower, value.ToString());
                }
            }
        }
        public double CubicCentimeters { get; protected set; }
        public double CalculateRacePoints(int laps)
        {
            return (this.CubicCentimeters / this.horsePower) * laps;
        }
    }
}
