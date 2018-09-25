using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    class Creature
    {
        public int ID { get; set; } // easier to randomize later on
        public string Name { get; set; }
        public string Description { get; set; }

        public Creature(string description, string name, int id)
        {
            ID = id;
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
