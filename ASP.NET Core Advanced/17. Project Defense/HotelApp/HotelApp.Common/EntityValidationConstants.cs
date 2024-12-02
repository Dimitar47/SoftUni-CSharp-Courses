

namespace HotelApp.Common
{
    public static class EntityValidationConstants
    {


        public static class Hotel
        {
            //Hotel
            public const int HotelNameMinLength = 2;
            public const int HotelNameMaxLength = 255;

            public const int HotelAddressMaxLength = 255;

            public const int HotelPhoneMaxLength = 15;

            public const int HotelEmailMaxLength = 255;


            public const int HotelStarsMinLength = 1;
            public const int HotelStarsMaxLength = 5;

            public const string CheckInOutTimeSpanFormat = @"hh\:mm";

        }

        public static class Room
        {
            //Room
            public const int RoomNumberMinLength = 1;
            public const int RoomNumberMaxLength = 700;
            public const int RoomStatusMaxLength = 20;
        }

        public static class Booking
        {
            //Booking
            public const decimal BookingTotalPriceMinLength = 0;
            public const decimal BookingTotalPriceMaxLength = decimal.MaxValue;
        }

        public static class Guest
        {
            //Guest
            public const int GuestFirstNameMaxLength = 50;

            public const int GuestLastNameMaxLength = 50;

            public const int GuestAddressMaxLength = 255;

            public const int GuestPhoneMaxLength = 15;

            public const int GuestEmailMaxLength = 255;
        }

        public static class Payment
        {

            //Payment
            public const decimal PaymentAmountMinLength = 0;
            public const decimal PaymentAmountMaxLength = decimal.MaxValue;

            public const int PaymentMethodMaxLength = 50;
        }

        public static class RoomType
        {
            //RoomType

            public const int RoomTypeNameMaxLength = 50;

            public const int RoomTypeDescriptionMaxLength = 255;

            public const decimal RoomTypePricePerNightMinLength = 1;
            public const decimal RoomTypePricePerNightMaxLength = decimal.MaxValue;

            public const int RoomTypeCapacityMinLength = 1;
            public const int RoomTypeCapacityMaxLength = int.MaxValue;

        }

        public static class Staff
        {
            //Staff
            public const int StaffFirstNameMaxLength = 50;

            public const int StaffLastNameMaxLength = 50;

            public const int StaffPositionMaxLength = 50;


            public const decimal StaffSalaryMinLength = 0;
            public const decimal StaffSalaryMaxLength = decimal.MaxValue;

            public const int StaffPhoneMaxLength = 15;

            public const int StaffEmailMaxLength = 255;
        }


    }
}
