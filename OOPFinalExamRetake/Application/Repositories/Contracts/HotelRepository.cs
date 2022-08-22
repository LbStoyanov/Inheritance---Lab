using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Hotels.Contacts;

namespace BookingApp.Repositories.Contracts
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotels;

        public HotelRepository()
        {
            this.hotels = new List<IHotel>();
        }
        public void AddNew(IHotel model)
        {
            this.hotels.Add(model);
        }

        public IHotel Select(string criteria)
        {
            return this.hotels.FirstOrDefault(x => x.GetType().Name == criteria);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return this.hotels.AsReadOnly();
        }
    }
}
