using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services.ContactService
{
	class ContactService : IContactService
	{
		private readonly DataContext _context;
		public ContactService(DataContext context) 
		{
			_context = context;
		}

		public async Task<List<Contact>> AddContact(Contact contact)
		{
			_context.Contacts.Add(contact);
			await _context.SaveChangesAsync();

			return await _context.Contacts.ToListAsync();
		}

		public async Task<List<Contact>?> DeleteContact(int id)
		{
			var result = _context.Contacts.Find(id);
			if (result is null)
				return null;

			_context.Contacts.Remove(result);
			await _context.SaveChangesAsync();

			return await _context.Contacts.ToListAsync();
		}
		public async Task<List<Contact>?> GetContacts()
		{ 
			var contacts = await _context.Contacts.ToListAsync();
			return contacts; 
		}
		public async Task<Contact?> GetSingleContact(int id)
		{
			var result = _context.Contacts.Find(id);
			if (result is null)
				return null;

			return result;
		}
		public async Task<List<Contact>?> UpdateContact(int id, Contact request)
		{
			var dbContact = _context.Contacts.Find(id);

			if (dbContact is null)
				return null;

			dbContact.FirstName = request.FirstName;
			dbContact.LastName = request.LastName;
			dbContact.Gender = request.Gender;
			dbContact.AvatarPath = request.AvatarPath;
			dbContact.DateOfBirth = request.DateOfBirth;

			await _context.SaveChangesAsync();

			return await _context.Contacts.ToListAsync();
		}


	}
}

