namespace Beekeeping.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.Interfaces;
    using Web.Infrastructure.Extensions;

    using static Common.NotificationMessages.ErrorMessages;

    [Authorize]
    public class EventController : Controller
    {
        private readonly ITreatmentService treatmentService;
        private readonly IFeedingService feedingService;
        private readonly INoteToDoService noteService;

        public EventController(ITreatmentService treatmentService, IFeedingService feedingService, INoteToDoService noteService)
        {
            this.treatmentService = treatmentService;
            this.feedingService = feedingService;
            this.noteService = noteService;
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
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return RedirectToAction("Feeding");
          
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
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return RedirectToAction("Treatment");
         }

        public async Task<IActionResult> Notes()
        {
            var userId = this.User.Id();

            try
            {
                var model = await noteService.AllNotesAsync(userId);

                if (model == null)
                {
                    TempData["InformationMessage"] = "Все още нямате добавена задача. Можете да го направите тук.";

                    return RedirectToAction("Add", "NoteToDo");
                }

                return View(model);
            }

            catch (Exception)
            {
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return RedirectToAction("Notes");

        }
    }
}