using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    class Room
    {
        public string title { get; set; }
        public string description { get; set; }
        public Room North { get; set; }
        public Room()
        {

        }
    }
}
