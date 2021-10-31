using BooksDevotee.Models;
using BooksDevotee.Repositories;
using BooksDevotee.ViewModels.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace BooksDevotee.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository bookRepository;

        public HomeController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.BookList = bookRepository.GetAllBooks();
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            DetailsViewModel viewModel = new DetailsViewModel();
            viewModel.Book = bookRepository.GetBook(id);
            return View(viewModel);
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            EditViewModel viewModel = new EditViewModel();
            viewModel.Book = bookRepository.GetBook(id);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel viewModel)
        {
            ModelState.Remove("Book.BookId");

            if (ModelState.IsValid)
            {
                if (viewModel.FormFile != null)
                {
                    Image image = new Image();
                    image.FileName = viewModel.FormFile.FileName;

                    using (var memoryStream = new MemoryStream())
                    {
                        await viewModel.FormFile.CopyToAsync(memoryStream);

                        if (memoryStream.Length < 2097152)
                        {
                            image.ImageData = memoryStream.ToArray();
                        }
                        else
                        {
                            ModelState.AddModelError("File", "Plik jest zbyt duży!");
                            return View(viewModel);
                        }

                        viewModel.Book.Image = image;
                    }
                }

                if (viewModel.Book.BookId > 0)
                {
                    bookRepository.Update(viewModel.Book);
                }
                else
                {
                    bookRepository.Add(viewModel.Book);
                }

                return RedirectToAction("index", "home");
            }
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            bookRepository.Delete(id);
            return RedirectToAction("index", "home");
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
