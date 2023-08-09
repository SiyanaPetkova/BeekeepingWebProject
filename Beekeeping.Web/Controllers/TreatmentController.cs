namespace Beekeeping.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Models.HiveTreatment;
    using Services.Interfaces;
    using Web.Infrastructure.Extensions;

    using static Common.NotificationMessages.ErrorMessages;

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
            var model = new HiveTreatmentFormModel
            {
                TreatmentDate = DateTime.Now
            };

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
                TempData["ErrorMessage"] = CommonErrorMessage;
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
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return RedirectToAction("Treatment", "Event");
        }
    }
}