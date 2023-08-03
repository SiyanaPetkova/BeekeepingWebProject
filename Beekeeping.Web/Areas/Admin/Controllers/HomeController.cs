namespace Beekeeping.Web.Areas.Admin.Controllers
{
    using Beekeeping.Data.Models;
    using Beekeeping.Models.Admin;
    using Beekeeping.Services.Interfaces;
    using Beekeeping.Services.Services;
    using Beekeeping.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using static Web.Areas.Admin.AdminConstants;
    using static Common.NotificationMessages.ErrorMessages;

    public class HomeController : AdminController
    {
        private readonly IAdminService adminService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(IAdminService adminService, UserManager<ApplicationUser> userManager)
        {
            this.adminService = adminService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var model = adminService.GetInformationAboutTheUsersAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin(string email)
        {
            var user = await userManager.FindByEmailAsync(email.ToUpper());

            if (user == null)
            {
                TempData["ErrorMessage"] = "Не съществува потребител с такъв e-mail.";

                return RedirectToAction("Index");
            }

            var result = await userManager.AddToRoleAsync(user, AdministratorRoleName);

            TempData["SuccessMessage"] = "Успешно добавихте нов администратор.";

            return RedirectToAction("AllAdmins");
        }

        public async Task<IActionResult> AllAdmins()
        {
            var adminUsers = await userManager.GetUsersInRoleAsync(AdministratorRoleName);

            var model = adminUsers.Select(a => new UserAdminModel()
            {
                Id = a.Id.ToString(),
                Email = a.Email,
                IsAdmin = true
            })
            .ToArray();

            return View(model);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var userId = this.User.Id();

            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                TempData["ErrorMessage"] = NotAuthorizedErrorMessage;

                return RedirectToAction("Index");
            }

            var isUserAdmin = await userManager.IsInRoleAsync(user, AdministratorRoleName);

            if (!isUserAdmin)
            {
                TempData["ErrorMessage"] = NotAuthorizedErrorMessage;

                return RedirectToAction("Index");
            }

            try
            {
                var userToRemove = await userManager.Users.FirstOrDefaultAsync(u => u.Id.ToString() == id);

                var result = await userManager.RemoveFromRoleAsync(userToRemove, AdministratorRoleName);

                TempData["SuccessMessage"] = "Успешно премахнахте потребителя от ролята на администратор.";

                return RedirectToAction("AllAdmins");

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = CommonErrorMessage;
            }

            return RedirectToAction("All");
        }
    }
}