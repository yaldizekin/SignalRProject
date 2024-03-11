using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.TAdd(new Contact()
            {
                Location = createContactDto.Location,
                Email= createContactDto.Email,
                PhoneNumber= createContactDto.PhoneNumber,
                FooterDescription= createContactDto.FooterDescription,
                
            });
            return Ok("Başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("Başarıyla silindi");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateContactDto updateContactDto)
        {
            _contactService.TAdd(new Contact()
            {
                ContactId= updateContactDto.ContactId,
                Location = updateContactDto.Location,
                Email = updateContactDto.Email,
                PhoneNumber = updateContactDto.PhoneNumber,
                FooterDescription = updateContactDto.FooterDescription,

            });
            return Ok("Başarıyla güncellendi.");
        }
    }
}
