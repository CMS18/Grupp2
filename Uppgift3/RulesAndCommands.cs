using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    public static class RulesAndCommands
    {
        public static string Look(this Room room)
        {
            return room.Description;
        }
        public static string Look(this Item item)
        {
            return item.Description;
        }
        public static string Look(this Creature creature)
        {
            return creature.Description;
        }

        public static Room Look(this Room room, string direction)
        {
            switch (direction)
            {
                case "NORTH":
                    if (room.North != null)
                        return room.North;
                    break;
                case "EAST":
                    if (room.East != null)
                        return room.East;
                    break;
                case "SOUTH":
                    if (room.South != null)
                        return room.South;
                    break;
                case "WEST":
                    if (room.West != null)
                        return room.West;
                    break;
            }
            return null;
        }

        public static Item Pickup(this Room room, string item)
        {
            return room.GetItems().Find(i => i.Name.ToUpper() == item);
        }
        public static Item Drop(this Creature inventory, string item)
        {
            return inventory.GetItems().Find(i => i.Name.ToUpper() == item);
        }


        public static void Rules()
        {
            string rules = @"
                             How to play: 
                             
                             After starting a new game, you will be asked 
                             for your name and a short description of yourself

                             ";


            new Game().Formatting(rules);
            Console.ReadLine();
        }
        public static void Commands()
        {
            string commands = @"
                                These are the commands: 
                                
                                Go / Move
                                Look / Examine
                                Get / Pickup
                                Drop
                                Use
                                Exit
                                Commands
                                Rules

                                Figure out yourself how to use them, adventurer!";
            new Game().Formatting(commands);
            Console.ReadLine();
        }
    }
}
