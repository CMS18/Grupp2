using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    class World
    {
        //List<Room> rooms = new List<Room>();
        public World()
        {
            Room forest = new Room("Title", "Description"); //starting out in forest with axe and tree to solve the uppgift

            Room library = new Room("Title", "Description");

            Room hall = new Room("Title", "Description");

            library.East = hall;

        }
    }
}
