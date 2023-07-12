namespace Beekeeping.Web.Controllers
{
    using Beekeeping.Models.Apiary;
    using Beekeeping.Models.BeeColony;
    using Beekeeping.Models.BeeQueen;
    using Beekeeping.Models.Inspection;
    using Beekeeping.Services.Interfaces;
    using Beekeeping.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class InspectionController : Controller
    {
        private readonly IInspectionService inspectionService;
        private readonly IBeeColonyService beeColonyService;

        public InspectionController(IInspectionService inspectionService, IBeeColonyService beeColonyService)
        {
            this.inspectionService = inspectionService;
            this.beeColonyService = beeColonyService;
        }

        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            string userId = User.Id();

            var beeColony = await beeColonyService.DoesBeeColonyExist(userId, id);

            if (!beeColony)
            {
                TempData["ErrorMessage"] = "Този кошер не съществува";

                return RedirectToAction("All", "BeeColony");
            }

            var model = new InspectionFormModel();

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

                return RedirectToAction("All", "BeeColony");
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

                return RedirectToAction("All", "BeeColony");
            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = "Съжаляваме, но нещо се обърка. Моля, свържете се с нас или опитайте по-късно!";
            }

            return RedirectToAction("All", "BeeColony");
        }
    }
}