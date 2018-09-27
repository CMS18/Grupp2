using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
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
            Room square = new Room("Town square", "This is the town square. Add something more. Add something more. Add something more. ");
            Room club = new Room("Puzzles", "It's a club called puzzles. But why is it called puzzles...? Maybe that's the puzzle..");
            Room masterBedroom = new Room("Master Bedroom", "Description");
            Room toilet = new Room("Toilet", "Description");
            Room bathRoom = new Room("Bathroom", "Description");
            Room diningRoom = new Room("Dining Room", "Description");
            Room guestRoom = new Room("Guest Room", "Description");

            // Exits
            alleyway.North = smallStreet;      //Move to street
            square.South = smallStreet;        //Move to street
            smallStreet.South = alleyway;      //Move to alleyway
            smallStreet.North = square;        //Move to hallway
            smallStreet.East = club;           //Go to the club
            square.West = smallStreet;         //Go to street



            Weapon axe = new Weapon(2, "Axe", "Tool to chop things.", 5, 25);
            Armor armor = new Armor(12, "Hat", "It's a fedora. You feel the sudden urge to say 'm'lady'.", 5, 1);
            Npc diamondUnicorn = new Npc(10, "Butt Stallion", "unicorn made of diamonds", true);
            Npc bouncer = new Npc(52, "Bouncer", "Wow, that's a big guy. He looks like a Brad.", false);

            square.AddItem(ChangeToLegendary(armor));
            square.AddItem(ChangeToLegendary(axe));
            square.AddCreature(SpawnBoss(diamondUnicorn));
            smallStreet.AddCreature(bouncer);


            CurrentRoom = alleyway;
        }

        private Item ChangeToLegendary(Item item)
        {
            
            var randomLegendary = rnd.Next(1, 11);
            if (randomLegendary == 1)
            {
                item.Legendary = true;
                item.Name = "Legendary " + item.Name.ToUpper();
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
