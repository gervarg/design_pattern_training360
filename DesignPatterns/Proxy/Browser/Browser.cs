using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Proxy
{
    interface IBrowser
    {
        Task<Response> Request(string url);
    }

    class Browser : IBrowser
    {
        // https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netcore-3.0
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<Response> Request(string url)
        {
            Response response = new Response();
            
            HttpResponseMessage httpResponse = await httpClient.GetAsync(url);
            
            response.StatusCode = (int)httpResponse.StatusCode;
            
            if (httpResponse.IsSuccessStatusCode)
            {
                response.Content = await httpResponse.Content.ReadAsStringAsync();
            }

            return response;
        }
    }

    class BrowserProxy : IBrowser
    {
        private readonly Browser browser = new Browser();

        public async Task<Response> Request(string url)
        {
            string host = new Uri(url).Host ?? string.Empty;
            
            if (host.Contains("facebook.com", StringComparison.OrdinalIgnoreCase))
            {
                return new Response { StatusCode = 403, Content = "FORBIDDEN" };
            }
            else
            {
                return await browser.Request(url);
            }
        }
    }
}
