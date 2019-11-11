using System;
using System.Net;

namespace Proxy
{
    internal class Response
    {
        public int StatusCode { get; internal set; }
        public string Content { get; internal set; }

        public override string ToString()
        {
            return $@"{StatusCode} {Content.Substring(0, Math.Min(Content.Length, 100))}
";
        }
    }
}