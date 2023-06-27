namespace Beekeeping.Web.Controllers
{
    using Beekeeping.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> Add()
        {
            return View();
        }
    }
}
