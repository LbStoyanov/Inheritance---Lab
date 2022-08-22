using System;
using System.Collections.Generic;
using System.Text;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private IRepository<IRoom> roomRepository;
        private IRepository<IBooking> bookingRepository;
        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.roomRepository = new RoomRepository();
            this.bookingRepository = new BookingRepository();
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }
                this.fullName = value;
            }
        }

        public int Category
        {
            get => this.category;
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }
                this.category = value;
            }
        }
        public double Turnover => CalculateTurnOver();

        public IRepository<IRoom> Rooms
        {
            get => this.roomRepository;
            set
            {
                this.roomRepository = value;
            }
        }

        public IRepository<IBooking> Bookings
        {
            get => this.bookingRepository;
            set
            {
                this.bookingRepository = value;
            }
        }

        private double CalculateTurnOver()
        {
            double turnOver = 0.00;

            foreach (var booking in bookingRepository.All())
            {
                var residenceDuration = booking.ResidenceDuration;
                var price = booking.Room.PricePerNight;
                turnOver += residenceDuration * price;
            }
            return Math.Round(turnOver,2);
        }
    }
}
