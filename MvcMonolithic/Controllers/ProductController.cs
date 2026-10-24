using Microsoft.AspNetCore.Mvc;
using MvcMonolithic.ApplicationServices.Dtos.ProductDtos;
using MvcMonolithic.ApplicationServices.Services.Contracts;

namespace MvcMonolithic.Controllers
{
    public class ProductController : Controller
    {
        #region Private Feilds
        private readonly IProductApplicationService _productApplicationService;
        #endregion

        #region Constructor
        public ProductController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
        }
        #endregion


        #region [-Create-]

        #region Post
        [HttpPost]
        public async Task<IActionResult> Create(PostProductDto productDto)
        {
            await _productApplicationService.Post(productDto);
            return RedirectToAction("Index");
        }
        #endregion

        #region Get
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #endregion

        #region [-Details-]

        #region Detail
        public async Task<IActionResult> Details(ProductIdDto productIdDto)
        {
            var result = await _productApplicationService.GetById(productIdDto.Id);
            return View(result);
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index()
        {
            var result = await _productApplicationService.GetAll();
            return View(result);
        }
        #endregion

        #endregion

        #region [-Edit-]

        #region Post
        [HttpPost]
        public async Task<IActionResult> Edit(PutProductDto productDto)
        {
            await _productApplicationService.Put(productDto);
            return RedirectToAction("Index");
        }
        #endregion

        #region Get
        public async Task<IActionResult> Edit(ProductIdDto productIdDto)
        {
            var result = await _productApplicationService.GetById(productIdDto.Id);

            var putProductDto = new PutProductDto()
            {
                Id = result.Id,
                ProductName = result.ProductName,
                ProductDescription = result.ProductDescription,
                UnitPrice = result.UnitPrice,
                Quantity = result.Quantity
            };

            return View(putProductDto);
        }
        #endregion

        #endregion

        #region [-Delete-]

        #region Post
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteProductDto deleteProductDto)
        {
            await _productApplicationService.Delete(deleteProductDto);
            return RedirectToAction("Index");
        }
        #endregion

        #region Get
        public async Task<IActionResult> Delete(ProductIdDto productIdDto)
        {
            var result = await _productApplicationService.GetById(productIdDto.Id);

            var deleteProductDto = new DeleteProductDto()
            {
                Id = result.Id,
                ProductName = result.ProductName,
                ProductDescription = result.ProductDescription,
                UnitPrice = result.UnitPrice,
                Quantity = result.Quantity
            };

            return View(deleteProductDto);
        }
        #endregion

        #endregion


    }
}
