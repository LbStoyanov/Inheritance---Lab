using System;
using System.Collections.Generic;
using System.Text;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultCount;
        private int childrenCount;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }
        public IRoom Room { get; }

        public int ResidenceDuration
        {
            get => this.residenceDuration;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                this.residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => this.adultCount;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                this.adultCount = value;
            }
        }

        public int ChildrenCount
        {
            get => this.childrenCount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                this.childrenCount = value;
            }
        }
        public int BookingNumber { get; }
        public string BookingSummary()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Booking number: {this.BookingNumber}");
            result.AppendLine($"Room type: {this.Room.GetType().Name}");
            result.AppendLine($"Adults: {this.AdultsCount} Children: {this.ChildrenCount}");
            double totalPaid = Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);
            result.AppendLine($"Total amount paid: {totalPaid:f2}$");

            return result.ToString().TrimEnd();
        }
    }
}
