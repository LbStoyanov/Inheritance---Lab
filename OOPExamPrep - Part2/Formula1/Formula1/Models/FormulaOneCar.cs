﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsePower;
        private double engineDisplacement;

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsePower;
            this.EngineDisplacement = engineDisplacement;
        }
        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1CarModel,value);
                }
                model = value;
            }
        }
        

        public int Horsepower
        {
            get { return horsePower; }
            private set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1HorsePower, value.ToString());
                }
                horsePower = value;
            }
        }

        public double EngineDisplacement
        {
            get { return engineDisplacement; }
            private set
            {
                if (value < 1.6 || value > 2.0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1EngineDisplacement, value.ToString());
                }

                engineDisplacement = value;
            }

        }

        public double RaceScoreCalculator(int laps)
        {
            return (this.engineDisplacement / this.horsePower) * laps;
        }
    }
}
