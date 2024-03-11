using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values =_aboutService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Title = createAboutDto.Title,
                AboutDescription = createAboutDto.AboutDescription,
                ImgUrl = createAboutDto.ImgUrl,
            };
            _aboutService.TAdd(about);
            return Ok("Başarıyla Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Başarıyla Silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout (UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutId = updateAboutDto.AboutId,
                Title = updateAboutDto.Title,
                AboutDescription = updateAboutDto.AboutDescription,
                ImgUrl = updateAboutDto.ImgUrl,
            };
            _aboutService.TUpdate(about);
            return Ok("Başarıyla Güncellendi");
        }
        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
           var value= _aboutService.TGetById(id);
            return Ok(value);
        }
    }
}
