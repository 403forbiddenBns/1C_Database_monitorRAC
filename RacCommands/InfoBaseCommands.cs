using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacItems;

namespace RacCommands
{
    public class InfoBaseCommands
    {
        InfoBase IbInstance { get; set; }

        public InfoBaseCommands(InfoBase ibInstance)
        {
            IbInstance = ibInstance;
        }
    }
}
