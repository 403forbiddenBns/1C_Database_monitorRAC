using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacItems
{
    public class ServerInitializer
    {
        RemoteAdminClient _rac { get; set; }

        public ServerInitializer(RemoteAdminClient rac)
        {
            _rac = rac;
        }

        public string Initialize()
        {
            if (_rac.ClusterRepository.Count  < 1)
                return "Кластеры не обнаружены";

            List<string> clusterIdList = _rac.GetClusterIDs();

            //Each server info output have 15 line of info, one empty line and one divider line.
            int ServerInfoContainsLines = 15 + 2;

            //Counter of servers that processed (will be increased during execution).
            int processedServers = 0;

            foreach (var clusterId in clusterIdList)
            {
                //Get server info, divide, and assign each line to list elements.
                List<string> inputData = _rac.GetServerListFromCmd(clusterId)
                    .Split("\n")
                    .ToList<string>();
                
                //Removes last item that always empty.
                inputData.RemoveAt(inputData.Count - 1);

                //Count of servers from output data
                int serversDiscoveredOnCluster = inputData.Count / ServerInfoContainsLines;

                for (int i = 0; i < serversDiscoveredOnCluster; i++)
                {
                    string serverId = inputData[0].Substring(44);
                    string agentHost = inputData[1].Substring(44);
                    string agentPort = inputData[2].Substring(44);
                    
                    string serverName = inputData[4].Substring(45, inputData[4].Length - 47);
                    string serverUsing = inputData[5].Substring(44);

                    //Add new server to server repository.
                    _rac.ServerRepository.Add(new Server(serverId, agentHost, agentPort, serverName, serverUsing, clusterId));
                    
                    //Increase counter cause added server.
                    processedServers += 1;

                    //Remove server info from console output container that already appended to server repository.
                    inputData.RemoveRange(0, ServerInfoContainsLines);
                }
            }
            
            return $"Зарегистрировано серверов: {_rac.ServerRepository.Count} из {processedServers}";
        }
    }
}
