using RacItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacCommands
{
    public class ServerCommands
    {
        Server ServerInstance { get; set; }

        public ServerCommands(Server serverInstance)
        {
            ServerInstance = serverInstance;
        }
    }
}
