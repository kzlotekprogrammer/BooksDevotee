using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BooksDevotee.Controllers
{
    public class BasketController : Controller
	{
        private readonly IConfiguration _config;

		public BasketController(IConfiguration config)
		{
			_config = config;
        }
		
		public IActionResult Show()
		{
			return View();
		}

		public IActionResult Add()
		{
			return View();
		}

		public IActionResult Clear()
		{
			return View();
		}
	}
}
