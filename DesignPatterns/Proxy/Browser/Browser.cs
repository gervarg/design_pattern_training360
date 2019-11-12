using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
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

    class ThrottlingProxy : IBrowser
    {
        private readonly IBrowser browser = new BrowserProxy();

        private int counter = 0;

        private readonly Timer timer;

        public ThrottlingProxy()
        {
            timer = new Timer(ResetCounter, state: null, dueTime: 1_000, period: 1_000);
        }

        private void ResetCounter(object state)
        {
            counter = 0;
        }

        public Task<Response> Request(string url)
        {
            if (counter <= 5)
            {
                return browser.Request(url);
            }
            else
            {
                return new Task.FromResult(new Response({ StatusCode: 503, Content = "Service Unavailable" }));
            }
        }
    }
}
