using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class HttpUtils
    {
        public static async Task<HttpResponseMessage> PostAsyncForm(Uri uri, Dictionary<string, string> parameters)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri) { Content = new FormUrlEncodedContent(parameters) };
                return await client.SendAsync(req);
            }
        }

        public static async Task<HttpResponseMessage> PostAsyncJson(Uri uri, string jsonContent, string authParam)
        {
            using (HttpClientHandler handler = new HttpClientHandler() { AllowAutoRedirect = false })
            {
                using (HttpClient client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);
                    request.Headers.Add("Authorization", authParam);
                    request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    return await client.SendAsync(request);
                }
            }            
        }
    }
}
