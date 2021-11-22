using Common;
using Newtonsoft.Json;
using SDK.PayU.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SDK.PayU
{
    public class PayUClient
    {
        private readonly string urlAuthorize = @"pl/standard/user/oauth/authorize";
        private readonly string urlCreateOrder = @"api/v2_1/orders";

        private readonly string clientId;
        private readonly string clientSecret;
        private readonly Uri baseUri;

        private string authParam;

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

            HttpResponseMessage authRespMsg = await HttpUtils.PostAsyncForm(new Uri(baseUri, urlAuthorize), authParams);
            if (!authRespMsg.IsSuccessStatusCode)
                throw new Exception("Authorization error");

            string authRespContent = await authRespMsg.Content.ReadAsStringAsync();
            AuthorizeResponseDTO authResp = JsonConvert.DeserializeObject<AuthorizeResponseDTO>(authRespContent);
            if (string.IsNullOrWhiteSpace(authResp?.token_type) || string.IsNullOrWhiteSpace(authResp?.token_type))
                throw new Exception("Missing authorization parameters");

            authParam = $"{authResp.token_type} {authResp.access_token}";

            return authRespMsg;
        }

        public async Task<HttpResponseMessage> Test()
        {
            OrderCreateRequestDTO ordCreDTO = GenerateTestOrderCreationRequest();
            string json = JsonConvert.SerializeObject(ordCreDTO, Formatting.Indented, GetJsonSerializerSettings());
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

        public async Task<CreateOrderResult> CreateOrder(OrderCreateRequestDTO ordCreDTO)
        {
            string json = JsonConvert.SerializeObject(ordCreDTO, Formatting.Indented, GetJsonSerializerSettings());
            Uri uri = new Uri(baseUri, urlCreateOrder);
            HttpResponseMessage ordCreRespMsg = await HttpUtils.PostAsyncJson(uri, json, authParam);

            if (ordCreRespMsg.StatusCode != System.Net.HttpStatusCode.Redirect)
                throw new Exception("Invalid status code");

            string contentStr = await ordCreRespMsg.Content.ReadAsStringAsync();
            OrderCreateResponseDTO ordCreResp = JsonConvert.DeserializeObject<OrderCreateResponseDTO>(contentStr);
            if (string.IsNullOrWhiteSpace(ordCreResp?.redirectUri))
                throw new Exception("Missing PayU redirection url");

            CreateOrderResult creOrdResult = new CreateOrderResult()
            {
                ResponseMessage = ordCreRespMsg,
                ResponseDTO = ordCreResp
            };

            return creOrdResult;
        }

        private JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }
    }
}
