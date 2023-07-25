﻿namespace Beekeeping.Web.Controllers
{
    using Beekeeping.Models.HiveFeeding;
    using Beekeeping.Models.HiveTreatment;
    using Beekeeping.Services.Interfaces;
    using Beekeeping.Services.Services;
    using Beekeeping.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class TreatmentController : Controller
    {
        private readonly ITreatmentService treatmentService;

        public TreatmentController(ITreatmentService treatmentService)
        {
            this.treatmentService = treatmentService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new HiveTreatmentFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HiveTreatmentFormModel model)
        {
            var userId = this.User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await treatmentService.AddTreatmentAsync(model, userId);
            }
            catch
            {
                TempData["ErrorMessage"] = "Възникна грешка при добавянето на ново третиране. Моля, свържете се с администратор или опитайте по-късно!";
            }

            this.TempData["SuccessMessage"] = "Информация за третирането беше добавена успешно";

            return RedirectToAction("Treatment", "Event");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.User.Id();

            bool treatmentExists = await treatmentService.DoesTreatmentExists(userId, id);
            if (!treatmentExists)
            {
                TempData["ErrorMessage"] = "Не съществува информация за това третиране!";

                return this.RedirectToAction("Treatment", "Event");
            }

            try
            {
                await treatmentService.DeleteTreatmentAsync(userId, id);

                this.TempData["SuccessMessage"] = "Данните за третирането бяха изтрити успешно!";

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Възникна неочаквана грешка! Моля, свържете се с нас или опитайте по-късно!";
            }

            return RedirectToAction("Treatment", "Event");
        }
    }
}