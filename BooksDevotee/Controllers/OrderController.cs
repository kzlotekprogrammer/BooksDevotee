using BooksDevotee.Models;
using BooksDevotee.Repositories;
using BooksDevotee.ViewModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BooksDevotee.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class OrderController : Controller
    {
        private readonly IBasketRepository basketRepository;

        public OrderController(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            ListViewModel viewModel = new ListViewModel()
            {
                baskets = basketRepository.GetAllOrders()
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            DetailsViewModel viewModel = new DetailsViewModel() 
            {
                OrderData = basketRepository.GetBasketDataById(id) 
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Details(DetailsViewModel viewModel)
        {
            Basket order = basketRepository.GetBasketById(viewModel.OrderData.BasketId);
            order.Status = viewModel.OrderData.Status;

            if (order.Status == BasketStatus.Sent)
            {
                order.SentDate = DateTime.Now;
                if (!order.PreparedDate.HasValue)
                    order.PreparedDate = order.SentDate;
                order.CancelDate = null;
            }
            else if (order.Status == BasketStatus.Prepared)
            {
                order.SentDate = null;
                order.PreparedDate = DateTime.Now;
                order.CancelDate = null;
            }
            else if (order.Status == BasketStatus.Paid)
            {
                order.SentDate = null;
                order.CancelDate = null;
                order.PreparedDate = null;
            }
            else if (order.Status == BasketStatus.Canceled)
            {
                order.CancelDate = DateTime.Now;
            }

            basketRepository.UpdateBasket(order);

            viewModel.OrderData = basketRepository.GetBasketDataById(viewModel.OrderData.BasketId);
            return View(viewModel);
        }
    }
}
