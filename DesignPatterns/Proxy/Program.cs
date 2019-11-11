using System;
using System.Threading.Tasks;

namespace Proxy
{
    // Summary:
    // A proxy is a wrapper or agent object that is being called by the client 
    // to access the real serving object behind the scenes. Use of the proxy 
    // can simply be forwarding to the real object, or can provide additional logic. 
    // In the proxy extra functionality can be provided, for example 
    // caching when operations on the real object are resource intensive, or 
    // checking preconditions before operations on the real object are invoked.
    class Program
    {
        static async Task Main(string[] args)
        {
            // 1. Security door
            var door = new Security(new LabDoor());
            door.Open("invalid"); // Big no! It ain't possible.

            door.Open("$ecr@t"); // Opening lab door
            door.Close(); // Closing lab door

            Console.WriteLine();



            // 2. Browser example
            IBrowser browser = new Browser();
            //IBrowser browser = new BrowserProxy();

            Console.WriteLine("Download data from facebook");
            Response response1 = await browser.Request("https://www.facebook.com");
            Console.WriteLine(response1);

            Console.WriteLine("Download data from google");
            Response response2 = await browser.Request("https://www.google.com");            
            Console.WriteLine(response2);

            // 3. Throttling
        }
    }
}
