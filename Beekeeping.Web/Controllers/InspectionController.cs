namespace Beekeeping.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class InspectionController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}