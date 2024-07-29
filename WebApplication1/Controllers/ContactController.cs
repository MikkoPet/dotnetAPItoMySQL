using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Contact>>> GetContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact is null)
                return BadRequest("Contact not found.");

            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<List<Contact>>> AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return Ok(await _context.Contacts.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Contact>>>  UpdateContact(Contact contact)
        {
            var dbContact = await _context.Contacts.FindAsync(contact.Id);

            if (dbContact is null)
                return BadRequest("Contact not found.");

            dbContact.FirstName = contact.FirstName;
            dbContact.LastName = contact.LastName;
            dbContact.Gender = contact.Gender;
            dbContact.AvatarPath = contact.AvatarPath;
            dbContact.DateOfBirth = contact.DateOfBirth;

            await _context.SaveChangesAsync();

            return Ok(await _context.Contacts.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Contact>>> DeleteContact(int id)
        {
			var contact = await _context.Contacts.FindAsync(id);
			if (contact is null)
				return BadRequest("Contact not found.");

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return Ok(await _context.Contacts.ToListAsync());
		}
	}
}
