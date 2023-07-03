namespace Beekeeping.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Beekeeping.Models.Apiary;
    using Beekeeping.Web.Infrastructure.Extensions;
    using Beekeeping.Services.Interfaces;
    using System.Xml.Schema;

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

            this.TempData["SuccessMessage"] = "Пчелинът беше добавен успешно";

            return RedirectToAction("All");
        }

        public async Task<IActionResult> All()
        {
            var userId = this.User.Id();

            var isUserOwner = await apiaryService.IsTheUserOwner(userId);

            if (!isUserOwner)
            {
                TempData["ErrorMessage"] = "Все още нямате добавен пчелин.";

                return RedirectToAction("Add");
            }

            try
            {
                var model = await apiaryService.AllApiaryAsync(userId);

                if (model == null)
                {
                    TempData["InformationMessage"] = "Все още нямате добавен пчелин. Можете да го направите тук.";

                    return RedirectToAction("Add");
                }

                return View(model);
            }

            catch (Exception)
            {
                TempData["ErrorMessage"] = "Възникна грешка при добавянето на Вашия пчелин. Моля, свържете се с нас или опитайте по-късно!";
            }

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = this.User.Id();

            var isUserOwner = await apiaryService.IsTheUserOwner(userId);

            if (!isUserOwner)
            {
                TempData["ErrorMessage"] = "Нямате достъп до тази страница! За повече информация можете да се свържете с нас.";

                return RedirectToAction("Index", "Home");
            }


            bool apiaryExists = await apiaryService.DoesApiaryExists(userId, id);
            if (!apiaryExists)
            {
                TempData["ErrorMessage"] = "Не съществуващ пчелин!";

                return this.RedirectToAction("All");
            }

            try
            {
                var model = await apiaryService.GetApiaryForEditAsync(userId, id);

                return this.View(model);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Възникна неочаквана грешка. Моля, свържете се с нас или опитайте по-късно!";
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ApiaryEditFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.Id();

            var isUserOwner = await apiaryService.IsTheUserOwner(userId);

            if (!isUserOwner)
            {
                TempData["ErrorMessage"] = "Нямате достъп до тази страница! За повече информация можете да се свържете с нас.";

                return RedirectToAction("Index", "Home");
            }


            bool apiaryExists = await apiaryService.DoesApiaryExists(userId, id);

            if (!apiaryExists)
            {
                TempData["ErrorMessage"] = "Не съществуващ пчелин!";

                return this.RedirectToAction("All");
            }

            try
            {
                await this.apiaryService.EditApiaryAsync(model, id, userId);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Възникна грешка при редакцията на Вашия пчелин. Моля, свържете се с нас или опитайте по-късно!";
                return this.View(model);
            }

            this.TempData["SuccessMessage"] = "Пчелинът беше редакриран успешно!";

            return this.RedirectToAction("All");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.User.Id();

            var isUserOwner = await apiaryService.IsTheUserOwner(userId);

            if (!isUserOwner)
            {
                TempData["ErrorMessage"] = "Нямате достъп до тази страница! За повече информация можете да се свържете с нас.";

                return RedirectToAction("Index", "Home");
            }


            bool apiaryExists = await apiaryService.DoesApiaryExists(userId, id);
            if (!apiaryExists)
            {
                TempData["ErrorMessage"] = "Не съществуващ пчелин!";

                return this.RedirectToAction("All");
            }

            try
            {
                await apiaryService.DeleteApiaryAsync(userId, id);

                this.TempData["SuccessMessage"] = "Пчелинът беше изтрит успешно!";

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Възникна грешка при изтриването на Вашия пчелин. Моля, свържете се с нас или опитайте по-късно!";
            }

            return RedirectToAction("All");
        }
    }
}