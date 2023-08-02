namespace Beekeeping.Web.Areas.Admin.Controllers
{
    using Beekeeping.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : AdminController
    {
        private readonly IAdminService adminService;

        public HomeController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public IActionResult Index()
        {
            var model = adminService.GetInformationAboutTheUsersAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MakeAdmin()
        {
            return View();
        }
    }
}