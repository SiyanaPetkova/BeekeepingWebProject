namespace Beekeeping.Web.Controllers
{
    using Beekeeping.Models.Cost;
    using Beekeeping.Models.Income;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Dynamic;

    [Authorize]
    public class BalanceController : Controller
    {

        public IActionResult Index()
        {
            //dynamic model = new ExpandoObject();

            //model.Income = 
            //model.Cost = ;
            return View();
        }
    }
}