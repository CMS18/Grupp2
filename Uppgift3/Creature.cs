using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    class Creature
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Creature(string description, string name)
        {
            Name = name;
            Description = description;
        }

        public void AddItem(Item item)
        {

        }

        public void RemoveItem(Item item)
        {

        }
    }
}
