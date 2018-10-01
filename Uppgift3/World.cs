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
        public Room TutorialStart { get; set; }
        public Room Start { get; set; }
        Random rnd = new Random();

        public World()
        {
            // Rooms to use
            Room alleyway = new Room("Dimmed alleyway", "The dingy alleyway reeks of the sour relics from a thousand take-away meals. "); 
            Room smallStreet = new Room("Small Street", "The street is crowded with sketchy looking people. \n There's steam coming from a manhole in the middle the of road. ");
            Room squareTutorial = new Room("Town square", "This is the town square. Add something more. Add something more. Add something more. ");
            Room square = new Room("Town square", "This is the town square. ");
            Room club = new Room("Puzzles", "It's a club called Puzzles. But why is it called Puzzles...? Maybe that's the puzzle.. \n There are some leftover dollar bills on the floor which explains what kind of a club this is. \n");

            // Exits
            alleyway.North = smallStreet;              //Move to street
            squareTutorial.South = smallStreet;        //Move to street
            smallStreet.South = alleyway;              //Move to alleyway
            smallStreet.North = squareTutorial;        //Move to hallway
            smallStreet.East = club;                   //Go to the club
            club.West = smallStreet;

            Door clubDoor = new Door(99, "Club door", "The door is made of thick metal of some sort, you would need a keycard to open it. ", true)
            {
                ChangedDescription = "The door is wide open. "
            };
            smallStreet.AddDoor(clubDoor, "EAST");

            alleyway.AddItem(new Item(99, "Dirty keycard", "It's a plastic keycard, the colors all faded but on it you notice the washed out remains of a word; zzl. ", 0));
            smallStreet.AddItem(new Item(98, "Blue keycard", "It's a plastic keycard, it's blue with no text on it. ", 0));

            squareTutorial.TutorialFinish = true;


            Item datapad = new Item(105, "Datapad", "It's one of the newer models, someone must have dropped it. ", 2)
            {
                
            ChangedDescription = "*Some RETRO music is playing*\n"+
                                        "We're no strangers to love\n"+
                                        "You know the rules and so do I\n" +
                                        "You wouldn't get this from any other guy\n" +
                                        "I just wanna tell you how I'm feeling\n" +
                                        "Gotta make you understand\n"+
                                        "Never gonna give you up\n"+
                                        "Never gonna let you down\n"+
                                        "... *You turn the music off*"
            };

            Item datastick = new Item(105, "Datastick", "It's a basic data stick, what could be on it? ", 0);
            Weapon railgun = new Weapon(2, "Railgun", "The classic instagib rifle", 100, 25);
            Armor armor = new Armor(12, "Hat", "It's a fedora. You feel the sudden urge to say \"m'lady\".", 5, 1);
            Npc diamondUnicorn = new Npc(10, "Diamond Unicorn", "Oh my god! It's Butt Stallion! It's the infamous unicorn made out of diamonds! ", true);
            Npc bouncer = new Npc(52, "Bouncer", "Wow, that's a big guy. He looks like a Brad.", false);
            Weapon knife = new Weapon(3, "Knife", "You call that a knife? THIS is a knife. ", 5, 1);
            Npc Bartender = new Npc(33, "Bartender","The occupied bartender doesn't notice you staring. ", false);
            Npc Dancers = new Npc(32, "Dancers", "The dancers are moving effortlessly to the music, but they don't seem to enjoy themselves. ", false);

            smallStreet.AddItem(ChangeToLegendary(armor));
            smallStreet.AddItem(ChangeToLegendary(railgun));
            club.AddItem(datapad);
            club.AddItem(knife);
            smallStreet.AddItem(datastick);
            squareTutorial.AddCreature(SpawnBoss(diamondUnicorn));
            smallStreet.AddCreature(SpawnBoss(bouncer));

            Start = square;
            TutorialStart = alleyway;
        }

        private Item ChangeToLegendary(Item item)
        {
            var randomLegendary = rnd.Next(1, 4);
            if (randomLegendary == 1)
            {
                item.Legendary = true;
                item.Name = "LEGENDARY "+item.Name;
            }

            return item;
        }

        private Creature SpawnBoss(Creature npc)
        {
            var randomBoss = rnd.Next(1, 5);
            if (randomBoss == 1)
            {
                npc.Elite = true;
                npc.Name = "Elite " + npc.Name;
            }

            return npc;
        }
    }
}
