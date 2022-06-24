using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> racers;
        public RacerRepository()
        {
            this.racers = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models { get { return this.racers.AsReadOnly(); } }

        public void Add(IRacer model)
        {
            throw new NotImplementedException();
        }

        public IRacer FindBy(string property)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IRacer model)
        {
            throw new NotImplementedException();
        }
    }
}
