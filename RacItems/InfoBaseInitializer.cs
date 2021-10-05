using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacItems
{
    public class InfoBaseInitializer
    {
        RemoteAdminClient _rac { get; set; }

        public InfoBaseInitializer(RemoteAdminClient rac)
        {
            _rac = rac;
        }

        public string Initialize()
        {
            if (_rac.ClusterRepository.Count < 1)
                return "Кластеры не обнаружены";

            List<string> clusterIdList = _rac.GetClusterIDs();

            //Each infobase info output have 3 line of info and 1 divider line.
            int infoBaseInfoContainsLines = 3 + 1;

            //Count of infobase that cluster contains (will be increased during execution).
            int processedInfoBases = 0;

            foreach (var clusterId in clusterIdList)
            {
                List<string> inputData = _rac.GetInfoBaseListFromCmd(clusterId)
                    .Split("\n")
                    .ToList<string>();

                //Removes last item that always empty.
                inputData.RemoveAt(inputData.Count - 1);

                //Count of infobases discovered on server.
                int discoveredInfoBases = inputData.Count / infoBaseInfoContainsLines;

                for (int i = 0; i < discoveredInfoBases; i++)
                {
                    string infobaseId = inputData[0].Substring(11);
                    string infobaseName = inputData[1].Substring(11);
                    _rac.InfobaseRepository.Add(new InfoBase(infobaseId, infobaseName));

                    //Increase counter cause added infobase.
                    processedInfoBases += 1;

                    //Remove infobase from console output container that already appended to server repository.
                    inputData.RemoveRange(0, infoBaseInfoContainsLines);
                }
            }

            return $"Зарегистрировано информационных баз: {_rac.InfobaseRepository.Count} из {processedInfoBases}";
        }
    }
}
