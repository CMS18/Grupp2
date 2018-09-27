using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace Uppgift3
{
    public class World
    {
        List<Room> rooms = new List<Room>();
        public Room CurrentRoom { get; set; }
        Random rnd = new Random();

        public World()
        {
            // Rooms to use
            Room alleyway =
                new Room("Dimmed alleyway", "The dingy alleyway reeks of the sour relics from a thousand take-away meals. "); 
            Room smallStreet = new Room("Small Street", "The street is crowded with sketchy looking people. There's steam coming from a manhole in the middle of road. ");
            Room garage = new Room("Garage", "Description");
            Room library = new Room("Library", "Description");
            Room hallway = new Room("Hallway", "Description. ");
            Room kitchen = new Room("Kitchen", "Description");
            Room masterBedroom = new Room("Master Bedroom", "Description");
            Room toilet = new Room("Toilet", "Description");
            Room bathRoom = new Room("Bathroom", "Description");
            Room diningRoom = new Room("Dining Room", "Description");
            Room guestRoom = new Room("Guest Room", "Description");

            // Exits
            library.East = hallway; //Move to hallway
            alleyway.North = smallStreet; //Move to street
            hallway.West = library; //Move to library
            hallway.South = smallStreet; //Move to street
            smallStreet.South = alleyway; //Move to alleyway
            smallStreet.North = hallway; //move to hallway


            hallway.AddItem(new Item(1, "Table", "This is a table made of cheap plastic.", 5));
            hallway.AddItem(new Item(1, "Chair", "This is an ugly chair.", 5));

            Weapon axe = new Weapon(2, "Axe", "Tool to chop things.", 5, 25);
            Armor armor = new Armor(12, "Hat", "It's a fedora. You feel the sudden urge to say 'm'lady'.", 5, 1);
            Npc glassUnicorn = new Npc(10, "Butt Stallion", "unicorn made of glass", true);

            hallway.AddItem(ChangeToLegendary(armor));
            hallway.AddItem(ChangeToLegendary(axe));
            hallway.AddCreature(SpawnBoss(glassUnicorn));


            CurrentRoom = hallway;
        }

        private Item ChangeToLegendary(Item item)
        {
            var randomLegendary = rnd.Next(1, 11);
            if (randomLegendary == 1)
            {
                item.Legendary = true;
                item.Name = "Legendary " + item.Name;
            }

            return item;
        }

        private Creature SpawnBoss(Creature boss)
        {
            var randomBoss = rnd.Next(1, 5);
            if (randomBoss == 1)
            {
                boss.Boss = true;
                boss.Name = "an Elite " + boss.Name;
            }

            return boss;
        }
    }
}
