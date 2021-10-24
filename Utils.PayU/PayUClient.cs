using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SDK.PayU.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SDK.PayU
{
    public class PayUClient
    {
        private readonly string urlAuthorize = @"pl/standard/user/oauth/authorize";
        private readonly string urlCreateOrder = @"api/v2_1/orders";

        private string clientId;
        private string clientSecret;
        private Uri baseUri;

        public PayUClient(string clientId, string clientSecret, Uri baseUri)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.baseUri = baseUri;
        }

        public async Task<HttpResponseMessage> Authorize()
        {
            Dictionary<string, string> authParams = new Dictionary<string, string>();
            authParams.Add("grant_type", "client_credentials");
            authParams.Add("client_id", clientId);
            authParams.Add("client_secret", clientSecret);

            return await HttpUtils.PostAsyncForm(new Uri(baseUri, urlAuthorize), authParams);
        }

        public async Task<HttpResponseMessage> Test(string authParam)
        {
            OrderCreateRequestDTO ordCreDTO = GenerateTestOrderCreationRequest();
            string json = JsonConvert.SerializeObject(ordCreDTO, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return await HttpUtils.PostAsyncJson(new Uri(baseUri, urlCreateOrder), json, authParam);
        }

        private OrderCreateRequestDTO GenerateTestOrderCreationRequest()
        {
            return new OrderCreateRequestDTO()
            {
                customerIp = "127.0.0.1",
                merchantPosId = 425673,
                description = "BooksDevotee",
                currencyCode = "PLN",
                totalAmount = 21000,
                buyer = new BuyerDTO()
                {
                    email = "jankowalski@gmail.com",
                    firstName = "Jan",
                    lastName = "Kowalski",
                    language = "pl",
                    phone = "123456789"
                },
                products = new List<ProductDTO>()
                {
                    new ProductDTO()
                    {
                       name = "Pan Tadeusz",
                       unitPrice = 15000,
                       quantity = 1
                    }
                }
            };
        }
    }
}
