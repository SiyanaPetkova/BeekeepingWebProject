namespace Beekeeping.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Beekeeping.Models.Apiary;
    using Beekeeping.Web.Infrastructure.Extensions;

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