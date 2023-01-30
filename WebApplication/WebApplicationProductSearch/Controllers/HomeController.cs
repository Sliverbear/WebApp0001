using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationProductSearch.Models;
using Newtonsoft.Json;
using MVCLogic;

namespace WebApplicationProductSearch.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        LogicUser logicUser = new LogicUser();
        LogicGoods logicGoods= new LogicGoods();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutMe()
        {
            return View("Views/AboutMe/AboutMe.cshtml");


        }

        public IActionResult SearchProductLoginPage()
        {
            return View("Views/SearchProduct/SearchProductLoginPage.cshtml");
        }

		public IActionResult NormalLoginPage()
		{
			return View("Views/NormalLogin/NormalLoginPage.cshtml");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Login (string username, string password)
        {
            if( string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password))
            {
                return ErrorResult(" request failure ");
            }
            else
            {
                var data = logicUser.CheckLogin(username, password);

                if (data != null)
                {
					return SucrssResult("sucess!");

				}
				else
                {
                    return ErrorResult("failure");
                }
            }

        }

    }
}