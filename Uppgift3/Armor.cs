using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3
{
    class Armor : Item
    {
        private int Defense { get; set; }

        public Armor(int id, string name, string description, int defense) : base(id, name, description)
        {
            Defense = defense;
        }
    }
}
