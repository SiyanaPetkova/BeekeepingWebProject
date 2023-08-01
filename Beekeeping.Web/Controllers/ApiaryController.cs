namespace Beekeeping.Web.Controllers
{
    using Beekeeping.Services.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Models.Apiary;
    using Services.Interfaces;
    using Web.Infrastructure.Extensions;

    using static Common.NotificationMessages.ErrorMessages;


    [Authorize]
    public class ApiaryController : Controller
    {
        private readonly IApiaryService apiaryService;

        public ApiaryController(IApiaryService apiaryService, IApiaryWeatherService apiaryWeatherService)
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
                TempData["ErrorMessage"] = CommonErrorMessage;
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
                TempData["ErrorMessage"] = CommonErrorMessage;
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
                TempData["ErrorMessage"] = NotAuthorizedErrorMessage;

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
                TempData["ErrorMessage"] = CommonErrorMessage;
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
                TempData["ErrorMessage"] = NotAuthorizedErrorMessage;

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
                TempData["ErrorMessage"] = CommonErrorMessage;
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
                TempData["ErrorMessage"] = NotAuthorizedErrorMessage;

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
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return RedirectToAction("All");
        }

    }
}