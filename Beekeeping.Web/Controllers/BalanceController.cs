namespace Beekeeping.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class BalanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}