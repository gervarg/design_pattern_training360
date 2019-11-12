using System;
using System.Collections.Generic;

namespace HttpConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var httpContext = new HttpContext();
            httpContext.GetSessionContext().Set("ProductId", "1001");

            DoSomething();
        }

        private static void DoSomething(IHttpContext httpContext)
        {

        }
    }

    internal interface IHttpContext
    {
    }

    class HttpContextWrapper : IHttpContext
    {

    }

    internal class HttpContext
    {
        public string User { get; set; } = Environment.UserName;

        public string Ver { get; set; } = "HTTP 1.1";

        public List<(string, string)> Variables { get; set; } = new List<(string, string)>



        public HttpContext()
        {
        }
    }
}
