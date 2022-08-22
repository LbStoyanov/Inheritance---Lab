using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RoomCreationWorking()
        {
            Room room = new Room(10, 10.50);

            Assert.AreEqual(10,room.BedCapacity);
            Assert.AreEqual(10.50,room.PricePerNight);
        }

        [Test]
        public void RoomCreationWithInvalidPriceThrows()
        {


            Assert.Throws<ArgumentException>(() =>
            {
                Room room = new Room(10, -10.50);
            });
        }

        [Test]
        public void RoomCreationWithInvalidBedCountThrows()
        {
            
            Assert.Throws<ArgumentException>(() =>
            {
                Room room = new Room(-10, 10.50);
            });
        }

        [Test]
        public void BookingCreationWorking()
        {
            Room room = new Room(10, 10.50);

            Booking booking = new Booking(1,room,10);
            Assert.AreEqual(1,booking.BookingNumber);
            Assert.AreEqual(10,booking.ResidenceDuration);
            Assert.AreEqual(room,booking.Room);
        }

        [Test]
        public void HotelCreationWorking()
        {
            Hotel hotel = new Hotel("Pri Chako", 4);

            Assert.AreEqual("Pri Chako",hotel.FullName);
            Assert.AreEqual(4,hotel.Category);
            
        }

        [Test]
        public void HotelCreationWithNullNameThrows()
        {
            
            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel(null, 4);
            });

        }

        [Test]
        public void HotelCreationWithBiggerCategoryThrows()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel("Pri Chako", 6);
            });

        }

        [Test]
        public void HotelCreationWithSmallerCategoryThrows()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel("Pri Chako", 0);
            });

        }

        [Test]
        public void AddRoomMethod()
        {
            Room room = new Room(10, 10.50);
            Hotel hotel = new Hotel("Pri Chako", 4);
            hotel.AddRoom(room);
           Assert.AreEqual(1,hotel.Rooms.Count);

        }

        [Test]
        public void BookRoomWithNegativeAddultCountThows()
        {
            Room room = new Room(10, 10.50);
            Hotel hotel = new Hotel("Pri Chako", 4);
            hotel.AddRoom(room);
            

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(-1, 1, 1, 5.50);
            });
        }

        [Test]
        public void BookRoomWithNegativeChildrenCountThows()
        {
            Room room = new Room(10, 10.50);
            Hotel hotel = new Hotel("Pri Chako", 4);
            hotel.AddRoom(room);


            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(1, -1, 1, 5.50);
            });
        }

        [Test]
        public void BookRoomWithNegativeResidenceDurationThows()
        {
            Room room = new Room(10, 10.50);
            Hotel hotel = new Hotel("Pri Chako", 4);
            hotel.AddRoom(room);


            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(1, 2, 0, 5.50);
            });
        }

        [Test]
        public void BookRoomWorking()
        {
            Room room = new Room(10, 10.50);
            Hotel hotel = new Hotel("Pri Chako", 4);
            hotel.AddRoom(room);
            hotel.BookRoom(1,1,1,15.00);
            double turnOver = 10.50;

            Assert.AreEqual(turnOver,hotel.Turnover);
            
            
        }

        [Test]
        public void BookRoomWorkingWithZeroTurnOver()
        {
            Room room = new Room(10, 10.50);
            Hotel hotel = new Hotel("Pri Chako", 4);
            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 1, 5.00);
            

            Assert.AreEqual(0, hotel.Turnover);


        }

    }
}