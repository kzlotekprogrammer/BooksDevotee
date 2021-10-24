using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BooksDevotee.Controllers
{
    public class PaymentController : Controller
	{
        private readonly IConfiguration _config;

		public PaymentController(IConfiguration config)
		{
			_config = config;
        }
		public IActionResult Basket()
		{
			return View();
		}

		public IActionResult Transaction()
        {
			return View();
        }
	}
}
