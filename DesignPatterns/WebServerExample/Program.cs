using System;
using System.Collections.Generic;

namespace WebServerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var webServers = new List<WebServer>();
            var webServer = new WebServer();
            for (int i = 0; i < 10; i++)
            {

            }
            Console.WriteLine("Hello World!");
        }
    }

    class WebServer
    {
        public string DockerImage { get; }
        public int RamInMb { get; }

        public string[] Drivers { get; private set; }

        public string Processor { get; private set; }

        public string[] EthernetAdapters { get; private set; }

        private string Locale;

        public WebServer(string dockerImage, int ramInMb, string[] drivers, string processor, string[] ethernetAdapters, string locale = "en-US")
        {
            LoadFrom(dockerImage);
        }

        public WebServer(WebServerBuilder builder)
        {
            DockerImage = builder.DockerImage;
            RamInMb = builder.RamInMb;
            Drivers = builder.Drivers;
            Processor = builder.Processor;
            EthernetAdapters = builder.EthernetAdapters;
            Locale = builder.Locale;
        }

        private void LoadFrom(string dockerImage)
        {
            Console.WriteLine($"Load from {dockerImage}");
            System.Threading.Thread.Sleep(10_000);
        }
    }

    class WebServerBuilder
    {
        public string DockerImage { get; }
        public int RamInMb { get; private set; }

        public string[] Drivers { get; private set; }

        public string Processor { get; private set; }

        public string[] EthernetAdapters { get; private set; }

        public string Locale { get; }

        public WebServerBuilder(string dockerImage)
        {
            DockerImage = dockerImage;
            Locale = "en-Us";
        }

        public WebServerBuilder AddRam(int ram)
        {
            RamInMb = ram;
            return this;
        }

        public WebServerBuilder AddDrivers(string[] drivers)
        {
            Drivers = drivers;
            return this;
        }

        public WebServerBuilder AddProcessor(string processor)
        {
            Processor = processor;
            return this;
        }

        public WebServerBuilder AddEthernetAdapters(string[] adapters)
        {
            EthernetAdapters = adapters;
            return this;
        }

        public WebServer Build()
        {
            return new WebServer(this);
        }

                     

    }
}
