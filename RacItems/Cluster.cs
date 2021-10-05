using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacItems
{
    public class Cluster
    {

        /// <summary>
        /// Cluster ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Cluster name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cluster host.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Cluster port.
        /// </summary>
        public string Port { get; set; }

        public Cluster(string clusterId, string name, string host, string port)
        {
            Id = clusterId;
            Name = name;
            Host = host;
            Port = port;
        }

        /// <summary>
        /// Return formated content of each field of class.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"| Кластер:" + new string(' ', 10) + $"{Id}\n" + 
                "| Имя кластера:" + new string(' ', 5) + $"{Name}\n" +
                "| Хост кластера:" + new string(' ', 4) + $"{Host}\n" +
                "| Порт кластера:"+ new string(' ', 4) + $"{Port}\n\n";
        }
    }
}
