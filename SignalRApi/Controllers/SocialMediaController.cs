using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var value = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
                Title= createSocialMediaDto.Title,
                Icon= createSocialMediaDto.Icon,
                Url = createSocialMediaDto.Url,


            });
            return Ok("Başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok("Başarıyla silindi");
        }
        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
                SocialMediaId= updateSocialMediaDto.SocialMediaId,
                Title = updateSocialMediaDto.Title,
                Icon = updateSocialMediaDto.Icon,
                Url = updateSocialMediaDto.Url,


            });
            return Ok("Başarıyla güncellendi.");
        }
    }
}
