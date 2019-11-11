using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Iterator
{
    // https://stackoverflow.com/questions/4972170/difference-between-ienumerable-and-ienumerablet
    class WebFarm : IEnumerable<Server>
    {
        private readonly List<Server> servers = new List<Server>();

        public void AddServer(Server server)
        {
            servers.Add(server);
        }

        #region IEnumerable<Server>

        public IEnumerator<Server> GetEnumerator()
        {
            return servers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return servers.GetEnumerator();
        }

        #endregion

        #region Custom iterator

        public IEnumerator<Server> GetCustomEnumerator()
        {
            List<Server> mediumServers = servers.Where(s => s.ServerCategory == Server.Category.Medium).ToList();
            return mediumServers.GetEnumerator();
        }

        #endregion
    }

    class Server
    {
        public Server(string name, string ipAddress, Category category)
        {
            Name = name;
            IpAddress = ipAddress;
            ServerCategory = category;
        }

        public string Name { get; }
        public string IpAddress { get; }
        public Category ServerCategory { get; }

        public override string ToString()
        {
            return $"{Name,-15}{IpAddress,-15}{ServerCategory}";
        }

        public enum Category { Low, Medium, High }
    }
}
