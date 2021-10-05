using System;
using System.Collections.Generic;
using RacItems;

namespace RacDataStorage
{
    public class ClusterStorage
    {
        public List<Cluster> clusterList { get; set; }

        public ClusterStorage()
        {
            clusterList = new List<Cluster>();
        }
    }
}
