using BookingApp.Core.Contracts;
using BookingApp.Models;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private IRepository<IHotel> hotels;
        public Controller() 
        {
            hotels = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = hotels.Select(hotelName);
            if(hotel != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }
            hotel = new Hotel(hotelName, category); 
            hotels.AddNew(hotel);
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }
        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotels.Select(hotelName);
            if(hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room != null)
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }
            
               
            
            if(roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
            }
            else if(roomTypeName == "Studio")
            {
                room = new Studio();
            }
            else if(roomTypeName == "Apartment") 
            {
                room = new Apartment();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect));
            }
            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName,hotelName);
   
        }
        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {

            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (roomTypeName != "DoubleBed" && roomTypeName != "Studio"
                && roomTypeName != "Apartment")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect));
            }
            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room == null)
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);
            }
            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PriceAlreadySet));
            }

            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName
                ,hotelName);
        }


        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            List<IHotel> sortedHotels = hotels.All().OrderBy(hotel => hotel.FullName).ToList();

            // Step 2: Filter rooms with PricePerNight > 0
            List<IRoom> availableRooms = sortedHotels
                .SelectMany(hotel => hotel.Rooms.All().Where(room => room.PricePerNight > 0))
                .ToList();

            List<IRoom> sortedRooms = availableRooms.OrderBy(room => room.BedCapacity).ToList();
            IRoom selectedRoom = sortedRooms.FirstOrDefault(
                room => room.BedCapacity >= (adults + children) );

            if(selectedRoom == null)
            {
                return string.Format(OutputMessages.RoomNotAppropriate);
            }

            IHotel selectedHotel = sortedHotels.FirstOrDefault(
       hotel => hotel.Rooms.All().Contains(selectedRoom) && hotel.Category == category
   );
            if (selectedHotel == null)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            int bookingNumber = selectedHotel.Bookings.All().Count + 1;
            IBooking booking = new Booking(selectedRoom,duration,adults,children,bookingNumber);
            selectedHotel.Bookings.AddNew(booking);
            return string.Format(OutputMessages.BookingSuccessful, bookingNumber, selectedHotel.FullName);


        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            StringBuilder sb = new StringBuilder();
         
                sb.AppendLine($"Hotel name: {hotelName}");
                sb.AppendLine($"--{hotel.Category} star hotel");
                sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();
            if (hotel.Bookings.All().Count > 0)
            {
                foreach(var book in hotel.Bookings.All())
                {
                    sb.AppendLine($"{book.BookingSummary()}");
                }
            }
            else
            {
                sb.AppendLine("none");
            }
            return sb.ToString().TrimEnd();

        }

       

    }
}
