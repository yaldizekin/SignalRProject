using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
         private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Name= createBookingDto.Name,
                Phone= createBookingDto.Phone,
                Email= createBookingDto.Email,
                PersonCount= createBookingDto.PersonCount,
                Date= createBookingDto.Date,
               
            };
            _bookingService.TAdd(booking);
            return Ok("Başarıyla Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Başarıyla Silindi");
        }
        [HttpPut]
        public IActionResult UpdateBooking (UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
               BookingId = updateBookingDto.BookingId,
                Name = updateBookingDto.Name,
                Phone = updateBookingDto.Phone,
                Email = updateBookingDto.Email,
                PersonCount = updateBookingDto.PersonCount,
                Date = updateBookingDto.Date,
            };
            _bookingService.TUpdate(booking);
            return Ok("Başarıyla Güncellendi");
        }
        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id)
        {
           var value= _bookingService.TGetById(id);
            return Ok(value);
        }
    }
}
