using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacItems
{
    public class InfoBase
    {   
        /// <summary>
        /// Infobase ID.
        /// </summary>
        string Id { get; set; }
    
        /// <summary>
        /// Infobase Name.
        /// </summary>
        string Name { get; set; }

        public InfoBase(string id, string infobaseName)
        {
            Id = id;
            Name = infobaseName;
        }

        public override string ToString()
        {
            return $"| ID ИБ: " + new string(' ', 8)  + $"{Id}\n" +
                $"| Название ИБ: " + new string(' ', 2) + $"{Name}\n\n";
        }
    }
}
