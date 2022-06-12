using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public IFormulaOneCar FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IFormulaOneCar model)
        {
            throw new NotImplementedException();
        }
    }
}
