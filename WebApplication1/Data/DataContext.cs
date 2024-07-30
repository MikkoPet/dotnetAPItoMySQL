using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

        }

    }
}
