namespace Beekeeping.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Models.NoteToDo;
    using Services.Interfaces;
    using Web.Infrastructure.Extensions;

    using static Common.NotificationMessages.ErrorMessages;

    [Authorize]
    public class NoteToDoController : Controller
    {
        private readonly INoteToDoService noteService;

        public NoteToDoController(INoteToDoService noteService)
        {
            this.noteService = noteService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new NoteToDoFormModel();

            model.DateToBeDone = DateTime.Now;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(NoteToDoFormModel model)
        {
            var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await noteService.AddNoteToDoAsync(model, userId);
            }
            catch
            {
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            TempData["SuccessMessage"] = "Бележката Ви беше добавена успешно";

            return RedirectToAction("Notes", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            string userId = User.Id();

            var doesNoteExist = await noteService.DoesNoteExists(userId, id);

            if (!doesNoteExist)
            {
                TempData["ErrorMessage"] = "Несъществуващa бележка";

                return RedirectToAction("Notes", "Event");
            }

            try
            {
                var model = await noteService.GetNoteForEditAsync(userId, id);

                return View(model);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = CommonErrorMessage;

                return RedirectToAction("All", "Apiary");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NoteToDoFormModel model, int id)
        {
            string userId = User.Id();

            var doesNoteExist = await noteService.DoesNoteExists(userId, id);

            if (!doesNoteExist)
            {
                TempData["ErrorMessage"] = "Несъществуващa бележка";

                return RedirectToAction("Notes", "Event");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await noteService.EditNoteAsync(model, userId, id);

                TempData["SuccessMessage"] = "Успешно редактирахте бележката си";

                return RedirectToAction("Notes", "Event");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return RedirectToAction("Home", "Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.Id();

            var noteExist = await noteService.DoesNoteExists(userId, id);

            if (!noteExist)
            {
                TempData["ErrorMessage"] = "Не съществуваща бележка!";

                return RedirectToAction("Index", "Home");
            }

            try
            {
                await noteService.DeleteNotesAsync(userId, id);

                TempData["SuccessMessage"] = "Бележката беше изтрита успешно!";

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return RedirectToAction("Notes", "Event");
        }

    }
}