using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> pilots;

        public PilotRepository()
        {
            this.pilots = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models { get { return this.pilots.AsReadOnly(); } }

        public void Add(IPilot model)
        {
            throw new NotImplementedException();
        }

        public IPilot FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IPilot model)
        {
            throw new NotImplementedException();
        }
    }
}
