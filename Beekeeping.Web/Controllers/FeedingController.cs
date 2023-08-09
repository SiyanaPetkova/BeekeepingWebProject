namespace Beekeeping.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Models.HiveFeeding;
    using Services.Interfaces;
    using Web.Infrastructure.Extensions;

    using static Common.NotificationMessages.ErrorMessages;

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
            var model = new HiveFeedingFormModel
            {
                DayOfFeeding = DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HiveFeedingFormModel model)
        {
            var userId = User.Id();
                        
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
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            TempData["SuccessMessage"] = "Информация за храненето беше добавена успешно";

            return RedirectToAction("Feeding", "Event");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.Id();

            bool feedingExists = await feedingService.DoesFeedingExists(userId, id);
            if (!feedingExists)
            {
                TempData["ErrorMessage"] = "Не съществува информация за това хранене!";

                return RedirectToAction("Index", "Home");
            }

            try
            {
                await feedingService.DeleteFeedingAsync(userId, id);

                TempData["SuccessMessage"] = "Данните за храненето бяха изтрити успешно!";

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return RedirectToAction("Feeding", "Event");
        }
    }
}