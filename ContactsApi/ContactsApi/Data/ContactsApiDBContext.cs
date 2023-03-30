using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Data
{
    public class ContactsApiDBContext:DbContext
    {
        public ContactsApiDBContext(DbContextOptions<ContactsApiDBContext> options):base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
