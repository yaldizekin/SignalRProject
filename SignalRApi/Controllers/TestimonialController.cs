using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                Name= createTestimonialDto.Name,
                Title=createTestimonialDto.Title,
                Comment=createTestimonialDto.Comment,
                ImgUrl=createTestimonialDto.ImgUrl,
                TestimonialStatus=true,


            });
            return Ok("Başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Başarıyla silindi");
        }
        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                TestimonialId= updateTestimonialDto.TestimonialId,
                Name = updateTestimonialDto.Name,
                Title = updateTestimonialDto.Title,
                Comment = updateTestimonialDto.Comment,
                ImgUrl = updateTestimonialDto.ImgUrl,
                TestimonialStatus = updateTestimonialDto.TestimonialStatus,


            });
            return Ok("Başarıyla güncellendi.");
        }
    }
}
