using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    public class World
    {
        //List<Room> rooms = new List<Room>();
        public World()
        {
            
            Room forest = new Room("Dark Forest", "There is an AXE on the floor. A TREE is in the way."); //starting out in forest with axe and tree to solve the uppgift - words in UpperCase have a meaning

            Room garden = new Room("Garden", "Description");

            Room garage = new Room("Garage", "Description");

            Room library = new Room("Library", "Description");

            Room hall = new Room("Hall", "Description");

            Room kitchen = new Room("Kitchen", "Description");

            Room masterBedroom = new Room("Master Bedroom", "Description");

            Room toilet = new Room("Toilet", "Description");

            Room bathRoom = new Room("Bathroom", "Description");

            Room diningRoom = new Room("Dining Room", "Description");

            Room guestRoom = new Room("Guest Room", "Description");

            library.East = hall;

            forest.North = garden;

        }
    }
}
