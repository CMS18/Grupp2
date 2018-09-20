using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    class Room
    {
        //Properties that's needed
        public string Title { get; set; }
        public string Description { get; set; }

        //Possible exits 
        public Room North { get; set; }
        public Room East { get; set; }
        public Room South { get; set; }
        public Room West { get; set; }

        public Room(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
