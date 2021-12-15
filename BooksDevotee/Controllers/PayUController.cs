using BooksDevotee.Models;
using BooksDevotee.Repositories;
using BooksDevotee.Utils;
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SDK.PayU;
using SDK.PayU.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace BooksDevotee.Controllers
{
    [Authorize]
    public class PayUController : Controller
    {
        private readonly string clientId;
        private readonly string clientSecret;
        private readonly string secondKey;
        private readonly int merchantPosId;
        private readonly Uri baseUri;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBasketRepository basketRepository;

        public IConfiguration Configuration { get; }
        public readonly string STATUS_COMPLETED = "COMPLETED";

        public PayUController(IConfiguration configuration, 
                              UserManager<ApplicationUser> userManager, 
                              IBasketRepository basketRepository)
        {
            Configuration = configuration;
            this.userManager = userManager;
            this.basketRepository = basketRepository;
            clientId = configuration.GetValue<string>("ClientId");
            clientSecret = configuration.GetValue<string>("ClientSecret");
            secondKey = configuration.GetValue<string>("SecondKey");
            baseUri = new Uri(configuration.GetValue<string>("BaseUrlPayU"));
            merchantPosId = configuration.GetValue<int>("MerchantPosId");
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Test()
        {
            PayUClient payUClient = new PayUClient(clientId, clientSecret, baseUri);

            await payUClient.Authorize();

            //ToDo
            HttpResponseMessage ordCreRespMsg = await payUClient.Test();
            if (ordCreRespMsg.StatusCode != System.Net.HttpStatusCode.Redirect)
                return RedirectToAction("error", "home");

            string contentStr = await ordCreRespMsg.Content.ReadAsStringAsync();
            OrderCreateResponseDTO ordCreResp = JsonConvert.DeserializeObject<OrderCreateResponseDTO>(contentStr);
            if (string.IsNullOrWhiteSpace(ordCreResp?.redirectUri))
                return RedirectToAction("error", "home");

            return Redirect(ordCreResp.redirectUri);
        }

        public async Task<IActionResult> CreateOrder()
        {
            PayUClient payUClient = new PayUClient(clientId, clientSecret, baseUri);

            ApplicationUser applicationUser = await userManager.GetUserAsync(User);
            Basket basket = BasketUtils.GetOrCreateActiveBasket(basketRepository, applicationUser);
            if (basket == null)
                return RedirectToAction("index", "home");

            basket = basketRepository.GetBasketDataById(basket.BasketId);
            if (basket.BasketBooks.Count == 0)
                return RedirectToAction("index", "home");

            await payUClient.Authorize();

            List<ProductDTO> books = new List<ProductDTO>();
            int totalPrice = 0;
            foreach (BasketBook basketBook in basket.BasketBooks)
            {
                Book book = basketBook.Book;
                int price = (int)(book.Price * 100 * basketBook.Quantity);
                totalPrice += price;

                books.Add(new ProductDTO()
                {
                    name = book.Title,
                    unitPrice = price,
                    quantity = basketBook.Quantity
                });
            }

            OrderCreateRequestDTO ordCreDTO = new OrderCreateRequestDTO()
            {
                extOrderId = basket.BasketId.ToString(),
                notifyUrl = "https://booksdevotee.azurewebsites.net/PayU/Notification/",
                customerIp = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                merchantPosId = merchantPosId,
                description = "BooksDevotee",
                currencyCode = "PLN",
                totalAmount = totalPrice,
                continueUrl = "https://booksdevotee.azurewebsites.net/",
                buyer = new BuyerDTO()
                {

                    email = applicationUser.Email,
                    firstName = applicationUser.FirstName,
                    lastName = applicationUser.LastName,
                    language = "pl",
                    phone = applicationUser.PhoneNumber
                },
                products = books
            };

            CreateOrderResult ordCreResult = await payUClient.CreateOrder(ordCreDTO);

            basket.Status = BasketStatus.InTransaction;
            basket.PaymentDate = DateTime.Now;
            basketRepository.UpdateBasket(basket);

            return Redirect(ordCreResult.ResponseDTO.redirectUri);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Notification()
        {
            string body;
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                body = await reader.ReadToEndAsync();
            }

            string opnPaSign = Request.Headers["OpenPayu-Signature"];
            string signature = opnPaSign.Split(";").FirstOrDefault(x => x.StartsWith("signature")).Replace("signature=", "");
            if (CryptoUtils.CalculateExpectedSignature(body + secondKey).Equals(signature, StringComparison.InvariantCultureIgnoreCase))
            {
                return BadRequest();
            }

            NotificationDTO notificationDTO = JsonConvert.DeserializeObject<NotificationDTO>(body);
            if (notificationDTO.order.status != STATUS_COMPLETED)
            {
                int basketId = int.Parse(notificationDTO.order.extOrderId);
                Basket basket = basketRepository.GetBasketById(basketId);

                if (basket == null)
                {
                    return BadRequest();
                }

                basket.Status = BasketStatus.Paid;
                basket.PaymentDate = DateTime.Now;
                basketRepository.UpdateBasket(basket);
            }

            return Ok();
        }
    }
}
