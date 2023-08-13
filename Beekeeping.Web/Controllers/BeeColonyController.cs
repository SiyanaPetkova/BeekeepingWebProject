namespace Beekeeping.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Models.Apiary;
    using Models.BeeColony;
    using Models.BeeQueen;
    using Services.Interfaces;
    using Web.Infrastructure.Extensions;

    using static Common.NotificationMessages.ErrorMessages;

    [Authorize]
    public class BeeColonyController : Controller
    {
        private readonly IBeeColonyService beeColonyService;
        private readonly IApiaryService apiaryService;

        public BeeColonyController(IBeeColonyService beeColonyService, IApiaryService apiaryService)
        {
            this.beeColonyService = beeColonyService;
            this.apiaryService = apiaryService;
        }

        public async Task<IActionResult> All(int id)
        {
            var userId = User.Id();

            var doesOwnerHasApiary = await apiaryService.DoesOwnerHasApiary(userId);

            if (!doesOwnerHasApiary)
            {
                TempData["InformationMessage"] = "Все още нямате добавен пчелин. Можете да го направите тук.";

                return RedirectToAction("Add");
            }


            var isUserOwner = await apiaryService.IsTheUserOwner(userId, id);

            if (!isUserOwner)
            {
                TempData["ErrorMessage"] = NotAuthorizedErrorMessage;

                return RedirectToAction("Index", "Home");
            }

            try
            {
                var model = await beeColonyService.AllColoniesAsync(userId, id);

                if (model == null)
                {
                    TempData["InformationMessage"] = "Все още нямате добавени кошери. Можете да го направите тук.";

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
        public async Task<IActionResult> Add()
        {
            string userId = User.Id();

            var apiaries = await apiaryService.AllApiaryAsync(userId);

            if (apiaries == null)
            {
                TempData["ErrorMessage"] = "Трябва първо да добавите пчелин, за да можете да попълните данни за кошерите в него.";

                return RedirectToAction("Add", "Apiary");
            }

            var apiariesForSelect = apiaryService.AllApiariesForSelectAsync(apiaries);

            var model = new BeeColonyFormModel();
            var beeQueen = new BeeQueenFormModel();

            model.Apiaries = apiariesForSelect;
            model.BeeQueen = beeQueen;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BeeColonyFormModel model)
        {
            string userId = User.Id();

            bool doesApiaryExist = await apiaryService.DoesApiaryExists(userId, model.ApiaryId);

            if (!doesApiaryExist)
            {
                TempData["ErrorMessage"] = "Трябва първо да добавите пчелин, за да можете да попълните данни за кошерите в него.";

                return RedirectToAction("Add", "Apiary");
            }

            if (!ModelState.IsValid)
            {
                var apiaries = await apiaryService.AllApiaryAsync(userId);

                var apiariesForSelect = apiaryService.AllApiariesForSelectAsync(apiaries);

                var beeQueen = new BeeQueenFormModel();

                model.Apiaries = apiariesForSelect;
                model.BeeQueen = beeQueen;

                return View(model);
            }

            try
            {
                await beeColonyService.AddNewBeeColonyAsync(model, userId);

                TempData["SuccessMessage"] = "Успешно добавихте нов кошер към своя пчелин";

                return RedirectToAction("All", "Apiary");
            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return RedirectToAction("All", "Apiary");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            string userId = User.Id();

            bool isUserOwner = await beeColonyService.IsTheUserOwner(userId);

            if (!isUserOwner)
            {
                TempData["ErrorMessage"] = "Нямате достъп до тези данни!";

                return RedirectToAction("Home", "Index");
            }

            var apiaries = await apiaryService.AllApiaryAsync(userId);

            if (apiaries == null)
            {
                TempData["ErrorMessage"] = "Трябва първо да добавите пчелин, за да можете да редактирате данните.";

                return RedirectToAction("Add", "Apiary");
            }

            try
            {
                var model = await beeColonyService.GetBeeColonyForEditAsync(userId, id);

                var apiariesForSelect = apiaryService.AllApiariesForSelectAsync(apiaries);

                model.Apiaries = apiariesForSelect;

                return View(model);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = CommonErrorMessage;

                return RedirectToAction("All", "BeeColony");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BeeColonyFormModel model, int id)
        {
            string userId = User.Id();

            bool doesApiaryExist = await apiaryService.DoesApiaryExists(userId, model.ApiaryId);

            if (!doesApiaryExist)
            {
                TempData["ErrorMessage"] = "Трябва първо да добавите пчелин, за да можете да попълните данни за кошерите в него.";

                return RedirectToAction("Add", "Apiary");
            }

            if (!ModelState.IsValid)
            {
                var apiaries = await apiaryService.AllApiaryAsync(userId);

                var apiariesForSelect = apiaryService.AllApiariesForSelectAsync(apiaries);

                model.Apiaries = apiariesForSelect;

                return View(model);
            }

            try
            {
                await beeColonyService.EditBeeColonyAsync(model, userId, id);

                TempData["SuccessMessage"] = "Успешно редактирахте своя кошер";

                return RedirectToAction("All", "Apiary");
            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return RedirectToAction("All", "Apiary");
        }

        public async Task<IActionResult> Details(int id)
        {
            string userId = User.Id();

            var doesApiaryExist = await beeColonyService.DoesBeeColonyExist(userId, id);

            if (!doesApiaryExist)
            {
                TempData["ErrorMessage"] = "Не съществуващ koшер!";

                return RedirectToAction("All", "Apiary");
            }

            try
            {
                var model = await beeColonyService.GetDetailsForTheBeeColonyAsync(userId, id);

                return View(model);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return RedirectToAction("All", "Apiary");

        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.Id();

            var isUserOwner = await beeColonyService.IsTheUserOwner(userId);

            if (!isUserOwner)
            {
                TempData["ErrorMessage"] = NotAuthorizedErrorMessage;

                return RedirectToAction("Index", "Home");
            }

            bool beeColonyExists = await beeColonyService.DoesBeeColonyExist(userId, id);

            if (!beeColonyExists)
            {
                TempData["ErrorMessage"] = "Не съществуващ koшер!";

                return RedirectToAction("All", "Apiary");
            }

            try
            {
                await beeColonyService.DeleteBeeColonyAsync(userId, id);

                TempData["SuccessMessage"] = "Кошерът беше изтрит успешно!";
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return RedirectToAction("All", "Apiary");
        }



    }
}