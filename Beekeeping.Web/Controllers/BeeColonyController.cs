namespace Beekeeping.Web.Controllers
{
    using Beekeeping.Models.Apiary;
    using Beekeeping.Models.BeeColony;
    using Beekeeping.Models.BeeQueen;
    using Beekeeping.Services.Interfaces;
    using Beekeeping.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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

            List<AllApiariesForSelectModel> apiariesForSelect = AddApiaries(apiaries);

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

            var apiaries = await apiaryService.AllApiaryAsync(userId);

            if (apiaries == null)
            {
                TempData["ErrorMessage"] = "Трябва първо да добавите пчелин, за да можете да попълните данни за кошерите в него.";

                return RedirectToAction("Add", "Apiary");
            }

            if (!ModelState.IsValid)
            {
                List<AllApiariesForSelectModel> apiariesForSelect = AddApiaries(apiaries);

                var beeQueen = new BeeQueenFormModel();

                model.Apiaries = apiariesForSelect;
                model.BeeQueen = beeQueen;

                return View(model);
            }

            try
            {
                await beeColonyService.AddNewBeeColonyAsync(model, userId);

                TempData["SuccessMessage"] = "Успечно добавихте нов кошер към своя пчелин";

                return RedirectToAction("All", "Apiary");
            }
            catch (Exception)
            {

                TempData["ErrorMessage"] = "Съжаляваме, но нещо се обърка. Моля, свържете се с нас или опитайте по-късно!";
            }

            return RedirectToAction("All", "Apiary");
        }

        private static List<AllApiariesForSelectModel> AddApiaries(IEnumerable<ApiaryViewModel>? apiaries)
        {
            var apiariesForSelect = new List<AllApiariesForSelectModel>();

            if (apiaries != null)
            {
                foreach (var apiary in apiaries)
                {
                    var apiaryForSelect = new AllApiariesForSelectModel()
                    {
                        Id = apiary.Id,
                        Name = apiary.Name
                    };
                    apiariesForSelect.Add(apiaryForSelect);
                }

                return apiariesForSelect;
            }

            return null;
        }

    }
}