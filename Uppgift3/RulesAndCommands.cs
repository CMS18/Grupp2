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
