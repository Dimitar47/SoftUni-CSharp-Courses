namespace HotelApp.Common
{
    public static class EntityValidationMessages
    {

        public static class Hotel
        {
            public const string NameRequiredMessage = "Hotel Name is required.";
            public const string AddressRequiredMessage = "Address is required.";
            public const string PhoneRequiredMessage = "Phone is required.";
            public const string EmailRequiredMessage = "Email is required.";
            public const string StarsRequiredMessage = "Please specify the stars of the hotel.";
            public const string CheckinTimeRequiredMessage = @"Check-in time is required in format hh:mm.";
            public const string CheckoutTimeRequiredMessage = @"Check-out time is required in format hh:mm.";
        }

        public static class Room
        {
            public const string RoomNumberRequiredMessage = "Room Number is required.";
            public const string RoomStatusRequiredMessage = "Room Status is required.";
            public const string RoomHotelRequiredMessage = "Please select a hotel.";

        }
        public static class RoomType
        {
            public const string RoomTypeNameAllowedTypesMessage = "Room type must be Single, Double, or Suite.";
        }

        public static class Booking
        {
            public const string CheckinDateRequiredMessage = @"Check-in date is required in format yyyy-MM-dd.";
            public const string CheckoutDateRequiredMessage = @"Check-out date is required in format yyyy-MM-dd.";
            public const string TotalPriceRequiredMessage = "Total Price is required.";
            public const string GuestRequiredMessage = "Guest is required.";
            public const string HotelRequiredMessage = "Hotel is required.";
            public const string RoomRequiredMessage = "Room is required.";
          
        }
    }
}
