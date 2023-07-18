namespace Beekeeping.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class FeedingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}