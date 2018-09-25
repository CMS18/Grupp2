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
        Weapon axe = new Weapon(2, "Axe", "Tool to chop things.", 5, 25);

        public World()
        {
            // Rooms to use
            Room forest = new Room("Dark Forest", "There is an AXE on the floor. A TREE is in the way."); //starting out in forest with axe and tree to solve the uppgift - words in UpperCase have a meaning
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

            // Exits
            library.East = hallway; //Move to hallway
            forest.North = garden; //Move to garden

            library.AddItem(new Item(1, "Table", "This is a table made of cheap plastic.", 5));
            library.AddItem(new Item(1, "Chair", "This is an ugly chair.", 5));

            Weapon axe = new Weapon(2, "Axe", "Tool to chop things.", 5, 25);
            Armor armor = new Armor(12, "Hat","It's a fedora m'lady! *tips fedora*", 5, 1);

            library.AddItem(makeToLegendary(armor));
            library.AddItem(makeToLegendary(axe));
            Console.WriteLine(library.Description);
        }
        private Item makeToLegendary(Item item)
        {
            int randomLegendary = new Random().Next(1, 5);
            if (randomLegendary == 1)
            {
                item.Legendary = true;
                item.Name = "Legendary " + item.Name;
            }
            return item;
        }
    }
}
