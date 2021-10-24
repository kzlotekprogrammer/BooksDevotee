using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SDK.PayU;
using SDK.PayU.DTO;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BooksDevotee.Controllers
{
    public class PayUController : Controller
    {
        private string clientId;
        private string clientSecret;
        private Uri baseUri;

        public IConfiguration Configuration { get; }

        public PayUController(IConfiguration configuration)
        {
            Configuration = configuration;

            clientId = configuration.GetValue<string>("ClientId");
            clientSecret = configuration.GetValue<string>("ClientSecret");
            baseUri = new Uri(configuration.GetValue<string>("BaseUrlPayU"));
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Test()
        {
            PayUClient payUClient = new PayUClient(clientId, clientSecret, baseUri);

            HttpResponseMessage authRespMsg = await payUClient.Authorize();
            if (!authRespMsg.IsSuccessStatusCode)
                return RedirectToAction("error", "home");

            string authRespContent = await authRespMsg.Content.ReadAsStringAsync();
            AuthorizeResponseDTO authResp = JsonConvert.DeserializeObject<AuthorizeResponseDTO>(authRespContent);
            if (string.IsNullOrWhiteSpace(authResp?.token_type) || string.IsNullOrWhiteSpace(authResp?.token_type))
                return RedirectToAction("error", "home"); 
            string authParam = $"{authResp.token_type} {authResp.access_token}";

            HttpResponseMessage ordCreRespMsg = await payUClient.Test(authParam);
            if (ordCreRespMsg.StatusCode != System.Net.HttpStatusCode.Redirect)
                return RedirectToAction("error", "home");

            string contentStr = await ordCreRespMsg.Content.ReadAsStringAsync();
            OrderCreateResponseDTO ordCreResp = JsonConvert.DeserializeObject<OrderCreateResponseDTO>(contentStr);
            if (string.IsNullOrWhiteSpace(ordCreResp?.redirectUri))
                return RedirectToAction("error", "home");

            return Redirect(ordCreResp.redirectUri);
        }
    }
}
