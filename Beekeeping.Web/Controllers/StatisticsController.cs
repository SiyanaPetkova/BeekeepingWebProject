namespace Beekeeping.Web.Controllers
{
    using Beekeeping.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;

    using Services.Interfaces;

    public class StatisticsController : Controller
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = this.User.Id();

            var model = await statisticsService.GetStatisticsForUserAsync(userId);

            return View(model);
        }
    }
}