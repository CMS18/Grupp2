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
        static Random rnd = new Random();
        int randomLegendary = rnd.Next(1, 101);

        Weapon legendary = new Weapon(1, "Legendary!", "It's a Legendary ", 100);
        Weapon axe = new Weapon(2, "Axe", "Tool to chop things.", 5);



        public World()
        {
            Room forest = new Room("Dark Forest", "You can see a house behind the THICKET covering the NORTH exit. There is an AXE on the floor. There are no other exits."); //starting out in forest with axe and tree to solve the uppgift - words in UpperCase have a meaning

            Room garden = new Room("Garden", "Description");

            Room garage = new Room("Garage", "Description");

            Room library = new Room("Library", "Description");

            Room hallway = new Room("Hall", "Description");

            Room kitchen = new Room("Kitchen", "Description");

            Room masterBedroom = new Room("Master Bedroom", "Description");

            Room toilet = new Room("Toilet", "Description");

            Room bathRoom = new Room("Bathroom", "Description");

            Room diningRoom = new Room("Dining Room", "Description");

            Room guestRoom = new Room("Guest Room", "Description");

            library.East = hallway; //Move to hallway
            hallway.West = library; //Move to library
            hallway.South = garden; //Move to gareden
            forest.North = garden; //Move to garden
            garden.South = forest; //Move to forest
            garden.North = hallway; //move to hallway

        }
    }
}
