using Microsoft.AspNetCore.Mvc;
using MvcMonolithic.ApplicationServices.Dtos.PersonDtos;
using MvcMonolithic.ApplicationServices.Services.Contracts;

namespace MvcMonolithic.Controllers
{
    public class PersonController : Controller
    {
        #region Private Feilds
        private readonly IPersonApplicationService _personApplicationService;
        #endregion

        #region Constructor
        public PersonController(IPersonApplicationService personApplicationService)
        {
            _personApplicationService = personApplicationService;
        }
        #endregion


        #region [-Create-]

        #region Post
        [HttpPost]
        public async Task<IActionResult> Create(PostPersonDto personDto)
        {
            await _personApplicationService.Post(personDto);
            return View(personDto);
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
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _personApplicationService.GetById(id);
            return View(result);
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index()
        {
            var result = await _personApplicationService.GetAll();
            return View(result);
        }
        #endregion

        #endregion

        #region [-Edit-]

        #region Post
        [HttpPost]
        public async Task<IActionResult> Edit(PutPersonDto personDto)
        {
            await _personApplicationService.Put(personDto);
            return View(personDto);
        }
        #endregion

        #region Get
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _personApplicationService.GetById(id);
            return View(result);
        }
        #endregion

        #endregion

        #region [-Delete-]

        #region Post
        [HttpPost]
        public async Task<IActionResult> Delete(DeletePersonDto deletePersonDto)
        {
            await _personApplicationService.Delete(deletePersonDto);
            return RedirectToAction("Index");
        }
        #endregion

        #region Get
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _personApplicationService.GetById(id);
            return View(result);
        }
        #endregion

        #endregion


    }
}
