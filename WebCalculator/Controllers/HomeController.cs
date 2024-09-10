using Microsoft.AspNetCore.Mvc;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateExpression(string expression)
        {
            try
            {

                return View("Index", expression);
            }
            catch(Exception ex) 
            {
                return View("Index", ex.Message);
            }
        }
    }
}
