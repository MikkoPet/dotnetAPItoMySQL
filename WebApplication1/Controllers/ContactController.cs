using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services.ContactService;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService context)
        {
            contactService = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            var result = await contactService.GetContacts();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Contact>>> GetContact(int id)
        {
            var result = await contactService.GetSingleContact(id);
            if (result is null)
                return NotFound("Contact not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Contact>>> AddContact(Contact contact)
        {
            var result = await contactService.AddContact(contact);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Contact>>> UpdateContact(int id, Contact contact)
        {
            var result = await contactService.UpdateContact(id, contact);
            if (result is null)
                return NotFound("Contact not found");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Contact>>> DeleteContact(int id)
        {
            var contact = await contactService.DeleteContact(id);
            if (contact is null)
                return NotFound("Contact not found.");

            return Ok(contact);

        }
    }
}
