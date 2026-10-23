using MvcMonolithic.Models.DomainModels.ProductAggregate;

namespace MvcMonolithic.Models.Services.Contracts
{
    public interface IProductRepository
    {
        #region Insert
        Task Insert(Product product);
        #endregion

        #region SelectAll
        Task<IEnumerable<Product>> SelectAll(); // ?
        #endregion

        #region SelectById
        Task<Product?> SelectById(Guid id);
        #endregion

        #region Delete
        Task Delete(Product product);
        #endregion

        #region Update
        Task Update(Product product);
        #endregion
    }
}
