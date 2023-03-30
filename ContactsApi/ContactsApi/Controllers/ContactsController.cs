using ContactsApi.Data;
using ContactsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactsApiDBContext _dbContext;

        public ContactsController(ContactsApiDBContext dBContext)
        {
            _dbContext = dBContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
          
            return  Ok(await _dbContext.Contacts.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> CreateContacts(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
                Phone = addContactRequest.Phone
            };
           await _dbContext.Contacts.AddAsync(contact);
           await _dbContext.SaveChangesAsync();

            return Ok(contact);
        }
    }
}
