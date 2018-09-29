using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public bool Legendary { get; set; }

        //Properties for when the item has changed
        private bool changed;
        public string ChangedName { get; set; }
        public string ChangedDescription { get; set; }

        public Item (int id, string name, string description, int weight)
        {
            ID = id;
            Name = name;
            Description = description;
            Weight = weight;
            changed = false;
            ChangedName = name;
            ChangedDescription = description;
        }
        public void Change()
        {
            changed = true;
            Name = ChangedName;
            Description = ChangedDescription;
        }
        public bool IsChanged()
        {
            return changed;
        }
    }
}
