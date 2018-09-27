using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    public class Creature
    {
        public int ID { get; set; } // easier to randomize later on
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Boss { get; set; }

        private List<Item> inventory;

        public Creature(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
            inventory = new List<Item>();
        }

        //TODO: Fix inventory for Creature

        public void additem(Item item)
        {
            inventory.Add(item);
        }

        public void removeitem(Item item)
        {
            inventory.Remove(item);
        }
    }
}
