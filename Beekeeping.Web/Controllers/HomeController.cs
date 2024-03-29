﻿namespace Beekeeping.Web.Controllers
{
    using Beekeeping.Services.Interfaces;
    using Beekeeping.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models.Errors;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly INoteToDoService noteService;

        public HomeController(ILogger<HomeController> logger,
                              INoteToDoService noteService)
        {
            this.logger = logger;
            this.noteService = noteService;

        }

        public async Task<IActionResult> Index()
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                var userId = User.Id();
                var tasksCount = await noteService.DoesUserHasNotFinishedTasks(userId);

                if (tasksCount > 0)
                {
                    var taskMessage = $"Вие имате {tasksCount} незавършени задачи!";
                    TempData["InformationMessage"] = taskMessage;
                }
            }

            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            ViewBag.StatusCode = statusCode;

            return View();
        }
    }
}