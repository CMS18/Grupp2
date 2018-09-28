using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    public class Creature
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Boss { get; set; }

        private List<Item> inventory;

        public Creature(string name, string description)
        {
            Name = name;
            Description = description;
            inventory = new List<Item>();
        }

        public void AddItem(Item item)
        {
            inventory.Add(item);
        }

        public void RemoveItem(Item item)
        {
            inventory.Remove(item);
        }

        public List<Item> GetItems()
        {
            return inventory;
        }
    }
}
