namespace Beekeeping.Test.Controllers
{
    using Web.Controllers;

    using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

    internal class HomeControllerTests
    {
        private HomeController homeController;
       
        [OneTimeSetUp]
        public void SetUp()
        {
            homeController = new HomeController(logger: null);
        }

        [Test]
        public void HomeControllerActionIndexShouldReturnIndexViewResult()
        {           
            var result = homeController.View();
            var viewResult = result as ViewResult;

            Assert.That(viewResult, Is.Not.Null);       
        }
    }
}