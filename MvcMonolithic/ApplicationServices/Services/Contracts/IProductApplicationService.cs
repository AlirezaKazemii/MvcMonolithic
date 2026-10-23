using MvcMonolithic.ApplicationServices.Dtos.ProductDtos;
using MvcMonolithic.Models.DomainModels.ProductAggregate;

namespace MvcMonolithic.ApplicationServices.Services.Contracts
{
    public interface IProductApplicationService
    {
        #region Post
        Task Post(PostProductDto postProductDto);
        #endregion

        #region GetAll
        Task<IEnumerable<GetProductDto>> GetAll();
        #endregion

        #region GetById
        Task<GetProductByIdDto> GetById(Guid id);
        #endregion

        #region Delete
        Task Delete(DeleteProductDto deleteProductDto);
        #endregion

        #region Put
        Task Put(PutProductDto putProductDto);
        #endregion
    }
}
