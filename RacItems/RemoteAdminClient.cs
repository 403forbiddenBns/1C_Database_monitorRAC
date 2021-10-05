using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace RacItems
{
    public class RemoteAdminClient
    {
        /// <summary>
        /// Path to rac.exe file.
        /// </summary>
        public string Path { get; set; }

        public List<Cluster> ClusterRepository { get; set; }

        public List<Server> ServerRepository { get; set; }

        public List<InfoBase> InfobaseRepository { get; set; }


        /// <summary>
        /// Initialize with rac.exe path.
        /// </summary>
        /// <param name="pathToRacExe"></param>
        public RemoteAdminClient(string pathToRac)
        {
            Path = pathToRac;
            ClusterRepository = new List<Cluster>();
            ServerRepository = new List<Server>();
            InfobaseRepository = new List<InfoBase>();
        }
        
        /// <summary>
        /// Launch RAC with the specified argument.
        /// </summary>
        /// <param name="argument"></param>
        /// <returns></returns>
        public string LaunchRAC(string argument)
        {
            Process cmdOutputData = Process.Start(new ProcessStartInfo
            {
                FileName = Path,
                Arguments = argument,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true
            });

            return cmdOutputData.StandardOutput.ReadToEnd();
        }

        /// <summary>
        /// Get all cluster IDs on server
        /// </summary>
        /// <returns></returns>
        public List<string> GetClusterIDs()
        {
            string strOutput = GetClusterListFromCmd();

            string[] splittedLines = strOutput.Split($"\n");

            List<string> Idlines = new List<string>();

            foreach (var item in splittedLines)
            {
                if (item.Contains("cluster"))
                {
                    Idlines.Add(item.Substring(32, 36));
                }
            }

            return Idlines;
        }

        /// <summary>
        /// Full info about clusters (equals to cmd "rac cluster list")
        /// </summary>
        /// <returns></returns>
        public string GetClusterListFromCmd()
        {
            return LaunchRAC("cluster list");
        }

        /// <summary>
        /// Full info about servers (equal to cmd "rac sever list --cluster=%clusterID%"
        /// </summary>
        /// <param name="clusterId"></param>
        /// <returns></returns>
        public string GetServerListFromCmd(string clusterId)
        {
            return LaunchRAC($"server list --cluster={clusterId}");
        }

        /// <summary>
        /// Get short info about infobases (equal to cmd "rac infobase summary list --cluster%clusterId%")
        /// </summary>
        /// <param name="clusterId"></param>
        /// <returns></returns>
        public string GetInfoBaseListFromCmd(string clusterId)
        {
            return LaunchRAC($"infobase summary list --cluster={clusterId}");
        }


        /// <summary>
        /// Return formated info about each cluster.
        /// </summary>
        /// <returns></returns>
        public string ClustersToString()
        {
            StringBuilder stb = new StringBuilder();

            foreach (var cluster in ClusterRepository)
            {
                stb.Append(cluster.ToString());
            }

            return stb.ToString();
        }
        
        /// <summary>
        /// Return formatted info about each server.
        /// </summary>
        /// <returns></returns>
        public string ServersToString()
        {
            StringBuilder stb = new StringBuilder();

            foreach (var server in ServerRepository)
            {
                stb.Append(server.ToString());
            }

            return stb.ToString();
        }

        /// <summary>
        /// Return formated info baout each infobase.
        /// </summary>
        /// <returns></returns>
        public string InfoBasesToString()
        {
            StringBuilder stb = new StringBuilder();

            foreach (var infobase in InfobaseRepository)
            {
                stb.Append(infobase.ToString());
            }

            return stb.ToString();
        }
    }
}
