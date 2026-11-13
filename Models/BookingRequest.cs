namespace SmartHotelApi.Models;

public class BookingRequest
{
    public string GuestName { get; set; }

    public int HotelId { get; set; }

    public int NumberOfGuests { get; set; }
}