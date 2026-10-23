using MvcMonolithic.ApplicationServices.Dtos.ProductDtos;
using MvcMonolithic.ApplicationServices.Services.Contracts;
using MvcMonolithic.Models.DomainModels.ProductAggregate;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.ApplicationServices.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        #region Private Feilds
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructor
        public ProductApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Implemention of IPersonApplicationService

        #region Delete
        public async Task Delete(DeleteProductDto deleteProductDto)
        {
            var product = await _productRepository.SelectById(deleteProductDto.Id);

            if (product == null)
                throw new NullReferenceException();

            await _productRepository.Delete(product);
        }
        #endregion

        #region GetAll
        public async Task<IEnumerable<GetProductDto>> GetAll()
        {
            var productList = await _productRepository.SelectAll();

            if (productList is null)
                throw new NullReferenceException();

            var productDtoList = new List<GetProductDto>();

            foreach (var product in productList)
            {
                var productDto = new GetProductDto()
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    UnitPrice = product.UnitPrice,
                    Quantity = product.Quantity
                };
                productDtoList.Add(productDto);
            }

            return productDtoList;
        }
        #endregion

        #region GetById
        public async Task<GetProductByIdDto> GetById(Guid id)
        {
            var product = await _productRepository.SelectById(id);

            if (product is null)
                throw new NullReferenceException();

            var productDto = new GetProductByIdDto()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                UnitPrice = product.UnitPrice,
                Quantity = product.Quantity
            };

            return productDto;
        }
        #endregion

        #region Post
        public async Task Post(PostProductDto postProductDto)
        {
            var product = new Product
                (
                    postProductDto.ProductName,
                    postProductDto.ProductDescription,
                    postProductDto.UnitPrice,
                    postProductDto.Quantity
                );

            await _productRepository.Insert(product);
        }
        #endregion

        #region Put
        public async Task Put(PutProductDto putProductDto)
        {
            var product = await _productRepository.SelectById(putProductDto.Id);

            if (product is null)
                throw new NullReferenceException();

            product.UpdateProduct(putProductDto.ProductName, putProductDto.ProductDescription, putProductDto.UnitPrice, putProductDto.Quantity);

            await _productRepository.Update(product);
        }
        #endregion

        #endregion
    }
}
