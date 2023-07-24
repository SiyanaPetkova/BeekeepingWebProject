namespace Beekeeping.Web.Controllers
{
    using Beekeeping.Services.Interfaces;
    using Beekeeping.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class EventController : Controller
    {
        private readonly ITreatmentService treatmentService;
        private readonly IFeedingService feedingService;

        public EventController(ITreatmentService treatmentService, IFeedingService feedingService)
        {
            this.treatmentService = treatmentService;
            this.feedingService = feedingService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Feeding()
        {
            var userId = this.User.Id();
                      
            try
            {
                var model = await feedingService.AllFeedingsAsync(userId);

                if (model == null)
                {
                    TempData["InformationMessage"] = "Все още нямате добавенo хранене. Можете да го направите тук.";

                    return RedirectToAction("Add", "Feeding");
                }

                return View(model);
            }

            catch (Exception)
            {
                TempData["ErrorMessage"] = "Възникна грешка при добавянето на Вашия пчелин. Моля, свържете се с нас или опитайте по-късно!";
            }

            return RedirectToAction("Index", "Home");
          
        }

        public async Task<IActionResult> Treatment()
        {
            var userId = this.User.Id();
        
            try
            {
                var model = await treatmentService.AllTreatmentsAsync(userId);

                if (model == null)
                {
                    TempData["InformationMessage"] = "Все още нямате добавенo третиране. Можете да го направите тук.";

                    return RedirectToAction("Add", "Treatment");
                }

                return View(model);
            }

            catch (Exception)
            {
                TempData["ErrorMessage"] = "Възникна грешка при добавянето на Вашия пчелин. Моля, свържете се с нас или опитайте по-късно!";
            }

            return RedirectToAction("Index", "Home");
         }
    }
}