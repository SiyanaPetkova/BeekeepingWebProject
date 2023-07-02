namespace Beekeeping.Web.Controllers
{
    using Beekeeping.Models.Pictures;
    using Beekeeping.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class GalleryController : Controller
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        public async Task<IActionResult> All()
        {
            var model = await _galleryService.ShowPicturesAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new PictureViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PictureViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _galleryService.AddPictureAsync(model);

            return RedirectToAction("All");
        }

        public PartialViewResult DropdownMenu()
        {
            var options = new List<SelectListItem>
        {
            new SelectListItem { Value = "Gallery", Text = "Option 1" },
            new SelectListItem { Value = "Add picture", Text = "Option 2" }
        };

            return PartialView("_DropdownMenu", options);
        }
    }
}
