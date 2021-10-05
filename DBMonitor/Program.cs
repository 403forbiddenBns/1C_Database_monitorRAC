using System;
using System.Collections.Generic;
using RacItems;
using RacCommands;
using System.Linq;
using System.IO;

namespace DBMonitor
{
    public class Program
    {
        //Path to rac.exe //todo:change path after tests.
        static string path = $"C:\\Program Files\\1cv8\\8.3.18.1289\\bin\\rac.exe";
        
        static public string clusterIniStatus = "Нет данных";
        static public string serverIniStatus = "Нет данных";
        static public string infobaseIniStatus = "Нет данных";
        
        static void Main()
        {
            RemoteAdminClient rac = new RemoteAdminClient(path);



            ClusterInitializer clusterIni = new ClusterInitializer(rac);
            clusterIniStatus = clusterIni.Ininialize();
            Console.WriteLine(clusterIniStatus);
                    //Close application if application can't establish connection.
                    if (clusterIniStatus == "Ошибка соединения. Программа завершает работу.")
                    {
                        return;
                    }
            Console.WriteLine(rac.ClustersToString());

            ServerInitializer serverIni = new ServerInitializer(rac);
            serverIniStatus = serverIni.Initialize();
            Console.WriteLine(serverIniStatus);
            Console.WriteLine(rac.ServersToString());

            InfoBaseInitializer infobaseIni = new InfoBaseInitializer(rac);
            infobaseIniStatus = infobaseIni.Initialize();
            Console.WriteLine(infobaseIniStatus);
            Console.WriteLine(rac.InfoBasesToString());
        }


    }
}
