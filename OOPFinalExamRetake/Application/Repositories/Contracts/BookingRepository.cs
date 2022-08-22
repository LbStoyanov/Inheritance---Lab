using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Bookings.Contracts;

namespace BookingApp.Repositories.Contracts
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly List<IBooking> bookings;

        public BookingRepository()
        {
            this.bookings = new List<IBooking>();
        }
        public void AddNew(IBooking model)
        {
            this.bookings.Add(model);
        }

        public IBooking Select(string criteria)
        {
            return this.bookings.FirstOrDefault(x => x.GetType().Name == criteria);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return this.bookings.AsReadOnly();
        }
    }
}
