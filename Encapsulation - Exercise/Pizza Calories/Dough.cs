using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationExercise
{
    public class Dough
    {
        private readonly Dictionary<string, double> doughModifiers 
            = new Dictionary<string, double> 
        {
            {"white",1.5 },
            {"wholegrain",1.0 },
            {"crispy",0.9 },
            {"chewy",1.1 },
            {"homemade",1.0 },
        };
        private int weight;
        private string backingTechnique;
        private string flourType;
        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.Weight = weight;
            this.BakingTechnique = bakingTechnique;
            this.FlourType = flourType;
        }

        public int Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }
        public string BakingTechnique 
        {
            get { return backingTechnique; }
            private set
            {
                if (!doughModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                backingTechnique = value;
            }
        }
        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (!doughModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }

        public double Calories
            => 2 * this.Weight * doughModifiers[flourType.ToLower()] * doughModifiers[backingTechnique.ToLower()];
    }
}
