using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> cars;

        public FormulaOneCarRepository()
        {
            this.cars = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models { get { return this.cars.AsReadOnly();} }

        public void Add(IFormulaOneCar model)
        {
            cars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            if (cars.Any(c => c.Model == name))
            {
                return cars.FirstOrDefault(c=>c.Model == name);
            }

            return null;
        }

        public bool Remove(IFormulaOneCar model)
        {
            bool result = cars.Remove(model);
            
            return result;
        }
    }
}
