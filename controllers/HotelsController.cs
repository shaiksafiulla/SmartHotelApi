using Microsoft.AspNetCore.Mvc;
namespace SmartHotelApi.Controllers;

using SmartHotelApi.Models;

[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHotels()
    {
        Console.WriteLine("2. HotelsController executing");
        var hotels = new[]
        {
            new
            {
                Id = 1,
                Name = "Grand Palace Hotel",
                Location = "Bengaluru",
                Rating = 5
            },
            new
            {
                Id = 2,
                Name = "Royal Stay",
                Location = "Hyderabad",
                Rating = 4
            }
        };
        Console.WriteLine("3. Preparing hotel response");
        return Ok(hotels);
    }

    [HttpGet("{id}")]
    public IActionResult GetHotelById(int id)
    {
        // Console.WriteLine("2. HotelsController executing");
        // Console.WriteLine("3. Preparing hotel response");
        return Ok($"Hotel ID: {id}");
    }

    //https://localhost:7028/api/hotels/search?location=Bengaluru 
    //Route parameter → Which hotel?,  Query string → What criteria should we use to search hotels?
    [HttpGet("search")]
    public IActionResult SearchHotels([FromQuery] string location)
    {
        return Ok($"Searching hotels in: {location}");
    }


    //HTTP Method Matching
    [HttpPost]
    public IActionResult CreateHotel()
    {
        return Ok("Hotel creation request received.");
    }
    [HttpPost("booking")]
    public IActionResult CreateBooking([FromBody] BookingRequest request)
    {
        return Ok(request);
    }
    [HttpGet("headers")]
    public IActionResult GetHeaders()
    {
        var userAgent = Request.Headers.UserAgent.ToString();

        return Ok($"Client: {userAgent}");
    }
    [HttpPost("guest-form")]
    public IActionResult SubmitGuestForm([FromForm] string guestName)
    {
        return Ok($"Guest received: {guestName}");
    }

}
