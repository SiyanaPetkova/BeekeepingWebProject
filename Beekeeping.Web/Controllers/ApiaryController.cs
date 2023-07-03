namespace Beekeeping.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Beekeeping.Models.Apiary;
    using Beekeeping.Web.Infrastructure.Extensions;
    using Beekeeping.Services.Interfaces;

    [Authorize]
    public class ApiaryController : Controller
    {
        private readonly IApiaryService apiaryService;

        public ApiaryController(IApiaryService apiaryService)
        {
            this.apiaryService = apiaryService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ApiaryFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ApiaryFormModel model)
        {
            var userId = this.User.Id();

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Възникна грешка при добавянето на Вашия пчелин. Моля, свържете се с администратор или опитайте по-късно!";
                return View(model);
            }
            try
            {
                await apiaryService.AddNewApiaryAsync(model, userId);
            }
            catch
            {
                TempData["ErrorMessage"] = "Възникна грешка при добавянето на Вашия пчелин. Моля, свържете се с администратор или опитайте по-късно!";
            }
           

            return RedirectToAction("All", "Gallery");
        }
    }
}