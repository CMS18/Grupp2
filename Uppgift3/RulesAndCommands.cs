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

        public static void Move(this Room room, string direction)
        {
            switch (direction)
            {
                case "NORTH":
                    room = room.North;
                    break;
                case "EAST":
                    room = room.East;
                    break;
                case "SOUTH":
                    room = room.South;
                    break;
                case "WEST":
                    room = room.West;
                    break;
            }
        }

        public static string Rules()
        {
            return "These are the rules: ";
        }
        public static string Commands()
        {
            return "These are the commands: ";
        }
    }
}
