using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RacItems;

namespace RacDataStorage
{
    public class InfoBaseStorage
    {
        public List<InfoBase> InfoBaseList { get; set; }

        public InfoBaseStorage()
        {
            InfoBaseList = new List<InfoBase>();
        }
    }
}
