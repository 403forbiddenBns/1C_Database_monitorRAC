using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacItems
{
    public class Server
    {
        
        /// <summary>
        /// Server ID.
        /// </summary>
        string Id { get; set; }
        
        /// <summary>
        /// Server agent host.
        /// </summary>
        string AgentHost { get; set; }
        
        /// <summary>
        /// Server agent port.
        /// </summary>
        string AgentPort { get; set; }
        
        /// <summary>
        /// Server name.
        /// </summary>
        string Name { get; set; }
        
        /// <summary>
        /// Server using mode.
        /// </summary>
        string ServerUsing { get; set; }

        /// <summary>
        /// Cluster ID wich server belongs.
        /// </summary>
        string ClusterId { get; set; }

        public Server(string serverId, string agentHost, string agentPort, string serverName, string serverUsing, string clusterId)
        {
            Id = serverId;
            AgentHost = agentHost;
            AgentPort = agentPort;
            Name = serverName;
            ServerUsing = serverUsing;
            ClusterId = clusterId;
        }

        /// <summary>
        /// Return formated content of each field of class.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"| ID Севрвера:" + new string(' ', 10) + $"{Id}\n" +
                "| Имя сеовеоа: " + new string(' ', 9) + $"{ Name}\n" +
                "| Хост агента: " + new string(' ', 9) + $"{AgentHost}\n" +
                "| Порт агента: " + new string(' ', 9) + $"{AgentPort}\n" +
                "| Режим использования: " + new string(' ', 1) + $"{ServerUsing}\n" +
                "| ID кластера сервера: " + new string(' ', 1) + $"{ClusterId}\n\n";
        }
    }
}
