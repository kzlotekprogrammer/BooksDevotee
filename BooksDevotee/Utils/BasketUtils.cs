using BooksDevotee.Models;
using BooksDevotee.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BooksDevotee.Utils
{
    public class BasketUtils
	{
        public static Basket GetOrCreateActiveBasket(IBasketRepository basketRepository,
                                                                 ApplicationUser applicationUser)
        {
            Basket basket = basketRepository.GetActiveBasketByUserName(applicationUser.Id);

            if (basket == null)
            {
                basket = new Basket()
                {
                    ApplicationUserId = applicationUser.Id,
                    CreationDate = DateTime.Now,
                    Status = BasketStatus.Active
                };
                basketRepository.AddBasket(basket);
            }

            return basket;
        }
    }
}
