using BooksDevotee.Models;
using BooksDevotee.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BooksDevotee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IBookRepository bookRepository;

        public HomeController(ILogger<HomeController> logger, IBookRepository bookRepository)
        {
            this.logger = logger;
            this.bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            return View(bookRepository.GetAllBooks());
        }

        public IActionResult Details(int id)
        {
            return View(bookRepository.GetBook(id));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
