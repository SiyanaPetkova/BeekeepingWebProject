namespace Beekeeping.Web.Controllers
{
    using Beekeeping.Models.Cost;
    using Beekeeping.Models.Income;
    using Beekeeping.Services.Interfaces;
    using Beekeeping.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Dynamic;

    [Authorize]
    public class BalanceController : Controller
    {
        private readonly ICostService costService;
        private readonly IIncomeService incomeService;

        public BalanceController(ICostService costService, IIncomeService incomeService)
        {
            this.costService = costService;
            this.incomeService = incomeService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.Id();

            var incomes = await incomeService.AllIncomesAsync(userId);
            var costs = await costService.AllCostAsync(userId);

            dynamic model = new ExpandoObject();

            if (incomes != null)
            {
                model.Income = incomes;
            }
            else
            {
                model.Income = new List<IncomeViewModel>();
            }

            if (costs != null)
            {
                model.Cost = costs;
            }
            else
            {
                model.Cost = new List<CostViewModel>();
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult AddIncome()
        {
            var model = new IncomeFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddIncome(IncomeFormModel model)
        {
            var userId = this.User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await incomeService.AddIncomeAsync(model, userId);
            }
            catch
            {
                TempData["ErrorMessage"] = "Възникна грешка при добавянето на прихода. Моля, свържете се с администратор или опитайте по-късно!";
            }

            this.TempData["SuccessMessage"] = "Информация за прихода беше добавена успешно";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddCost()
        {
            var model = new CostFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCost(CostFormModel model)
        {
            var userId = this.User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await costService.AddCostAsync(model, userId);
            }
            catch
            {
                TempData["ErrorMessage"] = "Възникна грешка при добавянето на разхода. Моля, свържете се с администратор или опитайте по-късно!";
            }

            this.TempData["SuccessMessage"] = "Информация за разхода беше добавена успешно";

            return RedirectToAction("Index");
        }

    }
}