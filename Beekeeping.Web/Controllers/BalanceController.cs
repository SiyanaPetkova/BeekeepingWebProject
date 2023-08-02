namespace Beekeeping.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Dynamic;

    using Models.Cost;
    using Models.Income;
    using Services.Interfaces;
    using Web.Infrastructure.Extensions;

    using static Common.NotificationMessages.ErrorMessages;

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

            var totalIncome = await incomeService.GetTotalIncomeAsync(userId);
            model.TotalIncome = totalIncome;

            var totalCost = await costService.GetTotalCostAsync(userId);
            model.TotalCost = totalCost;

            return View(model);
        }

        [HttpGet]
        public IActionResult AddIncome()
        {
            var model = new IncomeFormModel();

            model.DayOfTheIncome = DateTime.Now;

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
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            this.TempData["SuccessMessage"] = "Информация за прихода беше добавена успешно";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddCost()
        {
            var model = new CostFormModel();

            model.DayOfTheCost = DateTime.Now;

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
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            this.TempData["SuccessMessage"] = "Информация за разхода беше добавена успешно";

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteIncome(int id)
        {
            var userId = this.User.Id();

            bool incomeExists = await incomeService.DoesIncomeExists(userId, id);
            if (!incomeExists)
            {
                TempData["ErrorMessage"] = "Не съществува информация за този приход!";

                return this.RedirectToAction("Index");
            }

            try
            {
                await incomeService.DeleteIncomeAsync(userId, id);

                this.TempData["SuccessMessage"] = "Данните за прихода бяха изтрити успешно!";

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCost(int id)
        {
            var userId = this.User.Id();

            bool costExists = await costService.DoesCostExists(userId, id);
            if (!costExists)
            {
                TempData["ErrorMessage"] = "Не съществува информация за този разход!";

                return this.RedirectToAction("Index", "Home");
            }

            try
            {
                await costService.DeleteCostAsync(userId, id);

                this.TempData["SuccessMessage"] = "Данните за този разход бяха изтрити успешно!";

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return this.RedirectToAction("Index");
        }


    }
}