using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacItems
{
    public class ClusterInitializer
    {
        RemoteAdminClient _rac { get; set; }

        public ClusterInitializer(RemoteAdminClient RAC)
        {
            _rac = RAC;
        }


        /// <summary>
        /// Fill list of clusters that exist on a server with ref="Cluster" instances.
        /// </summary>
        /// <returns></returns>
        public string Ininialize()
        {

            List<string> inputData = _rac.GetClusterListFromCmd().Split("\n").ToList<string>();
            
            if (inputData[0] == String.Empty)
            {
                return "Ошибка соединения. Программа завершает работу.";
            }

            //Removes last item that always empty.
            inputData.RemoveAt(inputData.Count - 1);

            //Cluster list return info about each cluster on server, so each cluster have 14 lines info and 1 divider line so its 15 lines for each clusters in general.
            int clusterInfoContainsLines = 15;
            int clusterCount = inputData.Count / clusterInfoContainsLines;

            for (int i = 0; i < clusterCount; i++)
            {
                string clusterId = inputData[0].Substring(32);

                string clusterName = inputData[3].Substring(33, inputData[3].Length - 35);
                
                string clusterHost = inputData[1].Substring(32);
                string clusterPort = inputData[2].Substring(32);

                _rac.ClusterRepository.Add(new Cluster(clusterId, clusterName, clusterHost, clusterPort));

                //Remove cluster info from temporary console output container that already appended to cluster repository.
                inputData.RemoveRange(0, clusterInfoContainsLines);
            }

            return $"Зарегистрировано кластеров: {_rac.ClusterRepository.Count} из {clusterCount}";
        }
    }
}
