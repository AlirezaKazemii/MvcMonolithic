using MvcMonolithic.Models.DomainModels.PersonAggregate;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.Models.Services.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        #region Private Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public PersonRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        #endregion

        #region implementation of IPersonRepository
        public async Task Delete(Person person)
        {
            _context.Remove(person);
            _context.SaveChanges();
        }

        public async Task Insert(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Person>> SelectAll()
        {
            return _context.Persons.ToList();
        }

        public async Task<Person?> SelectById(Guid id)
        {
            return _context.Persons.Find(id);
        }

        public async Task Update(Person person)
        {
            _context.Update(person);
            _context.SaveChanges();
        }

        #endregion
    }
}
