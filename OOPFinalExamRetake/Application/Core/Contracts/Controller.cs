using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Core.Contracts
{
    public class Controller : IController
    {
        private HotelRepository hotelRepository;
        

        public Controller()
        {
            this.hotelRepository = new HotelRepository();
            
        }
        public string AddHotel(string hotelName, int category)
        {
            if (IsHotelExist(hotelName))
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            IHotel hotel = new Hotel(hotelName, category);
            this.hotelRepository.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered,category,hotelName);

        }

       

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (!IsHotelExist(hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != "Studio" && roomTypeName != "Apartment" && roomTypeName != "DoubleBed")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = null;

            if (roomTypeName == "Studio")
            {
                room = new Studio();
            }
            else if (roomTypeName == "Apartment")
            {
                room = new Apartment();
            }
            else
            {
                room = new DoubleBed();
            }


            IHotel hotel = this.hotelRepository.All().FirstOrDefault(x => x.FullName == hotelName);

            if (hotel.Rooms.All() != null && hotel.Rooms.All().Any(x => x.GetType().Name == roomTypeName))
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }
           
            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);


        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (!IsHotelExist(hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != "Studio" && roomTypeName != "Apartment" && roomTypeName != "DoubleBed")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IHotel hotel = this.hotelRepository.All().FirstOrDefault(x => x.FullName == hotelName);

            IRoom room = hotel.Rooms.Select(roomTypeName);

            if (hotel.Rooms.All().All(x => x.GetType().Name != roomTypeName))
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            if (room.PricePerNight > 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);

        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            
            if (this.hotelRepository.All().All(x => x.Category != category))
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            var orderedHotels = this.hotelRepository.All().Where(c => c.Category == category).OrderBy(x => x.FullName);
            var availableRooms = new List<IRoom>();
            foreach (var currHotel in orderedHotels)
            {
                foreach (var room in currHotel.Rooms.All())
                {
                    if (room.PricePerNight > 0)
                    {
                        availableRooms.Add(room);
                    }
                }
            }

            var orderedRooms = availableRooms.OrderBy(x => x.BedCapacity);

            var selectedRoom = orderedRooms.Min();
        

            if (selectedRoom == null)
            {
                return string.Format(OutputMessages.RoomNotAppropriate);
            }

            IHotel hotel = this.hotelRepository.All().FirstOrDefault(x => x.Category == category);

            int bookingNumber = hotel.Bookings.All().Count + 1;

            IBooking booking = new Booking(selectedRoom, duration, adults, children, bookingNumber);


            hotel.Bookings.AddNew(booking);



            return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);

        }

        public string HotelReport(string hotelName)
        {
            if (!IsHotelExist(hotelName))
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            IHotel hotel = this.hotelRepository.All().FirstOrDefault(x => x.FullName == hotelName);

            StringBuilder result = new StringBuilder();
            result.AppendLine($"Hotel name: {hotelName}");
            result.AppendLine($"--{hotel!.Category} star hotel");
            result.AppendLine($"--Turnover: {hotel.Turnover} $");
            result.AppendLine($"--Bookings:");
            result.AppendLine(Environment.NewLine);
        
            if (hotel.Bookings.All().Count == 0)
            {
                result.AppendLine($"none");
            }
            else
            {
                foreach (var booking in hotel.Bookings.All())
                {
                    result.AppendLine(booking.BookingSummary());
                    
                }
            }

            return result.ToString().TrimEnd();
        }

        private bool IsHotelExist(string hotelName)
        {
            if (this.hotelRepository.All().Any(x => x.FullName == hotelName))
            {
                return true;
            }

            return false;
        }
    }
}
