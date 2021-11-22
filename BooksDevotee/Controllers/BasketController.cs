using BooksDevotee.Models;
using BooksDevotee.Repositories;
using BooksDevotee.Utils;
using BooksDevotee.ViewModels.Basket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BooksDevotee.Controllers
{
	[Authorize]
	public class BasketController : Controller
	{
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBasketRepository basketRepository;

        public BasketController(UserManager<ApplicationUser> userManager, IBasketRepository basketRepository)
		{
            this.userManager = userManager;
            this.basketRepository = basketRepository;
        }

		public async Task<IActionResult> ShowAsync()
		{
			//ToDo koszyk jest pusty
			ApplicationUser applicationUser = await userManager.GetUserAsync(User);
			Basket basket = BasketUtils.GetOrCreateActiveBasket(basketRepository, applicationUser);

			ShowViewModel viewModel = new ShowViewModel()
			{
				ActiveBasket = basketRepository.GetBasketDataById(basket.BasketId)
			};

			return View(viewModel);
		}

		public async Task<IActionResult> AddOneBookAsync(int bookId)
		{
			ApplicationUser applicationUser = await userManager.GetUserAsync(User);
			Basket basket = BasketUtils.GetOrCreateActiveBasket(basketRepository, applicationUser);

			BasketBook basketBook = basketRepository.GetBasketBook(basket.BasketId, bookId);
			if (basketBook == null)
            {
				basketBook = new BasketBook()
				{
					BasketId = basket.BasketId,
					BookId = bookId,
					Quantity = 1
				};
				basketRepository.AddBasketBook(basketBook);
            }
            else
            {
				basketBook.Quantity++;
				basketRepository.UpdateBasketBook(basketBook);
			}

			return RedirectToAction("show");
		}

		public async Task<IActionResult> RemoveOneBookAsync(int bookId)
		{
			ApplicationUser applicationUser = await userManager.GetUserAsync(User);
			Basket basket = BasketUtils.GetOrCreateActiveBasket(basketRepository, applicationUser);

			BasketBook basketBook = basketRepository.GetBasketBook(basket.BasketId, bookId);
			if (basketBook != null && basketBook.Quantity > 0)
			{
				basketBook.Quantity--;

				if (basketBook.Quantity > 0)
					basketRepository.UpdateBasketBook(basketBook);
				else
					basketRepository.DeleteBasketBook(basketBook.BasketId, basketBook.BookId);
			}

			return RedirectToAction("show");
		}

		public async Task<IActionResult> RemoveAllBook(int bookId)
		{
			ApplicationUser applicationUser = await userManager.GetUserAsync(User);
			Basket basket = BasketUtils.GetOrCreateActiveBasket(basketRepository, applicationUser);

			BasketBook basketBook = basketRepository.GetBasketBook(basket.BasketId, bookId);
			if (basketBook != null && basketBook.Quantity > 0)
			{
				basketRepository.DeleteBasketBook(basketBook.BasketId, basketBook.BookId);
			}

			return RedirectToAction("show");
		}
	}
}
