namespace Beekeeping.Web.Controllers
{
    using Beekeeping.Models.HiveFeeding;
    using Beekeeping.Services.Interfaces;
    using Beekeeping.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class FeedingController : Controller
    {
        private readonly IFeedingService feedingService;

        public FeedingController(IFeedingService feedingService)
        {
            this.feedingService = feedingService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new HiveFeedingFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HiveFeedingFormModel model)
        {
            var userId = this.User.Id();
                        
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await feedingService.AddFeedingAsync(model, userId);
            }
            catch
            {
                TempData["ErrorMessage"] = "Възникна грешка при добавянето на Вашия пчелин. Моля, свържете се с администратор или опитайте по-късно!";
            }

            this.TempData["SuccessMessage"] = "Информация за храненето беше добавена успешно";

            return RedirectToAction("Feeding", "Event");
        }
    }
}