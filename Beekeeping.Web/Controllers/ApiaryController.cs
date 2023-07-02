namespace Beekeeping.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Beekeeping.Web.Extensions;
    using Beekeeping.Models.Apiary;

    [Authorize]
    public class ApiaryController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            var model = new ApiaryFormModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ApiaryFormModel model)
        {
            var userId = this.User.Id;
                      
            return View(model);
        }
    }
}