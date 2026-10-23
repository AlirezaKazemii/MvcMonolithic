using Microsoft.EntityFrameworkCore;
using MvcMonolithic.Models.DomainModels.PersonAggregate;
using MvcMonolithic.Models.DomainModels.ProductAggregate;

namespace MvcMonolithic.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
