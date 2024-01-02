using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;
        private IRoom room;
        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount
            , int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }
        public IRoom Room
        {
            get => room;
            private set
            {
                room = value;
            }

        }


        public int ResidenceDuration
        {
            get => residenceDuration;
            private set
            {
                if (value <=0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                residenceDuration = value;
            }
        }


        public int AdultsCount
        {
            get => adultsCount;
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                adultsCount = value;
            }

        }


        public int ChildrenCount
        {
            get => childrenCount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                childrenCount = value;
            }
                

        }

        public int BookingNumber
        {
            get => bookingNumber;
            private set => bookingNumber = value;

        }

   
        public string BookingSummary()
        {
            double totalAmountPaid =   Math.Round(ResidenceDuration * Room.PricePerNight, 2);
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Booking number: {BookingNumber}");
            str.AppendLine($"Room type: {room.GetType().Name}");
            str.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");

            str.AppendLine($"Total amount paid: {totalAmountPaid:F2} $");
            return str.ToString();
        }
    }
}
