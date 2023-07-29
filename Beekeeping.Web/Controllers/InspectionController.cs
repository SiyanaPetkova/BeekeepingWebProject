namespace Beekeeping.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Models.Inspection;
    using Services.Interfaces;
    using Web.Infrastructure.Extensions;

    using static Common.NotificationMessages.ErrorMessages;

    [Authorize]
    public class InspectionController : Controller
    {
        private readonly IInspectionService inspectionService;
        private readonly IBeeColonyService beeColonyService;
        private readonly IApiaryService apiaryService;

        public InspectionController(IInspectionService inspectionService, IBeeColonyService beeColonyService, IApiaryService apiaryService)
        {
            this.inspectionService = inspectionService;
            this.beeColonyService = beeColonyService;
            this.apiaryService = apiaryService;
        }

        public async Task<IActionResult> All(int id)
        {
            var userId = User.Id();

            var isUserOwner = await apiaryService.IsTheUserOwner(userId);

            if (!isUserOwner)
            {
                TempData["ErrorMessage"] = "Вие не сте собственик на този пчелин!";

                return RedirectToAction("Index", "Home");
            }

            var beeColony = await beeColonyService.DoesBeeColonyExist(userId, id);

            if (!beeColony)
            {
                TempData["ErrorMessage"] = "Този кошер не съществува";

                return RedirectToAction("All", "BeeColony");
            }

            try
            {
                var inspections = await inspectionService.AllInspectionsPerColonyAsync(userId, id);


                if (inspections == null)
                {
                    TempData["InformationMessage"] = "Все още нямате добавен преглед. Можете да го направите тук.";

                    return RedirectToAction("Add");
                }

                return View(inspections);
            }

            catch (Exception)
            {
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            string userId = User.Id();

            var beeColony = await beeColonyService.DoesBeeColonyExist(userId, id);

            if (!beeColony)
            {
                TempData["ErrorMessage"] = "Този кошер не съществува";

                return RedirectToAction("All", "Apiary");
            }

            var model = new InspectionFormModel();

            model.DayOfInspection = DateTime.Now;

            model.BeeColonyId = id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(InspectionFormModel model, int id)
        {
            string userId = User.Id();

            var beeColony = await beeColonyService.DoesBeeColonyExist(userId, id);

            if (!beeColony)
            {
                TempData["ErrorMessage"] = "Този кошер не съществува";

                return RedirectToAction("All", "Apiary");
            }

            model.BeeColonyId = id;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await inspectionService.AddNewInspectionAsync(model, userId);

                TempData["SuccessMessage"] = "Успешно добавихте нов преглед за избрания кошер";

                return RedirectToAction("All", "Inspection", new { id = model.BeeColonyId });
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

            try
            {
                var model = await inspectionService.GetDetailsForTheInspectionAsync(userId, id);

                return View(model);
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

            var inspection = await inspectionService.DoesInspectionExist(userId, id);

            if (!inspection)
            {
                TempData["ErrorMessage"] = "Несъществуващ преглед";

                return RedirectToAction("All", "Apiary");
            }

            try
            {
                var model = await inspectionService.GetInspectionForEditAsync(userId, id);

                return View(model);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = CommonErrorMessage;

                return RedirectToAction("All", "Apiary");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InspectionFormModel model, int id)
        {
            string userId = User.Id();

            var inspection = await inspectionService.DoesInspectionExist(userId, id);

            if (!inspection)
            {
                TempData["ErrorMessage"] = "Несъществуващ преглед";

                return RedirectToAction("All", "Inspection", new { id = model.BeeColonyId });
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await inspectionService.EditInspectionAsync(model, userId, id);

                TempData["SuccessMessage"] = "Успешно редактирахте прегледа за избрания кошер";

                return RedirectToAction("All", "Inspection", new { id = model.BeeColonyId });
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return RedirectToAction("All", "Apiary");
        }

        public async Task<IActionResult> Delete(int id)
        {
            string userId = User.Id();

            var inspection = await inspectionService.DoesInspectionExist(userId, id);

            if (!inspection)
            {
                TempData["ErrorMessage"] = "Несъществуващ преглед";

                return RedirectToAction("All", "Apiary");
            }

            try
            {
                var beeColonyId = await inspectionService.GetCurrentInspectionBeeColonyId(userId, id);

                await inspectionService.DeleteInspectionAsync(userId, id);

                this.TempData["SuccessMessage"] = "Прегледът беше изтрит успешно!";

                return RedirectToAction("All", "Inspection", new {id = beeColonyId});

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = CommonErrorMessage;

                return RedirectToAction("All", "Apiary");
            }           
        }
    }
}