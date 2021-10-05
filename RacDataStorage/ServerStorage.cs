using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacItems;

namespace RacDataStorage
{
    public class ServerStorage
    {
        List<Server> serverList { get; set; }

        public ServerStorage()
        {
            serverList = new List<Server>();
        }
    }
}
