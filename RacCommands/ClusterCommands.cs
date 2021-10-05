using System;
using System.Collections.Generic;
using RacItems;

namespace RacCommands
{
    public class ClusterCommands
    {
        RemoteAdminClient _rac { get; set; }
        
        public ClusterCommands(RemoteAdminClient rac)
        {
            _rac = rac;
        }

    }
}
