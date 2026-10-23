using MvcMonolithic.Models.DomainModels.ProductAggregate;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.Models.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Private Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        #endregion

        #region implementation of IPersonRepository
        public async Task Delete(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }

        public async Task Insert(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Product>> SelectAll()
        {
            return _context.Products.ToList();
        }

        public async Task<Product?> SelectById(Guid id)
        {
            return _context.Products.Find(id);
        }

        public async Task Update(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

        #endregion
    }
}
