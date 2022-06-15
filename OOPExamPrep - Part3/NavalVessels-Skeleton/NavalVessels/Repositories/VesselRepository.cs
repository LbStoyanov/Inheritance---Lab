using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> vessels;
        public VesselRepository()
        {
            this.vessels = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models { get { return this.vessels.AsReadOnly(); } }

        public void Add(IVessel model)
        {
            vessels.Add(model);
        }

        public IVessel FindByName(string name)
        {
            return vessels.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IVessel model)
        {
            bool result = vessels.Remove(model);

            return result;
        }
    }
}
